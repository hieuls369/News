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
    public partial class Login : Form
    {
        private Boolean check = false;
        FoodN.Entity.Account account;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            tbPass.PasswordChar = '*';

        }


        public void getCha()
        {
            string accountName = tbUser.Text;
            string accountPass = tbPass.Text;

            if (!string.IsNullOrEmpty(accountName) && !string.IsNullOrEmpty(accountPass))
            {
                account = FoodN.Entity.AdminLogin.getAdminLogin(accountName, accountPass);
                if (account.roleID == 1)
                {
                    this.Hide();
                    ManageInfo m = new ManageInfo();
                    m.Show();
                    
                }
                else
                {
                    this.Hide();
                    UserForm u = new UserForm(account);
                    u.Show();
                }
            }
            else
            {
                MessageBox.Show("Please fill all the content -.-' ");
            }
        }

        private void tbUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    getCha();
                }

            }
            catch
            {
                MessageBox.Show("Account not exist!!!");
            }
        }

        private void tbPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    getCha();
                }

            }
            catch
            {
                MessageBox.Show("Account not exist!!!");
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void linkCreateAcc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            checkUserName();
            if (check)
            {
                MessageBox.Show("This account is already exist!");
                tbUser.Text = "";
            }
            else
            {
                FoodN.DAO.AddDAO.AddNewAccount(tbUser.Text, tbPass.Text);
                MessageBox.Show("Create successfully! Now you can login and update your profile!");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void ckbPass_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbPass.Checked)
            {
                tbPass.PasswordChar = '\0';
            }
            else
            {
                tbPass.PasswordChar = '*';
            }
        }

        public void checkUserName()
        {
            foreach(DataRow dr in DAO.AddDAO.listUserName().Rows)
            {
                if(dr[0].Equals(tbUser.Text))
                {
                    check = true;
                    return;
                }
            }
            check = false;
        }
    }
}
