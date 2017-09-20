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
    public partial class PageInsciption : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            TbLogin.Text = "";
            TbPassword.Text = "";
        }

        protected void BContinuer_Click(object sender, EventArgs e)
        {


            try
            {
                User newUser = new User();
                if (TbPassword2.Text != TbPassword.Text)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", 
                        "javascript:alert('Les mots de passe ne correspondent pas.')", true);
                }
                
                else
                {
                    newUser.LastName = TbNom.Text;
                    newUser.FirstName = TbPrenom.Text;
                    newUser.Login = TbLogin.Text;
                    newUser.Password = TbPassword.Text;
                    newUser.BirthDate = TbBirthDate.Text;
                    newUser.Role = "client";
                    newUser.AdresUser = TbAdresse.Text;

                    if (((Metier)Session["metier"]).AjouterUser(newUser) == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", 
                            "javascript:alert('Votre compte a été enregistré.')", true);

                       // Server.Transfer("/couchePresentation/pageLogin.aspx");
                    }
                    else ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", 
                        "javascript:alert('Houston, We have a problem!!!')", true);

                    try // on test la combinaison login & pswd dasn la db
                    {
                        User userlogged = new User();
                        userlogged = ((Metier)Session["metier"]).createUserLogin(newUser.Login,newUser.Password);
                        if (userlogged != null) // si ça correspond a un enregistrement on ouvre la page et on start la session
                        {
                           
                            Session["idUser"] = userlogged;
                            List<OrderDetails> lePanier = new List<OrderDetails>();
                            Session["LePanier"] = lePanier;
                            Response.Redirect("/couchePresentation/pageVin.aspx", true);
                            
                        }
                        
                    }
                    catch (Exception message)
                    {

                        throw message;
                    }
                }


                //System.Diagnostics.Debug.WriteLine(Convert.ToString(((Metier)Session["metier"]).AjouterUser(newUser)));
            }
            catch (ExceptionAccesBd)
            {

                Response.Output.Write("Connexion à la BD impossible");
                Response.End();
            }
            catch (ExceptionMetier ex)
            {
                Session["message"] = ex.Message;
            }

           
        }
    }
}