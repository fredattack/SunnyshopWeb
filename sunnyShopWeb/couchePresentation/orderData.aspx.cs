using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services.Protocols;
using sunnyShopWeb.classesMetier;
using sunnyShopWeb.coucheMetier;
using Newtonsoft.Json;
namespace sunnyShopWeb.couchePresentation
{
    public partial class orderData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            Session["idOrder"] = getIdOrder();
        }

        public int getIdOrder()
        {
            string input = "";
            int idOrder = 0;
            using (var reader = new StreamReader(Request.InputStream))
            {
                input = reader.ReadToEnd();
            }
            idOrder = int.Parse(input);
            // idOrder = JsonConvert.DeserializeObject<int>(input);//a retourner
            return idOrder;

        }
    }
}