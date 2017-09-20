using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using sunnyShopWeb.classesMetier;

namespace sunnyShopWeb.coucheAccesBD
{
    public class CreateUserLoginBd : OperationBD
    {
        private User userLogged;
        private string Login;
        private string Password;
        private Decimal totalAchat;

        public User getUser()
        {
            return userLogged;
        }

        public CreateUserLoginBd(string login, string password)
            :base ("createUserLogin")
        {
            Login = login;
            Password = password;

        }

        public override int ExecuterRequete(SqlConnection sqlConn)
        {
            SqlCommand sqlCmd = new SqlCommand("createUserLogin", sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add("@login", SqlDbType.VarChar).Value = Login;
            sqlCmd.Parameters.Add("@password", SqlDbType.VarChar).Value = Password;

            SqlDataReader sqlReader = sqlCmd.ExecuteReader();

            if(sqlReader.Read()==true)
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