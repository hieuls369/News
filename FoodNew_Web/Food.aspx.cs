using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodNew_Web
{
    public partial class Food : System.Web.UI.Page
    {
        private int total;

        private int maxPage;

        private int pageSize = 4;

        private int index = 1;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ddType.DataTextField = "typeName";
                ddType.DataValueField = "typeID";
                ddType.DataSource = FoodN.Entity.TypeDisplay.getAllTypeWeb();
                ddType.SelectedIndex = 0;
                ddType.DataBind();

                ddCountry.DataTextField = "countryName";
                ddCountry.DataValueField = "countryID";
                ddCountry.DataSource = FoodN.Entity.CountryDisplay.getAllCountryWeb();
                ddCountry.SelectedIndex = 0;
                ddCountry.DataBind();

                loadData();
            }

        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            index = 1;
            loadData();
        }

        public void loadData()
        {
            int typeID = Convert.ToInt32(ddType.SelectedValue);
            int countryID = Convert.ToInt32(ddCountry.SelectedValue);
            string search = "";
            if (string.IsNullOrEmpty(tbSearchByName.Text))
            {
                search = "All Food";
            }
            else
            {
                search = tbSearchByName.Text;
            }
            total = Convert.ToInt32(FoodN.DAO.FoodNews.countNews(typeID, countryID, search).Rows[0][0].ToString());

            maxPage = total / pageSize;

            if (total % pageSize != 0)
            {
                maxPage++;
            }

            int start = (index * pageSize) - (pageSize - 1);
            int end = index * pageSize;
            if (maxPage == 0)
            {
                lblpage.Text = "Not Found!";
            }
            else
            {
                lblpage.Text = "Page " + (index) + " of " + maxPage;
            }

            MoreNewsRepeater.DataSource = FoodN.DAO.FoodNews.searchNews(typeID, countryID, search, start, end);
            MoreNewsRepeater.DataBind();
            pageIndices();
        }

        public void pageIndices()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PageIndex");


            for (int i = 1; i <= maxPage; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = i;
                dt.Rows.Add(dr);
            }

            rptPaging.DataSource = dt;
            rptPaging.DataBind();
        }

        protected void rptPaging_ItemCommand(object source, DataListCommandEventArgs e)
        {
            index = Convert.ToInt32(e.CommandArgument.ToString());
            loadData();
        }

        protected void MoreNewsRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int newsID = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Redirect("Detail.aspx?id="+newsID);
        }
    }
}