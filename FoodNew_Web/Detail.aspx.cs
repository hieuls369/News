using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodNew_Web
{
    public partial class Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    DataTable dt = FoodN.DAO.FoodNews.getNewsByID(id);
                    if(dt != null)
                    {
                        detail.DataSource = dt;
                        detail.DataBind();
                    }
                }
            }
        }
       

       
    }
}