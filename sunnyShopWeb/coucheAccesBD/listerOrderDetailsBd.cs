using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sunnyShopWeb.classesMetier;
using System.Data.SqlClient;
using System.Data;

namespace sunnyShopWeb.coucheAccesBD
{
    public class listerOrderDetailsBd : OperationBD
    {
        private List<OrderDetails> Liste;
        private int idOrder;

        public List<OrderDetails> getListe()
        {
            return Liste;
        }

        public listerOrderDetailsBd(int id)
            : base("listerOrderDetails")
        {
            idOrder = id;
        }

        public override int ExecuterRequete(SqlConnection sqlConn)
        {
            Liste = new List<OrderDetails>();
            SqlCommand sqlCmd = new SqlCommand("ListerOrderDetails", sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add("@idOrder", SqlDbType.VarChar).Value = idOrder;

            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read() == true)
                Liste.Add(new OrderDetails(Convert.ToString(sqlReader["idProduit"]),
                Convert.ToString(sqlReader["nom"]),
                Convert.ToInt32(sqlReader["quantity"]),
                Convert.ToDecimal(sqlReader["prixUnitaire"]),
                Convert.ToDecimal(sqlReader["sous-Total"]),
                idOrder));
            sqlReader.Close();
            return Liste.Count;
        }
    }
}