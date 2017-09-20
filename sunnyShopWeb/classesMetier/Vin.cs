using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sunnyShopWeb.classesMetier
{
    public class Vin
    {
        private String idVin;
        private String nomVin;
        private decimal prixUnitaire;
        private int idTypeVin;
        private String typeVin;
        private int idSaveur;
        private String saveur;
        private int idProvenance;
        private String provenanceVin;
        private int idMaturation;
        private String maturation;
        private String millesime;
        private int quantitéCaisse;
        private int stockVin;
        private String imageVin;
        private int idTypeProduit;
        private int afficherVin;



        #region Constructor
        public Vin() { }

        public Vin(string idVin, string nomVin, decimal prixUnitaire, string typeVin,
             string saveur, string provenanceVin, string maturation,
             string millesime, int stockVin,  string imageVin)
        {
            this.idVin = idVin;
            this.nomVin = nomVin;
            this.prixUnitaire = prixUnitaire;
            this.typeVin = typeVin;
            this.saveur = saveur;
            this.provenanceVin = provenanceVin;
            this.maturation = maturation;
            this.millesime = millesime;
            this.stockVin = stockVin;
            this.imageVin = imageVin;
        }

        #endregion

        #region Get/Set

        public string IdVin
        {
            get
            {
                return idVin;
            }

            set
            {
                idVin = value;
            }
        }

        public string NomVin
        {
            get
            {
                return nomVin;
            }

            set
            {
                nomVin = value;
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

        public int IdTypeVin
        {
            get
            {
                return idTypeVin;
            }

            set
            {
                idTypeVin = value;
            }
        }

        public string TypeVin
        {
            get
            {
                return typeVin;
            }

            set
            {
                typeVin = value;
            }
        }

        public int IdSaveur
        {
            get
            {
                return idSaveur;
            }

            set
            {
                idSaveur = value;
            }
        }

        public string Saveur
        {
            get
            {
                return saveur;
            }

            set
            {
                saveur = value;
            }
        }

        public int IdProvenance
        {
            get
            {
                return idProvenance;
            }

            set
            {
                idProvenance = value;
            }
        }

        public string ProvenanceVin
        {
            get
            {
                return provenanceVin;
            }

            set
            {
                provenanceVin = value;
            }
        }

        public int IdMaturation
        {
            get
            {
                return idMaturation;
            }

            set
            {
                idMaturation = value;
            }
        }

        public string Maturation
        {
            get
            {
                return maturation;
            }

            set
            {
                maturation = value;
            }
        }

        public string Millesime
        {
            get
            {
                return millesime;
            }

            set
            {
                millesime = value;
            }
        }

        public int QuantitéCaisse
        {
            get
            {
                return quantitéCaisse;
            }

            set
            {
                quantitéCaisse = value;
            }
        }

        public int StockVin
        {
            get
            {
                return stockVin;
            }

            set
            {
                stockVin = value;
            }
        }

        public string ImageVin
        {
            get
            {
                return imageVin;
            }

            set
            {
                imageVin = value;
            }
        }

        public int IdTypeProduit
        {
            get
            {
                return idTypeProduit;
            }

            set
            {
                idTypeProduit = value;
            }
        }

        public int AfficherVin
        {
            get
            {
                return afficherVin;
            }

            set
            {
                afficherVin = value;
            }
        }
        #endregion
    }
}