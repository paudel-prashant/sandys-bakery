using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SandysBakery.BusinessLogic
{
    public class ProductItems
    {
        public int ProductItemsId { get; set; }
        public int ProductCategoriesId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public decimal SellingPrice { get; set; }
        public string ImagePath { get; set; }
        public string FileName { get; set; }
    }
}