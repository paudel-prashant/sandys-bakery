using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SandysBakery.BusinessLogic
{
    public class Products
    {
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public string BrandName { get; set; }
        public int TotalQuantity { get; set; }
    }
}