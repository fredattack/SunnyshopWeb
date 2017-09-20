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
    public class AjouterCommandeBd : OperationBD
    {
        private Order NewOrder { get; set; }
        /**
        * Constructeur
        * param eleve : l'objet Eleve contenant les infos sur l'élève à ajouter
*/
        public AjouterCommandeBd(Order order)
                    : base("AjouterCommande")
        {
            NewOrder = order;
        }
        /**
        * Appeler la procédure stockée AjouterEleve
        * param SqlConn : la connexion à la base de données
        * retour : 1 si l'élève a été ajouté, 0 sinon
*/
        public override int ExecuterRequete(SqlConnection sqlConn)
        {
            int retVal;

            SqlCommand sqlCmd = new SqlCommand("[ajouterCommande]", sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add("@dateOrder", SqlDbType.VarChar).Value = NewOrder.DateOrder;
            sqlCmd.Parameters.Add("@idUserOrder", SqlDbType.Int).Value = NewOrder.IdUserOrder;
            sqlCmd.Parameters.Add("@totalPrice", SqlDbType.Float).Value = NewOrder.TotalPrice;
            sqlCmd.Parameters.Add("@deliveredOrder", SqlDbType.VarChar).Value = NewOrder.DeliveredOrder;
            sqlCmd.Parameters.Add("@timeOrder", SqlDbType.VarChar).Value = NewOrder.TimeOrder;
            sqlCmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;

            sqlCmd.ExecuteNonQuery();

            retVal = Int32.Parse(sqlCmd.Parameters["@RetVal"].Value.ToString());
            return retVal;
        }
    }
}