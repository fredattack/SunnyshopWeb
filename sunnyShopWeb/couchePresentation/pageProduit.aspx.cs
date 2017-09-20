using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using sunnyShopWeb.classesMetier;
using sunnyShopWeb.coucheMetier;
using sunnyShopWeb.coucheAccesBD;
using sunnyShopWeb.classesMetier;
using Newtonsoft.Json;

namespace sunnyShopWeb.couchePresentation
{
    public partial class pageProduit : System.Web.UI.Page
    {
        User userlogged;
        List<OrderDetails> lePanier;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            userlogged = (User)Session["idUser"];
            lePanier = (List<OrderDetails>)Session["LePanier"];
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
                theDiv.Visible = false;
                HiddenFieldSessionControl.Value = "null";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["idUser"] = null;
            LaUserName.Text = "";
            Server.Transfer("/couchePresentation/index.aspx", true);
            HttpContext.Current.Session.Abandon();

        }



    }
}