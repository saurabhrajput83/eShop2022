﻿using eShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Infrastructure
{
    public interface IShoppingCartRepository : IBaseRepository<ShoppingCart>
    {
    }
}
