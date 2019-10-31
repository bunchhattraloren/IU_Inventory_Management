namespace IU_Inventory_Management.StockOut
{
    partial class frmStaff
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStaff));
            this.gdcStaff = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsStockOut = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDetailStockOut = new System.Windows.Forms.ToolStripMenuItem();
            this.gdvStaff = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnAddStockOut = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnDetailStockOut = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnRefuse = new DevExpress.XtraBars.BarLargeButtonItem();
            this.cmsRefuse = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gdcStaff)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gdcStaff
            // 
            this.gdcStaff.ContextMenuStrip = this.contextMenuStrip1;
            this.gdcStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdcStaff.Location = new System.Drawing.Point(0, 49);
            this.gdcStaff.MainView = this.gdvStaff;
            this.gdcStaff.Name = "gdcStaff";
            this.gdcStaff.Size = new System.Drawing.Size(777, 343);
            this.gdcStaff.TabIndex = 0;
            this.gdcStaff.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvStaff});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsStockOut,
            this.cmsDetailStockOut,
            this.cmsRefuse});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(157, 92);
            // 
            // cmsStockOut
            // 
            this.cmsStockOut.Name = "cmsStockOut";
            this.cmsStockOut.Size = new System.Drawing.Size(156, 22);
            this.cmsStockOut.Text = "StockOut";
            this.cmsStockOut.Click += new System.EventHandler(this.cmsStockOut_Click);
            // 
            // cmsDetailStockOut
            // 
            this.cmsDetailStockOut.Name = "cmsDetailStockOut";
            this.cmsDetailStockOut.Size = new System.Drawing.Size(156, 22);
            this.cmsDetailStockOut.Text = "Detail StockOut";
            this.cmsDetailStockOut.Click += new System.EventHandler(this.cmsDetailStockOut_Click);
            // 
            // gdvStaff
            // 
            this.gdvStaff.GridControl = this.gdcStaff;
            this.gdvStaff.Name = "gdvStaff";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAddStockOut,
            this.btnDetailStockOut,
            this.btnRefuse});
            this.barManager1.MaxItemId = 3;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddStockOut),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDetailStockOut),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefuse)});
            this.bar1.Text = "Tools";
            // 
            // btnAddStockOut
            // 
            this.btnAddStockOut.Caption = "StockOut";
            this.btnAddStockOut.Id = 0;
            this.btnAddStockOut.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAddStockOut.ImageOptions.LargeImage")));
            this.btnAddStockOut.Name = "btnAddStockOut";
            this.btnAddStockOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddStockOut_ItemClick);
            // 
            // btnDetailStockOut
            // 
            this.btnDetailStockOut.Caption = "Detail StockOut";
            this.btnDetailStockOut.Id = 1;
            this.btnDetailStockOut.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDetailStockOut.ImageOptions.LargeImage")));
            this.btnDetailStockOut.Name = "btnDetailStockOut";
            this.btnDetailStockOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDetailStockOut_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(777, 49);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 392);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(777, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 49);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 343);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(777, 49);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 343);
            // 
            // btnRefuse
            // 
            this.btnRefuse.Caption = "Detail Refuse";
            this.btnRefuse.Id = 2;
            this.btnRefuse.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barLargeButtonItem1.ImageOptions.LargeImage")));
            this.btnRefuse.Name = "btnRefuse";
            this.btnRefuse.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefuse_ItemClick);
            // 
            // cmsRefuse
            // 
            this.cmsRefuse.Name = "cmsRefuse";
            this.cmsRefuse.Size = new System.Drawing.Size(156, 22);
            this.cmsRefuse.Text = "Detail Refuse";
            this.cmsRefuse.Click += new System.EventHandler(this.cmsRefuse_Click);
            // 
            // frmStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 415);
            this.Controls.Add(this.gdcStaff);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Staff";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmStaff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdcStaff)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdvStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gdcStaff;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvStaff;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cmsStockOut;
        private System.Windows.Forms.ToolStripMenuItem cmsDetailStockOut;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarLargeButtonItem btnAddStockOut;
        private DevExpress.XtraBars.BarLargeButtonItem btnDetailStockOut;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarLargeButtonItem btnRefuse;
        private System.Windows.Forms.ToolStripMenuItem cmsRefuse;
    }
}