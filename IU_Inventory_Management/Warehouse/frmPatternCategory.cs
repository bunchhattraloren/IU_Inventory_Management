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
    public partial class frmPatternCategory : DevExpress.XtraEditors.XtraForm
    {
        public frmPatternCategory()
        {
            InitializeComponent();
        }
        private void frmCategory_Load(object sender, EventArgs e)
        {
            loadGrid();
        }
        public void loadGrid()
        {
            gcdCategory.DataSource = Database.getData("SELECT idCategory AS Id,categoryName AS Category,categoryDescription AS Descriptions,'' AS [Delete] FROM tblInventoryGategory WHERE categoryStatus=1");
            gridButtonDelete();
            for (int i = 0; i < gcvCategory.Columns.Count - 1; i++)
            {
                gcvCategory.Columns[i].OptionsColumn.AllowEdit = false;
            }
            gcvCategory.Columns[0].Visible = false;
        }
        RepositoryItemButtonEdit btnDelete = new RepositoryItemButtonEdit();
        public void gridButtonDelete()
        {
            btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnDelete.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btnDelete.ButtonClick += repositoryItemButtonDelete_ButtonClick;
            btnDelete.Buttons[0].Image = Image.FromFile(@"Image\Icon\Delete.png");

            gcvCategory.Columns["Delete"].ColumnEdit = btnDelete;
            gcvCategory.Columns["Delete"].Width = 16;
            gcdCategory.RepositoryItems.Add(btnDelete);
        }
        int _id;
        private void repositoryItemButtonDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            MsgBox.msgLoad("question", "You sure want to Delete ?");
            try
            {
                if (MsgBox._resultYes)
                {
                    _id = Convert.ToInt16(gcvCategory.GetRowCellDisplayText(gcvCategory.GetSelectedRows()[0], gcvCategory.Columns["Id"]));
                    Database.executeSql("UPDATE tblInventoryGategory SET categoryStatus=0 WHERE idCategory=" + _id + "");
                    loadGrid();
                }
                MsgBox._resultYes = false;
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
                    Database.executeSql("INSERT INTO tblInventoryGategory VALUES(N'" + txtName.Text + "',N'" + rtbDescription.Text + "',1)");
                    MsgBox.msgLoad("success", "Category was insert success");
                    loadGrid();
                }
                else
                {
                    MsgBox.msgLoad("error", "Please input text field first");
                }
            }
            catch (Exception ex)
            {
                MsgBox.msgLoad("success", ex.Message);
            }
            
        }

        
    }
}