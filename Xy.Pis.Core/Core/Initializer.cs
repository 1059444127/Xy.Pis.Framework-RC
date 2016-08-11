﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using System.Data.Entity;
using System.Reflection;
using Xy.Pis.Utils.Unity;

namespace Xy.Pis.Core
{
    /// <summary>
    /// 数据库上下文和工作单元初始化类
    /// </summary>
    public class Initializer
    {
        /// <summary>
        /// 初始化数据库上下文和工作单元
        /// </summary>
        /// <typeparam name="TDbContext"></typeparam>
        public static void Init<TDbContext>() where TDbContext : DbContext
        {
            IoC.RegisterType<DbContext, TDbContext>();
            IoC.RegisterType<IUnitOfWork, EFUnitOfWork<TDbContext>>();
        }
    }
}