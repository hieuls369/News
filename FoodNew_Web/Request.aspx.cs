using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodNew_Web
{
    public partial class Request : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public void loadData()
        {
            RepeaterRequest.DataSource = FoodN.DAO.ManageDAO.getRequestByAccID(Convert.ToInt32(Session["accID"].ToString()));
            RepeaterRequest.DataBind();
        }

        protected void btnRequest_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbTitle.Text))
            {
                string strFromTextArea = Request.Form["taDescrip"];
                FoodN.DAO.AddDAO.makeRequest(tbTitle.Text, DateTime.Now, strFromTextArea, "a", Convert.ToInt32(Session["accID"].ToString()));
                lbShow.Text = "Successful request!";
                loadData();
            }
            else
            {
                lbShow.Text = "Please fill all the information";
            }
        }
    }
}