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

namespace IU_Inventory_Management.Warehouse
{
    public partial class frmItem : DevExpress.XtraEditors.XtraForm
    {
        public frmItem()
        {
            InitializeComponent();
        }
        public string _nameKh, _nameEn, _code, _serialNumber, _description, _problemDescription, _photoName, _brand = "";
        public string _Image = "product.png";
        public int _idItem, _idLocation, _idRoom, _idProduct, _quantity;
        public bool _checkProblem;
        public bool _save = true;

        private void frmProduct_Load(object sender, EventArgs e)
        {
            cboLocationLoad();
            cboRoomLoad();
            cboProductLoad();

            txtNameEn.Text = _nameEn;
            txtNameKh.Text = _nameKh;
            txtBrand.Text = _brand;
            txtSerialNumber.Text = _serialNumber;

            rtbDescription.Text = _description;
            cbProblem.Checked = _checkProblem;
            rtbProblemDescription.Text = _problemDescription;

            cboLocation.SelectedValue = _idLocation;
            cboRoom.SelectedValue = _idRoom;
            cboProduct.SelectedValue = _idProduct;
            txtCode.Text = _code;
            if (_quantity != 0)
            {
                cbQuantityCustom.Checked = true;
                //quantityCustom();
                txtQuantity.Text = _quantity.ToString();
            }
            if (_save == false)
            {
                btnProductSave.Caption = "Update";
            }

            pcbImage.Image = Image.FromFile(Application.StartupPath + @"\Image\Product\" + _Image);

        }

        private void cbQuantityCustom_CheckedChanged(object sender, EventArgs e)
        {
            quantityCustom();
        }
        public void quantityCustom()
        {
            if (cbQuantityCustom.Checked)
            {
                txtQuantity.Enabled = true;
                cboQuantity.Enabled = false;
            }
            else
            {
                txtQuantity.Enabled = false;
                cboQuantity.Enabled = true;
            }
        }
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "JPG|*.jpg|JPEG|*.jpeg|PNG|*.png";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string path = openFile.FileName;
                pcbImage.Image = Image.FromFile(path);
                _photoName = System.IO.Path.GetFileNameWithoutExtension(path);
            }
        }
        private void btnProductSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            string sql, sqltblInventoryWarehouse = "";
            string showMessage = "";

            try
            {
                _nameKh = txtNameKh.Text;
                _nameEn = txtNameEn.Text;
                _brand = txtBrand.Text;
                _code = txtCode.Text;
                _serialNumber = txtSerialNumber.Text;
                _description = rtbDescription.Text;
                _problemDescription = rtbProblemDescription.Text;
                _quantity = Convert.ToInt16(cboQuantity.Text);
                if (cbProblem.Checked)
                {
                    _checkProblem = true;
                }
                if (cbQuantityCustom.Checked)
                {
                    _quantity = Convert.ToInt16(txtQuantity.Text);
                }
                _idLocation = Convert.ToInt16(cboLocation.SelectedValue);
                _idRoom = Convert.ToInt16(cboRoom.SelectedValue);
                _idProduct = Convert.ToInt16(cboProduct.SelectedValue);
                if (!string.IsNullOrEmpty(_photoName))
                {
                    _Image = Utilities.saveImage(pcbImage, "./Image/Product/", _photoName, ".jpg");
                    _Image = System.IO.Path.GetFileName(_Image);
                }

                if (!string.IsNullOrEmpty(txtNameEn.Text) || !string.IsNullOrEmpty(txtNameKh.Text))
                {
                    if (cboLocation.SelectedIndex > 0 && cboRoom.SelectedIndex > 0 && cboProduct.SelectedIndex > 0)
                    {
                        if (_save == true)
                        {
                            //sql = "INSERT INTO tblInventoryItem VALUES('" + _nameEn + "','" + _nameKh + "','" + _Image + "','" + _serialNumber + "','" + _description + "','" + _checkProblem + "','" + _problemDescription + "'," + 1 + ",GETDATE(),NULL,'" + _idLocation + "','" + _idRoom + "','" + _idProduct + "','" + Database._idUser + "')";
                            Database.executeProce("spWarehouse", new Dictionary<string, object>() {
                            {"nameEn",_nameEn },
                            {"nameKh",_nameKh},
                            {"image",_Image },
                            {"brand", _brand},
                            {"code", _code},
                            {"serialNumber",_serialNumber },
                            {"description",_description },
                            {"problemDescription",_problemDescription },
                            {"idLocation",_idLocation },
                            {"idRoom",_idRoom },
                            {"idProduct",_idProduct },
                            {"quantity",_quantity },
                            {"checkProblem",_checkProblem },
                            {"idUser",Database._idUser }
                            });
                                showMessage = "Create product was success";
                        }
                        else
                        {
                            sql = "UPDATE tblInventoryItem SET itemNameEng=N'" + _nameEn + "', itemNameKh=N'" + _nameKh + "',itemImage='" + _Image + "',itemBrand='" + _brand + "',itemCode='" + _code + "',itemSerialNumber='" + _serialNumber + "',itemDescription=N'" + _description + "',itemProblem='" + _checkProblem + "',itemProblemDescrtiption=N'" + _problemDescription + "',idLocation=" + _idLocation + ",idRoom=" + _idRoom + ",idProduct=" + _idProduct + " WHERE idItem=" + _idItem + "";
                            sqltblInventoryWarehouse = "UPDATE tblInventoryWarehouse SET warehouseQuantity=" + _quantity + " WHERE idItem=" + _idItem + "";
                            showMessage = "Update user was success";
                            Database.executeSql(sql);
                            Database.executeSql(sqltblInventoryWarehouse);
                        }
                        //Setting.frmUser.reload = true;
                        frmStockIn._reload = true;
                        MsgBox.msgLoad("success", showMessage);
                        Utilities.clearControl(new Control[] { txtNameEn, txtNameKh, txtQuantity, txtSerialNumber });
                    }
                    else
                    {
                        MsgBox.msgLoad("error", "Please select Location , Room and Product first");
                    }
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

        public void cboLocationLoad()
        {
            Utilities.bindCombo(Database.getData("SELECT idLocation,locationName FROM tblInventoryLocation WHERE locationStatus=1"), cboLocation, "locationName", "idLocation", "[ Choose one ]", true);
        }
        public void cboRoomLoad()
        {
            Utilities.bindCombo(Database.getData("SELECT idRoom,roomName FROM tblInventoryRoom WHERE roomStatus=1"), cboRoom, "roomName", "idRoom", "[ Choose one ]", true);
        }
        public void cboProductLoad()
        {
            Utilities.bindCombo(Database.getData("SELECT idProduct,productName FROM tblInventoryProduct WHERE productStatus=1"), cboProduct, "productName", "idProduct", "[ Choose one ]", true);
        }
        private void cboLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectIndex = Convert.ToInt16(cboLocation.SelectedValue);
                if (selectIndex == -1)
                {
                    frmCuttingPattern _frmCuttingPattern = new frmCuttingPattern();
                    _frmCuttingPattern._saveFor = "Location";
                    _frmCuttingPattern.ShowDialog();
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
                    frmCuttingPattern _frmCuttingPattern = new frmCuttingPattern();
                    _frmCuttingPattern._saveFor = "Room";
                    _frmCuttingPattern.ShowDialog();
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

        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectIndex = Convert.ToInt16(cboProduct.SelectedValue);
                if (selectIndex == -1)
                {
                    frmCuttingPattern _frmCuttingPattern = new frmCuttingPattern();
                    _frmCuttingPattern._saveFor = "Product";
                    _frmCuttingPattern.ShowDialog();
                    if (MsgBox._resultYes)
                    {
                        cboProductLoad();
                    }
                    MsgBox._resultYes = false;
                }
            }
            catch (Exception ex)
            {

                MsgBox.msgLoad("error", ex.Message);
            }
        }
    }
}