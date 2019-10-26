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
    public partial class frmWarehouse : DevExpress.XtraEditors.XtraForm
    {
        public frmWarehouse()
        {
            InitializeComponent();
        }

        private void AddNew_Click(object sender, EventArgs e)
        {
            addNewWarehouse();
        }
        public static bool _reload;
        private void frmWarehouse_Load(object sender, EventArgs e)
        {
            loadGrid();
            gdvWarehouse.OptionsBehavior.Editable = false;
        }
        public void loadGrid()
        {
            
            gdcWarehouse.DataSource = Database.getData(@"SELECT
                DISTINCT(itemNameEng) AS ItemEn,
                itemNameKh AS ItemKh,
                itemCode AS Code,
                itemSerialNumber AS Serial,
                locationName AS Location,
                IVT_F.floorNumber AS Floor,
                roomName AS Room,
                categoryName AS Category,
                itemBrand AS Brand,
                productName AS Product,
                Qty AS Quantity
                FROM tblInventoryItem AS IVT_I
                LEFT JOIN tblInventoryWarehouse AS IVT_W ON IVT_W.idItem=IVT_I.idItem
                LEFT JOIN tblInventoryLocation AS IVT_L ON IVT_L.idLocation=IVT_I.idLocation
                LEFT JOIN tblInventoryRoom AS IVT_R ON IVT_R.idRoom=IVT_I.idRoom
                LEFT JOIN tblInventoryFloor AS IVT_F ON IVT_F.idFloor=IVT_R.idFloor
                LEFT JOIN tblInventoryProduct AS IVT_P ON IVT_P.idProduct=IVT_I.idProduct
                LEFT JOIN tblInventoryGategory AS IVT_CG ON IVT_CG.idCategory=IVT_P.idCategory
				LEFT JOIN (SELECT SUM(warehouseQuantity) AS Qty,idItem FROM tblInventoryWarehouse WHERE  warehouseStatus =1 GROUP BY idItem) AS WS ON WS.idItem=IVT_I.idItem
                WHERE itemStatus=1 AND Qty >= 0 ORDER BY IVT_I.itemNameEng");
            gdvWarehouse.Columns["Product"].Group();
            gdvWarehouse.ExpandAllGroups();

        }

        private void cmsReport_Click(object sender, EventArgs e)
        {

            reportWarehouse();
        }

        private void btnAddWarehouse_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            addNewWarehouse();
        }

        private void btnReportWarehouse_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            reportWarehouse();
        }
        public void addNewWarehouse()
        {
            _reload = false;
            Warehouse.frmItem frmProduct = new frmItem();
            frmProduct.ShowDialog();
            if (_reload)
            {
                loadGrid();
            }
        }
        public void reportWarehouse()
        {
            try
            {
                DataTable dtTmp = new DataTable();

                dtTmp.Columns.Add("ItemEn", typeof(string));
                dtTmp.Columns.Add("ItemKh", typeof(string));
                dtTmp.Columns.Add("Code", typeof(string));
                dtTmp.Columns.Add("Serial", typeof(string));
                dtTmp.Columns.Add("Product", typeof(string));
                dtTmp.Columns.Add("Brand", typeof(string));
                dtTmp.Columns.Add("Category", typeof(string));
                dtTmp.Columns.Add("Room", typeof(string));
                dtTmp.Columns.Add("Floor", typeof(string));
                dtTmp.Columns.Add("Location", typeof(string));
                dtTmp.Columns.Add("Quantity", typeof(int));

                for (int i = 0; i < gdvWarehouse.DataRowCount; i++)
                {
                    string ItemEn = gdvWarehouse.GetDataRow(i)["ItemEn"].ToString();
                    string ItemKh = gdvWarehouse.GetDataRow(i)["ItemKh"].ToString();
                    string Code = gdvWarehouse.GetDataRow(i)["Code"].ToString();
                    string Serial = gdvWarehouse.GetDataRow(i)["Serial"].ToString();
                    string Product = gdvWarehouse.GetDataRow(i)["Product"].ToString();
                    string Brand = gdvWarehouse.GetDataRow(i)["Brand"].ToString();
                    string Category = gdvWarehouse.GetDataRow(i)["Category"].ToString();
                    string Room = gdvWarehouse.GetDataRow(i)["Room"].ToString();
                    string Floor = gdvWarehouse.GetDataRow(i)["Floor"].ToString();
                    string Location = gdvWarehouse.GetDataRow(i)["Location"].ToString();
                    string Quantity = gdvWarehouse.GetDataRow(i)["Quantity"].ToString();

                    dtTmp.Rows.Add(ItemEn, ItemKh, Code, Serial, Product, Brand, Category, Room, Floor, Location, Quantity);
                }
                Utilities.xtraReportView("InventoryWarehouse", dtTmp);
            }
            catch (Exception ex)
            {

                MsgBox.msgLoad("error", ex.Message);
            }
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            reload();
        }
        public void reload()
        {
            loadGrid();
            gdvWarehouse.OptionsBehavior.Editable = false;
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reload();
        }
    }
}