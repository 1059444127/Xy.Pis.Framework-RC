﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Z.EntityFramework.Extensions;

namespace Xy.Pis.Core
{
    internal interface IRepository<T> 
        where T : class, new()
    {
        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> Get();

        T GetById(params object[] ids);

        void DeleteById(params object[] ids);

        int DeleteAll();

        IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

        int Update(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T>> updateExpression);

        int Delete(Expression<Func<T, bool>> queryExpression);

        void AddBatch(IEnumerable<T> entities);

        void UpdateBatch(IEnumerable<T> entities);

        void DeleteBatch(IEnumerable<T> entities);

        void BulkInsert(IEnumerable<T> entities);
    
        void BulkDelete(IEnumerable<T> entities);

        void BulkUpdate(IEnumerable<T> entities);
    }
}