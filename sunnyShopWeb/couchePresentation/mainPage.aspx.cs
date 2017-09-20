using sunnyShopWeb.coucheMetier;
using sunnyShopWeb.coucheAccesBD;
using sunnyShopWeb.classesMetier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sunnyShopWeb.couchePresentation
{
    public partial class PageAcceuil : System.Web.UI.Page
    {
        User userlogged;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            userlogged = (User)Session["idUser"];
            fillUserInfo();
        }

        protected void fillUserInfo()
        {
            if (userlogged != null)
            {
                    LaUserName.Text = "hello " + userlogged.FirstName;
                    HiddenFieldSessionControl.Value = "SessionStart";
            }
            else
            {
                theDiv.Visible = false;
                HiddenFieldSessionControl.Value = "null";

            }
        }

     

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Server.Transfer("/couchePresentation/pageCommande.aspx", true);
        }
    }
}
            
            