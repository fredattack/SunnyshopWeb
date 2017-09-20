using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sunnyShopWeb.classesMetier;
using sunnyShopWeb.coucheMetier;
using System.Data;
using System.Data.SqlClient;

namespace sunnyShopWeb.coucheAccesBD
{
    public class AjouterUserBd : OperationBD
    {
        private User NewUser { get; set; }
        /**
        * Constructeur
        * param eleve : l'objet Eleve contenant les infos sur l'élève à ajouter
*/
        public AjouterUserBd(User user)
                    : base("AjouterUser")
{
            NewUser = user;
        }
        /**
        * Appeler la procédure stockée AjouterEleve
        * param SqlConn : la connexion à la base de données
        * retour : 1 si l'élève a été ajouté, 0 sinon
*/
        public override int ExecuterRequete(SqlConnection sqlConn)
        {
            int retVal;

            SqlCommand sqlCmd = new SqlCommand("AddUser", sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add("@login", SqlDbType.VarChar).Value = NewUser.Login;
            sqlCmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = NewUser.FirstName;
            sqlCmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = NewUser.LastName;
            sqlCmd.Parameters.Add("@adressUser", SqlDbType.VarChar).Value = NewUser.AdresUser;
            sqlCmd.Parameters.Add("@password", SqlDbType.VarChar).Value = NewUser.Password;
            sqlCmd.Parameters.Add("@birthDate", SqlDbType.VarChar).Value = NewUser.BirthDate;
            sqlCmd.Parameters.Add("@role", SqlDbType.VarChar).Value = NewUser.Role;
            sqlCmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;

            sqlCmd.ExecuteNonQuery();

            retVal = Int32.Parse(sqlCmd.Parameters["@RetVal"].Value.ToString());
            return retVal;
        }
    }
}