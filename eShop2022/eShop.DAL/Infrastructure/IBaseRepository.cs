﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Infrastructure
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByGuid(Guid guid);
        T Insert(T entity);
        void Update(T entity);
        T Delete(T entity);

    }
}