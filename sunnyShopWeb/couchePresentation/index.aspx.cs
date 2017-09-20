using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sunnyShopWeb.classesMetier;

namespace sunnyShopWeb.couchePresentation
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        User userlogged;

        protected void Page_Load(object sender, EventArgs e)
        {
            
           
            userlogged = (User)Session["idUser"];
           
            List<OrderDetails> panier = new List<OrderDetails>();
            if (userlogged==null)
            {
                HiddenFieldSessionControl.Value = "null";
                Session["LePanier"] = panier;
            }
            else HiddenFieldSessionControl.Value = "SessionStart";
        }
    }
}