using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sunnyShopWeb.classesMetier;
using System.Data;
using System.Data.SqlClient;

namespace sunnyShopWeb.coucheAccesBD
{
    public class lireVinSpecifiqueBd:OperationBD
    {
        private Vin v;
        private string IdVin;


        public Vin getVin()
        {
            return v;
        }

        public lireVinSpecifiqueBd(string IdProduit)
            : base("LireVinSpecifique")
        {
            IdVin = IdProduit;

        }

        public override int ExecuterRequete(SqlConnection sqlConn)
        {
            SqlCommand sqlCmd = new SqlCommand("LireVinSpecifiqueWeb", sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add("@numVin", SqlDbType.VarChar).Value = IdVin;

            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            if (sqlReader.Read() == true)
            {


                v = new Vin(Convert.ToString(sqlReader["idProduit"]),
                                             Convert.ToString(sqlReader["nomVin"]),
                                             Convert.ToDecimal(sqlReader["prixUnitaire"]),
                                             Convert.ToString(sqlReader["typeVin"]),
                                             Convert.ToString(sqlReader["saveur"]),
                                             Convert.ToString(sqlReader["provenanceVin"]),
                                             Convert.ToString(sqlReader["maturation"]),
                                             Convert.ToString(sqlReader["millesime"]),
                                             Convert.ToInt32(sqlReader["stockVin"]),
                                             Convert.ToString(sqlReader["imageVin"]));
            }
            sqlReader.Close();
            return (v != null) ? 1 : 0;
        }
    }
}