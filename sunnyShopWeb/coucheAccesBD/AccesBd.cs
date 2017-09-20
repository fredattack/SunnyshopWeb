using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using sunnyShopWeb.classesMetier;

namespace sunnyShopWeb.coucheAccesBD
{
    public class AccesBd
    {
        private SqlConnection SqlConn = null;
        private const int MaxTentatives = 3;
        /**
        * Constructeur : ouvrir une première connexion avec la base de données
        */
        public AccesBd()
        {
            if (SqlConn == null)
            {
                int nbTentatives = 0;
                while (true)
                {
                    try
                    {
                        OuvrirConnexion();
                        return;
                    }
                    catch (Exception e)
                    {
                        nbTentatives++;
                        if (nbTentatives == MaxTentatives)
                            throw new ExceptionAccesBd("Connexion à la BD", e.Message);
                    }
                }
            }
        }
        /**
        * Ouvrir une connexion avec la base de données
*/
        private void OuvrirConnexion()
        {
            if (SqlConn != null) SqlConn.Close();
            SqlConn = new SqlConnection("Integrated security=true;" +
            "user id=fred;" +
            "Data Source=FREDATTACK\\SQLEXPRESS;" +
            "Initial Catalog=SunnyShopDb;");
            SqlConn.Open();
        }

        private int ExecuterRequete(OperationBD operation)
        {
            int nbTentatives = 0;
            while (true)
            {
                try
                {
                    if (nbTentatives > 0) OuvrirConnexion();
                    return operation.ExecuterRequete(SqlConn);
                }
                catch (Exception e)
                {
                    nbTentatives++;
                    if (nbTentatives == MaxTentatives)
                        throw new ExceptionAccesBd(operation.getNom(), e.Message);
                }
            }
        }

        public User createUserLogin(string login, string password)
        {
            CreateUserLoginBd operation = new CreateUserLoginBd(login, password);
            ExecuterRequete(operation);
            return operation.getUser();
        }

        public string testLogin(string login)
        {
            TestLoginBd operation = new TestLoginBd(login);
            ExecuterRequete(operation);
            return operation.getString();
        }

        public User lireUserSpecifique(int idUser)
        {
            LireUserSpecifiqueBd operation = new LireUserSpecifiqueBd(idUser);
            ExecuterRequete(operation);
            return operation.getUser();
        }

        public int AjouterUser(User user)
        {
            AjouterUserBd operation = new AjouterUserBd(user);
            return ExecuterRequete(operation);
        }

        public int ModifierUser(User user)
        {
            ModifierUserBd operation = new ModifierUserBd(user);
            return ExecuterRequete(operation);
        }

        public List<Vin> ListerVins()
        {
            ListerVinsBd operation = new ListerVinsBd();
            ExecuterRequete(operation);
            return operation.getListe();
        }

        public List<Alcool> ListerAlcools()
        {
            ListerAlcoolsBd operation = new ListerAlcoolsBd();
            ExecuterRequete(operation);
            return operation.getListe();
        }

        public List<Chemise> ListerChemises()
        {
            ListerChemisesBd operation = new ListerChemisesBd();
            ExecuterRequete(operation);
            return operation.getListe();
        }

        public Alcool lireAlcoolSpecifique(string idProduit)
        {
            lireAlcoolSpecifiqueBd operation = new lireAlcoolSpecifiqueBd(idProduit);
            ExecuterRequete(operation);
            return operation.getAlcool();
        }
        
        public Vin lireVinSpecifique(string idProduit)
        {
            lireVinSpecifiqueBd operation = new lireVinSpecifiqueBd(idProduit);
            ExecuterRequete(operation);
            return operation.getVin();
        }

        public Chemise lireChemiseSpecifique(string idProduit)
        {
            LireChemiseSpecifiqueBd operation = new LireChemiseSpecifiqueBd(idProduit);
            ExecuterRequete(operation);
            return operation.getChemise();
        }

        public int AjouterCommande(Order newOrder)
        {
            AjouterCommandeBd operation = new AjouterCommandeBd(newOrder);
            return ExecuterRequete(operation);
        }

        public int LastOrderId()
        {
            LastOrderIdBd operation = new LastOrderIdBd();
            return ExecuterRequete(operation);
        }
        
        public int AjouterLigneCommande(OrderDetails newOrderD)
        {
            AjouterLigneCommandeBd operation = new AjouterLigneCommandeBd(newOrderD);
            return ExecuterRequete(operation);
        }

        public List<Order> ListerOrderClient(int idUser)
        {
            ListerOrderClientBd operation = new ListerOrderClientBd(idUser);
            ExecuterRequete(operation);
            return operation.getListe();
        }

        public List<OrderDetails> listerOrderDetails(int idOrder)
        {
            listerOrderDetailsBd operation = new listerOrderDetailsBd(idOrder);
            ExecuterRequete(operation);
            return operation.getListe();
        }

        public int upDateStock(OrderDetails od,int newStock)
        {
            upDateStockBd operation = new upDateStockBd(od,newStock);
            return ExecuterRequete(operation);
        }
    }
}