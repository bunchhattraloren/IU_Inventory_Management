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

namespace IU_Inventory_Management.Setting
{
    public partial class frmCreateUser : DevExpress.XtraEditors.XtraForm
    {
        public frmCreateUser(string btnText)
        {
            InitializeComponent();
            btnUserSave.Text = btnText;
            if (btnText=="Update")
            {
                this.Text = "Update User";
            }
        }
        public int _id;
        public string _username, _password;
        public bool _checkAdmin;
        public string _photo = "user.jpeg";
        private void frmCreateUser_Load(object sender, EventArgs e)
        {
            txtUsername.Text = _username;
            if (!string.IsNullOrEmpty(_password))
            {
                _password = Utilities.Decrypt(_password);
                txtPassword.Text = _password;
            }
            txtConfirmPassword.Text = _password;
            chkAdmin.EditValue = _checkAdmin;
            pcbPhoto.Image = Image.FromFile(Application.StartupPath + @"\Image\Staff\" + _photo);
            
        }
        string photoname = "";

        private void btnUserSave_Click(object sender, EventArgs e)
        {
            //string password = "";
            //bool userAdmin = false;
            //string pathImage = "./Image/Staff/user.jpeg";
            string sql = "";
            string showMessage = "";
            try
            {
                _username = txtUsername.Text;
                _password = Utilities.Encrypt(txtPassword.Text);
                if (string.IsNullOrEmpty(_username))
                {
                    MsgBox.msgLoad("error", "Please input your name");
                    return;
                }
                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    MsgBox.msgLoad("error", "Please check your password and confirm password again");
                    return;
                }
                if (chkAdmin.Checked)
                {
                    _checkAdmin = true;
                }
                if (photoname != "")
                {
                    _photo = Utilities.saveImage(pcbPhoto, "./Image/Staff/", photoname, ".jpg");
                    _photo = System.IO.Path.GetFileName(_photo);
                }

                if (btnUserSave.Text == "Save")
                {
                    sql = "INSERT INTO tblInventoryUser VALUES('" + _username + "','" + _password + "','" + _photo + "','" + _checkAdmin + "',1,GETDATE(),NULL)";
                    showMessage = "Create user was success";
                    Utilities.clearControl(new Control[] { txtUsername, txtPassword, txtConfirmPassword });
                }
                else
                {
                    sql = "UPDATE tblInventoryUser SET userName='" + _username + "', userPassword='" + _password + "',userPhoto='" + _photo + "',userType='" + _checkAdmin + "' WHERE idUser=" + _id + "";
                    showMessage = "Update user was success";
                }


                Database.executeSql(sql);

                Setting.frmUser.reload = true;
                MsgBox.msgLoad("success", showMessage);
            }
            catch (Exception msg)
            {
                MsgBox.msgLoad("error", msg.Message);
            }
        }

        private void pcbPhoto_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "JPG|*.jpg|JPEG|*.jpeg|PNG|*.png";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string path = openFile.FileName;
                pcbPhoto.Image = Image.FromFile(path);
                photoname = System.IO.Path.GetFileNameWithoutExtension(path);
            }
        }

       
    }
}