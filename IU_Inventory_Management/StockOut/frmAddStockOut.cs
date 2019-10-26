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
    public partial class frmAddStockOut : DevExpress.XtraEditors.XtraForm
    {
        public frmAddStockOut()
        {
            InitializeComponent();
        }
        public int _idStaff;
        public int _idStockOut;
        DataTable _dtTmp;
        private void frmAddStockOut_Load(object sender, EventArgs e)
        {
            cboLocationLoad();
            cboRoomLoad();
            if (_save)
            {
                _dtTmp = new DataTable();
                _dtTmp.Columns.Add("idItem", typeof(int));
                _dtTmp.Columns.Add("Barcode", typeof(string));
                _dtTmp.Columns.Add("ItemEn", typeof(string));
                _dtTmp.Columns.Add("ItemKh", typeof(string));
                _dtTmp.Columns.Add("Description", typeof(string));
                _dtTmp.Columns.Add("idLocation", typeof(int));
                _dtTmp.Columns.Add("Location", typeof(string));
                _dtTmp.Columns.Add("idRoom", typeof(int));
                _dtTmp.Columns.Add("Room", typeof(string));
                _dtTmp.Columns.Add("Quantity", typeof(int));
                _dtTmp.Columns.Add("Delete", typeof(string));
                loadGridItem();
                gdvItem.OptionsBehavior.Editable = false;
                //for (int i = 0; i < gdvStockOut.Columns.Count - 1; i++)
                //{
                //    gdvStockOut.Columns[i].OptionsColumn.AllowEdit = false;
                //}
                gdcStockOut.DataSource = _dtTmp;
                loadGrid();
                gridButtonDelete();
            }
            else
            {
                btnStockOutSave.Caption = "Update";
                cboLocation.SelectedValue = _idLocation;
                cboRoom.SelectedValue = _idRoom;
                rtbDescription.Text = _Description;
                gdcItem.Enabled = false;
                gdcStockOut.DataSource = Database.getData(@"SELECT 
                                                            stockOutBarcode AS Barcode,
                                                            itemNameEng AS ItemEn,
                                                            itemNameKh AS ItemKh,
                                                            stockOutDescription AS Description,
                                                            roomName AS Room,
                                                            locationName AS Location,
                                                            ABS(warehouseQuantity) AS Quantity
                                                            FROM tblInventoryStockOut AS IVT_SO
                                                            LEFT JOIN tblStaff AS ST ON ST.idStaff=IVT_SO.idStaff
                                                            LEFT JOIN tblInventoryLocation AS IVT_L ON IVT_L.idLocation=IVT_SO.idLocation
                                                            LEFT JOIN tblInventoryRoom AS IVT_R ON IVT_R.idRoom= IVT_SO.idRoom
                                                            LEFT JOIN tblInventoryFloor AS IVT_F ON IVT_F.idFloor=IVT_R.idFloor
                                                            LEFT JOIN tblInventoryItem AS IVT_I ON IVT_I.idItem=IVT_SO.idItem
                                                            LEFT JOIN tblInventoryWarehouse AS IVT_W ON IVT_W.idStockOut=IVT_SO.idStockOut WHERE IVT_SO.idStockOut=" + _idStockOut + "");
            }
        }
        public void loadGridItem()
        {
            gdcItem.DataSource = Database.getData(@"SELECT DISTINCT(IVT_I.idItem) AS Id, 
                itemNameEng AS ItemEn,
                itemNameKh AS ItemKh,
                itemCode AS Code,
                itemSerialNumber AS [Serial Number],
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
                WHERE itemStatus=1 AND Qty > 0 ORDER BY IVT_I.itemNameEng");
        }
        public void cboLocationLoad()
        {
            Utilities.bindCombo(Database.getData("SELECT idLocation,locationName FROM tblInventoryLocation WHERE locationStatus=1"), cboLocation, "locationName", "idLocation", "[ Choose one ]", true);
        }
        public void cboRoomLoad()
        {
            Utilities.bindCombo(Database.getData("SELECT idRoom,roomName FROM tblInventoryRoom WHERE roomStatus=1"), cboRoom, "roomName", "idRoom", "[ Choose one ]", true);
        }
        public int _idItem, _idLocation, _idRoom, _qunatity;
        public string _itemNameEn, _itemNameKh, _barCode, _Description;
        public bool _save = true;

        private void cboLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectIndex = Convert.ToInt16(cboLocation.SelectedValue);
                if (selectIndex == -1)
                {
                    Warehouse.frmCuttingPattern _frmLocaiton = new Warehouse.frmCuttingPattern();
                    
                    _frmLocaiton._saveFor = "Location";
                    _frmLocaiton.ShowDialog();
                    if (MsgBox._resultYes)
                    {
                        cboLocationLoad();
                    }
                    MsgBox._resultYes = false;

                }
            }
            catch (Exception ex)
            {

                MsgBox.msgLoad("error", ex.Message);
            }
        }

        private void cboRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectIndex = Convert.ToInt16(cboRoom.SelectedValue);
                if (selectIndex == -1)
                {
                    Warehouse.frmCuttingPattern _frmLocaiton = new Warehouse.frmCuttingPattern();

                    _frmLocaiton._saveFor = "Room";
                    _frmLocaiton.ShowDialog();
                    if (MsgBox._resultYes)
                    {
                        cboRoomLoad();
                    }
                    MsgBox._resultYes = false;

                }
            }
            catch (Exception ex)
            {

                MsgBox.msgLoad("error", ex.Message);
            }
        }
        int _valueQty, _indexOf;
        int _indexCompair = -1;
        private void gdvStockOut_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                _indexOf = gdvStockOut.FocusedRowHandle; 
                if (_indexOf != _indexCompair)
                {
                    _indexCompair = _indexOf;
                    _valueQty = Convert.ToInt16(gdvStockOut.GetRowCellDisplayText(gdvStockOut.GetSelectedRows()[0], gdvStockOut.Columns["Quantity"]));
                }
               
                if (gdvStockOut.FocusedColumn.FieldName == "Quantity")
                {
                    int qty,value = 0;
                    int.TryParse(e.Value as string, out value);
                    if (!int.TryParse(e.Value as string, out qty) || value <= 0)
                    {
                        e.Valid = false;
                        e.ErrorText = "Numeric values are only accepted";
                    }
                    else if (value > _valueQty)
                    {
                        e.Valid = false;
                        e.ErrorText = "Please don't input value small than product quantity";
                    }
                }
            }
            catch (Exception ex)
            {

                MsgBox.msgLoad("error", ex.Message);
            }
            

        }

        private void btnStockOutSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (gdvStockOut.RowCount <= 0)
                {
                    MsgBox.msgLoad("search", "don't have record for stockout");
                    return;
                }
                if (_save)
                {
                    for (int i = 0; i < gdvStockOut.RowCount; i++)
                    {
                        int idItem = Convert.ToInt16(gdvStockOut.GetDataRow(i)["idItem"]);
                        int idLocation = Convert.ToInt16(gdvStockOut.GetDataRow(i)["idLocation"]);
                        int idRoom = Convert.ToInt16(gdvStockOut.GetDataRow(i)["idRoom"]);
                        int quantity = Convert.ToInt16(gdvStockOut.GetDataRow(i)["Quantity"]);
                        string barcode = gdvStockOut.GetDataRow(i)["Barcode"].ToString();
                        string description = gdvStockOut.GetDataRow(i)["Description"].ToString();

                        Database.executeProce("spStockOut", new Dictionary<string, object>()
                        {
                            {"stockOutBarcode", barcode},
                            {"stockOutDescription",description },
                            {"idLocation",idLocation },
                            {"idRoom",idRoom },
                            {"idItem",idItem },
                            {"idUser",Database._idUser },
                            {"idStaff",_idStaff },
                            {"quanity",quantity }

                        });
                    }
                    MsgBox.msgLoad("success", "StockOut was insert success");
                    _dtTmp.Clear();
                    loadGridItem();
                }
                else
                {
                    _idLocation = Convert.ToInt16(cboLocation.SelectedValue);
                    _idRoom = Convert.ToInt16(cboRoom.SelectedValue);
                    _Description = rtbDescription.Text;
                    string sql = "UPDATE tblInventoryStockOut SET idLocation=" + _idLocation + ", idRoom=" + _idRoom + ",stockOutDescription='" + _Description + "' WHERE idStockOut=" + _idStockOut + "";
                    Database.executeSql(sql);
                    MsgBox._resultYes = true;
                    MsgBox.msgLoad("success", "StockOut was update success");
                }
                
            }
            catch (Exception ex)
            {

                MsgBox.msgLoad("error", ex.Message);
            }
        }
        int _idItemCheck;
        string _location, _room;
        private void gdvItem_DoubleClick(object sender, EventArgs e)
        {
            
            try
            {
                if (cboLocation.SelectedIndex > 0 && cboRoom.SelectedIndex > 0)
                {

                    _idItem = Convert.ToInt16(gdvItem.GetRowCellDisplayText(gdvItem.GetSelectedRows()[0], gdvItem.Columns[0]));
                    _itemNameEn = gdvItem.GetRowCellDisplayText(gdvItem.GetSelectedRows()[0], gdvItem.Columns[1]);
                    _itemNameKh = gdvItem.GetRowCellDisplayText(gdvItem.GetSelectedRows()[0], gdvItem.Columns[2]);
                    _idLocation = Convert.ToInt16(cboLocation.SelectedValue);
                    _barCode = _idLocation.ToString() + "-" + _idStaff.ToString() + "-" + _idItem.ToString();
                    _Description = rtbDescription.Text;
                    _idRoom = Convert.ToInt16(cboRoom.SelectedValue);
                    _qunatity = Convert.ToInt16(gdvItem.GetRowCellDisplayText(gdvItem.GetSelectedRows()[0], gdvItem.Columns[11]));
                    _location = cboLocation.Text;
                    _room = cboRoom.Text;
                   
                    if (_dtTmp.Rows.Count >= 0)
                    {
                        _idItemCheck = (from DataRow dr in _dtTmp.Rows
                              where (int)dr["idItem"] == _idItem
                              select (int)dr["idItem"]).FirstOrDefault();
                    }

                    if (_idItemCheck == _idItem)
                    {
                        MsgBox.msgLoad("error", "This item is existing");
                        return;
                    }
                    _dtTmp.Rows.Add(_idItem, _barCode, _itemNameEn, _itemNameKh, _Description, _idLocation, _location, _idRoom, _room, _qunatity);

                    gdcStockOut.DataSource = _dtTmp;

                }else
                {
                    MsgBox.msgLoad("search", "Please select Location , Room first");
                    return;
                }
                
            }
            catch (Exception ex)
            {

                MsgBox.msgLoad("error", ex.Message);
            }
        }
        public void loadGrid()
        {
            for (int i = 0; i < gdvStockOut.Columns.Count - 2; i++)
            {
                gdvStockOut.Columns[i].OptionsColumn.AllowEdit = false;
            }
            gdvStockOut.Columns["idItem"].Visible = false;
            gdvStockOut.Columns["idLocation"].Visible = false;
            gdvStockOut.Columns["idRoom"].Visible = false;
        }
        RepositoryItemButtonEdit btnDelete = new RepositoryItemButtonEdit();
        public void gridButtonDelete()
        {
            btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnDelete.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            btnDelete.ButtonClick += repositoryItemButtonDelete_ButtonClick;
            btnDelete.Buttons[0].Image = Image.FromFile(@"Image\Icon\Delete.png");

            gdvStockOut.Columns["Delete"].ColumnEdit = btnDelete;
            gdvStockOut.Columns["Delete"].Width = 16;
            gdcStockOut.RepositoryItems.Add(btnDelete);
        }
        private void repositoryItemButtonDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            _dtTmp.Rows.RemoveAt(gdvStockOut.FocusedRowHandle);
        }
    }
}