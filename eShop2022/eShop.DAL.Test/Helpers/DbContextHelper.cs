using eShop.DAL.Main;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Test.Helpers
{
    public sealed class DBContextHelper
    {
        private static DbContextOptions<eShopDbContext> _options;
        private DBContextHelper()
        { }

        public static DbContextOptions<eShopDbContext> Options
        {
            get
            {
                if (_options == null)
                {
                    _options = new DbContextOptionsBuilder<eShopDbContext>()
                    .UseInMemoryDatabase(databaseName: "eShopDb")
                    .Options;
                }
                return _options;
            }
        }
    }
}
