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

namespace IU_Inventory_Management.StockOut
{
    public partial class frmRefuse : DevExpress.XtraEditors.XtraForm
    {
        public frmRefuse()
        {
            InitializeComponent();
        }
        public int _idStaff;
        private void frmRefuse_Load(object sender, EventArgs e)
        {
            loadGrid();
            gvcRefuse.Columns["Product"].Visible = false;
            gvcRefuse.Columns["Id"].Visible = false;
            gvcRefuse.Columns["idStaff"].Visible = false;
            gvcRefuse.Columns["idLocation"].Visible = false;
            gvcRefuse.Columns["idFloor"].Visible = false;
            gvcRefuse.Columns["idRoom"].Visible = false;
            gvcRefuse.Columns["Description"].Visible = false;
            gvcRefuse.Columns["Quantity"].Width = 29;
            gvcRefuse.Columns["Floor"].Width = 16;
            gvcRefuse.Columns["Brand"].Width = 42;
        }
        public void loadGrid()
        {
            string sql = string.Format(@"DECLARE @idStaff INT = {0}  
                                            SELECT 
                                            IVT_SO.stockOutDeactive AS [Date],
                                            IVT_SO.idStockOut AS Id,
                                            ST.idStaff,
                                            ST.staffName AS Staff,
                                            stockOutBarcode AS Barcode,
											itemSerialNumber AS Serial,
											itemNameEng AS ItemEn,
											itemNameKh AS ItemKh,
											IVT_P.productName AS Product,
											IVT_I.itemBrand AS Brand,
											IVT_CG.categoryName AS Category,
											roomName AS Room,
											floorNumber AS [Floor],
											locationName AS Location,
                                            stockOutDescription AS Description,
                                            warehouseQuantity AS Quantity,
                                            IVT_L.idLocation,
											IVT_F.idFloor,
											IVT_R.idRoom
                                            FROM tblInventoryStockOut AS IVT_SO
                                            LEFT JOIN tblStaff AS ST ON ST.idStaff=IVT_SO.idStaff
                                            LEFT JOIN tblInventoryLocation AS IVT_L ON IVT_L.idLocation=IVT_SO.idLocation
                                            LEFT JOIN tblInventoryRoom AS IVT_R ON IVT_R.idRoom= IVT_SO.idRoom
                                            LEFT JOIN tblInventoryFloor AS IVT_F ON IVT_F.idFloor=IVT_R.idFloor
                                            LEFT JOIN tblInventoryItem AS IVT_I ON IVT_I.idItem=IVT_SO.idItem
                                            LEFT JOIN tblInventoryProduct AS IVT_P ON IVT_P.idProduct=IVT_I.idProduct
                                            LEFT JOIN tblInventoryGategory AS IVT_CG ON IVT_CG.idCategory=IVT_P.idCategory
                                            LEFT JOIN tblInventoryWarehouse AS IVT_W ON IVT_W.idStockOut=IVT_SO.idStockOut
                                            WHERE  IVT_SO.stockOutStatus=1 AND IVT_SO.StockIn=1 AND IVT_W.warehouseStatus = 0 AND IVT_I.itemStatus=1 AND (ST.idStaff=@idStaff OR @idStaff=0) ORDER BY ST.staffName", _idStaff);
            gdcRefuse.DataSource = Database.getData(sql);
            gvcRefuse.Columns["Product"].Group();
            gvcRefuse.ExpandAllGroups();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadGrid();
        }

        private void btnReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            reportStockOut();
        }

        public void reportStockOut()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Columns.Add("Staff", typeof(string));
                dtTmp.Columns.Add("Barcode", typeof(string));
                dtTmp.Columns.Add("Serial", typeof(string));
                dtTmp.Columns.Add("ItemEn", typeof(string));
                dtTmp.Columns.Add("ItemKh", typeof(string));
                dtTmp.Columns.Add("Product", typeof(string));
                dtTmp.Columns.Add("Brand", typeof(string));
                dtTmp.Columns.Add("Category", typeof(string));
                dtTmp.Columns.Add("Room", typeof(string));
                dtTmp.Columns.Add("Floor", typeof(string));
                dtTmp.Columns.Add("Location", typeof(string));
                dtTmp.Columns.Add("Description", typeof(string));
                dtTmp.Columns.Add("Date", typeof(string));
                dtTmp.Columns.Add("Quantity", typeof(int));


                for (int i = 0; i < gvcRefuse.DataRowCount; i++)
                {
                    string Staff = gvcRefuse.GetDataRow(i)["Staff"].ToString();
                    string Barcode = gvcRefuse.GetDataRow(i)["Barcode"].ToString();
                    string Serial = gvcRefuse.GetDataRow(i)["Serial"].ToString();
                    string ItemEn = gvcRefuse.GetDataRow(i)["ItemEn"].ToString();
                    string ItemKh = gvcRefuse.GetDataRow(i)["ItemKh"].ToString();
                    string Product = gvcRefuse.GetDataRow(i)["Product"].ToString();
                    string Brand = gvcRefuse.GetDataRow(i)["Brand"].ToString();
                    string Category = gvcRefuse.GetDataRow(i)["Category"].ToString();
                    string Room = gvcRefuse.GetDataRow(i)["Room"].ToString();
                    string Floor = gvcRefuse.GetDataRow(i)["Floor"].ToString();
                    string Location = gvcRefuse.GetDataRow(i)["Location"].ToString();
                    string Description = gvcRefuse.GetDataRow(i)["Description"].ToString();
                    string Date = Convert.ToDateTime(gvcRefuse.GetDataRow(i)["Date"].ToString()).ToString("yyyy-MM-dd");
                    int Quantity = Convert.ToInt16(gvcRefuse.GetDataRow(i)["Quantity"]);


                    dtTmp.Rows.Add(Staff, Barcode, Serial, ItemEn, ItemKh, Product, Brand, Category, Room, Floor, Location, Description, Date, Quantity);
                }
                Utilities.xtraReportView("InventoryRefuse", dtTmp);
            }
            catch (Exception ex)
            {
                MsgBox.msgLoad("error", ex.Message);
            }
        }
    }
}