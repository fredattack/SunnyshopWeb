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
    public class ModifierUserBd : OperationBD
    {
        private User userObj;
        /**
        * Constructeur
        * param eleve : l'objet Eleve contenant les informations actualisées
*/
        public ModifierUserBd(User user)
            : base("ModifierUser")
        {
            userObj = user;
        }
        /**
        * Appeler la procédure stockée ModifierEleve
        * param SqlConn : la connexion à la base de données
        * retour : 1 si l'élève a été modifié, 0 sinon
*/
        public override int ExecuterRequete(SqlConnection sqlConn)
        {
            int retVal;

            SqlCommand sqlCmd = new SqlCommand("ModifierUser", sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add("@idUser", SqlDbType.Int).Value = userObj.IdUser;
            sqlCmd.Parameters.Add("@login", SqlDbType.VarChar).Value = userObj.Login;
            sqlCmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = userObj.FirstName;
            sqlCmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = userObj.LastName;
            sqlCmd.Parameters.Add("@adressUser", SqlDbType.VarChar).Value = userObj.AdresUser;
            sqlCmd.Parameters.Add("@password", SqlDbType.VarChar).Value = userObj.Password;
            sqlCmd.Parameters.Add("@birthDate", SqlDbType.VarChar).Value = userObj.BirthDate;
            sqlCmd.Parameters.Add("@role", SqlDbType.VarChar).Value = userObj.Role;
            sqlCmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;

            sqlCmd.ExecuteNonQuery();

            retVal = Int32.Parse(sqlCmd.Parameters["@RetVal"].Value.ToString());
            return retVal;
        }
    }
}
