using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sunnyShopWeb.classesMetier
{
    public class Chemise
    {
        private String idProduit;
        private String nomChemise;
        private decimal prixUnitaire;
        private int idMatiere;
        private String matiere;
        private String couleurChemise;
        private int stockChemise;
        private String imageChemise;
        private int idTypeProduit;
        private int afficherProduit;
        private int idTaille;
        private String taille;
        private int model;


        #region Constructor
        public Chemise()
        { }

        public Chemise(string idProduit, string nomChemise, decimal prixUnitaire, 
             string matiere, string couleurChemise, int stockChemise, 
             string imageChemise,  string taille, int model)
        {
            this.idProduit = idProduit;
            this.nomChemise = nomChemise;
            this.prixUnitaire = prixUnitaire;
            this.matiere = matiere;
            this.couleurChemise = couleurChemise;
            this.stockChemise = stockChemise;
            this.imageChemise = imageChemise;
            this.taille = taille;
            this.model = model;
        }


        #endregion

        #region Get/Set

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

        public string NomChemise
        {
            get
            {
                return nomChemise;
            }

            set
            {
                nomChemise = value;
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

        public int IdMatiere
        {
            get
            {
                return idMatiere;
            }

            set
            {
                idMatiere = value;
            }
        }

        public string Matiere
        {
            get
            {
                return matiere;
            }

            set
            {
                matiere = value;
            }
        }

        public string CouleurChemise
        {
            get
            {
                return couleurChemise;
            }

            set
            {
                couleurChemise = value;
            }
        }

        public int StockChemise
        {
            get
            {
                return stockChemise;
            }

            set
            {
                stockChemise = value;
            }
        }

        public string ImageChemise
        {
            get
            {
                return imageChemise;
            }

            set
            {
                imageChemise = value;
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

        public int AfficherProduit
        {
            get
            {
                return afficherProduit;
            }

            set
            {
                afficherProduit = value;
            }
        }

        public int IdTaille
        {
            get
            {
                return idTaille;
            }

            set
            {
                idTaille = value;
            }
        }

        public string Taille
        {
            get
            {
                return taille;
            }

            set
            {
                taille = value;
            }
        }

        public int Model
        {
            get
            {
                return model;
            }

            set
            {
                model = value;
            }
        }
        #endregion
    }
}