using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sunnyShopWeb.coucheAccesBD;
using sunnyShopWeb.coucheMetier;

namespace sunnyShopWeb.couchePresentation
{
    public partial class SunnyMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                if (Session["metier"] == null)
                {
                    Session["metier"] = new Metier();
                    Session.Timeout = 5;
                }
            }
            catch (ExceptionAccesBd)
            {
                Response.Output.Write("Connexion à la BD impossible");
                Response.End();
            }
        }

      
            public void SetContentHeaderVisibility(bool isVisible)
            {
                this.CPHHeader.Visible = isVisible;
            }

        
    }
}