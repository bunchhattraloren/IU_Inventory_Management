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
using System.Data.SqlClient;

namespace IU_Inventory_Management.Setting
{
    public partial class frmConfigure : DevExpress.XtraEditors.XtraForm
    {
        public frmConfigure()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private SqlConnection con;
        public static bool status = false;
        private string connectionString = string.Empty;
        private void btnTest_Click(object sender, EventArgs e)
        {
            if (chkIntegrated.Checked)
            {
                //Check NULL/Empty
                if (Utilities.isNull(new Control[] { txtServer, txtDatabase }))
                {
                    MsgBox.msgLoad("error", "Not allow null or empty!");
                    return;
                }
            }
            else
            {
                //Check NULL/Empty
                if (Utilities.isNull(new Control[] { txtServer, txtDatabase, txtUsername, txtPassword }))
                {
                    MsgBox.msgLoad("error", "Not allow null or empty!");
                    return;
                }
            }
            if (!chkIntegrated.Checked)
                connectionString = string.Format("Data Source={0};Initial Catalog={1};User Id={2};Password={3}", txtServer.Text, txtDatabase.Text, txtUsername.Text, txtPassword.Text);
            else
                connectionString = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", txtServer.Text, txtDatabase.Text);
            try
            {
                con = new SqlConnection(connectionString);
                con.Open(); status = true;
                MsgBox.msgLoad("success", "Connection Success!");
            }
            catch (Exception ex)
            {
                status = false;
                MsgBox.msgLoad("error", ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!status)
            {
                MsgBox.msgLoad("error", "Not yet test connection!");
                return;
            }
            System.IO.StreamWriter sw = new System.IO.StreamWriter(@"connectionString.txt");
            sw.WriteLine(connectionString);
            sw.Close();
            this.Close();
        }
    }
}