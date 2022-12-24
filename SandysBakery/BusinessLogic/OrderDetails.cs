using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SandysBakery.BusinessLogic
{
    public class OrderDetails
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductItemsId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}