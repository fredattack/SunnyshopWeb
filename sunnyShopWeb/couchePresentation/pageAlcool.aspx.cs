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
    public partial class pageAlcool : System.Web.UI.Page
    {
        User userlogged;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<OrderDetails> lePanier= (List<OrderDetails>)Session["LePanier"];
            userlogged = (User)Session["idUser"];
            if (IsPostBack) return;
            fillUserInfo();
            loadItems();
            LabCart.Text = lePanier.Count.ToString();
        }
      

        protected void loadItems()
        {
            int cptr = 0;
            ContentPlaceHolder cph = (ContentPlaceHolder)Master.FindControl("CPHContenu");
            try
            {
                List<Alcool> liste = ((Metier)Session["metier"]).ListerAlcools();
                if (liste.Count == 0)
                {
                    Session["message"] = "Il n'y a aucun alcool dans la BD!";
                    Server.Transfer("/couchePresentation/pagemessage.aspx", true);
                }

                int listeSize = liste.Count();
                string motifHTML = File.ReadAllText(Server.MapPath("..") +
                "/couchePresentation/motifsHTML/motifAlcool.html");

                while (liste.Count > 0)
                {
                    string stockImg = "ok";

                    if (liste[0].StockAlcool == 0)
                    {
                        stockImg = "no";
                    }
                    if (DateTime.Parse(liste[0].DatePeremption) > DateTime.Now)
                    {
                        cph.Controls.Add((new LiteralControl(
                        string.Format(motifHTML,
                        liste[0].ImageAlcool,//0
                        liste[0].FamilleAlcool,//1
                        liste[0].GoutAlcool,//2
                        liste[0].DegréAlcool,//3
                        liste[0].ProvenanceAlcool,//4
                        stockImg,//5
                        liste[0].NomAlcool,//6
                        liste[0].PrixUnitaire.ToString("0.00"),//7
                        cptr,//8
                        liste[0].StockAlcool,//9
                        liste[0].IdAlcool,//10
                        listeSize//11
                        ))));
                        cptr = cptr + 1;
                      
                    }
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
            if (userlogged!=null)
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

    }
    
}