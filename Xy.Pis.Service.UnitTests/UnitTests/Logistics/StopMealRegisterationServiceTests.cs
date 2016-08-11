﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using log4net;
using Microsoft.Practices.Unity;
using System.Reflection;
using System.Linq.Expressions;
using Xy.Pis.Contract.Message.Logistics;
using Xy.Pis.Contract.Service.Logistics;
using Xy.Pis.Proxy;
using Xy.Pis;

namespace Xy.Pis.Service.UnitTests.Logistics
{
    [TestClass]
    public partial class StopMealRegisterationServiceTests : TestBase
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        int Add()
        {
            var expectedDto = new StopMealRegisterationDTO() 
            {
                LocationID = 1517,
                OrderQty = 10,
                CancelQty = 3,                
                IsAudit = null,                
                OperID = 999999,
                OperTime = DateTime.Now
            };

            var response = ServiceWrapper.Invoke<IStopMealRegisterationService, StopMealRegisterationDTO>(x => x.Add(expectedDto));
            
            Assert.IsTrue(response.Status == ResponseStatus.OK);
            Assert.IsNotNull(response.Result);
            Assert.AreNotEqual(0, response.Result.ID);          

            return response.Result.ID;
        }

        [TestMethod]
        public void Test_Add()
        {
            int ID = Add();
        }

        [TestMethod]
        public void Test_Delete()
        {
            int ID = Add();
            var deleteResponse = ServiceWrapper.Invoke<IStopMealRegisterationService>(x => x.DeleteById(ID));
            Assert.IsTrue(deleteResponse.Status == ResponseStatus.OK);

            var getResponse = ServiceWrapper.Invoke<IStopMealRegisterationService, StopMealRegisterationDTO>(x => x.GetById(ID));
            Assert.IsTrue(getResponse.Status == ResponseStatus.OK);
            Assert.IsNull(getResponse.Result);
        }

        [TestMethod]
        public void Test_Update()
        {
            int ID = Add();
            var getResponse = ServiceWrapper.Invoke<IStopMealRegisterationService, StopMealRegisterationDTO>(x => x.GetById(ID));
            Assert.IsTrue(getResponse.Status == ResponseStatus.OK);
            Assert.IsNotNull(getResponse.Result);

            var dto = getResponse.Result;
            dto.AuditTime = DateTime.Now;
            dto.AuditID = 999999;
            dto.IsAudit = true;
            dto.CancelQty = 2;
            var updateResponse = ServiceWrapper.Invoke<IStopMealRegisterationService, int>(x => x.Update(dto));
            Assert.IsTrue(updateResponse.Status == ResponseStatus.OK);
            Assert.AreEqual(1, updateResponse.Result);
        }

        [TestMethod]
        public void Test_GetAll()
        {
            int ID = Add();
            var response = ServiceWrapper.Invoke<IStopMealRegisterationService, IEnumerable<StopMealRegisterationDTO>>(x => x.GetAll());
            Assert.IsTrue(response.Status == ResponseStatus.OK);
            Assert.IsTrue(response.Result.Where(x => x.ID == ID).Any());
        }

        [TestMethod]
        public void Test_GetById()
        {
            int ID = Add();
            var getResponse = ServiceWrapper.Invoke<IStopMealRegisterationService, StopMealRegisterationDTO>(x => x.GetById(ID));
            Assert.IsTrue(getResponse.Status == ResponseStatus.OK);
            Assert.IsNotNull(getResponse.Result);
        }       

        [TestMethod]
        public void Test_AddOrUpdate()
        {
            var getResponse = ServiceWrapper.Invoke<IStopMealRegisterationService, IEnumerable<StopMealRegisterationDTO>>(x => x.GetAll());

            List<StopMealRegisterationDTO> addDTOs = new List<StopMealRegisterationDTO>();
            addDTOs.Add(new StopMealRegisterationDTO()
            {
                LocationID = 1510,
                OrderQty = 100,
                CancelQty = 10,
                IsAudit = null,
                OperID = 999999,
                OperTime = DateTime.Now
            });

            addDTOs.Add(new StopMealRegisterationDTO()
            {
                LocationID = 1511,
                OrderQty = 200,
                CancelQty = 20,
                IsAudit = null,
                OperID = 999999,
                OperTime = DateTime.Now
            });

            List<StopMealRegisterationDTO> addOrUpdateDTOs = new List<StopMealRegisterationDTO>();
            var updateDTOs = getResponse.Result.Where(x => x.OperID == 999999).ToList();
            updateDTOs.ForEach(x =>
            {
                x.IsAudit = true;
                x.AuditID = 999999;
                x.AuditTime = DateTime.Now.AddDays(-10);
            });

            addOrUpdateDTOs.AddRange(addDTOs);
            addOrUpdateDTOs.AddRange(updateDTOs);

            var updateResponse = ServiceWrapper.Invoke<IStopMealRegisterationService, Tuple<int, int>>(x => x.AddOrUpdate(addOrUpdateDTOs));
            Assert.IsTrue(updateResponse.Status == ResponseStatus.OK);
            Assert.AreEqual(addDTOs.Count, updateResponse.Result.Item1);
            Assert.AreEqual(updateDTOs.Count, updateResponse.Result.Item2);
        }        
    
        [TestMethod]
        public void Test_GetByLambdaExpressionWithKey()
        {
            int registerationId = Add();
            Expression<Func<StopMealRegisterationDTO, bool>> predicate = (y => (y.ID == registerationId));
            var getResponse = ServiceWrapper.Invoke<IStopMealRegisterationService>(x => x.Get(predicate));
            Assert.IsTrue(getResponse.Status == ResponseStatus.OK);
        }

        [TestMethod]
        public void Test_GetByLambdaExpression()
        {
            var getResponse = ServiceWrapper.Invoke<IStopMealRegisterationService, IEnumerable<StopMealRegisterationDTO>>(x => x.Get(y => y.AuditID.Value == 999999));
            Assert.IsTrue(getResponse.Status == ResponseStatus.OK);

            var date = DateTime.Now.AddDays(-6);
            Expression<Func<StopMealRegisterationDTO, bool>> expression = (x => (x.LocationID == 1517 && x.AuditID == 999999 && x.AuditTime.Value > date));
            getResponse = ServiceWrapper.Invoke<IStopMealRegisterationService, IEnumerable<StopMealRegisterationDTO>>(x => x.Get(expression));
            Assert.IsTrue(getResponse.Status == ResponseStatus.OK);           
        }       

        [TestMethod]
        public void Test_DeleteByLambdaWithKey()
        {
            int registerationId = Add();            
            var getResponse = ServiceWrapper.Invoke<IStopMealRegisterationService>(x => x.Delete(y => y.ID == registerationId));
            Assert.IsTrue(getResponse.Status == ResponseStatus.OK);
        }

        [TestMethod]
        public void Test_DeleteByLambdaExpression()
        {
            //var date = DateTime.Now.AddDays(-10);
            Expression<Func<StopMealRegisterationDTO, bool>> expression = (x => (x.LocationID != 1517 && x.AuditID == 999999));

            var deleteResponse = ServiceWrapper.Invoke<IStopMealRegisterationService>(x => x.Delete(expression));
            Assert.IsTrue(deleteResponse.Status == ResponseStatus.OK);
        }

        [TestMethod]
        public void Test_UpdateByLambdaExpression()
        {
            Expression<Func<StopMealRegisterationDTO, bool>> predicate = x => (x.LocationID != 1517);

            var updateResponse = ServiceWrapper.Invoke<IStopMealRegisterationService, int>(x => x.Update(predicate, u => new StopMealRegisterationDTO() { OrderQty = 5, CancelQty = 2, IsAudit = true }));
            Assert.IsTrue(updateResponse.Status == ResponseStatus.OK);
        }
    }
}