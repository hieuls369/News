using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FoodN
{
    public partial class ManageInfo : Form
    {
        
        private Boolean flag1 = true;
        private Boolean flag2 = true;

        public ManageInfo()
        {
            InitializeComponent();
        }

        private void menuUser_Click(object sender, EventArgs e)
        {
            userData();
        }

        private void ManageInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login l = new Login();
            l.Show();
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuProduct_Click(object sender, EventArgs e)
        {
            foodData();
        }

        public void checkList()
        {
            for(int i = 0; i < InfoData.Columns.Count; i++)
            {
                listEntity.Items.Add(InfoData.Columns[i].HeaderText.ToString(), true);
            }
        }

        public void hideColumns()
        {
            int a = listEntity.SelectedIndex;
           
            if (listEntity.GetItemCheckState(a) == CheckState.Checked)
            {
                InfoData.Columns[a].Visible = true;
            }
            else
            {
                InfoData.Columns[a].Visible = false;
            }
           
        }

        public void userData()
        {
            flag1 = true;
            flag2 = true;

            listEntity.Show();

            listEntity.Items.Clear();
            
            InfoData.Columns.Clear();
            
            InfoData.AutoGenerateColumns = false;

            InfoData.Columns.Add("UserID", "UserID");
            InfoData.Columns["UserID"].DataPropertyName = "userID";

            InfoData.Columns.Add("UserName", "UserName");
            InfoData.Columns["UserName"].DataPropertyName = "userName";

            InfoData.Columns.Add("Email", "Email");
            InfoData.Columns["Email"].DataPropertyName = "email";

            InfoData.Columns.Add("Address", "Address");
            InfoData.Columns["Address"].DataPropertyName = "address";

            InfoData.Columns.Add("Phone", "Phone");
            InfoData.Columns["Phone"].DataPropertyName = "phone";

            InfoData.Columns.Add("Date", "Date");
            InfoData.Columns["Date"].DataPropertyName = "date";

            InfoData.Columns.Add("AccountName", "AccountName");
            InfoData.Columns["AccountName"].DataPropertyName = "accountName";

            InfoData.Columns.Add("AccountID", "AccountID");
            InfoData.Columns["AccountID"].DataPropertyName = "accountID";

            InfoData.Columns.Add("ImgLink", "ImgLink");
            InfoData.Columns["ImgLink"].DataPropertyName = "imgLink";

            InfoData.Columns.Add("Role", "Role");
            InfoData.Columns["Role"].DataPropertyName = "roleName";

            DataGridViewButtonColumn delcol = new DataGridViewButtonColumn();
            delcol.Name = "Delete";
            delcol.Text = "Remove";
            delcol.UseColumnTextForButtonValue = true;
            InfoData.Columns.Add(delcol);

            InfoData.DataSource = FoodN.Entity.UserDisplay.getAllUser();


            checkList();
        }

        public void foodData()
        {
            flag1 = true;
            flag2 = false;

            listEntity.Show();

            listEntity.Items.Clear();

            InfoData.Columns.Clear();
            
            InfoData.AutoGenerateColumns = false;

            InfoData.Columns.Add("FoodID", "FoodID");
            InfoData.Columns["FoodID"].DataPropertyName = "foodID";

            InfoData.Columns.Add("Title", "Title");
            InfoData.Columns["Title"].DataPropertyName = "title";

            InfoData.Columns.Add("ShortDes", "ShortDes");
            InfoData.Columns["ShortDes"].DataPropertyName = "shortDes";

            InfoData.Columns.Add("LongDes", "LongDes");
            InfoData.Columns["LongDes"].DataPropertyName = "longDes";

            InfoData.Columns.Add("DatePub", "DatePub");
            InfoData.Columns["DatePub"].DataPropertyName = "datePub";

            InfoData.Columns.Add("TypeName", "TypeName");
            InfoData.Columns["TypeName"].DataPropertyName = "typeName";

            InfoData.Columns.Add("CountryName", "CountryName");
            InfoData.Columns["CountryName"].DataPropertyName = "countryName";

            InfoData.Columns.Add("ImgLink", "ImgLink");
            InfoData.Columns["imgLink"].DataPropertyName = "imgLink";

            InfoData.Columns.Add("AccountName", "AccountName");
            InfoData.Columns["AccountName"].DataPropertyName = "accountName";

            DataGridViewButtonColumn delcol = new DataGridViewButtonColumn();
            delcol.Name = "Delete";
            delcol.Text = "Remove";
            delcol.UseColumnTextForButtonValue = true;
            InfoData.Columns.Add(delcol);

            InfoData.DataSource = FoodN.Entity.FoodDisplay.getAllFood();

            checkList();
        }

        public void request()
        {
            flag1 = false;
            flag2 = true;

            listEntity.Show();

            listEntity.Items.Clear();

            InfoData.Columns.Clear();
            InfoData.AutoGenerateColumns = false;

            InfoData.Columns.Add("RequestID", "RequestID");
            InfoData.Columns["RequestID"].DataPropertyName = "requestID";

            InfoData.Columns.Add("Title", "Title");
            InfoData.Columns["Title"].DataPropertyName = "title";

            InfoData.Columns.Add("Date", "Date");
            InfoData.Columns["Date"].DataPropertyName = "date";

            InfoData.Columns.Add("Description", "Description");
            InfoData.Columns["Description"].DataPropertyName = "description";

            InfoData.Columns.Add("AccountName", "AccountName");
            InfoData.Columns["AccountName"].DataPropertyName = "accountName";

            InfoData.DataSource = FoodN.Entity.requestDisplay.getAllRequest();

            DataGridViewButtonColumn delcol = new DataGridViewButtonColumn();
            delcol.Name = "Delete";
            delcol.Text = "Remove";
            delcol.UseColumnTextForButtonValue = true;
            InfoData.Columns.Add(delcol);

            checkList();
        }

        private void ManageInfo_Load(object sender, EventArgs e)
        {
            userData();
        }

        private void menuRequest_Click(object sender, EventArgs e)
        {
            request();
        }

        private void listEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            hideColumns();
        }

        private void InfoData_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (flag1 == true && flag2 == true)
                {
                    if (InfoData.Columns[e.ColumnIndex].Name == "Delete")
                    {
                        DialogResult result = MessageBox.Show("Do you want to delete?", "Confirm!", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            FoodN.DAO.DeleteDAO.delUserByID(Convert.ToInt32(InfoData.Rows[e.RowIndex].Cells[0].Value.ToString()),
                               Convert.ToInt32(InfoData.Rows[e.RowIndex].Cells[7].Value.ToString()));
                        }
                    }
                    else
                    {
                        DetailInfo detailInfo = new DetailInfo(((List<FoodN.Entity.User>)InfoData.DataSource)[e.RowIndex], 0);
                        detailInfo.ShowDialog();
                    }
                    userData();
                }
                if (flag1 == true && flag2 == false)
                {
                    if (InfoData.Columns[e.ColumnIndex].Name == "Delete")
                    {
                        DialogResult result = MessageBox.Show("Do you want to delete?", "Confirm!", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            FoodN.DAO.DeleteDAO.delFood(Convert.ToInt32(InfoData.Rows[e.RowIndex].Cells[0].Value.ToString()));
                        }
                    }
                    else
                    {
                        DetailNews detailNews = new DetailNews(((List<FoodN.Entity.Food>)InfoData.DataSource)[e.RowIndex], 0);
                        detailNews.ShowDialog();
                    }
                    foodData();
                }
                if (flag1 == false && flag2 == true)
                {
                    if (InfoData.Columns[e.ColumnIndex].Name == "Delete")
                    {
                        DialogResult result = MessageBox.Show("Do you want to delete?", "Confirm!", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            FoodN.DAO.DeleteDAO.delRequest(Convert.ToInt32(InfoData.Rows[e.RowIndex].Cells[0].Value.ToString()));
                        }
                    }
                    else
                    {
                        Request request = new Request(((List<FoodN.Entity.Request>)InfoData.DataSource)[e.RowIndex]);
                        request.ShowDialog();
                    }
                    request();
                }
            }
            catch
            {
                MessageBox.Show("Somebody touch my sapget!!");
            }
            
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSearch.Text))
            {
                if (flag1 == true && flag2 == true)
                {
                    InfoData.DataSource = FoodN.Entity.UserDisplay.getAllUserBySearch(tbSearch.Text);
                }
                if (flag1 == true && flag2 == false)
                {
                    InfoData.DataSource = FoodN.Entity.FoodDisplay.getAllFoodBySearch(tbSearch.Text);
                }
                if (flag1 == false && flag2 == true)
                {
                    InfoData.DataSource = FoodN.Entity.requestDisplay.getRequestBySearch(tbSearch.Text);
                }
            }
            else
            {
                if (flag1 == true && flag2 == true)
                {
                    InfoData.DataSource = FoodN.Entity.UserDisplay.getAllUser();
                }
                if (flag1 == true && flag2 == false)
                {
                    InfoData.DataSource = FoodN.Entity.FoodDisplay.getAllFood();
                }
                if (flag1 == false && flag2 == true)
                {
                    InfoData.DataSource = FoodN.Entity.requestDisplay.getAllRequest();
                }
            }

            
        }

    }
}
