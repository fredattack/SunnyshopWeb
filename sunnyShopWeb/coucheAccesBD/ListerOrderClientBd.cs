using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sunnyShopWeb.classesMetier;
using System.Data.SqlClient;
using System.Data;

namespace sunnyShopWeb.coucheAccesBD
{
    public class ListerOrderClientBd :OperationBD
    {
        private List<Order> Liste;
        private int idUser;

        public List<Order> getListe()
        {
            return Liste;
        }

        public ListerOrderClientBd(int id)
            : base("ListerOrderClient")
        {
            idUser = id;
        }

        public override int ExecuterRequete(SqlConnection sqlConn)
        {
            Liste = new List<Order>();
            SqlCommand sqlCmd = new SqlCommand("ListerOrderClients", sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add("@idUser", SqlDbType.VarChar).Value = idUser;

            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read() == true)
                Liste.Add(new Order(Convert.ToInt32(sqlReader["idOrder"]),
                Convert.ToString(sqlReader["dateOrder"]),
                Convert.ToString(sqlReader["timeOrder"]),
                Convert.ToDecimal(sqlReader["totalPrice"]),
                Convert.ToString(sqlReader["deliveredOrder"]),
                idUser));
            sqlReader.Close();
            return Liste.Count;
        }
        }
}