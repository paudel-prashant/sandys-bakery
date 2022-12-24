using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SandysBakery.BusinessLogic
{
    public class CartItems
    {
        public int CartId { get; set; }
        public int ProductItemsId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public DateTime AddDate { get; set; }
    }
}