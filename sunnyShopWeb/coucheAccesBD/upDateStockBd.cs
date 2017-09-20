using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using sunnyShopWeb.classesMetier;
using sunnyShopWeb.coucheMetier;
using System.Data.SqlClient;

namespace sunnyShopWeb.coucheAccesBD
{
    public class upDateStockBd : OperationBD
    {
        private OrderDetails newOd;
        private int newStock;
        private string procedure = ""; 

        public upDateStockBd(OrderDetails od, int stock)
            : base("upDateStock")
        {
            newOd = od;
            newStock = stock;
        }
        


        public override int ExecuterRequete(SqlConnection sqlConn)
        {
            int retVal;
            if (newOd.IdProduit.Substring(0, 2) == "01") procedure = "Alcool";
            else if (newOd.IdProduit.Substring(0, 2) == "00") procedure = "Vin";
            else procedure = "Chemise";

            SqlCommand sqlCmd = new SqlCommand("updateStock" + procedure, sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add("@idProduit", SqlDbType.VarChar).Value = newOd.IdProduit;
            sqlCmd.Parameters.Add("@stock"+procedure, SqlDbType.Int).Value = newStock;
            sqlCmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;

            sqlCmd.ExecuteNonQuery();

            retVal = Int32.Parse(sqlCmd.Parameters["@RetVal"].Value.ToString());
            return retVal;
        }

    }
}