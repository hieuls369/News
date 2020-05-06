using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodNew_Web
{
    public partial class Profile : System.Web.UI.Page
    {
        private int total;

        private int maxPage;

        private int pageSize = 3;

        private int index = 1;
        public string img
        {
            get
            {
                object o = ViewState["img"];
                return (o == null) ? string.Empty : (string)o;
            }

            set
            {
                ViewState["img"] = value;
            }
        }

        FoodN.Entity.User user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                loadData();
                loadNews();
            }
        }

        public void loadData()
        {
            user = FoodN.Entity.UserDisplay.getUserByAccountID(Convert.ToInt32(Session["accID"].ToString()));
            if(user != null)
            {
                tbUsername.Text = user.userName;
                tbEmail.Text = user.email;
                tbAddress.Text = user.address;
                tbPhone.Text = user.phone.ToString();
                tbDate.Text = user.date.ToString("dd/MM/yyyy");
                Image1.ImageUrl = "~/Image/user/" + user.imgLink;
                img = user.imgLink;
            }

            
        }

        public void loadNews()
        {
            total = Convert.ToInt32(FoodN.DAO.FoodNews.getCountNewsWeb(Convert.ToInt32(Session["accID"].ToString())).Rows[0][0].ToString());

            maxPage = total / pageSize;

            if (total % pageSize != 0)
            {
                maxPage++;
            }

            int start = (index * pageSize) - (pageSize - 1);
            int end = index * pageSize;

            lblpage.Text = "Page " + (index) + " of " + maxPage;

            RepeaterNews.DataSource = FoodN.DAO.FoodNews.getNewsByAccID(Convert.ToInt32(Session["accID"].ToString()), start, end);
            RepeaterNews.DataBind();
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
            loadNews();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string folderPath = Server.MapPath("~/Files/");

            //Check whether Directory (Folder) exists.
            if (!Directory.Exists(folderPath))
            {
                //If Directory (Folder) does not exists Create it.
                Directory.CreateDirectory(folderPath);
            }

            //Save the File to the Directory (Folder).
            FileUpload1.SaveAs(folderPath + Path.GetFileName(FileUpload1.FileName));

            img = Path.GetFileName(FileUpload1.FileName);

            //Display the Picture in Image control.
            Image1.ImageUrl = "~/Files/" + img;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (!string.IsNullOrEmpty(tbUsername.Text) && !string.IsNullOrEmpty(tbEmail.Text) && !string.IsNullOrEmpty(tbAddress.Text)
                   && !string.IsNullOrEmpty(tbPhone.Text)  && !string.IsNullOrEmpty(tbDate.Text))
                {
                    FoodN.DAO.UpdateDAO.updateInformationWeb(tbUsername.Text, tbEmail.Text, tbAddress.Text, Convert.ToInt32(tbPhone.Text), 
                        Convert.ToDateTime(tbDate.Text), Convert.ToInt32(Session["accID"].ToString()), img);
                    lbError.Text = "Success! Your profile has been updated!";
                    loadData();
                }
                else
                {
                    lbError.Text = "Please fill all the information";
                }
                
            }
            catch 
            {
                lbError.Text = "Something wrong!";
            }

        }

        protected void btnRe_Click(object sender, EventArgs e)
        {
            Response.Redirect("Request.aspx");
        }
    }
}