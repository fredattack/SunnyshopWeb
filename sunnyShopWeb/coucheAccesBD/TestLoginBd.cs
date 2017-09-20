using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace sunnyShopWeb.coucheAccesBD
{
    public class TestLoginBd : OperationBD
    {
        
        private string Login;
        private string retLogin;

       public String getString()
        {
            return retLogin;
        }

        public TestLoginBd(string login)
            :base ("testLogin")
        {
            Login = login;
           

        }

        public override int ExecuterRequete(SqlConnection sqlConn)
        {
            SqlCommand sqlCmd = new SqlCommand("testLogin", sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add("@login", SqlDbType.VarChar).Value = Login;

            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            if (sqlReader.Read() == true)
            {
               

                retLogin = (Convert.ToString(sqlReader["login"] ));

            }
            sqlReader.Close();
            return (retLogin != null) ? 1 : 0;
        }
    }
}