namespace FoodN
{
    partial class ManageInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRequest = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.InfoData = new System.Windows.Forms.DataGridView();
            this.tbTitle = new System.Windows.Forms.Label();
            this.listEntity = new System.Windows.Forms.CheckedListBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InfoData)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLogout,
            this.manageToolStripMenuItem,
            this.menuRequest});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1031, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuLogout
            // 
            this.menuLogout.Name = "menuLogout";
            this.menuLogout.Size = new System.Drawing.Size(70, 24);
            this.menuLogout.Text = "Logout";
            this.menuLogout.Click += new System.EventHandler(this.menuLogout_Click);
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUser,
            this.menuProduct});
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.manageToolStripMenuItem.Text = "Manage";
            // 
            // menuUser
            // 
            this.menuUser.Name = "menuUser";
            this.menuUser.Size = new System.Drawing.Size(143, 26);
            this.menuUser.Text = "User";
            this.menuUser.Click += new System.EventHandler(this.menuUser_Click);
            // 
            // menuProduct
            // 
            this.menuProduct.Name = "menuProduct";
            this.menuProduct.Size = new System.Drawing.Size(143, 26);
            this.menuProduct.Text = "Product";
            this.menuProduct.Click += new System.EventHandler(this.menuProduct_Click);
            // 
            // menuRequest
            // 
            this.menuRequest.Name = "menuRequest";
            this.menuRequest.Size = new System.Drawing.Size(76, 24);
            this.menuRequest.Text = "Request";
            this.menuRequest.Click += new System.EventHandler(this.menuRequest_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(737, 37);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(282, 22);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // InfoData
            // 
            this.InfoData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InfoData.Location = new System.Drawing.Point(139, 68);
            this.InfoData.Name = "InfoData";
            this.InfoData.ReadOnly = true;
            this.InfoData.RowHeadersWidth = 51;
            this.InfoData.RowTemplate.Height = 24;
            this.InfoData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.InfoData.Size = new System.Drawing.Size(879, 373);
            this.InfoData.TabIndex = 2;
            this.InfoData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InfoData_CellClick);
            // 
            // tbTitle
            // 
            this.tbTitle.AutoSize = true;
            this.tbTitle.Location = new System.Drawing.Point(12, 40);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(0, 17);
            this.tbTitle.TabIndex = 3;
            // 
            // listEntity
            // 
            this.listEntity.CheckOnClick = true;
            this.listEntity.FormattingEnabled = true;
            this.listEntity.Location = new System.Drawing.Point(12, 68);
            this.listEntity.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.listEntity.Name = "listEntity";
            this.listEntity.Size = new System.Drawing.Size(120, 174);
            this.listEntity.TabIndex = 4;
            this.listEntity.SelectedIndexChanged += new System.EventHandler(this.listEntity_SelectedIndexChanged);
            // 
            // ManageInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 456);
            this.Controls.Add(this.listEntity);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.InfoData);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ManageInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageInfo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManageInfo_FormClosed);
            this.Load += new System.EventHandler(this.ManageInfo_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InfoData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuLogout;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuUser;
        private System.Windows.Forms.ToolStripMenuItem menuProduct;
        private System.Windows.Forms.ToolStripMenuItem menuRequest;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.DataGridView InfoData;
        private System.Windows.Forms.Label tbTitle;
        private System.Windows.Forms.CheckedListBox listEntity;
    }
}