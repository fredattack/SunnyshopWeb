using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sunnyShopWeb.classesMetier;
using System.IO;
using sunnyShopWeb.coucheMetier;

namespace sunnyShopWeb.couchePresentation
{
    public partial class pageDetailOrder : System.Web.UI.Page
    {
        List<OrderDetails> laListe;
        protected void Page_Load(object sender, EventArgs e)
        {

         int idOrder =(int)Session["idOrder"];

            laListe = ((Metier)Session["metier"]).listerOrderDetails(idOrder);
            if(idOrder!= 0) afficherProduits();
        }

        public void afficherProduits()
        {
           
            int cptr = 0;

            try
            {
                ContentPlaceHolder cph = (ContentPlaceHolder)Master.FindControl("CPHContenu");

                if (laListe.Count == 0)
                {
                    Session["message"] = "Il n'y a aucun produit dans votre!";
                    Server.Transfer("/couchePresentation/pagemessage.aspx", true);
                }

                string motifHTML = File.ReadAllText(Server.MapPath("..") +
                "/couchePresentation/motifsHTML/motifDetailOrder.html");

                //while (panier.Count > 0)
                foreach (OrderDetails od in laListe)
                {

                    cph.Controls.Add((new LiteralControl(
                        string.Format(motifHTML,
                                      od.IdProduit,//0
                                       od.Nom,//1
                                       od.PrixUnitaire.ToString("0.00"),//2
                                      od.Quantity.ToString(),//3
                                     od.SousTotal.ToString("0.00"),//4
                                     od.IdOrder,//5
                                     cptr))));//6
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