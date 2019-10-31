namespace IU_Inventory_Management
{
    partial class frmImageView
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
            this.pcbImageView = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbImageView)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbImageView
            // 
            this.pcbImageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbImageView.Location = new System.Drawing.Point(0, 0);
            this.pcbImageView.Name = "pcbImageView";
            this.pcbImageView.Size = new System.Drawing.Size(937, 609);
            this.pcbImageView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbImageView.TabIndex = 0;
            this.pcbImageView.TabStop = false;
            // 
            // frmImageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 609);
            this.Controls.Add(this.pcbImageView);
            this.Name = "frmImageView";
            this.Text = "frmImageView";
            ((System.ComponentModel.ISupportInitialize)(this.pcbImageView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbImageView;
    }
}