﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevFramework.Entities.Concrete;

namespace DevFrameworks.Northwind.MvcWebUI.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
    }
}