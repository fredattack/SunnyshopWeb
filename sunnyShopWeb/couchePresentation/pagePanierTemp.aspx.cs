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
    public partial class pagePanierTemp : System.Web.UI.Page
    {
        List<OrderDetails> panier = new List<OrderDetails>();

        protected void Page_Load(object sender, EventArgs e)
        {
            panier = (List<OrderDetails>)Session["LePanier"];
            if (panier.Count != 0)
            {
                Session["pagePanierTemp"] = this;
                afficherProduits();
                if(panier.Count!=0)laTotal.InnerText = "Total= " + ((Metier)Session["metier"]).totalCount(panier)+" €" ;
              else laTotal.InnerText = "Total= 0 €";
            }
        }

        public void afficherProduits()
        {
            string image="";
            string nom = "";
            decimal prix=0 ;
            int stock = 0;
            string idProduit = "";
            int cptr=0;
            
            try
            {
                ContentPlaceHolder cph = (ContentPlaceHolder)Master.FindControl("CPHContenu");

                if (panier.Count == 0)
                {
                    Session["message"] = "Il n'y a aucun produit dans votre!";
                    Server.Transfer("/couchePresentation/pagemessage.aspx", true);
                }

                string motifHTML = File.ReadAllText(Server.MapPath("..") +
                "/couchePresentation/motifsHTML/motifPanier.html");

                //while (panier.Count > 0)
                    foreach (OrderDetails od   in panier)
                    {
                    if (od.IdProduit.Substring(0, 2) == "01")
                    {
                        Alcool prod = ((Metier)Session["metier"]).lireAlcoolSpecifique(od.IdProduit);
                        nom = prod.NomAlcool + " " + prod.DegréAlcool;
                        image = "imgAlcool/"+ prod.ImageAlcool;
                        prix = System.Math.Round(prod.PrixUnitaire, 2);
                        idProduit = prod.IdAlcool;
                        stock = prod.StockAlcool;
                    }
                    else if (od.IdProduit.Substring(0, 2) == "00")
                    {
                         Vin prod = ((Metier)Session["metier"]).lireVinSpecifique(od.IdProduit);
                        nom = prod.NomVin + " " + prod.Millesime + " " + prod.TypeVin;
                        image = "imgVin/"+prod.ImageVin;
                        prix = System.Math.Round(prod.PrixUnitaire, 2);
                        idProduit = prod.IdVin;
                        stock = prod.StockVin;
                    }
                    else if (od.IdProduit.Substring(0, 2) == "02")
                    {
                        Chemise prod = ((Metier)Session["metier"]).lireChemiseSpecifique(od.IdProduit);
                        nom = prod.NomChemise + " (" + prod.CouleurChemise + " en " + prod.Matiere+")";
                        image ="imgChemise/"+ prod.ImageChemise;
                        prix = System.Math.Round(prod.PrixUnitaire, 2);
                        idProduit = prod.IdProduit;
                        stock = prod.StockChemise;
                    }
                    cph.Controls.Add((new LiteralControl(
                        string.Format(motifHTML,
                                       image,//0
                                       nom ,//1
                                       prix,//2
                                      od.Quantity.ToString(),//3
                                     od.Quantity*prix,//4
                                     idProduit,//5
                                     cptr,//6
                                     stock))));//7
                    cptr = cptr + 1;
                }
            }
            catch (Exception)
            {
              //  Response.End();
                throw;
            }

        }

        
    }
}
