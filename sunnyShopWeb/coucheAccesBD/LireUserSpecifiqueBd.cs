using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sunnyShopWeb.classesMetier;
using System.Data;
using System.Data.SqlClient;

namespace sunnyShopWeb.coucheAccesBD
{
    public class LireUserSpecifiqueBd : OperationBD
    {
        private User userLogged;
        private int IdUser;
        private Decimal totalAchat;

        public User getUser()
        {
            return userLogged;
        }

        public LireUserSpecifiqueBd(int idUser)
            : base("LireUserSpecifique")
        {
            IdUser = idUser;

        }

        public override int ExecuterRequete(SqlConnection sqlConn)
        {
            SqlCommand sqlCmd = new SqlCommand("LireUserSpecifique", sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add("@idUser", SqlDbType.Int).Value = IdUser;

            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            if (sqlReader.Read() == true)
            {
                if (Convert.IsDBNull(sqlReader["role"]) != true)
                {
                    totalAchat = 0;
                }

                userLogged = new User(Convert.ToInt32(sqlReader["idUser"]),
                                            Convert.ToString(sqlReader["firstName"]),
                                            Convert.ToString(sqlReader["login"]),
                                            Convert.ToString(sqlReader["lastName"]),
                                            Convert.ToString(sqlReader["adressUser"]),
                                            Convert.ToString(sqlReader["password"]),
                                            Convert.ToString(sqlReader["birthdate"]),
                                            Convert.ToString(sqlReader["role"]),
                                            totalAchat);

            }
            sqlReader.Close();
            return (userLogged != null) ? 1 : 0;
        }
    }
}