using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace IU_Inventory_Management
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
            this.pictureEdit1.EditValue = global::IU_Inventory_Management.Properties.Resources.iu_logo__1_q;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                Database.getConnection();
                lblConnectionString.Text = "SERVER CONNECTION : SUCCESS";
                
            }
            catch (Exception)
            {
                lblConnectionString.Text = "SERVER CONNECTION : FAILED";
                Setting.frmConfigure frmConfigure = new Setting.frmConfigure();
                frmConfigure.ShowDialog();
                if (Setting.frmConfigure.status != true)
                {
                    this.Close();
                }

            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }

        }
        public void login()
        {
            string username = txtUsername.Text;
            string password = Utilities.Encrypt(txtPassword.Text);
            bool authentication = Database.authentication("SELECT * FROM tblInventoryUser WHERE userName='" + username + "' AND userPassword='" + password + "'");
            if (authentication)
            {
                this.Hide();
                MainPage _mainPage = new MainPage();
                _mainPage.Show();
            }
            else
            {
                MsgBox.msgLoad("search", "Please check your username and password again");
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                login();
            }
        }
    }
}