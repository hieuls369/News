using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodNew_Web
{
    public partial class Signup : System.Web.UI.Page
    {
        private Boolean check = false;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            checkUserName();
            if (check)
            {
                lbError.Text = "This username already exist!";
                tbUsername.Text = "";
            }
            else
            {
                if (tbPassword.Text.Equals(tbPassword.Text))
                {
                    FoodN.DAO.AddDAO.AddNewAccount(tbUsername.Text, tbPassword.Text);
                    Session["accName"] = tbUsername.Text;
                    Session["accPass"] = tbPassword.Text;
                    Session["accRole"] = 3;
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    lbError.Text = "The pass must be repass again!";
                    tbRepass.Text = "";
                }
            }
        }

        public void checkUserName()
        {
            foreach (DataRow dr in FoodN.DAO.AddDAO.listUserName().Rows)
            {
                if (dr[0].Equals(tbUsername.Text))
                {
                    check = true;
                    return;
                }
            }
            check = false;
        }
    }
}