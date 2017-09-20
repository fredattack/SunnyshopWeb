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

namespace sunnyShopWeb.couchePresentation
{
    public partial class panierData : System.Web.UI.Page
    {
        OrderDetails ligneCommande;
        List<OrderDetails> panier;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            panier = (List<OrderDetails>)Session["LePanier"];
            ligneCommande = getData();
            panier= ((Metier)Session["metier"]).addToCart(ligneCommande,panier);
            Session["totalPanier"] = ((Metier)Session["metier"]).totalCount(panier);
            Session["LePanier"] = panier;
           


        }

        public OrderDetails getData()
        {
            string input="";
            using (var reader = new StreamReader(Request.InputStream))
            {
                input = reader.ReadToEnd();
            }
            ligneCommande = JsonConvert.DeserializeObject<OrderDetails>(input);//a retourner

            return ligneCommande;
        }

        public decimal UpdateTotal()
        {
            string Total = ((Metier)Session["metier"]).totalCount(panier);
            
            return Convert.ToDecimal(Total);

        }

        

    }
}