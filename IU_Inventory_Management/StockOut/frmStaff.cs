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

namespace IU_Inventory_Management.StockOut
{
    public partial class frmStaff : DevExpress.XtraEditors.XtraForm
    {
        public frmStaff()
        {
            InitializeComponent();
        }

        private void frmStaff_Load(object sender, EventArgs e)
        {
            gdcStaff.DataSource = Database.getData("SELECT *,'' [StockOut] FROM tblStaff");
            gridButtonStockOut();
        }
        RepositoryItemButtonEdit btnStockOut = new RepositoryItemButtonEdit();
        public void gridButtonStockOut()
        {
            btnStockOut.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnStockOut.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btnStockOut.ButtonClick += repositoryItemButtonEdit_ButtonClick;
            btnStockOut.Buttons[0].Image = Image.FromFile(@"Image\Icon\Edit.png");

            gdvStaff.Columns["StockOut"].ColumnEdit = btnStockOut;
            gdvStaff.Columns["StockOut"].Width = 16;
            gdcStaff.RepositoryItems.Add(btnStockOut);
        }
        private void repositoryItemButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            editWarehouse();
        }
        public void editWarehouse()
        {

            try
            {
                frmStockOut _frmStockOut = new frmStockOut();
                _frmStockOut._idStaff = Convert.ToInt16(gdvStaff.GetRowCellDisplayText(gdvStaff.GetSelectedRows()[0], gdvStaff.Columns[0]));
                _frmStockOut.ShowDialog();
            }
            catch (Exception er)
            {

                MsgBox.msgLoad("error", er.Message);
            }

        }
        private void cmsStockOut_Click(object sender, EventArgs e)
        {
            addStockOut();
        }

        private void cmsDetailStockOut_Click(object sender, EventArgs e)
        {
            deatilStockOut();
        }

        private void btnAddStockOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            addStockOut();
        }

        private void btnDetailStockOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deatilStockOut();
        }
        public void addStockOut()
        {
            int _id = Convert.ToInt16(gdvStaff.GetRowCellDisplayText(gdvStaff.GetSelectedRows()[0], gdvStaff.Columns[0]));
            if (gdvStaff.RowCount <= 0 || _id == 0)
            {
                MsgBox.msgLoad("search", "Please select on your recorde");
                return;
            }
            frmAddStockOut _frmStockOut = new frmAddStockOut();
            _frmStockOut._idStaff = _id;
            _frmStockOut.ShowDialog();
        }
        public void deatilStockOut()
        {
            frmStockOut _frmStockOut = new frmStockOut();
            _frmStockOut._idStaff = Convert.ToInt16(gdvStaff.GetRowCellDisplayText(gdvStaff.GetSelectedRows()[0], gdvStaff.Columns[0]));
            _frmStockOut.ShowDialog();
        }
    }
}