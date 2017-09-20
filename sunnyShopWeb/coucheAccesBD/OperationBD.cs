using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace sunnyShopWeb.coucheAccesBD
{
    public abstract class OperationBD
    {
        protected string Nom;
        /**
        * Obtenir le nom de la procédure stockée
        * retour : le nom de la procédure stockée
*/
        public string getNom() { return Nom; }
        /**
        * Constructeur
        * param nom : le nom de le procédure stockée
*/
        protected OperationBD(string nom)
        {
            Nom = nom;
        }
        /**
        * Exécuter une requête SQL ou appeler une procédure stockée
        * param SqlConn : la connexion à la base de données
        * retour : le nombre de lignes affectées dans la base de données
*/
        public abstract int ExecuterRequete(SqlConnection sqlConn);
    }
}