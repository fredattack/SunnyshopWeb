using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sunnyShopWeb.classesMetier;
using System.Data.SqlClient;
using System.Data;

namespace sunnyShopWeb.coucheAccesBD
{
    public class ListerChemisesBd : OperationBD
    {
        private List<Chemise> Liste;
        /**
        * Obtenir la liste des Chemises récupérés de la base de données
        * retour : une liste d'objets Chemise
*/
        public List<Chemise> getListe() { return Liste; }
        /**
        * Constructeur
*/
        public ListerChemisesBd()
        : base("ListerChemises")
        { }
        /**
        * Appeler la procédure stockée ListerChemises
        * param SqlConn : la connexion à la base de données
        * retour : le nombre de Chemises lus
*/
        public override int ExecuterRequete(SqlConnection sqlConn)
        {
            Liste = new List<Chemise>();
            SqlCommand sqlCmd = new SqlCommand("ListerChemiseMotifWeb", sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read() == true)
                Liste.Add(new Chemise(Convert.ToString(sqlReader["idProduit"]),
                Convert.ToString(sqlReader["nomChemise"]),
                Convert.ToDecimal(sqlReader["prixUnitaire"]),

                Convert.ToString(sqlReader["matiere"]),
                Convert.ToString(sqlReader["couleurChemise"]),
                 Convert.ToInt32(sqlReader["StockChemise"]),
                
                 Convert.ToString(sqlReader["imageChemise"]),
                Convert.ToString(sqlReader["taille"]),
                Convert.ToInt32(sqlReader["numModel"])));
            sqlReader.Close();
            return Liste.Count;
        }
    }
}