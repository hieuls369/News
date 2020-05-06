namespace FoodN
{
    partial class DetailNews
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
            this.lbID = new System.Windows.Forms.Label();
            this.tbShort = new System.Windows.Forms.TextBox();
            this.tbLong = new System.Windows.Forms.TextBox();
            this.pnFoodPicture = new System.Windows.Forms.Panel();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.lbDate = new System.Windows.Forms.Label();
            this.lbAuthor = new System.Windows.Forms.Label();
            this.btnUpdateFood = new System.Windows.Forms.Button();
            this.btnAddImgFood = new System.Windows.Forms.Button();
            this.btnRefreshFood = new System.Windows.Forms.Button();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(13, 9);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(0, 17);
            this.lbID.TabIndex = 1;
            // 
            // tbShort
            // 
            this.tbShort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbShort.Location = new System.Drawing.Point(12, 130);
            this.tbShort.Multiline = true;
            this.tbShort.Name = "tbShort";
            this.tbShort.Size = new System.Drawing.Size(441, 190);
            this.tbShort.TabIndex = 2;
            // 
            // tbLong
            // 
            this.tbLong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLong.Location = new System.Drawing.Point(12, 326);
            this.tbLong.Multiline = true;
            this.tbLong.Name = "tbLong";
            this.tbLong.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLong.Size = new System.Drawing.Size(674, 288);
            this.tbLong.TabIndex = 3;
            // 
            // pnFoodPicture
            // 
            this.pnFoodPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnFoodPicture.Location = new System.Drawing.Point(460, 130);
            this.pnFoodPicture.Name = "pnFoodPicture";
            this.pnFoodPicture.Size = new System.Drawing.Size(226, 190);
            this.pnFoodPicture.TabIndex = 4;
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(12, 99);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(221, 24);
            this.cbType.TabIndex = 5;
            // 
            // cbCountry
            // 
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(239, 100);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(214, 24);
            this.cbCountry.TabIndex = 6;
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDate.Location = new System.Drawing.Point(457, 106);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(0, 18);
            this.lbDate.TabIndex = 8;
            // 
            // lbAuthor
            // 
            this.lbAuthor.AutoSize = true;
            this.lbAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAuthor.Location = new System.Drawing.Point(13, 78);
            this.lbAuthor.Name = "lbAuthor";
            this.lbAuthor.Size = new System.Drawing.Size(0, 18);
            this.lbAuthor.TabIndex = 9;
            // 
            // btnUpdateFood
            // 
            this.btnUpdateFood.Location = new System.Drawing.Point(239, 60);
            this.btnUpdateFood.Name = "btnUpdateFood";
            this.btnUpdateFood.Size = new System.Drawing.Size(98, 23);
            this.btnUpdateFood.TabIndex = 11;
            this.btnUpdateFood.Text = "Update";
            this.btnUpdateFood.UseVisualStyleBackColor = true;
            this.btnUpdateFood.Visible = false;
            this.btnUpdateFood.Click += new System.EventHandler(this.btnUpdateFood_Click);
            // 
            // btnAddImgFood
            // 
            this.btnAddImgFood.Location = new System.Drawing.Point(355, 60);
            this.btnAddImgFood.Name = "btnAddImgFood";
            this.btnAddImgFood.Size = new System.Drawing.Size(98, 23);
            this.btnAddImgFood.TabIndex = 12;
            this.btnAddImgFood.Text = "Add Image";
            this.btnAddImgFood.UseVisualStyleBackColor = true;
            this.btnAddImgFood.Visible = false;
            this.btnAddImgFood.Click += new System.EventHandler(this.btnAddImgFood_Click);
            // 
            // btnRefreshFood
            // 
            this.btnRefreshFood.Location = new System.Drawing.Point(473, 60);
            this.btnRefreshFood.Name = "btnRefreshFood";
            this.btnRefreshFood.Size = new System.Drawing.Size(97, 23);
            this.btnRefreshFood.TabIndex = 13;
            this.btnRefreshFood.Text = "Refresh";
            this.btnRefreshFood.UseVisualStyleBackColor = true;
            this.btnRefreshFood.Visible = false;
            this.btnRefreshFood.Click += new System.EventHandler(this.btnRefreshFood_Click);
            // 
            // btnAddFood
            // 
            this.btnAddFood.Location = new System.Drawing.Point(588, 60);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(98, 23);
            this.btnAddFood.TabIndex = 14;
            this.btnAddFood.Text = "Add";
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Visible = false;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // tbTitle
            // 
            this.tbTitle.Font = new System.Drawing.Font("Segoe Print", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTitle.Location = new System.Drawing.Point(239, 12);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.ReadOnly = true;
            this.tbTitle.Size = new System.Drawing.Size(447, 38);
            this.tbTitle.TabIndex = 15;
            // 
            // DetailNews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 628);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.btnAddFood);
            this.Controls.Add(this.btnRefreshFood);
            this.Controls.Add(this.btnAddImgFood);
            this.Controls.Add(this.btnUpdateFood);
            this.Controls.Add(this.cbCountry);
            this.Controls.Add(this.lbAuthor);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.pnFoodPicture);
            this.Controls.Add(this.tbLong);
            this.Controls.Add(this.tbShort);
            this.Controls.Add(this.lbID);
            this.Name = "DetailNews";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DetailNews";
            this.Load += new System.EventHandler(this.DetailNews_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.TextBox tbShort;
        private System.Windows.Forms.TextBox tbLong;
        private System.Windows.Forms.Panel pnFoodPicture;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Label lbAuthor;
        private System.Windows.Forms.Button btnUpdateFood;
        private System.Windows.Forms.Button btnAddImgFood;
        private System.Windows.Forms.Button btnRefreshFood;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.TextBox tbTitle;
    }
}