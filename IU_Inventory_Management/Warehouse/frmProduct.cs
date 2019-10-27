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
    public partial class frmProduct : DevExpress.XtraEditors.XtraForm
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            Utilities.bindCombo(Database.getData("SELECT * FROM tblInventoryGategory WHERE categoryStatus=1"), cboCategory, "categoryName", "idCategory", "[ Choose One]", false);
            loadGrid();
            gridButtonDelete();
            for (int i = 0; i < gdvProduct.Columns.Count - 1; i++)
            {
                gdvProduct.Columns[i].OptionsColumn.AllowEdit = false;
            }
            gdvProduct.Columns[0].Visible = false;
            gdvProduct.Columns[2].Visible = false;
        }
        public void loadGrid()
        {
            gdcProduct.DataSource = Database.getData(@"SELECT idProduct AS Id,productName AS Product,IVT_G.idCategory,categoryName AS Category,productDescription AS Description,'' AS [Delete] FROM tblInventoryProduct AS IVT_P
                                                            LEFT JOIN tblInventoryGategory AS IVT_G ON IVT_G.idCategory=IVT_P.idCategory WHERE productStatus=1");
        }
        RepositoryItemButtonEdit btnDelete = new RepositoryItemButtonEdit();
        public void gridButtonDelete()
        {
            btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnDelete.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btnDelete.ButtonClick += repositoryItemButtonDelete_ButtonClick;
            btnDelete.Buttons[0].Image = Image.FromFile(@"Image\Icon\Delete.png");

            gdvProduct.Columns["Delete"].ColumnEdit = btnDelete;
            gdvProduct.Columns["Delete"].Width = 16;
            gdcProduct.RepositoryItems.Add(btnDelete);
        }
        int _id;
        private void repositoryItemButtonDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            MsgBox.msgLoad("question", "You sure want to Delete ?");
            try
            {
                if (MsgBox._resultYes)
                {
                    _id = Convert.ToInt16(gdvProduct.GetRowCellDisplayText(gdvProduct.GetSelectedRows()[0], gdvProduct.Columns["Id"]));
                    Database.executeSql("UPDATE tblInventoryProduct SET productStatus=0 WHERE idProduct=" + _id + "");
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
                    if (cboCategory.SelectedIndex > 0)
                    {
                        Database.executeSql("INSERT INTO tblInventoryProduct VALUES(N'" + txtName.Text + "',N'" + rtbDescription.Text + "',1," + Convert.ToInt16(cboCategory.SelectedValue) + ")");
                        MsgBox.msgLoad("success", " Room was insert success");
                        MsgBox._resultYes = false;
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

        private void gdvProduct_Click(object sender, EventArgs e)
        {
            try
            {
                _id = Convert.ToInt16(gdvProduct.GetRowCellDisplayText(gdvProduct.GetSelectedRows()[0], gdvProduct.Columns["Id"]));
                txtName.Text = gdvProduct.GetRowCellDisplayText(gdvProduct.GetSelectedRows()[0], gdvProduct.Columns["Product"]);
                rtbDescription.Text = gdvProduct.GetRowCellDisplayText(gdvProduct.GetSelectedRows()[0], gdvProduct.Columns["Description"]);
                cboCategory.SelectedValue = gdvProduct.GetRowCellDisplayText(gdvProduct.GetSelectedRows()[0], gdvProduct.Columns["idCategory"]);
            }
            catch (Exception ex)
            {

                MsgBox.msgLoad("error", ex.Message);
            }
        }

        private void btnUpdateProduct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (_id == 0)
                {
                    MsgBox.msgLoad("search", "Please select on record data");
                    return;
                }
                if (cboCategory.SelectedIndex > 0)
                {
                    Database.executeSql("UPDATE tblInventoryProduct SET productName=N'" + txtName.Text + "',productDescription=N'" + rtbDescription.Text + "',idCategory=" + Convert.ToInt16(cboCategory.SelectedValue) + " WHERE idProduct=" + _id + "");
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
    }
}