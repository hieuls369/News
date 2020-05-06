using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FoodN
{
    public partial class UserForm : Form
    {
        FoodN.Entity.Account selectedAccount;

        public UserForm()
        {
            InitializeComponent();
        }

        public UserForm(FoodN.Entity.Account acc)
        {
            selectedAccount = acc;
            InitializeComponent();
        }

        private void UserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login l = new Login();
            l.Show();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            mainScreen();
        }

        public void mainScreen()
        {

            lbName.Text = selectedAccount.accountName;
            if(selectedAccount.roleID != 3)
            {
                btnViewProduct.Enabled = true;
                btnViewUser.Text = "View Profile";
                btnViewProduct.Text = "Add new product";
            }
            else
            {
                btnViewUser.Text = "Update profile";
                btnViewProduct.Text = "You not a publisher yet";
                btnViewProduct.Enabled = false;
            }
            if(selectedAccount.roleID == 2)
            {
                btnViewProduct.Text = "You not a publisher yet";
                btnViewProduct.Enabled = false;
            }
            

        }

        private void btnViewUser_Click(object sender, EventArgs e)
        {
            try
            {

                if (selectedAccount.roleID == 3)
                {
                    DetailInfo detail = new DetailInfo(selectedAccount, 1);
                    detail.ShowDialog();
                    selectedAccount.roleID = Convert.ToInt32(FoodN.DAO.LoginDAO.getAdminLogin(selectedAccount.accountName, selectedAccount.accountPass).Rows[0][3].ToString());
                }
                else
                {
                    DetailInfo detailInfo = new DetailInfo(Entity.UserDisplay.getUserByAccountID(selectedAccount.accountID), selectedAccount, 1);
                    detailInfo.ShowDialog();
                    selectedAccount.roleID = Convert.ToInt32(FoodN.DAO.LoginDAO.getAdminLogin(selectedAccount.accountName, selectedAccount.accountPass).Rows[0][3].ToString());
                }
                mainScreen();
            }
            catch
            {
                MessageBox.Show("Your account didn't fill all the information");
            }
            
        }

        private void btnViewProduct_Click(object sender, EventArgs e)
        {
            try
            {
                DetailNews detailNews = new DetailNews(selectedAccount, 1);
                detailNews.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Your account didn't fill all the information");
            }
        }
    }
}
