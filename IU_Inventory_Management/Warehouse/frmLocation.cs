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

namespace IU_Inventory_Management.Warehouse
{
    public partial class frmLocation : DevExpress.XtraEditors.XtraForm
    {
        public frmLocation()
        {
            InitializeComponent();
        }

        private void frmLocation_Load(object sender, EventArgs e)
        {
            loadGrid();
            gridButtonDelete();
            for (int i = 0; i < gdvLocation.Columns.Count - 1; i++)
            {
                gdvLocation.Columns[i].OptionsColumn.AllowEdit = false;
            }
            gdvLocation.Columns[0].Visible = false;
        }
        public void loadGrid()
        {
                gdcLocation.DataSource = Database.getData("SELECT idLocation AS Id,locationName AS Location,locationDescription AS Description,'' AS [Delete] FROM tblInventoryLocation WHERE locationStatus=1");
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    Database.executeSql("INSERT INTO tblInventoryLocation VALUES(N'" + txtName.Text + "',N'" + rtbDescription.Text + "',1)");
                    MsgBox.msgLoad("success", " Product was insert success");
                    loadGrid();
                }
                else
                {
                    MsgBox.msgLoad("error", "Please input text field first");
                }

            }
            catch (Exception ex)
            {

                MsgBox.msgLoad("error", ex.Message);
            }
        }

        RepositoryItemButtonEdit btnDelete = new RepositoryItemButtonEdit();
        public void gridButtonDelete()
        {
            btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnDelete.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btnDelete.ButtonClick += repositoryItemButtonDelete_ButtonClick;
            btnDelete.Buttons[0].Image = Image.FromFile(@"Image\Icon\Delete.png");

            gdvLocation.Columns["Delete"].ColumnEdit = btnDelete;
            gdvLocation.Columns["Delete"].Width = 16;
            gdcLocation.RepositoryItems.Add(btnDelete);
        }
        int _id;
        private void repositoryItemButtonDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            MsgBox.msgLoad("question", "You sure want to Delete ?");
            try
            {
                if (MsgBox._resultYes)
                {
                    _id = Convert.ToInt16(gdvLocation.GetRowCellDisplayText(gdvLocation.GetSelectedRows()[0], gdvLocation.Columns["Id"]));
                    Database.executeSql("UPDATE tblInventoryLocation SET locationStatus=0 WHERE idLocation=" + _id + "");
                    MsgBox.msgLoad("success", "Product was delete success");
                    MsgBox._resultYes = false;
                    loadGrid();
                }
               
            }
            catch (Exception ex)
            {

                MsgBox.msgLoad("error", ex.Message);
            }
        }

        private void btnLocationUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (_id == 0)
                {
                    MsgBox.msgLoad("search", "Please select on record data");
                    return;
                }
                Database.executeSql("UPDATE tblInventoryLocation SET locationName=N'" + txtName.Text + "',locationDescription=N'"+rtbDescription.Text+"' WHERE idLocation=" + _id + ""); ;
                MsgBox.msgLoad("success", "Product was update success");
                MsgBox._resultYes = false;
                loadGrid();
            }
            catch (Exception ex)
            {

                MsgBox.msgLoad("error", ex.Message);
            }
        }

        private void gdvLocation_Click(object sender, EventArgs e)
        {
            try
            {
                _id = Convert.ToInt16(gdvLocation.GetRowCellDisplayText(gdvLocation.GetSelectedRows()[0], gdvLocation.Columns["Id"]));
                txtName.Text = gdvLocation.GetRowCellDisplayText(gdvLocation.GetSelectedRows()[0], gdvLocation.Columns["Location"]);
                rtbDescription.Text = gdvLocation.GetRowCellDisplayText(gdvLocation.GetSelectedRows()[0], gdvLocation.Columns["Description"]);
            }
            catch (Exception ex)
            {

                MsgBox.msgLoad("error", ex.Message);
            }
        }
    }
}