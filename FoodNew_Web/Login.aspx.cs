using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodNew_Web
{
    public partial class Login : System.Web.UI.Page
    {
        FoodN.Entity.Account account;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string accountName = tbUsername.Text;
                string accountPass = tbPassword.Text;

                if (!string.IsNullOrEmpty(accountName) && !string.IsNullOrEmpty(accountPass))
                {
                    account = FoodN.Entity.AdminLogin.getAdminLogin(accountName, accountPass);
                    if (account.roleID == 1)
                    {
                        lbError.Text = "Account doesn't exist";
                        tbUsername.Text = "";
                        tbPassword.Text = "";
                    }
                    else
                    {
                        Session["accID"] = account.accountID;
                        Session["accName"] = account.accountName;
                        Session["accPass"] = account.accountPass;
                        Session["accRole"] = account.roleID;
                        Response.Redirect("HomePage.aspx");
                    }
                }
                else
                {
                    lbError.Text = "Please fill all the content -.-' ";
                }
            }
            catch
            {
                lbError.Text = "Account doesn't exist";
                tbUsername.Text = "";
                tbPassword.Text = "";
            }
        }
    }
}