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
    public partial class frmStockIn : DevExpress.XtraEditors.XtraForm
    {
        public frmStockIn()
        {
            InitializeComponent();
        }

        private void frmStockIn_Load(object sender, EventArgs e)
        {
            loadGrid();
            gridButtonDelete();
            gridButtonEdit();
            for (int i = 0; i < gdvStockIn.Columns.Count - 2; i++)
            {
                gdvStockIn.Columns[i].OptionsColumn.AllowEdit = false;
            }
            gdvStockIn.Columns["Id"].Visible = false;
            gdvStockIn.Columns["idLocation"].Visible = false;
            gdvStockIn.Columns["idRoom"].Visible = false;
            gdvStockIn.Columns["idProduct"].Visible = false;
            gdvStockIn.Columns["Image"].Visible = false;
            gdvStockIn.Columns["Description"].Visible = false;
            gdvStockIn.Columns["Problem Description"].Visible = false;
            gdvStockIn.Columns["Problem"].Width = 25;
            gdvStockIn.Columns["Quantity"].Width = 29;
            gdvStockIn.Columns["Floor"].Width = 16;
            gdvStockIn.Columns["Serial Number"].Width = 42;
            gdvStockIn.Columns["Code"].Width = 42;
            gdvStockIn.Columns["Brand"].Width = 42;
        }
        public void loadGrid()
        {

            gdcStockIn.DataSource = Database.getData(@"SELECT IVT_I.idItem AS Id,
                                                        itemActiveDate AS [Date],
                                                        itemProblem AS Problem,
                                                        itemCode AS Code,
                                                        itemSerialNumber AS [Serial Number],
                                                        itemNameEng AS ItemEn,
                                                        itemNameKh AS ItemKh,
                                                        itemBrand AS Brand,
                                                        categoryName AS Category,
                                                         roomName AS Room,
                                                        IVT_F.floorNumber AS Floor,
                                                        locationName AS Location,                                                        productName AS Product,
                                                        itemDescription AS [Description],
                                                        IVT_L.idLocation,
                                                        IVT_R.idRoom,
                                                        IVT_P.idProduct,
                                                        itemImage AS [Image],
                                                        warehouseQuantity AS Quantity,
                                                        itemProblemDescrtiption AS [Problem Description],
                                                        '' AS [Edit],
                                                        '' AS [Delete] 
                                                        FROM tblInventoryItem AS IVT_I
                                                        LEFT JOIN tblInventoryWarehouse AS IVT_W ON IVT_W.idItem=IVT_I.idItem
                                                        LEFT JOIN tblInventoryLocation AS IVT_L ON IVT_L.idLocation=IVT_I.idLocation
                                                        LEFT JOIN tblInventoryRoom AS IVT_R ON IVT_R.idRoom=IVT_I.idRoom
														LEFT JOIN tblInventoryFloor AS IVT_F ON IVT_F.idFloor=IVT_R.idFloor
                                                        LEFT JOIN tblInventoryProduct AS IVT_P ON IVT_P.idProduct=IVT_I.idProduct
                                                        LEFT JOIN tblInventoryGategory AS IVT_CG ON IVT_CG.idCategory=IVT_P.idCategory
                                                        WHERE itemStatus=1 AND IVT_W.warehouseStockIn=1 ORDER BY IVT_I.itemNameEng");
            gdvStockIn.Columns["Product"].Group();
            gdvStockIn.ExpandAllGroups();

        }
        RepositoryItemButtonEdit btnDelete = new RepositoryItemButtonEdit();
        public void gridButtonDelete()
        {
            btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnDelete.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btnDelete.ButtonClick += repositoryItemButtonDelete_ButtonClick;
            btnDelete.Buttons[0].Image = Image.FromFile(@"Image\Icon\Delete.png");

            gdvStockIn.Columns["Delete"].ColumnEdit = btnDelete;
            gdvStockIn.Columns["Delete"].Width = 16;
            gdcStockIn.RepositoryItems.Add(btnDelete);
        }
        int _id;
        private void repositoryItemButtonDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            deleteWarehouse();
        }

        RepositoryItemButtonEdit btnEdit = new RepositoryItemButtonEdit();
        public void gridButtonEdit()
        {
            btnEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnEdit.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btnEdit.ButtonClick += repositoryItemButtonEdit_ButtonClick;
            btnEdit.Buttons[0].Image = Image.FromFile(@"Image\Icon\Edit.png");

            gdvStockIn.Columns["Edit"].ColumnEdit = btnEdit;
            gdvStockIn.Columns["Edit"].Width = 16;
            gdcStockIn.RepositoryItems.Add(btnEdit);
        }
        private void repositoryItemButtonEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            editWarehouse();
        }
        public void editWarehouse()
        {
            string checkProblem = "Unchecked";
            try
            {
                frmItem _frmItem = new frmItem();
                _frmItem._idItem = Convert.ToInt16(gdvStockIn.GetRowCellDisplayText(gdvStockIn.GetSelectedRows()[0], gdvStockIn.Columns["Id"]));
                checkProblem = gdvStockIn.GetRowCellDisplayText(gdvStockIn.GetSelectedRows()[0], gdvStockIn.Columns["Problem"]);
                if (checkProblem != "Unchecked")
                {
                    _frmItem._checkProblem = true;
                }

                _frmItem._brand = gdvStockIn.GetRowCellDisplayText(gdvStockIn.GetSelectedRows()[0], gdvStockIn.Columns["Brand"]);
                _frmItem._nameEn = gdvStockIn.GetRowCellDisplayText(gdvStockIn.GetSelectedRows()[0], gdvStockIn.Columns["ItemEn"]);
                _frmItem._nameKh = gdvStockIn.GetRowCellDisplayText(gdvStockIn.GetSelectedRows()[0], gdvStockIn.Columns["ItemKh"]);
                _frmItem._Image = gdvStockIn.GetRowCellDisplayText(gdvStockIn.GetSelectedRows()[0], gdvStockIn.Columns["Image"]);
                _frmItem._code = gdvStockIn.GetRowCellDisplayText(gdvStockIn.GetSelectedRows()[0], gdvStockIn.Columns["Code"]);
                _frmItem._serialNumber = gdvStockIn.GetRowCellDisplayText(gdvStockIn.GetSelectedRows()[0], gdvStockIn.Columns["Serial Number"]);
                _frmItem._idLocation = Convert.ToInt16(gdvStockIn.GetRowCellDisplayText(gdvStockIn.GetSelectedRows()[0], gdvStockIn.Columns["idLocation"]));
                _frmItem._description = gdvStockIn.GetRowCellDisplayText(gdvStockIn.GetSelectedRows()[0], gdvStockIn.Columns["Description"]);
                _frmItem._idRoom = Convert.ToInt16(gdvStockIn.GetRowCellDisplayText(gdvStockIn.GetSelectedRows()[0], gdvStockIn.Columns["idRoom"]));
                _frmItem._idProduct = Convert.ToInt16(gdvStockIn.GetRowCellDisplayText(gdvStockIn.GetSelectedRows()[0], gdvStockIn.Columns["idProduct"]));
                _frmItem._quantity = Convert.ToInt16(gdvStockIn.GetRowCellDisplayText(gdvStockIn.GetSelectedRows()[0], gdvStockIn.Columns["Quantity"]));
                _frmItem._save = false;
                _frmItem.ShowDialog();

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
        public void deleteWarehouse()
        {
            MsgBox.msgLoad("question", "You sure want to Delete ?");
            try
            {
                if (MsgBox._resultYes)
                {
                    _id = Convert.ToInt16(gdvStockIn.GetRowCellDisplayText(gdvStockIn.GetSelectedRows()[0], gdvStockIn.Columns["Id"]));
                    bool checkRecord = Database.hashRecord(@"SELECT 
                                                    IVT_SO.idItem
                                                    FROM tblInventoryStockOut AS IVT_SO
                                                    LEFT JOIN tblStaff AS ST ON ST.idStaff=IVT_SO.idStaff
                                                    LEFT JOIN tblInventoryLocation AS IVT_L ON IVT_L.idLocation=IVT_SO.idLocation
                                                    LEFT JOIN tblInventoryRoom AS IVT_R ON IVT_R.idRoom= IVT_SO.idRoom
                                                    LEFT JOIN tblInventoryFloor AS IVT_F ON IVT_F.idFloor=IVT_R.idFloor
                                                    LEFT JOIN tblInventoryItem AS IVT_I ON IVT_I.idItem=IVT_SO.idItem
                                                    LEFT JOIN tblInventoryProduct AS IVT_P ON IVT_P.idProduct=IVT_I.idProduct
                                                    LEFT JOIN tblInventoryGategory AS IVT_CG ON IVT_CG.idCategory=IVT_P.idCategory
                                                    LEFT JOIN tblInventoryWarehouse AS IVT_W ON IVT_W.idStockOut=IVT_SO.idStockOut
                                                    WHERE  IVT_SO.stockOutStatus=1 AND IVT_W.warehouseStatus = 1 AND IVT_SO.idItem=" + _id + "");
                    if (checkRecord)
                    {
                        MsgBox.msgLoad("error", "This item have related with another staff already");
                        return;
                    }
                    Database.executeSql("UPDATE tblInventoryItem SET itemStatus=0,itemDeactiveDate=GETDATE() WHERE idItem=" + _id + "");
                    Database.executeSql("UPDATE tblInventoryWarehouse SET warehouseStatus=0,warehouseDeactive=GETDATE() WHERE idItem=" + _id + "");
                    loadGrid();
                }
                MsgBox._resultYes = false;
            }
            catch (Exception ex)
            {

                MsgBox.msgLoad("error", ex.Message);
            }
        }
        public static bool _reload;
        private void AddNew_Click(object sender, EventArgs e)
        {
            addStockIn();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (gdvStockIn.RowCount <= 0 || _id == 0)
            {
                MsgBox.msgLoad("search", "Please select on your recorde");
                return;
            }
            editWarehouse();
        }

        private void cmsDelete_Click(object sender, EventArgs e)
        {
            if (gdvStockIn.RowCount <= 0 || _id == 0)
            {
                MsgBox.msgLoad("search", "Please select on your recorde");
                return;
            }
            deleteWarehouse();
        }

        private void cmsReport_Click(object sender, EventArgs e)
        {

            reportStockIn();
        }
        private void btnAddStockIn_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            addStockIn();
        }
        private void btnReportStockIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            reportStockIn();
        }
        public void addStockIn()
        {
            _reload = false;
            Warehouse.frmItem frmProduct = new frmItem();
            frmProduct.ShowDialog();
            if (_reload)
            {
                loadGrid();
            }
        }
        public void reportStockIn()
        {
            try
            {
                DataTable dtTmp = new DataTable();
                dtTmp.Columns.Add("Code", typeof(string));
                dtTmp.Columns.Add("SerialNumber", typeof(string));
                dtTmp.Columns.Add("ItemEn", typeof(string));
                dtTmp.Columns.Add("ItemKh", typeof(string));
                dtTmp.Columns.Add("Product", typeof(string));
                dtTmp.Columns.Add("Brand", typeof(string));
                dtTmp.Columns.Add("Category", typeof(string));
                dtTmp.Columns.Add("Floor", typeof(string));
                dtTmp.Columns.Add("Location", typeof(string));
                dtTmp.Columns.Add("Description", typeof(string));
                dtTmp.Columns.Add("Problem", typeof(bool));
                dtTmp.Columns.Add("ProblemDescription", typeof(string));
                dtTmp.Columns.Add("Image", typeof(string));
                dtTmp.Columns.Add("Date", typeof(string));
                dtTmp.Columns.Add("Quantity", typeof(int));
                string code, SerialNumber, ItemEn, ItemKh, Product, Brand, Category, Floor, Location, Description, ProblemDescription, Image, date;
                int Quantity;
                bool Problem;
                for (int i = 0; i < gdvStockIn.DataRowCount; i++)
                {
                    code = gdvStockIn.GetDataRow(i)["Code"].ToString();
                    SerialNumber = gdvStockIn.GetDataRow(i)["Serial Number"].ToString();
                    ItemEn = gdvStockIn.GetDataRow(i)["ItemEn"].ToString();
                    ItemKh = gdvStockIn.GetDataRow(i)["ItemKh"].ToString();
                    Product = gdvStockIn.GetDataRow(i)["Product"].ToString();
                    Brand = gdvStockIn.GetDataRow(i)["Brand"].ToString();
                    Category = gdvStockIn.GetDataRow(i)["Category"].ToString();
                    Floor = gdvStockIn.GetDataRow(i)["Floor"].ToString();
                    Location = gdvStockIn.GetDataRow(i)["Location"].ToString();
                    Category = gdvStockIn.GetDataRow(i)["Category"].ToString();
                    Description = gdvStockIn.GetDataRow(i)["Description"].ToString();
                    Problem = Convert.ToBoolean(gdvStockIn.GetDataRow(i)["Problem"]);
                    ProblemDescription = gdvStockIn.GetDataRow(i)["Problem Description"].ToString();
                    Image = gdvStockIn.GetDataRow(i)["Image"].ToString();
                    date = Convert.ToDateTime(gdvStockIn.GetDataRow(i)["Date"]).ToString("yyyy-MM-dd");
                    Quantity = Convert.ToInt16(gdvStockIn.GetDataRow(i)["Quantity"]);
                    string imagePath = Application.StartupPath + @"\Image\Product\" + Image;
                    dtTmp.Rows.Add(code, SerialNumber, ItemEn, ItemKh, Product, Brand, Category, Floor, Location, Description, Problem, ProblemDescription, imagePath, date, Quantity);
                }

                Utilities.xtraReportView("InventoryStockIn", dtTmp);
            }
            catch (Exception ex)
            {

                MsgBox.msgLoad("error", ex.Message);
            }
        }
    }
}