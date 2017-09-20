using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sunnyShopWeb.coucheMetier
{
    public class ExceptionMetier : Exception
    {
        public ExceptionMetier(string sCause)
        : base(sCause)
        { }
    }
}