using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Helpers
{
    public sealed class ConfigurationHelper
    {

        private static IConfiguration _configuration;

        private ConfigurationHelper()
        {
        }


        public static IConfiguration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    IConfigurationBuilder builder = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json", false, true);
                    _configuration = builder.Build();
                }
                return _configuration;

            }
        }
    }
}
