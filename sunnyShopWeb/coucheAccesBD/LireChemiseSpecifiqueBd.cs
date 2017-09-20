using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sunnyShopWeb.classesMetier;
using System.Data;
using System.Data.SqlClient;

namespace sunnyShopWeb.coucheAccesBD
{
    public class LireChemiseSpecifiqueBd : OperationBD
    {
        private Chemise a;
        private string IdProduit;


        public Chemise getChemise()
        {
            return a;
        }

        public LireChemiseSpecifiqueBd(string Idproduit)
            : base("LireChemiseSpecifique")
        {
            IdProduit = Idproduit;

        }

        public override int ExecuterRequete(SqlConnection sqlConn)
        {
            SqlCommand sqlCmd = new SqlCommand("LireChemiseSpecifiqueWeb", sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add("@IdProduit", SqlDbType.VarChar).Value = IdProduit;

            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            if (sqlReader.Read() == true)
            {


                a = new Chemise(Convert.ToString(sqlReader["idProduit"]),
                                Convert.ToString(sqlReader["nomChemise"]),
                                Convert.ToDecimal(sqlReader["prixUnitaire"]),
                                Convert.ToString(sqlReader["matiere"]),
                                Convert.ToString(sqlReader["couleurChemise"]),
                                Convert.ToInt32(sqlReader["stockChemise"]),
                                Convert.ToString(sqlReader["imageChemise"]),
                                Convert.ToString(sqlReader["taille"]),
                                Convert.ToInt32(sqlReader["numModel"]));
            }
            sqlReader.Close();
            return (a != null) ? 1 : 0;
        }
    }
}