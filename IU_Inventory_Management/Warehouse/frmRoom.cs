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
    public partial class frmRoom : DevExpress.XtraEditors.XtraForm
    {
        public frmRoom()
        {
            InitializeComponent();
        }

        private void frmRoom_Load(object sender, EventArgs e)
        {
            Utilities.bindCombo(Database.getData("SELECT * FROM tblInventoryFloor"), cboFloor, "floorNumber", "idFloor", "[ Choose One]", false);
            loadGrid();
            gridButtonDelete();
            for (int i = 0; i < gdvRoom.Columns.Count - 1; i++)
            {
                gdvRoom.Columns[i].OptionsColumn.AllowEdit = false;
            }
            gdvRoom.Columns[0].Visible = false;
            gdvRoom.Columns[2].Visible = false;
        }
        public void loadGrid()
        {
            gdcRoom.DataSource = Database.getData(@"SELECT idRoom AS Id,roomName AS Room,IVT_F.idFloor,floorNumber AS [Floor],roomDescription AS Description,'' AS [Delete] FROM tblInventoryRoom AS IVT_R
                                                    LEFT JOIN tblInventoryFloor AS IVT_F ON IVT_F.idFloor=IVT_R.idFloor
                                                    WHERE roomStatus=1");
        }
        RepositoryItemButtonEdit btnDelete = new RepositoryItemButtonEdit();
        public void gridButtonDelete()
        {
            btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnDelete.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btnDelete.ButtonClick += repositoryItemButtonDelete_ButtonClick;
            btnDelete.Buttons[0].Image = Image.FromFile(@"Image\Icon\Delete.png");

            gdvRoom.Columns["Delete"].ColumnEdit = btnDelete;
            gdvRoom.Columns["Delete"].Width = 16;
            gdcRoom.RepositoryItems.Add(btnDelete);
        }
        int _id;
        private void repositoryItemButtonDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            MsgBox.msgLoad("question", "You sure want to Delete ?");
            try
            {
                if (MsgBox._resultYes)
                {
                    _id = Convert.ToInt16(gdvRoom.GetRowCellDisplayText(gdvRoom.GetSelectedRows()[0], gdvRoom.Columns["Id"]));
                    Database.executeSql("UPDATE tblInventoryRoom SET roomStatus=0 WHERE idRoom=" + _id + "");
                    MsgBox.msgLoad("success", "Room was delete success");
                    MsgBox._resultYes = false;
                    loadGrid();
                }

            }
            catch (Exception ex)
            {

                MsgBox.msgLoad("error", ex.Message);
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    if (cboFloor.SelectedIndex > 0)
                    {
                        Database.executeSql("INSERT INTO tblInventoryRoom VALUES(N'" + txtName.Text + "',N'" + rtbDescription.Text + "',1," + Convert.ToInt16(cboFloor.SelectedValue) + ")");
                        MsgBox.msgLoad("success", " Room was insert success");
                        loadGrid();
                    }
                    else
                    {
                        MsgBox.msgLoad("error", "Please select floor first");
                        return;
                    }
                   
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

        private void btnUpdateRoom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (_id == 0)
                {
                    MsgBox.msgLoad("search", "Please select on record data");
                    return;
                }
                if (cboFloor.SelectedIndex > 0)
                {
                    Database.executeSql("UPDATE tblInventoryRoom SET roomName=N'" + txtName.Text + "',roomDescription=N'" + rtbDescription.Text + "',idFloor=" + Convert.ToInt16(cboFloor.SelectedValue) + " WHERE idRoom=" + _id + "");
                    MsgBox.msgLoad("success", "Room was update success");
                    MsgBox._resultYes = false;
                    loadGrid();
                }
                else
                {
                    MsgBox.msgLoad("error", "Please select floor first");
                    return;
                }
               
            }
            catch (Exception ex)
            {

                MsgBox.msgLoad("error", ex.Message);
            }
        }

        private void gdvRoom_Click(object sender, EventArgs e)
        {
            try
            {
                _id = Convert.ToInt16(gdvRoom.GetRowCellDisplayText(gdvRoom.GetSelectedRows()[0], gdvRoom.Columns["Id"]));
                txtName.Text = gdvRoom.GetRowCellDisplayText(gdvRoom.GetSelectedRows()[0], gdvRoom.Columns["Room"]);
                rtbDescription.Text = gdvRoom.GetRowCellDisplayText(gdvRoom.GetSelectedRows()[0], gdvRoom.Columns["Description"]);
                cboFloor.SelectedValue = gdvRoom.GetRowCellDisplayText(gdvRoom.GetSelectedRows()[0], gdvRoom.Columns["idFloor"]);
            }
            catch (Exception ex)
            {

                MsgBox.msgLoad("error", ex.Message);
            }
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}