using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetaPocoDB;
using System.Data.Common;
using System.Data;
using PetaPoco;

namespace PetaWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DataTable dt = DbProviderFactories.GetFactoryClasses();
                foreach (DataRow item in dt.Rows)
                {
                    Console.WriteLine(item[0].ToString());
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            //Database _db = new Database("PetaPocoDB");

            PetaPocoDB.petapoco2 petapoco2 = new petapoco2();

            petapoco2.email = "xhhe2@ctrip.com";
            petapoco2.name = "何湘红";
            object obj = petapoco2.Insert();
            Response.Write(obj.ToString());
            //_db.Save(petapoco2);
            //PetaPocoDBDB.GetInstance().Save(petapoco2);
        }
    }
}