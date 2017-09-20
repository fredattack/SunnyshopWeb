using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace sunnyShopWeb.couchePresentation
{
    
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundels)
        {
            bundels.Add(new ScriptBundle("/couchePresentation/scripts")
                .Include("~/couchePresentation/scripts/sunnyShopWeb.js")
                .IncludeDirectory("~/couchePresentation/scripts", ".js"));
        }
    }
}