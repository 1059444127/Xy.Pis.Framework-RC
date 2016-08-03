﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ServiceModel;
using System.Diagnostics;
using log4net;
using Xy.Pis.Contract.Service;

namespace Xy.Pis.Proxy
{
    public class ServiceManager
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static Type[] _remoteService = new Type[]
        {
           //typeof(IAdditionalMealService)
        };
       
        static Response<String> Invoke<T, TResult>(Action<T> action)    
            where T : IServiceBase
        {
            T proxy = GetService<T>();
            
            bool isRemoteService = IsRemoteService(proxy);

            var st = new Stopwatch();
            if (Log.IsDebugEnabled)
            {
                st.Start();
                Log.DebugFormat("Request to {0} service {1} ......", (isRemoteService ? "remote" : "local"), typeof(T));
                Log.DebugFormat("Client Method: {0}", action.Method);
            }

            var response = isRemoteService ? InvokeRemoteService(proxy, action) : InvokeLocalService(proxy, action);

            if (Log.IsDebugEnabled)
            {
                st.Stop();
                Log.DebugFormat("Request done in {0} ms.", st.ElapsedMilliseconds);
            }

            return response;
        }
        
        static Response<TResult> Invoke<T, TResult>(Func<T, TResult> func)
            where T : IServiceBase
        {
            T proxy = GetService<T>();
            bool isRemoteService = IsRemoteService(proxy);

            var st = new Stopwatch();

            if (Log.IsDebugEnabled)
            {
                st.Start();
                Log.DebugFormat("Request to {0} service {1} ......", (isRemoteService ? "remote" : "local"), typeof(T));
                Log.DebugFormat("Client Method: {0}", func.Method);
            }

            var response = isRemoteService ? InvokeRemoteService(proxy, func) : InvokeLocalService(proxy, func);

            if (Log.IsDebugEnabled)
            {
                st.Stop();
                Log.DebugFormat("Request done in {0} ms.", st.ElapsedMilliseconds);
            }

            return response;
        }

        public static T GetService<T>() 
            where T : IServiceBase
        {
            try
            {
                ServiceType type = ServiceType.Local;

                if (_remoteService.Where(t => t == typeof(T)).Any())
                {
                    type = ServiceType.Remote;
                }

                return (type == ServiceType.Local) ? GetLocalService<T>() : GetRemoteService<T>();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("GetService<{0}> Exception: {1} \n{2}", typeof(T), ex.Message, ex.StackTrace);
                throw;
            }
        }

        static T GetLocalService<T>() 
            where T : IServiceBase
        {
            return Common.Unity.IoC.Resolve<T>();
        }

        static T GetRemoteService<T>()
            where T : IServiceBase
        {
            ClientProxy proxy = new ClientProxy();
            return proxy.GetContract<T>();
        }

        static bool IsRemoteService<T>(T service)
            where T : IServiceBase
        {
            return (service as IClientChannel) != null ? true : false;
        }

        static Response<String> InvokeLocalService<T>(T proxy, Action<T> action)
          where T : IServiceBase
        {
            Response<String> result = new Response<String>()
            {
                Status = ResponseStatus.Error,
                Message = "Unknow Error",
                Result = String.Empty,
                ServiceType = ServiceType.Local,
            };

            try
            {
                action(proxy);
                result.Status = ResponseStatus.OK;
                result.Message = string.Empty;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                LogWriter("Exception", ex);
            }

            return result;
        }

        static Response<TResult> InvokeLocalService<T, TResult>(T proxy, Func<T, TResult> func)
             where T : IServiceBase
        {
            Response<TResult> result = new Response<TResult>()
            {
                Status = ResponseStatus.Error,
                Message = "Unknow Error",
                Result = default(TResult),
                ServiceType = ServiceType.Local,
            };

            try
            {
                result.Result = func(proxy);
                result.Status = ResponseStatus.OK;
                result.Message = string.Empty;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                LogWriter("Exception", ex);
            }

            return result;
        }

        static void LogWriter(string type, Exception ex)
        {
            if (ex != null)
            {
                if (string.IsNullOrEmpty(type))
                    type = "Exception";

                Log.ErrorFormat("{2}: {0} \n{1}", ex.Message, ex.StackTrace, type);
                if (ex.InnerException != null)
                    Log.ErrorFormat("InnerException: {0} \n{1}", ex.InnerException.Message, ex.InnerException.StackTrace);
            }
        }

        static Response<String> InvokeRemoteService<T>(T proxy, Action<T> action)
             where T : IServiceBase
        {
            Response<String> result = new Response<String>()
            {
                Status = ResponseStatus.Error,
                Message = "Unknow Error",
                Result = String.Empty,
                ServiceType = ServiceType.Remote,
            };

            try
            {
                action(proxy);
                (proxy as IClientChannel).Close();
                result.Status = ResponseStatus.OK;
                result.Message = string.Empty;
            }
            catch (System.ServiceModel.CommunicationException ce)
            {
                (proxy as IClientChannel).Abort();
                result.Message = ce.Message;

                LogWriter("CommunicationException", ce);
            }
            catch (TimeoutException te)
            {
                (proxy as IClientChannel).Abort();
                result.Message = te.Message;

                LogWriter("CommunicationException", te);
            }
            catch (Exception ex)
            {
                (proxy as IClientChannel).Abort();
                result.Message = ex.Message;

                LogWriter("Exception", ex);
                //throw;
            }

            return result;
        }

        static Response<TResult> InvokeRemoteService<T, TResult>(T proxy, Func<T, TResult> func)
             where T : IServiceBase
        {
            Response<TResult> result = new Response<TResult>()
            {
                Status = ResponseStatus.Error,
                Message = "Unknow Error",
                Result = default(TResult),
                ServiceType = ServiceType.Remote,
            };

            try
            {
                result.Result = func(proxy);
                (proxy as IClientChannel).Close();
                result.Status = ResponseStatus.OK;
                result.Message = string.Empty;
            }
            catch (System.ServiceModel.CommunicationException ce)
            {
                (proxy as IClientChannel).Abort();
                result.Message = ce.Message;

                LogWriter("CommunicationException", ce);
            }
            catch (TimeoutException te)
            {
                (proxy as IClientChannel).Abort();
                result.Message = te.Message;

                LogWriter("TimeoutException", te);
            }
            catch (Exception ex)
            {
                (proxy as IClientChannel).Abort();
                result.Message = ex.Message;

                LogWriter("Exception", ex);
                //throw;
            }

            return result;
        }
    }
}
