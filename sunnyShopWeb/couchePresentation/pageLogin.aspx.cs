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
    public partial class pageLogin : System.Web.UI.Page
    {
        User userlogged = new User();
        List<OrderDetails> panier = new List<OrderDetails>();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (IsPostBack) return;
            LaLoginFalse.Visible = false;
            LaPassFalse.Visible = false;

        }
            protected void BContinuer_Click(object sender, EventArgs e)
            {
            LaLoginFalse.Visible = false;
            LaPassFalse.Visible = false;
             
            string login = TBLogin.Text;
            string pass = TBPass.Text;

            
            try // on test la combinaison login & pswd dasn la db
            {
                userlogged = ((Metier)Session["metier"]).createUserLogin(login, pass);
                if (userlogged != null) // si ça correspond a un enregistrement on ouvre la page et on start la session
                {
                   
                   
                    Session["idUser"] = userlogged;
                    HiddenFieldSessionControl.Value = "SessionStart";
                    Session["LePanier"] = panier;
                    Server.Transfer("/couchePresentation/pageVin.aspx", true);

                    
                }
                else // si ça ne correspond pas on teste si le login existe dasn la db
                {
                    string testedLogin = ((Metier)Session["metier"]).testLogin(login);
                    if (testedLogin != null) // si le login existe --> c'est le pwd qui est faux 
                    {
                        LaPassFalse.Visible = true;
                    }
                    else  LaLoginFalse.Visible = true; // sinon, le login est faux.
                }
            }
            catch (Exception message)
            {

                throw message;
            }
            
        }
        
    }
}