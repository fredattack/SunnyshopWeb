using System;
using System.Collections.Generic;
using sunnyShopWeb.coucheAccesBD;
using sunnyShopWeb.classesMetier;
using System.Web.UI;

namespace sunnyShopWeb.coucheMetier
{
    public class Metier
    {
        #region AccesBd

        private AccesBd coucheAccesBD;
        /**
        * Constructeur: créer l'objet de type AccesBD
        */

        public Metier()
        {
            coucheAccesBD = new AccesBd();
        }

        public User createUserLogin(string login, string password)
        {
            User u = new User();
            try
            {
                u = coucheAccesBD.createUserLogin(login, password);
            }
            catch (Exception)
            {

                throw new ExceptionMetier("le LOGIN et/ou le PASSWORD ne sont pas correct.") ;
            }
            return u;
        }

        public String testLogin(string login)
        {
            string l = "";
            try
            {
                l = coucheAccesBD.testLogin(login);
            }
            catch (Exception)
            {

                throw new ExceptionMetier("le LOGIN et/ou le PASSWORD ne sont pas correct.");
            }
            return l;
        }

        public User lireUserSpecifique(int idUser)
        {
            User u = new User();
            try
            {
                u = coucheAccesBD.lireUserSpecifique(idUser);
            }
            catch (Exception)
            {

                throw new ExceptionMetier("le LOGIN et/ou le PASSWORD ne sont pas correct.");
            }
            return u;
        }

        public int AjouterUser(User user)
        {
            return coucheAccesBD.AjouterUser(user);
        }

        public int ModifierUser(User user)
        {
            return coucheAccesBD.ModifierUser(user);
        }

        public List<Vin> ListerVins()
        {
            return coucheAccesBD.ListerVins();
        }

        public List<Alcool> ListerAlcools()
        {
            return coucheAccesBD.ListerAlcools();
        }

        public List<Chemise> ListerChemises()
        {
            return coucheAccesBD.ListerChemises();
        }

        public Alcool lireAlcoolSpecifique(string idProduit)
        {
            Alcool a = new Alcool();
            try
            {
                a = coucheAccesBD.lireAlcoolSpecifique(idProduit);
            }
            catch (Exception)
            {

                throw new ExceptionMetier("Il n'y a pas d'alcool avec cet id dans la db.");
            }
            return a;
        }
        

        public Vin lireVinSpecifique(string idProduit)
        {
            Vin a = new Vin();
            try
            {
                a = coucheAccesBD.lireVinSpecifique(idProduit);
            }
            catch (Exception)
            {

                throw new ExceptionMetier("Il n'y a pas d'alcool avec cet id dans la db.");
            }
            return a;
        }


        public Chemise lireChemiseSpecifique(string idProduit)
        {
            Chemise a = new Chemise();
            try
            {
                a = coucheAccesBD.lireChemiseSpecifique(idProduit);
            }
            catch (Exception)
            {

                throw new ExceptionMetier("Il n'y a pas de Chemise avec cet id dans la db.");
            }
            return a;
        }

        public int AjouterCommande(Order newOrder)
        {
            return coucheAccesBD.AjouterCommande(newOrder);
        }

        public int LastOrderId()
        {
            return coucheAccesBD.LastOrderId();
        }

        public int AjouterLigneCommande(OrderDetails od)
        {
            return coucheAccesBD.AjouterLigneCommande(od);
        }

        public List<Order> ListerOrderClient(int idUser)
        {
            return coucheAccesBD.ListerOrderClient(idUser);
            
        }

        public List<OrderDetails> listerOrderDetails(int idOrder)
        {
            return coucheAccesBD.listerOrderDetails(idOrder);

        }

        public int upDateStock(OrderDetails od)
        {

            return coucheAccesBD.upDateStock(od,( stockCheck(od.IdProduit)-od.Quantity));
        }
        #endregion

        #region controle

        public List<OrderDetails> addToCart(OrderDetails ligne, List<OrderDetails> panier)
        {
          
            int cptr = -1;
            if (panier.Count == 0)
                if (ligne.Quantity > stockCheck(ligne.IdProduit))
                {
                    ligne.Quantity = stockCheck(ligne.IdProduit);
                    panier.Add(ligne);
                }
                 else   
                 panier.Add(ligne);
            else
            {
                for (int i = 0; i < panier.Count; i++)
                {
                    if (panier[i].IdProduit == ligne.IdProduit) //on cherche dans la liste si l'article ne s'y trouve pas
                    {
                        cptr = i;
                    }
                }
                if (cptr != -1)//si l'article s'y trouve
                {
                    if (ligne.Quantity == 0) panier.RemoveAt(cptr); // on verifie si la quantité transmise est de 0 si oui on supprime l'article 

                    else // si la quantité transmise est différente de zero
                    {
                        int stockDispo = stockCheck(panier[cptr].IdProduit);
                        //   if(ligne.IdProduit.Substring(0,2)!="02")

                        if (ligne.Quantity + panier[cptr].Quantity <= stockDispo)// vérifie la stock dispo
                        {
                            panier[cptr].Quantity += ligne.Quantity;// si possible on ajoute la quantité
                        }
                        else // sinon on ajoute la quantité max.

                            panier[cptr].Quantity = stockDispo;
                    }
                }
                else  //si l'article ne s'y trouve pas, on l'ajoute.
                {
                    int stockDispo = stockCheck(ligne.IdProduit);
                    //   if(ligne.IdProduit.Substring(0,2)!="02")

                    if (ligne.Quantity <= stockDispo)// vérifie la stock dispo
                    {
                        panier.Add(ligne);// si possible on ajoute la quantité
                    }
                    else // sinon on ajoute la quantité max.
                    {
                        ligne.Quantity = stockDispo;
                        panier.Add(ligne);
                    }
                } 

            }
            return panier;
        }

        public int stockCheck(string idProduit)
        {
            int retVal = new int();
            if (idProduit.Substring(0, 2) == "01")
            {
                Alcool prod = lireAlcoolSpecifique(idProduit);
                retVal = prod.StockAlcool;
            }
            else if (idProduit.Substring(0, 2) == "00")
            {
                Vin prod = lireVinSpecifique(idProduit);
                retVal = prod.StockVin;
            }

            else if (idProduit.Substring(0, 2) == "02")
            {
                Chemise prod = lireChemiseSpecifique(idProduit);
                retVal = prod.StockChemise;
            }

            return retVal;
        }

        public String totalCount(List<OrderDetails> panier)
        {
            decimal total =0 ;
            decimal sousTotal;
            foreach (OrderDetails od in panier)
            {
                if (od.IdProduit.Substring(0, 2) == "01")
                {
                    Alcool prod = lireAlcoolSpecifique(od.IdProduit);
                    sousTotal = prod.PrixUnitaire * od.Quantity;
                    total += sousTotal;

                  
                    
                }
                else if (od.IdProduit.Substring(0, 2) == "00")
                {
                    Vin prod = lireVinSpecifique(od.IdProduit);
                    sousTotal = prod.PrixUnitaire * od.Quantity;
                    total += sousTotal;

                }

                else if (od.IdProduit.Substring(0, 2) == "02")
                {
                    Chemise prod = lireChemiseSpecifique(od.IdProduit);
                    sousTotal = prod.PrixUnitaire * od.Quantity;
                    total += sousTotal;
                }

            }
            total = System.Math.Round(total, 2);
            
            return total.ToString();

        }

        public int controlUserAge(string BirthDate)
        {
            TimeSpan ts = DateTime.Now - (DateTime.Parse(BirthDate));
            double age = ts.TotalDays / 365.25;
            int retVal;
            if (age >= 18) retVal = 2;
            else if (age > 16 && age < 18) retVal = 1;
            else retVal = 0;

            return retVal;
        }

        public int controlCartContent(List<OrderDetails> panier)
        {
            Boolean vin = false;
            Boolean alcool = false;
            int retVal = 0;

            foreach (OrderDetails od in panier)
            {
                if(od.IdProduit.Substring(0,2)=="00")
                {
                    vin = true;
                }
                else if (od.IdProduit.Substring(0, 2) == "01")
                {
                    alcool = true;   
                }
            }
            if (vin == true && alcool == false) retVal = 1;
            else if (vin == false && alcool == true) retVal = 2;
            else if (vin == true && alcool == true) retVal = 3;
            return retVal;
        }


        #endregion
    }
}