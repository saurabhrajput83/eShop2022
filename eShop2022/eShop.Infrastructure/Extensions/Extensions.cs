using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure.Extensions
{
    public static class Extensions
    {
        public static bool IsNotNull(this object source)
        {
            return (source != null) ? true : false;
        }

        public static bool IsNull(this object source)
        {
            return (source == null) ? true : false;
        }

        public static bool IsNotEmpty<T>(this List<T> source)
        {
            return (source.IsNotNull() && source.Count > 0) ? true : false;
        }

    }
}
