using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sunnyShopWeb.classesMetier;
using System.Data.SqlClient;
using System.Data;

namespace sunnyShopWeb.coucheAccesBD
{
    public class ListerAlcoolsBd : OperationBD
    {
        private List<Alcool> Liste;
        /**
        * Obtenir la liste des Alcools récupérés de la base de données
        * retour : une liste d'objets Alcool
*/
        public List<Alcool> getListe() { return Liste; }
        /**
        * Constructeur
*/
        public ListerAlcoolsBd()
        : base("ListerAlcools")
        { }
        /**
        * Appeler la procédure stockée ListerAlcools
        * param SqlConn : la connexion à la base de données
        * retour : le nombre de Alcools lus
*/
        public override int ExecuterRequete(SqlConnection sqlConn)
        {
            Liste = new List<Alcool>();
            SqlCommand sqlCmd = new SqlCommand("ListerAlcoolsMotifWeb", sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read() == true)
                Liste.Add(new Alcool(Convert.ToString(sqlReader["idProduit"]),
                Convert.ToString(sqlReader["nomAlcool"]),
                Convert.ToDecimal(sqlReader["prixUnitaire"]),
                Convert.ToString(sqlReader["familleAlcool"]),
                Convert.ToString(sqlReader["ProvenanceAlcool"]),
                Convert.ToInt32(sqlReader["degreAlcool"]),
                Convert.ToString(sqlReader["GoutAlcool"]),
                Convert.ToString(sqlReader["DatePeremption"]),
                Convert.ToInt32(sqlReader["StockAlcool"]),
                Convert.ToInt32(sqlReader["quantitéCaisse"]),
                Convert.ToString(sqlReader["imageAlcool"])));
            sqlReader.Close();
            return Liste.Count;
        }
    }
}