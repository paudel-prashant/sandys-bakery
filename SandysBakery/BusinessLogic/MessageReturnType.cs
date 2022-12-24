using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SandysBakery.BusinessLogic
{
    public class MessageReturnType
    {
        public string ReturnMessage { get; set; }
        public string ReturnMessage2 { get; set; }
        public string ReturnMessage3 { get; set; }
        public bool IsSuccess { get; set; }
        public int ReturnInteger { get; set; }
        public int ReturnInteger2 { get; set; }
        public DateTime DateTime { get; set; }
        public Double ReturnDouble { get; set; }
    }
}