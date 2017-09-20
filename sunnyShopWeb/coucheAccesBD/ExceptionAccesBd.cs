using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sunnyShopWeb.coucheAccesBD
{
    public class ExceptionAccesBd : Exception
    {
        public string Details { get; set; }
        public ExceptionAccesBd(string cause, string details) : base(cause)
        {
            Details = details;
        }
    }
}