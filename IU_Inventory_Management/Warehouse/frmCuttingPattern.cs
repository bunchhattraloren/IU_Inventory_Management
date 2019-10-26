using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

namespace IU_Inventory_Management.Warehouse
{
    public partial class frmCuttingPattern : DevExpress.XtraEditors.XtraForm
    {
        public frmCuttingPattern()
        {
            InitializeComponent();
        }
        public string _saveFor = "";
        private void frmLocation_Load(object sender, EventArgs e)
        {
            if (_saveFor == "Location")
            {
                gcName.Text = "Location";
                this.Text = "Location";
            }
            else if (_saveFor == "Room")
            {
                gcName.Text = "Room";
                this.Text = "Room";
                cboFloor.Enabled = true;
                cboFloorLoad();
            }
            else if (_saveFor=="Product")
            {
                gcName.Text = "Product";
                this.Text = "Product";
                cboCategory.Enabled = true;
                cboCategoryLoad();
            }
            loadGrid();
            gridButtonDelete();
            for (int i = 0; i < gdvLocation.Columns.Count - 1; i++)
            {
                gdvLocation.Columns[i].OptionsColumn.AllowEdit = false;
            }
            gdvLocation.Columns[0].Visible = false;

        }
        public void cboCategoryLoad()
        {
            Utilities.bindCombo(Database.getData("SELECT idCategory,categoryName FROM tblInventoryGategory WHERE categoryStatus=1"), cboCategory, "categoryName", "idCategory", "[ Choose one ]", true);
        }
        public void cboFloorLoad()
        {
            Utilities.bindCombo(Database.getData("SELECT * FROM tblInventoryFloor"), cboFloor, "floorNumber", "idFloor", "[ Choose one ]", false);
        }
        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectIndex = Convert.ToInt16(cboCategory.SelectedValue);
            if (selectIndex == -1)
            {
                frmPatternCategory _frmPatternCategory = new frmPatternCategory();
                _frmPatternCategory.ShowDialog();
                cboCategoryLoad();
            }
        }

        public void loadGrid()
        {
            if (_saveFor == "Location")
            {
                gdcLocation.DataSource = Database.getData("SELECT idLocation AS Id,locationName AS Location,locationDescription AS Description,'' AS [Delete] FROM tblInventoryLocation WHERE locationStatus=1");
            }
            else if (_saveFor == "Room")
            {
                gdcLocation.DataSource = Database.getData("SELECT idRoom AS Id,roomName AS Room,roomDescription AS Descriptions,'' AS [Delete] FROM tblInventoryRoom WHERE roomStatus=1");
            }
            else
            {
                gdcLocation.DataSource = Database.getData(@"SELECT idProduct AS Id,productName AS Product,productDescription AS Description,categoryName AS Category,'' AS [Delete] FROM tblInventoryProduct AS IVT_P
                                                            LEFT JOIN tblInventoryGategory AS IVT_G ON IVT_G.idCategory=IVT_P.idCategory WHERE productStatus=1");
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
                    if (_saveFor == "Location")
                    {
                        Database.executeSql("UPDATE tblInventoryLocation SET locationStatus=0 WHERE idLocation=" + _id + "");
                    }
                    else if (_saveFor == "Room")
                    {
                        Database.executeSql("UPDATE tblInventoryRoom SET roomStatus=0 WHERE idRoom=" + _id + "");
                    }
                    else
                    {

                        Database.executeSql("UPDATE tblInventoryProduct SET productStatus=0 WHERE idProduct=" + _id + "");
                    }

                    MsgBox.msgLoad("success", _saveFor + " was update success");
                    MsgBox._resultYes = false;
                    loadGrid();
                }
                
            }
            catch (Exception ex)
            {

                MsgBox.msgLoad("error", ex.Message);
            }
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    if (_saveFor == "Location")
                    {
                        Database.executeSql("INSERT INTO tblInventoryLocation VALUES(N'" + txtName.Text + "',N'" + rtbDescription.Text + "',1)");
                    }
                    else if (_saveFor == "Room")
                    {
                        if (cboFloor.SelectedIndex > 0)
                        {
                            Database.executeSql("INSERT INTO tblInventoryRoom VALUES('" + txtName.Text + "','" + rtbDescription.Text + "',1," + Convert.ToInt16(cboFloor.SelectedValue) + ")");
                        }
                        else
                        {
                            MsgBox.msgLoad("error", "Please select floor first");
                            return;
                        }

                    }
                    else
                    {

                        int idCategory = Convert.ToInt16(cboCategory.SelectedValue);
                        if (idCategory > 0)
                        {
                            Database.executeSql("INSERT INTO tblInventoryProduct VALUES('" + txtName.Text + "','" + rtbDescription.Text + "',1," + idCategory + ")");
                        }
                        else
                        {
                            MsgBox.msgLoad("search", "Please select category");
                            return;
                        }

                    }
                    MsgBox.msgLoad("success", _saveFor + " was insert success");
                    MsgBox._resultYes = true;
                    loadGrid();
                }else
                {
                    MsgBox.msgLoad("error", "Please input text field first");
                }
                
            }
            catch (Exception ex)
            {

                MsgBox.msgLoad("error", ex.Message);
            }
        }

        private void gdvLocation_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtName.Text = gdvLocation.GetRowCellDisplayText(gdvLocation.GetSelectedRows()[0], gdvLocation.Columns[""]);
                rtbDescription.Text = gdvLocation.GetRowCellDisplayText(gdvLocation.GetSelectedRows()[0], gdvLocation.Columns[""]);
            }
            catch (Exception ex)
            {
                MsgBox.msgLoad("error", ex.Message);
            }
        }
    }
}