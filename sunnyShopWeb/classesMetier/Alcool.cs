using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sunnyShopWeb.classesMetier
{
    public class Alcool
    {
        private String idAlcool;
        private String nomAlcool;
        private decimal prixUnitaire;
        private int idFamille;
        private String familleAlcool;
        private int idProvenanceAlcool;
        private String provenanceAlcool;
        private int degréAlcool;
        private String goutAlcool;
        private String datePeremption;
        private int stockAlcool;
        private int quantitéCaisse;
        private String imageAlcool;
        private int idTypeProduit;
        private int afficherAlcool;

        #region Constructor
        public Alcool()
        {

        }

        public Alcool(string idAlcool, string nomAlcool, decimal prixUnitaire,
                        string familleAlcool, string provenanceAlcool, int degréAlcool,
                        string goutAlcool, string datePeremption, int stockAlcool,
                        int quantitéCaisse, string imageAlcool)
        {
            this.idAlcool = idAlcool;
            this.nomAlcool = nomAlcool;
            this.prixUnitaire = prixUnitaire;
            this.familleAlcool = familleAlcool;
            this.provenanceAlcool = provenanceAlcool;
            this.degréAlcool = degréAlcool;
            this.goutAlcool = goutAlcool;
            this.datePeremption = datePeremption;
            this.stockAlcool = stockAlcool;
            this.quantitéCaisse = quantitéCaisse;
            this.imageAlcool = imageAlcool;
        }

        #endregion
        
        #region Get/Set
        public string IdAlcool
        {
            get
            {
                return idAlcool;
            }

            set
            {
                idAlcool = value;
            }
        }

        public string NomAlcool
        {
            get
            {
                return nomAlcool;
            }

            set
            {
                nomAlcool = value;
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

        public int IdFamille
        {
            get
            {
                return idFamille;
            }

            set
            {
                idFamille = value;
            }
        }

        public string FamilleAlcool
        {
            get
            {
                return familleAlcool;
            }

            set
            {
                familleAlcool = value;
            }
        }

        public int IdProvenanceAlcool
        {
            get
            {
                return idProvenanceAlcool;
            }

            set
            {
                idProvenanceAlcool = value;
            }
        }

        public string ProvenanceAlcool
        {
            get
            {
                return provenanceAlcool;
            }

            set
            {
                provenanceAlcool = value;
            }
        }

        public int DegréAlcool
        {
            get
            {
                return degréAlcool;
            }

            set
            {
                degréAlcool = value;
            }
        }

        public string GoutAlcool
        {
            get
            {
                return goutAlcool;
            }

            set
            {
                goutAlcool = value;
            }
        }

        public string DatePeremption
        {
            get
            {
                return datePeremption;
            }

            set
            {
                datePeremption = value;
            }
        }

        public int StockAlcool
        {
            get
            {
                return stockAlcool;
            }

            set
            {
                stockAlcool = value;
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

        public string ImageAlcool
        {
            get
            {
                return imageAlcool;
            }

            set
            {
                imageAlcool = value;
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

        public int AfficherAlcool
        {
            get
            {
                return afficherAlcool;
            }

            set
            {
                afficherAlcool = value;
            }
        }

        #endregion
    }
}