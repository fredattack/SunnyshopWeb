using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sunnyShopWeb.classesMetier;
using System.Data;
using System.Data.SqlClient;


namespace sunnyShopWeb.coucheAccesBD
{
    public class lireAlcoolSpecifiqueBd: OperationBD
    {
        private Alcool a;
        private string IdAlcool;
       

        public Alcool getAlcool()
        {
            return a;
        }

        public lireAlcoolSpecifiqueBd(string IdProduit)
            : base("LireAlcoolSpecifique")
        {
            IdAlcool = IdProduit;

        }

        public override int ExecuterRequete(SqlConnection sqlConn)
        {
            SqlCommand sqlCmd = new SqlCommand("LireAlcoolSpecifique", sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add("@numAlcool", SqlDbType.VarChar).Value = IdAlcool;

            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            if (sqlReader.Read() == true)
            {
                

               a = new Alcool(Convert.ToString(sqlReader["idProduit"]),
                                            Convert.ToString(sqlReader["nomAlcool"]),
                                            Convert.ToDecimal(sqlReader["prixUnitaire"]),
                                            Convert.ToString(sqlReader["familleAlcool"]),
                                            Convert.ToString(sqlReader["provenanceAlcool"]),
                                            Convert.ToInt32(sqlReader["degreAlcool"]),
                                            Convert.ToString(sqlReader["goutAlcool"]),
                                            Convert.ToString(sqlReader["datePeremption"]),
                                            Convert.ToInt32(sqlReader["stockAlcool"]),
                                            Convert.ToInt32(sqlReader["QuantitéCaisse"]),
                                            Convert.ToString(sqlReader["imageAlcool"]));
            }
            sqlReader.Close();
            return (a != null) ? 1 : 0;
        }
    }
}