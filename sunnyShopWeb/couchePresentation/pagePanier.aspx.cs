using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using sunnyShopWeb.classesMetier;
using sunnyShopWeb.coucheAccesBD;
using sunnyShopWeb.coucheMetier;
using System.Net;
using System.IO;


namespace sunnyShopWeb.couchePresentation
{
    public partial class pagePanier : System.Web.UI.Page
    {
        List<OrderDetails> panier = new List<OrderDetails>();
        User userLogged;
        protected void Page_Load(object sender, EventArgs e)
        {

            Session["PagePanier"] = this;
            userLogged = (User)Session["idUser"];
            panier = (List<OrderDetails>)Session["LePanier"];
            fillUserInfo();
            if (panier.Count != 0) laTotal.InnerText = "Total= " + ((Metier)Session["metier"]).totalCount(panier) + " €";
            else laTotal.InnerText = "Total= 0 €";

            
            if (panier.Count != 0)
            {
                afficherProduits();
            }
        }

        protected void fillUserInfo()
        {
            if (userLogged != null)
            {
                LaUserName.Text = "hello " + userLogged.FirstName;
                HiddenFieldSessionControl.Value = "SessionStart";
                LabCart.Text = panier.Count.ToString();
            }
            else
            {
                theDiv.Visible = false;
                HiddenFieldSessionControl.Value = "null";

            }
        }

        public void afficherProduits()
        {
            string image = "";
            string nom = "";
            decimal prix = 0;
            string idProduit = "";
            int cptr = 0;
            int stock = 0;

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
                foreach (OrderDetails od in panier)
                {
                    if (od.IdProduit.Substring(0, 2) == "01")
                    {
                        Alcool prod = ((Metier)Session["metier"]).lireAlcoolSpecifique(od.IdProduit);
                        nom = prod.NomAlcool + " " + prod.DegréAlcool;
                        image = "imgAlcool/" + prod.ImageAlcool;
                        prix = System.Math.Round(prod.PrixUnitaire, 2);
                        idProduit = prod.IdAlcool;
                        stock = prod.StockAlcool;
                    }
                    else if (od.IdProduit.Substring(0, 2) == "00")
                    {
                        Vin prod = ((Metier)Session["metier"]).lireVinSpecifique(od.IdProduit);
                        nom = prod.NomVin + " " + prod.Millesime + " " + prod.TypeVin;
                        image = "imgVin/" + prod.ImageVin;
                        prix = System.Math.Round(prod.PrixUnitaire, 2);
                        idProduit = prod.IdVin;
                        stock = prod.StockVin;

                    }

                    else if (od.IdProduit.Substring(0, 2) == "02")
                    {
                        Chemise prod = ((Metier)Session["metier"]).lireChemiseSpecifique(od.IdProduit);
                        nom = prod.NomChemise + " (" + prod.CouleurChemise + " en " + prod.Matiere + ")";
                        image = "imgChemise/" + prod.ImageChemise;
                        prix = System.Math.Round(prod.PrixUnitaire, 2);
                        idProduit = prod.IdProduit;
                        stock = prod.StockChemise;
                    }
                    cph.Controls.Add((new LiteralControl(
                        string.Format(motifHTML,
                                       image,//0
                                       nom,//1
                                       prix,//2
                                      od.Quantity.ToString(),//3
                                     od.Quantity * prix,//4
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["idUser"] = null;
            LaUserName.Text = "";
            Server.Transfer("/couchePresentation/index.aspx", true);
            HttpContext.Current.Session.Abandon();

        }

        protected void BtClearCart_Click(object sender, EventArgs e)
        {
            panier.Clear();
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void BtCheckOut_Click(object sender, EventArgs e)
        {
            //Contrôle age Acheteur
            int ageUser=((Metier)Session["metier"]).controlUserAge(userLogged.BirthDate);
            int controlCart = ((Metier)Session["metier"]).controlCartContent(panier);
            if (controlCart == 0 || ageUser == 2) ValiderCommande();// si l'acheteur est majeur ou le panier ne contient que des chemises -->  ok
            else if (ageUser == 1 && (controlCart != 2 && controlCart != 3)) ValiderCommande();// acheteur 16-18 et pas d'alcool --> ok
            else if (ageUser == 1 && (controlCart == 2 || controlCart == 3)) // acheteur 16-18 mais le panier contient de l'alcool --> pas ok
            {
                laAlert.InnerText = "Désolé, vous avez moins de 18 ans, la loi ne nous permet pas de vous vendre de l'alcool.";
                
            }
            else if (ageUser == 0 && controlCart != 0)// acheteur -de 16 ans et le panier contient de l'alcool ou du vin --> pas ok 
            {
                laAlert.InnerText = "Vous avez moins de 16 ans, vous ne pouvez acheter ni de vin, ni d'alcool.";
                

            }


        }

        public void ValiderCommande()
        {
            int idOrder = ((Metier)Session["metier"]).LastOrderId() + 1;
            //insert orderdetails
            foreach (OrderDetails od in panier)
            {
                od.IdOrder = idOrder;
                ((Metier)Session["metier"]).AjouterLigneCommande(od);
                ((Metier)Session["metier"]).upDateStock(od);

            }
            //controler les stock des orderdetails

            //creer la commande(order)
            Order newOrder = new Order();
            newOrder.IdOrder = idOrder;
            newOrder.DateOrder = DateTime.Now.ToShortDateString();
            newOrder.IdUserOrder = userLogged.IdUser;
            newOrder.TimeOrder = DateTime.Now.ToShortTimeString();
            newOrder.DeliveredOrder = "non";
            newOrder.TotalPrice = decimal.Parse(((Metier)Session["metier"]).totalCount(panier));
            if (((Metier)Session["metier"]).AjouterCommande(newOrder) == 1)
            {
                panier.Clear();
                Session["LePanier"] = panier;
                Server.Transfer("/couchePresentation/pageConfirmationOrder.aspx");

            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts",
               "javascript:alert('Houston, We have a problem!!!')", true);
        }

       

       

    }
}
