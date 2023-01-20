﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Entities
{
    public class DepartmentProduct : BaseEntity
    {
        public int? DepartmentId { get; set; }
        public int? ProductId { get; set; }
        public virtual Department? Department { get; set; }
        public virtual Product? Product { get; set; }
    }
}
