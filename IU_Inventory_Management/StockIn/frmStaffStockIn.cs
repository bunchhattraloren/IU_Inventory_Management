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

namespace IU_Inventory_Management.StockIn
{
    public partial class frmStaffStockIn : DevExpress.XtraEditors.XtraForm
    {
        public frmStaffStockIn()
        {
            InitializeComponent();
        }

        private void frmStaffStockIn_Load(object sender, EventArgs e)
        {
            gdcStaff.DataSource = Database.getData("SELECT *,'' [StockOut] FROM tblStaff");
        }

        private void btnAddStockIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            addStockIn();
        }
        public void addStockIn()
        {
            int _id = Convert.ToInt16(gdvStaff.GetRowCellDisplayText(gdvStaff.GetSelectedRows()[0], gdvStaff.Columns[0]));
            if (gdvStaff.RowCount <= 0 || _id == 0)
            {
                MsgBox.msgLoad("search", "Please select on your recorde");
                return;
            }
            Warehouse.frmItem _frmStockIn = new Warehouse.frmItem();
            _frmStockIn._idStaff = _id;
            _frmStockIn.ShowDialog();
        }

        private void btnDetailStockIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deatilStockIn();
        }
        public void deatilStockIn()
        {
            Warehouse.frmStockIn _frmStocIn = new Warehouse.frmStockIn();
            _frmStocIn._idStaff = Convert.ToInt16(gdvStaff.GetRowCellDisplayText(gdvStaff.GetSelectedRows()[0], gdvStaff.Columns[0]));
            _frmStocIn.ShowDialog();
        }

        private void cmsDetailStockIn_Click(object sender, EventArgs e)
        {

        }

        private void cmsStockIn_Click(object sender, EventArgs e)
        {
            addStockIn();
        }
    }
}