using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sunnyShopWeb.classesMetier
{
    public class OrderDetails
    {
        private int idOrderDetails;
        private string idProduit;
        private string nom;
        private int quantity;
        private decimal prixUnitaire;
        private decimal sousTotal;
        private int idOrder;


        public OrderDetails() { }

        public OrderDetails(int idOrderDetails, string idProduit, int quantity, int idOrder)
        {
            this.idOrderDetails = idOrderDetails;
            this.idProduit = idProduit;
            this.quantity = quantity;
            this.idOrder = idOrder;
        }

      
        public OrderDetails( string idProduit, string nom, 
                            int quantity, decimal prixUnitaire, decimal sousTotal, 
                            int idOrder)
        {
            
            this.idProduit = idProduit;
            this.nom = nom;
            this.quantity = quantity;
            this.prixUnitaire = prixUnitaire;
            this.sousTotal = sousTotal;
            this.idOrder = idOrder;
        }



        #region GET/SET
        public int IdOrderDetails
        {
            get
            {
                return idOrderDetails;
            }

            set
            {
                idOrderDetails = value;
            }
        }

        public string IdProduit
        {
            get
            {
                return idProduit;
            }

            set
            {
                idProduit = value;
            }
        }

        

        public int IdOrder
        {
            get
            {
                return idOrder;
            }

            set
            {
                idOrder = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public decimal PrixUnitaire
        {
            get
            {
                return prixUnitaire;
            }

            set
            {
                prixUnitaire = value;
            }
        }

        public decimal SousTotal
        {
            get
            {
                return sousTotal;
            }

            set
            {
                sousTotal = value;
            }
        }


        #endregion
    }
}