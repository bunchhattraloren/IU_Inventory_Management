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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

namespace IU_Inventory_Management.Setting
{
    public partial class frmUser : DevExpress.XtraEditors.XtraForm
    {
        public frmUser()
        {
            InitializeComponent();
        }
        int _userID = 0;
        private void frmUser_Load(object sender, EventArgs e)
        {
            if (!Database._userAdmin)
            {
                _userID = Database._idUser;
                btnAddStaff.Enabled = false;
                contextMenuStrip1.Enabled = false;
            }
            loadGrid(_userID);
            gridButtonDelete();
            gridButtonEdit();
            for (int i = 0; i < gdvStaff.Columns.Count - 2; i++)
            {
                gdvStaff.Columns[i].OptionsColumn.AllowEdit = false;
            }
            gdvStaff.Columns[0].Visible = false;
        }
        public static bool reload;
        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addStaff();
        }

        public void loadGrid(int idUser)
        {
            string sql = string.Format(@"DECLARE @idUSER INT = {0}  SELECT idUser AS Id,
                                                    userName AS Username,
                                                    userPassword AS Password,
                                                    userType AS [User Type],
                                                    userPhoto AS Photo,
                                                    '' AS [Edit],
                                                    '' AS [Delete] FROM tblInventoryUser 
                                                    WHERE userStatus=1 AND (idUser=@idUser OR @idUser=0)", idUser);
            gdcStaff.DataSource = Database.getData(sql);
        }
        RepositoryItemButtonEdit btnDelete = new RepositoryItemButtonEdit();
        public void gridButtonDelete()
        {
            btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnDelete.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btnDelete.ButtonClick += repositoryItemButtonDelete_ButtonClick;
            btnDelete.Buttons[0].Image = Image.FromFile(@"Image\Icon\Delete.png");

            gdvStaff.Columns["Delete"].ColumnEdit = btnDelete;
            gdvStaff.Columns["Delete"].Width = 16;
            gdcStaff.RepositoryItems.Add(btnDelete);
        }
        int _id;
        private void repositoryItemButtonDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            MsgBox.msgLoad("question", "You sure want to Delete ?");
            try
            {
                if (MsgBox._resultYes)
                {
                    _id = Convert.ToInt16(gdvStaff.GetRowCellDisplayText(gdvStaff.GetSelectedRows()[0], gdvStaff.Columns["Id"]));
                    Database.executeSql("UPDATE tblInventoryUser SET userStatus=0,userDeactive=GETDATE() WHERE idUser=" + _id + "");
                    loadGrid(_userID);
                }
                MsgBox._resultYes = false;
            }
            catch (Exception ex)
            {

                MsgBox.msgLoad("error", ex.Message);
            }
        }

        RepositoryItemButtonEdit btnEdit = new RepositoryItemButtonEdit();
        public void gridButtonEdit()
        {
            btnEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnEdit.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btnEdit.ButtonClick += repositoryItemButtonEdit_ButtonClick;
            btnEdit.Buttons[0].Image = Image.FromFile(@"Image\Icon\Edit.png");

            gdvStaff.Columns["Edit"].ColumnEdit = btnEdit;
            gdvStaff.Columns["Edit"].Width = 16;
            gdcStaff.RepositoryItems.Add(btnEdit);
        }

        private void repositoryItemButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                frmCreateUser _frmCreateUser = new frmCreateUser("Update");
                _frmCreateUser._id = Convert.ToInt16(gdvStaff.GetRowCellDisplayText(gdvStaff.GetSelectedRows()[0], gdvStaff.Columns["Id"]));
                _frmCreateUser._username = gdvStaff.GetRowCellDisplayText(gdvStaff.GetSelectedRows()[0], gdvStaff.Columns["Username"]);
                _frmCreateUser._password = gdvStaff.GetRowCellDisplayText(gdvStaff.GetSelectedRows()[0], gdvStaff.Columns["Password"]);
                string userAdmin = gdvStaff.GetRowCellDisplayText(gdvStaff.GetSelectedRows()[0], gdvStaff.Columns["User Type"]);
                if (userAdmin != "Unchecked")
                {
                    _frmCreateUser._checkAdmin = true;
                }
                _frmCreateUser._photo = gdvStaff.GetRowCellDisplayText(gdvStaff.GetSelectedRows()[0], gdvStaff.Columns["Photo"]);
                _frmCreateUser.ShowDialog();
                if (MsgBox._resultYes)
                {
                    loadGrid(_userID);
                }
                MsgBox._resultYes = false;
            }
            catch (Exception er)
            {

                MsgBox.msgLoad("error", er.Message);
            }
        }

        private void btnAddStaff_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            addStaff();
        }
        public void addStaff()
        {
            reload = false;
            frmCreateUser frmCreateUser = new frmCreateUser("Save");
            frmCreateUser.ShowDialog();
            if (reload)
            {
                loadGrid(_userID);
            }

        }
    }
}