using System;
using sunnyShopWeb.classesMetier;
using System.Data;
using System.Data.SqlClient;

namespace sunnyShopWeb.coucheAccesBD
{
    public class AjouterLigneCommandeBd:OperationBD
	{
        private OrderDetails NewOrderD { get; set; }
        /**
        * Constructeur
        * param eleve : l'objet Eleve contenant les infos sur l'élève à ajouter
*/
        public AjouterLigneCommandeBd(OrderDetails orderD)
                    : base("AjouterLigneCommande")
        {
            NewOrderD = orderD;
        }
        /**
        * Appeler la procédure stockée AjouterEleve
        * param SqlConn : la connexion à la base de données
        * retour : 1 si l'élève a été ajouté, 0 sinon
*/
        public override int ExecuterRequete(SqlConnection sqlConn)
        {
            int retVal;

            SqlCommand sqlCmd = new SqlCommand("[ajouterLigneCommande]", sqlConn);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add("@idOrder", SqlDbType.Int).Value = NewOrderD.IdOrder;
            sqlCmd.Parameters.Add("@idProduit", SqlDbType.VarChar).Value = NewOrderD.IdProduit;
            sqlCmd.Parameters.Add("@quantity", SqlDbType.Int).Value = NewOrderD.Quantity;
            sqlCmd.Parameters.Add("@RetVal", SqlDbType.Int).Direction = ParameterDirection.Output;

            sqlCmd.ExecuteNonQuery();

            retVal = Int32.Parse(sqlCmd.Parameters["@RetVal"].Value.ToString());
            return retVal;
        }
    }
}