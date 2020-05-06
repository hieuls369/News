using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodNew_Web
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                title.InnerText = FoodN.DAO.IntroNews.getTopNews().Rows[0][1].ToString();
                img.Src = "../Image/food/" + FoodN.DAO.IntroNews.getTopNews().Rows[0][7].ToString();
                loadData();
            }
        }

        public void loadData()
        {
            NewsRepeater.DataSource = FoodN.DAO.IntroNews.get6TopRecentNews();
            NewsRepeater.DataBind();
        }
    }
}