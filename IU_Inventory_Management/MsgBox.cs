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

namespace IU_Inventory_Management
{
    public partial class MsgBox : DevExpress.XtraEditors.XtraForm
    {
        public MsgBox(string icon, string message)
        {
            InitializeComponent();
            btnClose.Visible = false;
            _question = false;
            if (icon == "success")
            {
                picIcon.Image = Properties.Resources.checkmark;
            }
            else if (icon == "search")
            {
                picIcon.Image = Properties.Resources.search;
            }
            else if (icon == "question")
            {
                picIcon.Image = Properties.Resources.question_mark;
                btnClose.Visible = true;
                _question = true;
            }
            else
            {
                picIcon.Image = Properties.Resources.error;
            }
            lblMessage.Text = message;
            btnClose.ImageOptions.Image = global::IU_Inventory_Management.Properties.Resources.Delete;
            btnClose.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
        }
        bool _question;
        public static void msgLoad(string icon, string message)
        {
            MsgBox showDialog = new MsgBox(icon, message);
            showDialog.ShowDialog();
        }
        public static bool _resultYes;
        private void btnClick_Click(object sender, EventArgs e)
        {
            if (_question)
            {
                _resultYes = true;
            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}