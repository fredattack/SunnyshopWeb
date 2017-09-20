using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sunnyShopWeb.classesMetier;
using System.Data.SqlClient;
using System.Data;

namespace sunnyShopWeb.coucheAccesBD
{
    public class ListerVinsBd : OperationBD
    {
        private List<Vin> Liste;
        /**
        * Obtenir la liste des Vins récupérés de la base de données
        * retour : une liste d'objets Vin
*/
        public List<Vin> getListe() { return Liste; }
        /**
        * Constructeur
*/
        public ListerVinsBd()
        : base("ListerVins")
        { }
        /**
        * Appeler la procédure stockée ListerVins
        * param SqlConn : la connexion à la base de données
        * retour : le nombre de Vins lus
*/
        public override int ExecuterRequete(SqlConnection sqlConn)
        {
            Liste = new List<Vin>();
            SqlCommand sqlCmd = new SqlCommand("ListerVinsMotifWeb", sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read() == true)
                Liste.Add(new Vin(Convert.ToString(sqlReader["idProduit"]),
                Convert.ToString(sqlReader["nomVin"]),
                Convert.ToDecimal(sqlReader["prixUnitaire"]),
                Convert.ToString(sqlReader["typeVin"]),
                Convert.ToString(sqlReader["Saveur"]),
                Convert.ToString(sqlReader["ProvenanceVin"]),
                Convert.ToString(sqlReader["maturation"]),
                Convert.ToString(sqlReader["millesime"]),
                Convert.ToInt32(sqlReader["StockVin"]),
                Convert.ToString(sqlReader["imageVin"])));
            sqlReader.Close();
            return Liste.Count;
        }
    }
}