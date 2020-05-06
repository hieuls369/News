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
    public partial class Request : Form
    {
        Entity.Request selectedRequest;
        public Request()
        {
            InitializeComponent();
        }
        public Request(Entity.Request request)
        {
            selectedRequest = request;
            InitializeComponent();
        }
        private void Request_Load(object sender, EventArgs e)
        {
            if(selectedRequest != null)
            {
                lbUserName.Text = selectedRequest.accountName;
                lbTitle.Text = selectedRequest.title;
                tbContent.Text = selectedRequest.description;
                this.Text = selectedRequest.requestID.ToString();
            }
        }
    }
}
