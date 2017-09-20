using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services.Protocols;
using sunnyShopWeb.classesMetier;
using sunnyShopWeb.coucheMetier;
using Newtonsoft.Json;
using System.Web.UI.HtmlControls;

namespace sunnyShopWeb.couchePresentation
{
    public partial class pageCommande : System.Web.UI.Page
    {
        User userlogged;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            List<OrderDetails> lePanier = (List<OrderDetails>)Session["LePanier"];
            LabCart.Text = lePanier.Count.ToString();
            userlogged = (User)Session["idUser"];
            fillUserInfo();
            fillLvOrder();

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
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["idUser"] = null;
            LaUserName.Text = "";
            Server.Transfer("/couchePresentation/index.aspx", true);
            HttpContext.Current.Session.Abandon();

        }

        public void fillLvOrder()
        {
            List<Order> laListe = ((Metier)Session["metier"]).ListerOrderClient(userlogged.IdUser);
            int cptr = 0;
            string status = "";
            try
            {
                ContentPlaceHolder cph = (ContentPlaceHolder)Master.FindControl("CPHContenu");

                
                string motifHTML = File.ReadAllText(Server.MapPath("..") +
                "/couchePresentation/motifsHTML/motifOrderClient.html");

                //while (panier.Count > 0)
                foreach (Order od in laListe)
                {
                    if (od.DeliveredOrder == "oui") status = "Expédiée";
                    else status = "En cours de préparation"; 
                    cph.Controls.Add((new LiteralControl(
                        string.Format(motifHTML,
                                       od.IdOrder,//0
                                       od.DateOrder,//1
                                       od.TimeOrder,//2
                                       od.TotalPrice,//3
                                       status,//4
                                       cptr))));//5
                                    
                    cptr = cptr + 1;
                }
            }
            catch (Exception)
            {
                //  Response.End();
                throw;
            }
        }


        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}