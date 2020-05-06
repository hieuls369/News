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
    public partial class DetailNews : Form
    {
        private int check = 0;
        private string imgName = "";
        FoodN.Entity.Food selectedFood;
        FoodN.Entity.Account selectedAccount;
        public DetailNews()
        {
            InitializeComponent();
        }

        public DetailNews(FoodN.Entity.Account acc, int c)
        {
            check = c;
            selectedAccount = acc;
            InitializeComponent();
        }

        public DetailNews(FoodN.Entity.Food food, int c)
        {
            check = c;
            selectedFood = food;
            InitializeComponent();
        }

        public DetailNews(FoodN.Entity.Food food, FoodN.Entity.Account acc, int c)
        {
            check = c;
            selectedAccount = acc;
            selectedFood = food;
            InitializeComponent();
        }

        private void DetailNews_Load(object sender, EventArgs e)
        {
            loadData();
        }


        public void loadData()
        {
            cbType.DisplayMember = "typeName";
            cbType.ValueMember = "typeID";
            cbType.DataSource = Entity.TypeDisplay.getAllType();

            cbCountry.DisplayMember = "countryName";
            cbCountry.ValueMember = "countryID";
            cbCountry.DataSource = Entity.CountryDisplay.getAllCountry();


            if (check == 1)
            {
                btnRefreshFood.Visible = true;
                btnAddImgFood.Visible = true;
                tbTitle.ReadOnly = false;
                if (selectedFood == null)
                {
                    btnAddFood.Visible = true;
                    
                }
                else
                {
                    btnUpdateFood.Visible = true;
                }
            }
            else
            {
                tbTitle.ReadOnly = true;
            }


            if (selectedFood != null)
            {
                lbID.Text = "FooID: " + selectedFood.foodID.ToString();

                lbAuthor.Text = "Publisher: "+ selectedFood.accountName;
                tbShort.Text = selectedFood.shortDes;
                tbLong.Text = selectedFood.longDes;

                tbTitle.Text = selectedFood.title;

                lbDate.Text = "Publish: " + selectedFood.datePub.ToString("MM/dd/yyyy");

                cbType.SelectedIndex = cbType.FindStringExact(selectedFood.typeName);
                cbCountry.SelectedIndex = cbCountry.FindStringExact(selectedFood.countryName);

                imgName = selectedFood.imgLink;
                pnFoodPicture.BackgroundImage = Image.FromFile("F:\\Chuyên Ngành 5\\PRN201\\Project\\FoodN\\img\\food\\" + selectedFood.imgLink);
                pnFoodPicture.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                lbAuthor.Text = "Publisher: " + selectedAccount.accountName;
            }
        }
       

        private void btnAddImgFood_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.ShowDialog();
                op.InitialDirectory = @"F:\Chuyên Ngành 5\PRN201\Project\FoodN\img\food\";

                string[] a = op.FileName.Split('\\');
                imgName = a[a.Length - 1];

                pnFoodPicture.BackgroundImage = Image.FromFile(@"F:\Chuyên Ngành 5\PRN201\Project\FoodN\img\food\" + imgName);
                pnFoodPicture.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch
            {
                MessageBox.Show("Not Found!");
            }
        }

        private void btnRefreshFood_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnUpdateFood_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbTitle.Text) && !string.IsNullOrEmpty(tbShort.Text) &&
                !string.IsNullOrEmpty(tbLong.Text) && !string.IsNullOrEmpty(imgName))
            {
                DAO.UpdateDAO.updateFoodNews(tbTitle.Text, tbShort.Text, tbLong.Text, DateTime.Now,
                    Convert.ToInt32(cbType.SelectedValue), Convert.ToInt32(cbCountry.SelectedValue), imgName, selectedAccount.accountID, selectedFood.foodID);
                this.Close();
                MessageBox.Show("Success! Your news has been updated!");
            }
            else
            {
                MessageBox.Show("Please fill all the information");
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(tbTitle.Text) && !string.IsNullOrEmpty(tbShort.Text) &&
                !string.IsNullOrEmpty(tbLong.Text) && !string.IsNullOrEmpty(imgName))
            {
                DAO.AddDAO.addFoodNew(tbTitle.Text, tbShort.Text, tbLong.Text, DateTime.Now, 
                    Convert.ToInt32(cbType.SelectedValue), Convert.ToInt32(cbCountry.SelectedValue), imgName, selectedAccount.accountID);
                this.Close();
                MessageBox.Show("Success! Your news has been added!");
            }
            else
            {
                MessageBox.Show("Please fill all the information");
            }

        }
    }
}
