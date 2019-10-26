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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace IU_Inventory_Management.StockOut
{
    public partial class frmStockOut : DevExpress.XtraEditors.XtraForm
    {
        public frmStockOut()
        {
            InitializeComponent();
        }
        public int _idStaff;
        private void frmStockOut_Load(object sender, EventArgs e)
        {
            loadGrid();
            gdvStockOut.Columns["Product"].Visible = false;
            gdvStockOut.Columns["Id"].Visible = false;
            gdvStockOut.Columns["idStaff"].Visible = false;
            gdvStockOut.Columns["idLocation"].Visible = false;
            gdvStockOut.Columns["idFloor"].Visible = false;
            gdvStockOut.Columns["idRoom"].Visible = false;
            gdvStockOut.Columns["Description"].Visible = false;
            gdvStockOut.Columns["Quantity"].Width = 29;
            gdvStockOut.Columns["Floor"].Width = 16;
            gdvStockOut.Columns["Brand"].Width = 42;
            gridButtonEdit();
            gridButtonRefuse();
        }
        public void loadGrid()
        {
            string sql = string.Format(@"DECLARE @idStaff INT = {0}  
                                            SELECT 
                                            IVT_SO.stockOutActive AS [Date],
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
											IVT_R.idRoom,
                                            '' AS Edit,
                                            '' AS [Refuse]
                                            FROM tblInventoryStockOut AS IVT_SO
                                            LEFT JOIN tblStaff AS ST ON ST.idStaff=IVT_SO.idStaff
                                            LEFT JOIN tblInventoryLocation AS IVT_L ON IVT_L.idLocation=IVT_SO.idLocation
                                            LEFT JOIN tblInventoryRoom AS IVT_R ON IVT_R.idRoom= IVT_SO.idRoom
                                            LEFT JOIN tblInventoryFloor AS IVT_F ON IVT_F.idFloor=IVT_R.idFloor
                                            LEFT JOIN tblInventoryItem AS IVT_I ON IVT_I.idItem=IVT_SO.idItem
                                            LEFT JOIN tblInventoryProduct AS IVT_P ON IVT_P.idProduct=IVT_I.idProduct
                                            LEFT JOIN tblInventoryGategory AS IVT_CG ON IVT_CG.idCategory=IVT_P.idCategory
                                            LEFT JOIN tblInventoryWarehouse AS IVT_W ON IVT_W.idStockOut=IVT_SO.idStockOut
                                            WHERE  IVT_SO.stockOutStatus=1 AND IVT_W.warehouseStatus = 1 AND (ST.idStaff=@idStaff OR @idStaff=0) ORDER BY ST.staffName", _idStaff);
            gdcStockOut.DataSource = Database.getData(sql);
            gdvStockOut.Columns["Product"].Group();
            gdvStockOut.ExpandAllGroups();
        }

        RepositoryItemButtonEdit btnRefuse = new RepositoryItemButtonEdit();
        public void gridButtonRefuse()
        {
            btnRefuse.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnRefuse.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btnRefuse.ButtonClick += repositoryItemButtonbtnRefuse_ButtonClick;
            btnRefuse.Buttons[0].Image = Image.FromFile(@"Image\Icon\Refuse.png");

            gdvStockOut.Columns["Refuse"].ColumnEdit = btnRefuse;
            gdvStockOut.Columns["Refuse"].Width = 16;
            gdcStockOut.RepositoryItems.Add(btnRefuse);
        }
        int _id;
        private void repositoryItemButtonbtnRefuse_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            refuseWarehouse();
        }

        RepositoryItemButtonEdit btnEdit = new RepositoryItemButtonEdit();
        public void gridButtonEdit()
        {
            btnEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnEdit.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btnEdit.ButtonClick += repositoryItemButtonEdit_ButtonClick;
            btnEdit.Buttons[0].Image = Image.FromFile(@"Image\Icon\Edit.png");

            gdvStockOut.Columns["Edit"].ColumnEdit = btnEdit;
            gdvStockOut.Columns["Edit"].Width = 16;
            gdcStockOut.RepositoryItems.Add(btnEdit);
        }
        private void repositoryItemButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            editWarehouse();
        }

        public void editWarehouse()
        {
            try
            {
                frmAddStockOut _frmAddStockOut = new frmAddStockOut();
                _frmAddStockOut._idStockOut = Convert.ToInt16(gdvStockOut.GetRowCellDisplayText(gdvStockOut.GetSelectedRows()[0], gdvStockOut.Columns["Id"]));
                _frmAddStockOut._idStaff = Convert.ToInt16(gdvStockOut.GetRowCellDisplayText(gdvStockOut.GetSelectedRows()[0], gdvStockOut.Columns["idStaff"]));
                _frmAddStockOut._idLocation = Convert.ToInt16(gdvStockOut.GetRowCellDisplayText(gdvStockOut.GetSelectedRows()[0], gdvStockOut.Columns["idLocation"]));
                _frmAddStockOut._idRoom = Convert.ToInt16(gdvStockOut.GetRowCellDisplayText(gdvStockOut.GetSelectedRows()[0], gdvStockOut.Columns["idRoom"]));
                _frmAddStockOut._Description = gdvStockOut.GetRowCellDisplayText(gdvStockOut.GetSelectedRows()[0], gdvStockOut.Columns["Description"]);
                _frmAddStockOut._save = false;
                _frmAddStockOut.ShowDialog();
                if (MsgBox._resultYes)
                {
                    loadGrid();
                }
                MsgBox._resultYes = false;
            }
            catch (Exception er)
            {

                MsgBox.msgLoad("error", er.Message);
            }
        }
        public void refuseWarehouse()
        {
            MsgBox.msgLoad("question", "You sure want to Refuse ?");
            try
            {
                if (MsgBox._resultYes)
                {
                    _id = Convert.ToInt16(gdvStockOut.GetRowCellDisplayText(gdvStockOut.GetSelectedRows()[0], gdvStockOut.Columns["Id"]));
                    Database.executeSql("UPDATE tblInventoryWarehouse SET warehouseStatus=0,warehouseDeactive=GETDATE() WHERE idStockOut=" + _id + "");
                    Database.executeSql("UPDATE tblInventoryStockOut SET stockOutStatus=0,stockOutDeactive=GETDATE() WHERE idStockOut=" + _id + "");
                    loadGrid();
                }
                MsgBox._resultYes = false;
            }
            catch (Exception ex)
            {

                MsgBox.msgLoad("error", ex.Message);
            }
        }

        private void gdcStockOut_Click(object sender, EventArgs e)
        {

        }
        
        private void cmsReport_Click(object sender, EventArgs e)
        {
            reportStockOut();
        }


        private void btnReportStockOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                

                for (int i = 0; i < gdvStockOut.DataRowCount; i++)
                {
                    string Staff = gdvStockOut.GetDataRow(i)["Staff"].ToString();
                    string Barcode = gdvStockOut.GetDataRow(i)["Barcode"].ToString();
                    string Serial = gdvStockOut.GetDataRow(i)["Serial"].ToString();
                    string ItemEn = gdvStockOut.GetDataRow(i)["ItemEn"].ToString();
                    string ItemKh = gdvStockOut.GetDataRow(i)["ItemKh"].ToString();
                    string Product = gdvStockOut.GetDataRow(i)["Product"].ToString();
                    string Brand = gdvStockOut.GetDataRow(i)["Brand"].ToString();
                    string Category = gdvStockOut.GetDataRow(i)["Category"].ToString();
                    string Room = gdvStockOut.GetDataRow(i)["Room"].ToString();
                    string Floor = gdvStockOut.GetDataRow(i)["Floor"].ToString();
                    string Location = gdvStockOut.GetDataRow(i)["Location"].ToString();
                    string Description = gdvStockOut.GetDataRow(i)["Description"].ToString();
                    string Date = Convert.ToDateTime(gdvStockOut.GetDataRow(i)["Date"].ToString()).ToString("yyyy-MM-dd");
                    int Quantity = Convert.ToInt16(gdvStockOut.GetDataRow(i)["Quantity"]);


                    dtTmp.Rows.Add(Staff, Barcode, Serial, ItemEn, ItemKh, Product, Brand, Category, Room, Floor, Location, Description, Date, Quantity);
                }
                Utilities.xtraReportView("InventoryStockOut", dtTmp);
            }
            catch (Exception ex)
            {
                MsgBox.msgLoad("error", ex.Message);
            }
        }
    }
}