namespace IU_Inventory_Management.Setting
{
    partial class frmCreateUser
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.xtrTabUsername = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.xtrTabUserSecurity = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.xtrTabUserType = new DevExpress.XtraTab.XtraTabPage();
            this.chkAdmin = new DevExpress.XtraEditors.CheckEdit();
            this.xtrUserPhoto = new DevExpress.XtraTab.XtraTabPage();
            this.pcbPhoto = new DevExpress.XtraEditors.PictureEdit();
            this.btnUserSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtrTabUsername)).BeginInit();
            this.xtrTabUsername.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.xtrTabUserSecurity.SuspendLayout();
            this.xtrTabUserType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAdmin.Properties)).BeginInit();
            this.xtrUserPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPhoto.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.xtrTabUsername);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnUserSave);
            this.splitContainer1.Size = new System.Drawing.Size(490, 230);
            this.splitContainer1.SplitterDistance = 177;
            this.splitContainer1.TabIndex = 1;
            // 
            // xtrTabUsername
            // 
            this.xtrTabUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtrTabUsername.Location = new System.Drawing.Point(0, 0);
            this.xtrTabUsername.Name = "xtrTabUsername";
            this.xtrTabUsername.SelectedTabPage = this.xtraTabPage1;
            this.xtrTabUsername.Size = new System.Drawing.Size(490, 177);
            this.xtrTabUsername.TabIndex = 1;
            this.xtrTabUsername.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtrTabUserSecurity,
            this.xtrTabUserType,
            this.xtrUserPhoto});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Controls.Add(this.txtUsername);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(484, 149);
            this.xtraTabPage1.Text = "Username";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(71, 19);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtUsername.Location = new System.Drawing.Point(11, 53);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(466, 27);
            this.txtUsername.TabIndex = 0;
            // 
            // xtrTabUserSecurity
            // 
            this.xtrTabUserSecurity.Controls.Add(this.labelControl3);
            this.xtrTabUserSecurity.Controls.Add(this.txtConfirmPassword);
            this.xtrTabUserSecurity.Controls.Add(this.labelControl2);
            this.xtrTabUserSecurity.Controls.Add(this.txtPassword);
            this.xtrTabUserSecurity.Name = "xtrTabUserSecurity";
            this.xtrTabUserSecurity.Size = new System.Drawing.Size(484, 149);
            this.xtrTabUserSecurity.Text = "Security";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(11, 81);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(129, 19);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtConfirmPassword.Location = new System.Drawing.Point(10, 109);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(466, 27);
            this.txtConfirmPassword.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(11, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(67, 19);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtPassword.Location = new System.Drawing.Point(10, 38);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(466, 27);
            this.txtPassword.TabIndex = 2;
            // 
            // xtrTabUserType
            // 
            this.xtrTabUserType.Controls.Add(this.chkAdmin);
            this.xtrTabUserType.Name = "xtrTabUserType";
            this.xtrTabUserType.Size = new System.Drawing.Size(484, 149);
            this.xtrTabUserType.Text = "User Type";
            // 
            // chkAdmin
            // 
            this.chkAdmin.Location = new System.Drawing.Point(12, 15);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Properties.Caption = "Admin";
            this.chkAdmin.Size = new System.Drawing.Size(75, 19);
            this.chkAdmin.TabIndex = 0;
            // 
            // xtrUserPhoto
            // 
            this.xtrUserPhoto.Controls.Add(this.pcbPhoto);
            this.xtrUserPhoto.Name = "xtrUserPhoto";
            this.xtrUserPhoto.Size = new System.Drawing.Size(484, 149);
            this.xtrUserPhoto.Text = "Photo";
            // 
            // pcbPhoto
            // 
            this.pcbPhoto.Cursor = System.Windows.Forms.Cursors.Default;
            this.pcbPhoto.Location = new System.Drawing.Point(156, 11);
            this.pcbPhoto.Name = "pcbPhoto";
            this.pcbPhoto.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pcbPhoto.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pcbPhoto.Properties.ZoomAccelerationFactor = 1D;
            this.pcbPhoto.Size = new System.Drawing.Size(180, 132);
            this.pcbPhoto.TabIndex = 0;
            this.pcbPhoto.DoubleClick += new System.EventHandler(this.pcbPhoto_DoubleClick);
            // 
            // btnUserSave
            // 
            this.btnUserSave.BackColor = System.Drawing.Color.White;
            this.btnUserSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnUserSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserSave.Location = new System.Drawing.Point(204, 15);
            this.btnUserSave.Name = "btnUserSave";
            this.btnUserSave.Size = new System.Drawing.Size(75, 23);
            this.btnUserSave.TabIndex = 0;
            this.btnUserSave.Text = "Save";
            this.btnUserSave.UseVisualStyleBackColor = false;
            this.btnUserSave.Click += new System.EventHandler(this.btnUserSave_Click);
            // 
            // frmCreateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 230);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCreateUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create User";
            this.Load += new System.EventHandler(this.frmCreateUser_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtrTabUsername)).EndInit();
            this.xtrTabUsername.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            this.xtrTabUserSecurity.ResumeLayout(false);
            this.xtrTabUserSecurity.PerformLayout();
            this.xtrTabUserType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkAdmin.Properties)).EndInit();
            this.xtrUserPhoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbPhoto.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraTab.XtraTabControl xtrTabUsername;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox txtUsername;
        private DevExpress.XtraTab.XtraTabPage xtrTabUserSecurity;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.TextBox txtPassword;
        private DevExpress.XtraTab.XtraTabPage xtrTabUserType;
        private DevExpress.XtraEditors.CheckEdit chkAdmin;
        private DevExpress.XtraTab.XtraTabPage xtrUserPhoto;
        private DevExpress.XtraEditors.PictureEdit pcbPhoto;
        private System.Windows.Forms.Button btnUserSave;
    }
}