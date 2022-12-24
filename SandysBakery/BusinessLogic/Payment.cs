using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SandysBakery.BusinessLogic
{
    public class Payment
    {
        public int PaymentOrderId { get; set; }
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}