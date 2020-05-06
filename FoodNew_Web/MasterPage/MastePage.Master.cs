using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodNew_Web.MasterPage
{
    public partial class MastePage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("HomePage.aspx");
        }

        protected void lbSign_Click(object sender, EventArgs e)
        {

        }

        protected void lbIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }
    }
}