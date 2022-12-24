using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SandysBakery.BusinessLogic
{
    public class ProductCategories
    {
        public int ProductCategoriesId { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
        public int TotalQuantity { get; set; }
    }
}