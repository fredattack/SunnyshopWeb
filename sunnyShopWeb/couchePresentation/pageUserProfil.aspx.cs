using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using sunnyShopWeb.classesMetier;
using sunnyShopWeb.coucheAccesBD;
using sunnyShopWeb.coucheMetier;

namespace sunnyShopWeb.couchePresentation
{
    public partial class WebForm2 : System.Web.UI.Page
    {

                User userlogged = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<OrderDetails> lePanier = (List<OrderDetails>)Session["LePanier"];
            userlogged = (User)Session["idUser"];
            if ((userlogged  == null))
                {
                    Session["message"] = "Le client demandé n'existe pas dans la BD!";
                    Server.Transfer("/couchePresentation/pagemessage.aspx", true);
                }

           LabCart.Text = lePanier.Count.ToString();
            if (IsPostBack) return;
            try
            {
                //création de la session utilisateur 

                //affichage des données des labels et des textBoxs
                LaUserName.Text = "hello " + userlogged.FirstName;

                TbAdresse.Text = userlogged.AdresUser;
                TbBirthDate.Text = userlogged.BirthDate;
                TbNom.Text = userlogged.LastName;
                TbPrenom.Text = userlogged.FirstName;
            }
            catch (ExceptionAccesBd)
            {
                Response.Output.Write("Connexion à la BD impossible");
                Response.End();
            }
            catch (ExceptionMetier ex)
            {
                Session["message"] = ex.Message;
                Server.Transfer("/couchePresentation/pagemessage.aspx", true);
            }
        }

        protected void BContinuer_Click(object sender, EventArgs e)
        {
            userlogged.FirstName = TbPrenom.Text;
            userlogged.LastName = TbNom.Text;
            userlogged.AdresUser = TbAdresse.Text;
            userlogged.BirthDate = TbBirthDate.Text;
            if (((Metier)Session["metier"]).ModifierUser(userlogged) == 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Votre profil a été modifié')", true);
               
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts","javascript:alert('Houston, We have a problem!!!')", true);
           

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