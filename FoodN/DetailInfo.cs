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
    public partial class DetailInfo : Form
    {

        private int check = 0;

        FoodN.Entity.User selectUser;
        FoodN.Entity.Account selectedAccount;

        private string imgName = "";
        public DetailInfo()
        {
            InitializeComponent();
        }

        public DetailInfo(FoodN.Entity.Account account, int c)
        {
            check = c;
            selectedAccount = account;
            InitializeComponent();
        }

        public DetailInfo(FoodN.Entity.User user, int c)
        {
            check = c;
            selectUser = user;
            InitializeComponent();
        }
        public DetailInfo(FoodN.Entity.User user, FoodN.Entity.Account account, int c)
        {
            check = c;
            selectUser = user;
            selectedAccount = account;
            InitializeComponent();
        }

        private void DetailInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void DetailInfo_Load(object sender, EventArgs e)
        {
            loadData();
        }

        public void loadData()
        {
            cbRole.DisplayMember = "roleName";
            cbRole.ValueMember = "roleID";
            cbRole.DataSource = FoodN.Entity.RoleDisplay.getAllRole();

            if (check == 1)
            {
                btnRefresh.Visible = true;

                btnAddImage.Visible = true;
                if (selectUser == null)
                {
                    btnAdd.Visible = true;
                }
                else
                {
                    btnUpdate.Visible = true;
                }
            }
            try
            {
                if (selectedAccount.roleID == 1 || selectedAccount.roleID == 4)
                {
                    cbRole.Enabled = false;
                }
                else
                {
                    cbRole.Enabled = true;
                }
            }
            catch
            {
                cbRole.Enabled = false;
            }

            if (selectUser != null)
            {
                lbAccountID.Text = selectUser.accountName;
                tbUserName.Text = selectUser.userName;
                tbPassword.Text = selectUser.accountPass;
                tbEmail.Text = selectUser.email;
                tbAddress.Text = selectUser.address;
                datePick.Value = Convert.ToDateTime(selectUser.date.ToString());
                tbPhone.Text = selectUser.phone.ToString();
                cbRole.SelectedIndex = selectUser.roleID - 1;
               
                imgName = selectUser.imgLink;
                pnPicture.BackgroundImage = Image.FromFile("F:\\Chuyên Ngành 5\\PRN201\\Project\\FoodN\\img\\user\\" + imgName);
                pnPicture.BackgroundImageLayout = ImageLayout.Stretch;
                dataNews();
            }
            else
            {
                lbAccountID.Text = selectedAccount.accountName;
                tbPassword.Text = selectedAccount.accountPass;
                cbRole.SelectedIndex = selectedAccount.roleID - 1;
            }
        }


        public void dataNews()
        {
            dataNewsUser.AutoGenerateColumns = false;

            dataNewsUser.Columns.Add("Title", "Title");
            dataNewsUser.Columns["Title"].DataPropertyName = "title";

            dataNewsUser.Columns.Add("DatePub", "DatePub");
            dataNewsUser.Columns["DatePub"].DataPropertyName = "datePub";

            if(selectUser.roleID == 4 || selectUser.roleID == 1)
            {
                dataNewsUser.DataSource = FoodN.Entity.FoodDisplay.getAllFoodByID(selectUser.accountID);
            }
            else
            {
                dataNewsUser.AllowUserToAddRows = false;
            }
            lbCount.Text = dataNewsUser.Rows.Count.ToString();
        }

        private void dataNewsUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DetailNews detailNews = new DetailNews(((List<FoodN.Entity.Food>)dataNewsUser.DataSource)[e.RowIndex], selectedAccount, check);
            detailNews.ShowDialog();
            loadData();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.ShowDialog();
                op.InitialDirectory = "F:\\Chuyên Ngành 5\\PRN201\\Project\\FoodN\\img\\user\\";

                string[] a = op.FileName.Split('\\');
                imgName = a[a.Length - 1];

                pnPicture.BackgroundImage = Image.FromFile("F:\\Chuyên Ngành 5\\PRN201\\Project\\FoodN\\img\\user\\" + imgName);
                pnPicture.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch
            {
                MessageBox.Show("Not Found!");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbUserName.Text) && !string.IsNullOrEmpty(tbEmail.Text) && !string.IsNullOrEmpty(tbAddress.Text)
               && !string.IsNullOrEmpty(tbPhone.Text) && !string.IsNullOrEmpty(tbPassword.Text) && !string.IsNullOrEmpty(imgName))
            {
                DAO.AddDAO.fillInformation(tbUserName.Text, tbEmail.Text, tbAddress.Text, Convert.ToInt32(tbPhone.Text), datePick.Value,
                    Convert.ToInt32(selectedAccount.accountID), imgName, tbPassword.Text);
                this.Close();
                MessageBox.Show("Success! Your profile has been updated!");
            }
            else
            {
                MessageBox.Show("Please fill all the information");
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbUserName.Text) && !string.IsNullOrEmpty(tbEmail.Text) && !string.IsNullOrEmpty(tbAddress.Text)
               && !string.IsNullOrEmpty(tbPhone.Text) && !string.IsNullOrEmpty(tbPassword.Text) && !string.IsNullOrEmpty(imgName))
            {
                DAO.UpdateDAO.updateInformation(tbUserName.Text, tbEmail.Text, tbAddress.Text, Convert.ToInt32(tbPhone.Text), datePick.Value,
                    Convert.ToInt32(selectedAccount.accountID), imgName, tbPassword.Text, Convert.ToInt32(cbRole.SelectedValue));
                this.Close();
                MessageBox.Show("Success! Your profile has been updated!");
            }
            else
            {
                MessageBox.Show("Please fill all the information");
            }
            
        }

        private void dataNewsUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
