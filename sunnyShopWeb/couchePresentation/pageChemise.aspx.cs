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
using System.Collections;

namespace sunnyShopWeb.couchePresentation
{
    public partial class pageChemise : System.Web.UI.Page
    {
        User userlogged;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<OrderDetails> lePanier = (List<OrderDetails>)Session["LePanier"];
            userlogged = (User)Session["idUser"];
            if (IsPostBack) return;
            fillUserInfo();
            loadItems();
            LabCart.Text = lePanier.Count.ToString();
        }

        protected void loadItems()
        {

            int cptr = 0;
            ContentPlaceHolder cpl = (ContentPlaceHolder)Master.FindControl("CPHContenu");
            try
            {
                ArrayList listeTaille = new ArrayList();
                List<Chemise> liste = new List<Chemise>();
                List<Chemise> firstListe = ((Metier)Session["metier"]).ListerChemises();
                List<string> tailleCouleur = new List<string>();
                foreach (Chemise chem in firstListe)
                {
                    if (chem.Taille == "XS")
                    {
                        liste.Add(chem);
                    }
                    if (chem.StockChemise == 0)
                    {
                        listeTaille.Add("disabled class='outOfStock' ");
                    }
                    else listeTaille.Add("class='dispo' onmousemove='overElement(this);' onmouseout='outElement(this);'");
                }

                if (liste.Count == 0)
                {
                    Session["message"] = "Il n'y a aucun vins dans la BD!";
                    Server.Transfer("/couchePresentation/pagemessage.aspx", true);
                }

                int listeSize = liste.Count();
                string motifHTML = File.ReadAllText(Server.MapPath("..") +
                "/couchePresentation/motifsHTML/motifChemise.html");

                while (liste.Count > 0)
                {
                    string stockImg = "ok";

                    if (liste[0].StockChemise == 0)
                    {
                        stockImg = "no";
                    }


                    cpl.Controls.Add((new LiteralControl(
                    string.Format(motifHTML,
                    liste[0].ImageChemise,//0
                    liste[0].Matiere,//1
                    liste[0].CouleurChemise,//2
                    liste[0].Model,//3
                    liste[0].Taille,//4
                    stockImg,//5
                    liste[0].NomChemise,//6
                    liste[0].PrixUnitaire.ToString("0.00"),//7
                    liste[0].IdProduit,//8
                    liste[0].StockChemise,//9
                    cptr,//10
                    listeSize,//11
                    listeTaille[0],//12
                     listeTaille[1],//13
                     listeTaille[2],//14
                     listeTaille[3],//15
                     listeTaille[4],//16
                     listeTaille[5]//17
                    ))));
                    cptr = cptr + 1;
                    liste.RemoveAt(0);
                    for (int i = 0; i <= 5; i++)
                    {
                        listeTaille.RemoveAt(0);
                    }
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