using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SandysBakery.BusinessLogic
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int TotalOrderQuantity { get; set; }
        public int PaymentTypeId { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int ProductItemsId { get; set; }
        public decimal Price { get; set; }
        public int? PaymentGatewayId { get; set; }
        public string PaymentType { get; set; }
        public string StatusName { get; set; }
        public string ActiveStatus { get; set; }
        public string ItemName { get; set; }
        public string FullName { get; set; }
        public int CardNumber { get; set; }
    }
}