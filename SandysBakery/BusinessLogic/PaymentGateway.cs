using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SandysBakery.BusinessLogic
{
    public class PaymentGateway
    {
        public int CreditCardId { get; set; }
        public int CardNumber { get; set; }
        public int UserId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CreditCardType { get; set; }
        public string CardName { get; set; }
        public string PostalCode { get; set; }
        public int SecurityCode { get; set; }
        public int PaymentGatewayId { get; set; }
        public int CardTypeId { get; set; }
    }
}