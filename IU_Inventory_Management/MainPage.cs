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

namespace IU_Inventory_Management
{
    public partial class MainPage : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainPage()
        {
            InitializeComponent();
            //this.btnRoom.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRoom.ImageOptions.Image")));
            //this.btnRoom.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRoom.ImageOptions.LargeImage")));

        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            bliConnectionString.Caption = Database._userName;
        }
        private void btnWarehouse_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }
        public void viewChidForm(Form form)
        {

            if (!IsFormActived(form))
            {
                form.MdiParent = this;
                form.Show();
            }
        }
        public bool IsFormActived(Form form)
        {
            bool IsOpened = false;
            if (MdiChildren.Count() > 0)
            {
                foreach (var item in MdiChildren)
                {
                    if (form.Name == item.Name)
                    {
                        xtraTabbedMdiManager1.Pages[item].MdiChild.Activate();
                        IsOpened = true;
                    }
                }
            }
            return IsOpened;
        }

        private void btnUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            viewChidForm(new Setting.frmUser());
        }

        private void btnStaff_ItemClick(object sender, ItemClickEventArgs e)
        {
            viewChidForm(new StockOut.frmStaff());
        }

        private void btnWarehouse_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            viewChidForm(new Warehouse.frmWarehouse());
        }

        private void btnStockOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            viewChidForm(new StockOut.frmStockOut());
        }

        private void btnLocation_ItemClick(object sender, ItemClickEventArgs e)
        {
            viewChidForm(new Warehouse.frmLocation());
        }

        private void btnRoom_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            viewChidForm(new Warehouse.frmRoom());
        }
        private void btnProduct_ItemClick(object sender, ItemClickEventArgs e)
        {
            viewChidForm(new Warehouse.frmProduct());
        }

        private void btnCategory_ItemClick(object sender, ItemClickEventArgs e)
        {
            viewChidForm(new Warehouse.frmCategory());
        }

        private void btnStockIn_ItemClick(object sender, ItemClickEventArgs e)
        {
            viewChidForm(new Warehouse.frmStockIn());
        }
        bool isLogOut = false;
        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            isLogOut = true;
            this.Close();
            frmLogin _frmLogin = new frmLogin();
            _frmLogin.Show();
        }

        private void MainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isLogOut == false)
            {
                if (MsgBox._resultYes)
                {
                    Application.Exit();
                }
            }
            
        }

        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isLogOut == false)
            {
                MsgBox.msgLoad("question", "Do you want to close ?");
                if (!MsgBox._resultYes)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
    }
}