using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sunnyShopWeb.classesMetier;
using sunnyShopWeb.coucheMetier;
using System.Data;
using System.Data.SqlClient;

namespace sunnyShopWeb.coucheAccesBD
{
    public class LastOrderIdBd :OperationBD
    {
        private int OrderId;
        /**
        * Obtenir la liste des Alcools récupérés de la base de données
        * retour : une liste d'objets Alcool
*/
        public int getListe() { return OrderId; }
        /**
        * Constructeur
*/
        public LastOrderIdBd()
        : base("LastOrderId")
        { }
        /**
        * Appeler la procédure stockée ListerAlcools
        * param SqlConn : la connexion à la base de données
        * retour : le nombre de Alcools lus
*/
        public override int ExecuterRequete(SqlConnection sqlConn)
        {
            
            SqlCommand sqlCmd = new SqlCommand("LastOrderId", sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read() == true)
                OrderId= int.Parse(Convert.ToString(sqlReader[0]));
            sqlReader.Close();
            return OrderId;
        }
    }
}