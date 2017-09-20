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

namespace sunnyShopWeb.couchePresentation
{
    public partial class pageVin : System.Web.UI.Page
    {

        /**
        * Méthode exécutée au chargement de la page. Elle charge
        * les Vins
        */
        User userlogged;
        List<OrderDetails> lePanier;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            if (Session["LePanier"] == null)
            {
                List<OrderDetails> lePanier = new List<OrderDetails>();
                Session["LePanier"] = lePanier;
            }
            else lePanier =(List<OrderDetails>)Session["LePanier"];
           
            userlogged = (User)Session["idUser"];
            fillUserInfo();
            loadItems();


        }

        protected void loadItems()
        {
            int cptr = 0;
            ContentPlaceHolder cpl = (ContentPlaceHolder)Master.FindControl("CPHContenu");
            try
            {
                List<Vin> liste = ((Metier)Session["metier"]).ListerVins();
                if (liste.Count == 0)
                {
                    Session["message"] = "Il n'y a aucun vins dans la BD!";
                    Server.Transfer("/couchePresentation/pagemessage.aspx", true);
                }

                int listeSize = liste.Count();
                string motifHTML = File.ReadAllText(Server.MapPath("..") +
                "/couchePresentation/motifsHTML/motifVin.html");

                while (liste.Count > 0)
                {
                    string stockImg = "ok";

                    if (liste[0].StockVin == 0)
                    {
                        stockImg = "no";
                    }


                    cpl.Controls.Add((new LiteralControl(
                    string.Format(motifHTML,
                    liste[0].ImageVin,//0
                    liste[0].TypeVin,//1
                    liste[0].Saveur,//2
                    liste[0].Maturation,//3
                    liste[0].ProvenanceVin,//4
                    stockImg,//5
                    liste[0].NomVin + " " + liste[0].Millesime,//6
                    liste[0].PrixUnitaire.ToString("0.00"),//7
                    cptr,//8
                    liste[0].StockVin,//9
                    liste[0].IdVin,//10
                    listeSize))));//11
                    cptr = cptr + 1;
                    liste.RemoveAt(0);
                }
            }
            catch (ExceptionAccesBd)
            {
                Response.Output.Write("Connexion à la BD impossible");
                Response.End();
            }
        }

        protected void fillUserInfo()
        {
            if (userlogged != null)
            {
                LaUserName.Text = "hello " + userlogged.FirstName;
                HiddenFieldSessionControl.Value = "SessionStart";
                LabCart.Text = lePanier.Count.ToString();
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
    }
}