using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using DevExpress.XtraGrid.Views.Card;
using System.Security.Cryptography;
using System.IO;
using DevExpress.XtraReports.UI;
//using Microsoft.Reporting.WinForms;
namespace IU_Inventory_Management
{
    class Utilities
    {

        public static void bindGrid(DataTable dt, GridControl gc)
        {
            gc.DataSource = dt;
        }
        public static void bindCombo(DataTable dt, System.Windows.Forms.ComboBox cbo, string display, string value, string selectString, bool AllowAdd)
        {
            int RowToInsert = 0;
            DataRow drow;
            if (!string.IsNullOrEmpty(selectString))
            {
                drow = dt.NewRow();
                drow[value] = 0;
                drow[display] = selectString;
                dt.Rows.InsertAt(drow, RowToInsert);
                RowToInsert += 1;
            }
            if (AllowAdd)
            {
                drow = dt.NewRow();
                drow[value] = -1;
                drow[display] = "< Add New >";
                dt.Rows.InsertAt(drow, RowToInsert);
                RowToInsert += 1;
            }
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.DataSource = dt;
        }
        
        public static void clearControl(Control[] ctrs, string focus = "")
        {
            foreach (Control ctr in ctrs)
            {
                if (ctr is TextBox)
                    ctr.Text = string.Empty;
                if (ctr is TextEdit)
                    ctr.Text = string.Empty;
                if (ctr is System.Windows.Forms.ComboBox)
                    ((System.Windows.Forms.ComboBox)ctr).SelectedIndex = -1;
                if (ctr is DateTimePicker)
                    ((DateTimePicker)ctr).Value = DateTime.Now;
                if (ctr is PictureEdit)
                    ((PictureEdit)ctr).Image = null;
                if (ctr is PictureBox)
                    ((PictureBox)ctr).Image = null;
                if (ctr is RadioButton)
                    ((RadioButton)ctr).Checked = false;
                if (ctr is CheckBox)
                    ((CheckBox)ctr).Checked = false;
                if (ctr.Name.Equals(focus))
                    ctr.Select();
            }
        }

        static string hash = "9neal";
        public static string Encrypt(string Encrypt)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(Encrypt);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    Encrypt = Convert.ToBase64String(results, 0, results.Length);
                }

            }
            return Encrypt;
        }
        public static string Decrypt(string Decrypt)
        {
            byte[] data = Convert.FromBase64String(Decrypt);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    Decrypt = UTF8Encoding.UTF8.GetString(results);
                }
            }
            return Decrypt;
        }
        public static bool isNull(Control[] ctrs)
        {
            bool b = false;
            foreach (Control ctr in ctrs)
            {
                if (ctr is TextBox)
                    if (string.IsNullOrEmpty(ctr.Text))
                    {
                        ctr.Select();
                        b = true;
                        break;
                    }
                if (ctr is System.Windows.Forms.ComboBox)
                    if (((System.Windows.Forms.ComboBox)ctr).SelectedIndex == -1)
                    {
                        b = true;
                        break;
                    }
            }
            return b;
        }
       
        public static string saveImage(PictureEdit pcbPohot,string path,string photoName,string extension)
        {
            string fileToSaveAs = path + photoName + "_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + extension;
            if (extension == ".jpg")
            {
                pcbPohot.Image.Save(fileToSaveAs, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else
            {
                pcbPohot.Image.Save(fileToSaveAs, System.Drawing.Imaging.ImageFormat.Png);
            }
            return fileToSaveAs;
        }
        public static void xtraReportView(string pathXtraReport, DataTable dataSourceXtraReport = null, Dictionary<string, object> param = null, string dataMemberXtraReport = null)
        {
            XtraReport report = new XtraReport();
            report = XtraReport.FromFile(Application.StartupPath + @"\Report\" + pathXtraReport + ".repx", true);
            if (dataSourceXtraReport != null)
            {
                report.DataSource = dataSourceXtraReport;
            }
            if (param != null)
            {
                foreach (string key in param.Keys)
                {
                    report.Parameters[key].Value = param[key];
                }
            }
            if (dataMemberXtraReport != null)
            {
                report.DataMember = dataMemberXtraReport;
            }else
            {
                report.DataMember = "ValidDataMember";
            }
            report.ShowPreviewDialog();
        }
    //    Public Sub xtraReportShow(pathXtrareport As String, Optional ByVal dataSourceXtraReport As DataTable = Nothing, Optional ByVal paramXtraReport As Dictionary(Of String, Object) = Nothing, Optional ByVal dataMemberXtraReport As String = Nothing)
    //    Dim xtrReport As New XtraReport
    //    xtrReport = XtraReport.FromFile(Application.StartupPath & "\Report\" & pathXtrareport, True)
    //    If dataSourceXtraReport IsNot Nothing Then
    //        xtrReport.DataSource = dataSourceXtraReport
    //    End If

    //    If paramXtraReport IsNot Nothing Then
    //        For Each param As String In paramXtraReport.Keys
    //            xtrReport.Parameters(param).Value = paramXtraReport(param)
    //        Next
    //    End If

    //    If dataMemberXtraReport IsNot Nothing Then
    //        xtrReport.DataMember = dataMemberXtraReport
    //    Else
    //        xtrReport.DataMember = "ValidDataMember"
    //    End If
    //    xtrReport.ShowPreviewDialog()
    //End Sub
        //public static void reportView(ReportViewer reportViewer, string rptName, Dictionary<string, DataTable> rep, DataTable dt)
        //{
        //    try
        //    {
        //        reportViewer.LocalReport.ReportEmbeddedResource = rptName;
        //        reportViewer.LocalReport.DataSources.Clear();
        //        foreach (string str in rep.Keys)
        //        {
        //            ReportDataSource rps = new ReportDataSource(str, rep[str]);
        //            reportViewer.LocalReport.DataSources.Add(rps);
        //        }
        //        // reportViewer.LocalReport.SetParameters(rpt);

        //        //string pathBin = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        //        //string imageUrl = pathBin + @".\images\ANT_Logo.png";
        //        //ReportParameter pName = new ReportParameter("antLogo", new Uri(imageUrl).AbsoluteUri);
        //        ReportParameter pNameAntLogo = new ReportParameter("antLogo", new Uri(Application.StartupPath + @".\images\ANT_Logo.png").AbsoluteUri);
        //        ReportParameter pNamePicture = new ReportParameter("images", new Uri(Application.StartupPath).AbsoluteUri);
        //        reportViewer.LocalReport.EnableExternalImages = true;
        //        reportViewer.LocalReport.SetParameters(new ReportParameter[] { pNameAntLogo, pNamePicture });

        //        reportViewer.RefreshReport();
        //    }
        //    catch (Exception ex)
        //    {

        //        MsgBox.msgLoad("error", ex.Message);
        //    }
        //}
    }
}
