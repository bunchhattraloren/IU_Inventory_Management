namespace IU_Inventory_Management.StockIn
{
    partial class frmStaffStockIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStaffStockIn));
            this.gdcStaff = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsStockIn = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDetailStockIn = new System.Windows.Forms.ToolStripMenuItem();
            this.gdvStaff = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnAddStockIn = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btnDetailStockIn = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
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
            this.gdcStaff.Size = new System.Drawing.Size(1150, 442);
            this.gdcStaff.TabIndex = 5;
            this.gdcStaff.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvStaff});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsStockIn,
            this.cmsDetailStockIn});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // cmsStockIn
            // 
            this.cmsStockIn.Name = "cmsStockIn";
            this.cmsStockIn.Size = new System.Drawing.Size(152, 22);
            this.cmsStockIn.Text = "StockIn";
            this.cmsStockIn.Click += new System.EventHandler(this.cmsStockIn_Click);
            // 
            // cmsDetailStockIn
            // 
            this.cmsDetailStockIn.Name = "cmsDetailStockIn";
            this.cmsDetailStockIn.Size = new System.Drawing.Size(152, 22);
            this.cmsDetailStockIn.Text = "Detail StockIn";
            this.cmsDetailStockIn.Click += new System.EventHandler(this.cmsDetailStockIn_Click);
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
            this.btnAddStockIn,
            this.btnDetailStockIn});
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAddStockIn),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDetailStockIn)});
            this.bar1.Text = "Tools";
            // 
            // btnAddStockIn
            // 
            this.btnAddStockIn.Caption = "StockIn";
            this.btnAddStockIn.Id = 0;
            this.btnAddStockIn.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAddStockIn.ImageOptions.LargeImage")));
            this.btnAddStockIn.Name = "btnAddStockIn";
            this.btnAddStockIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddStockIn_ItemClick);
            // 
            // btnDetailStockIn
            // 
            this.btnDetailStockIn.Caption = "Detail StockIn";
            this.btnDetailStockIn.Id = 1;
            this.btnDetailStockIn.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDetailStockIn.ImageOptions.LargeImage")));
            this.btnDetailStockIn.Name = "btnDetailStockIn";
            this.btnDetailStockIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDetailStockIn_ItemClick);
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
            this.barDockControlTop.Size = new System.Drawing.Size(1150, 49);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 491);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1150, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 49);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 442);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1150, 49);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 442);
            // 
            // frmStaffStockIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 514);
            this.Controls.Add(this.gdcStaff);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmStaffStockIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StaffStockIn";
            this.Load += new System.EventHandler(this.frmStaffStockIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdcStaff)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdvStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gdcStaff;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cmsStockIn;
        private System.Windows.Forms.ToolStripMenuItem cmsDetailStockIn;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvStaff;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarLargeButtonItem btnAddStockIn;
        private DevExpress.XtraBars.BarLargeButtonItem btnDetailStockIn;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}