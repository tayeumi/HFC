using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data;
using Microsoft.Office.Interop.Excel;
using System.IO;


namespace HFC.Class
{  
    public class App
    {
        public static string media = string.Empty;
        public static int checkSV = 0;
        public static string client_User="";
        public static string _manv = "";
        public static string _hotennv = "Nguyen Van A";
        public static System.Data.DataTable dtPermision;
        public static int Wait=0;

        ///Class Kiem tra form dang duoc active hay khong

        public static bool IsFocusForm(Type type, Form frmParent)
        {
            int i = 0;
            if (frmParent == null) return false;
            foreach (Form frm in frmParent.MdiChildren)
            {
                if (frm.GetType() == type)
                {
                    if (frm.MinimizeBox)
                    {
                        frm.Focus();
                        frm.WindowState = FormWindowState.Normal;
                    }
                    frm.Focus();
                    return true;
                }
                else
                {
                    i++;
                }

            }
            if (i != 0)
                return false;
            return false;
        }

        /// <summary>
        /// Save Successfully
        /// </summary>
        public static void SaveSuccessfully()
        {
            MessageBox.Show("Lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Save Not Successfully
        /// </summary>
        public static void SaveNotSuccessfully()
        {
            MessageBox.Show("Lưu không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Delete Confirmation
        /// </summary>
        public static DialogResult ConfirmDeletion()
        {
            return MessageBox.Show("Bạn có chắc chắn muốn xoá hay không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult ConfirmDeletionMulti()
        {
            return MessageBox.Show("Bạn đang chọn nhiều hơn 1 dòng để xóa. bạn thực sự muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult ConfirmDeletion(string msb)
        {
            return MessageBox.Show(msb, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult DeleteSuccessfully()
        {
            return MessageBox.Show("Xoá thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult DeleteSuccessfully(string msg)
        {
            return MessageBox.Show("Xoá thành công."+ msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult DeleteNotSuccessfully()
        {
            return MessageBox.Show("Xoá không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Delete Confirmation
        /// </summary>
        public static DialogResult ConfirmChangedData()
        {
            return MessageBox.Show("Dữ liệu đã thay đổi, bạn có muốn lưu hay không ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult InputNotAccess()
        {
            return MessageBox.Show("(*) Dữ liệu bạn nhập chưa đủ, Vui lòng nhập lại.!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static string EncryptString(string Message, string Passphrase)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            // Buoc 1: Bam chuoi su dung MD5
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));
            // Step 2. Tao doi tuong TripleDESCryptoServiceProvider moi
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            // Step 3. Cai dat bo ma hoa
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            // Step 4. Convert chuoi (Message) thanh dang byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(Message);
            // Step 5. Ma hoa chuoi
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Xoa moi thong tin ve Triple DES va HashProvider de dam bao an toan
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            // Step 6. Tra ve chuoi da ma hoa bang thuat toan Base64
            return Convert.ToBase64String(Results);
        }

        public static string DecryptString(string Message, string Passphrase)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            // Step 1. Bam chuoi su dung MD5
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));
            // Step 2. Tao doi tuong TripleDESCryptoServiceProvider moi
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            // Step 3. Cai dat bo giai ma
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            // Step 4. Convert chuoi (Message) thanh dang byte[]
            byte[] DataToDecrypt = Convert.FromBase64String(Message);
            // Step 5. Bat dau giai ma chuoi
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                // Xoa moi thong tin ve Triple DES va HashProvider de dam bao an toan
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            // Step 6. Tra ve ket qua bang dinh dang UTF8
            return UTF8.GetString(Results);
        }
        //
        public static string ChuyenSo(string number)
        {
            string[] dv = { "", "mươi", "trăm", "nghìn", "triệu", "tỉ" };
            string[] cs = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string doc;
            int i, j, k, n, len, found, ddv, rd;

            len = number.Length;
            number += "ss";
            doc = "";
            found = 0;
            ddv = 0;
            rd = 0;

            i = 0;
            while (i < len)
            {
                //So chu so o hang dang duyet
                n = (len - i + 2) % 3 + 1;

                //Kiem tra so 0
                found = 0;
                for (j = 0; j < n; j++)
                {
                    if (number[i + j] != '0')
                    {
                        found = 1;
                        break;
                    }
                }

                //Duyet n chu so
                if (found == 1)
                {
                    rd = 1;
                    for (j = 0; j < n; j++)
                    {
                        ddv = 1;
                        switch (number[i + j])
                        {
                            case '0':
                                if (n - j == 3) doc += cs[0] + " ";
                                if (n - j == 2)
                                {
                                    if (number[i + j + 1] != '0') doc += "lẻ ";
                                    ddv = 0;
                                }
                                break;
                            case '1':
                                if (n - j == 3) doc += cs[1] + " ";
                                if (n - j == 2)
                                {
                                    doc += "mười ";
                                    ddv = 0;
                                }
                                if (n - j == 1)
                                {
                                    if (i + j == 0) k = 0;
                                    else k = i + j - 1;

                                    if (number[k] != '1' && number[k] != '0')
                                        doc += "mốt ";
                                    else
                                        doc += cs[1] + " ";
                                }
                                break;
                            case '5':
                                if (i + j == len - 1)
                                    doc += "lăm ";
                                else
                                    doc += cs[5] + " ";
                                break;
                            default:
                                doc += cs[(int)number[i + j] - 48] + " ";
                                break;
                        }

                        //Doc don vi nho
                        if (ddv == 1)
                        {
                            doc += dv[n - j - 1] + " ";
                        }
                    }
                }


                //Doc don vi lon
                if (len - i - n > 0)
                {
                    if ((len - i - n) % 9 == 0)
                    {
                        if (rd == 1)
                            for (k = 0; k < (len - i - n) / 9; k++)
                                doc += "tỉ ";
                        rd = 0;
                    }
                    else
                        if (found != 0) doc += dv[((len - i - n + 1) % 9) / 3 + 2] + " ";
                }

                i += n;
            }

            if (len == 1)
                if (number[0] == '0' || number[0] == '5') return cs[(int)number[0] - 48];

            doc = doc.Replace("  ", " ");
            doc = doc.Replace("  ", " ");
            doc = doc.Replace("mươi năm", "mươi lăm");
            doc = doc.Replace("mười năm", "mười lăm");
            return doc;
        }

       
        /*
        public static void Excel_FromDataTable(System.Data.DataTable dt, string filename)
        {
            // Create an Excel object and add workbook...
            Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Application.Workbooks.Add(true); // true for object template???
            // Add column headings...
            int iCol = 0;
            foreach (DataColumn c in dt.Columns)
            {
                iCol++;
                excel.Cells[1, iCol] = c.ColumnName;
            }
            // for each row of data...
            int iRow = 0;
            foreach (DataRow r in dt.Rows)
            {
                iRow++;
                // add each row's cell data...
                iCol = 0;
                foreach (DataColumn c in dt.Columns)
                {
                    if (c.ColumnName == "Photo")
                    {
                        iCol++;
                        excel.Cells[iRow + 1, iCol] = null;
                    }
                    else
                    {
                        iCol++;
                        excel.Cells[iRow + 1, iCol] = r[c.ColumnName];
                    }
                }
            }
            // Global missing reference for objects we are not defining...
            object missing = System.Reflection.Missing.Value;
            // If wanting to Save the workbook...
            workbook.SaveAs(filename,
                Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, missing, missing,
                false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                missing, missing, missing, missing, missing);
            // If wanting to make Excel visible and activate the worksheet...
            excel.Visible = true;
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;
            ((Microsoft.Office.Interop.Excel._Worksheet)worksheet).Activate();
            // If wanting excel to shutdown...
            //((Microsoft.Office.Interop.Excel._Application)excel).Quit();
        }

        */
        /*
        public static void exportToExcel(System.Data.DataSet dsTable, string fileName, string[] SheetNames)
        {

            Microsoft.Office.Interop.Excel.Application xlApp =
             new Microsoft.Office.Interop.Excel.Application();
            Sheets xlSheets = null; Workbook xlWorkbook = null;
            Worksheet xlWorksheet = null;
            int sheetno = 1;
            xlWorkbook = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            xlSheets = xlWorkbook.Sheets;
            //xlWorksheet = new Worksheet();
            xlWorksheet = (Worksheet)xlSheets.Add(xlSheets[1],
                        Type.Missing, Type.Missing, Type.Missing);
            xlWorksheet.Name = Convert.ToString(SheetNames[0]);
            foreach (System.Data.DataTable dTable in dsTable.Tables)
            {

                System.Data.DataTable dataTable = dTable;
                int rowNo = dataTable.Rows.Count;
                int columnNo = dataTable.Columns.Count;
                int colIndex = 0;

                if (sheetno >= 2)
                {

                    xlWorksheet = (Worksheet)xlSheets.Add(xlSheets[1],
                       Type.Missing, Type.Missing, Type.Missing);
                    xlWorksheet.Name = Convert.ToString(SheetNames[1]);

                }

                sheetno++;
                //Generate Field Names
                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    colIndex++;
                    xlApp.Cells[1, colIndex] = dataColumn.ColumnName;
                }

                object[,] objData = new object[rowNo, columnNo];

                //Convert DataSet to Cell Data
                for (int row = 0; row < rowNo; row++)
                {
                    for (int col = 0; col < columnNo; col++)
                    {
                        objData[row, col] = dataTable.Rows[row][col];
                    }
                }

                //Add the Data
                Range range = xlWorksheet.Range[xlApp.Cells[2, 1], xlApp.Cells[rowNo + 1, columnNo]];
                range.Value2 = objData;

                //Format Data Type of Columns 
                colIndex = 0;
                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    colIndex++;
                    string format = "@";
                    switch (dataColumn.DataType.Name)
                    {
                        case "Boolean":
                            break;
                        case "Byte":
                            break;
                        case "Char":
                            break;
                        case "DateTime":
                            format = "dd/mm/yyyy";
                            break;
                        case "Decimal":
                            format = "$* #,##0.00;[Red]-$* #,##0.00";
                            break;
                        case "Double":
                            break;
                        case "Int16":
                            format = "0";
                            break;
                        case "Int32":
                            format = "0";
                            break;
                        case "Int64":
                            format = "0";
                            break;
                        case "SByte":
                            break;
                        case "Single":
                            break;
                        case "TimeSpan":
                            break;
                        case "UInt16":
                            break;
                        case "UInt32":
                            break;
                        case "UInt64":
                            break;
                        default: //String
                            break;
                    }
                    //Format the Column accodring to Data Type
                    xlWorksheet.Range[xlApp.Cells[2, colIndex],
                          xlApp.Cells[rowNo + 1, colIndex]].NumberFormat = format;
                }
            }

            //Remove the Default Worksheet
            ((Worksheet)xlApp.ActiveWorkbook.Sheets[xlApp.ActiveWorkbook.Sheets.Count]).Delete();
            if (File.Exists(fileName))
                File.Delete(fileName);
            //Save
            xlWorkbook.Saved = true;
            xlWorkbook.SaveCopyAs(fileName);
            xlWorkbook.Close(null, null, null);

            xlApp.Quit();
            GC.Collect();
        }   
         */

        public static void Log_Write(string logline)
        {
            TextWriter sw = new StreamWriter(@"DB_log.txt", true);
            sw.WriteLine(DateTime.Now +" : " + logline);
            sw.Close();
        }

        public static void Log_WriteApp(string logline)
        {
            TextWriter sw = new StreamWriter(@"App_log.txt", true);
            sw.WriteLine(DateTime.Now + " : " + logline);
            sw.Close();
        }
    }
}
