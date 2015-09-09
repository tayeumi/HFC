using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Reflection;

namespace HFC.Class
{
   public class ExportDataToExcel
    {
        #region Export Excel


        static public void CreateColumnName(DataTable dt, Microsoft.Office.Interop.Excel._Worksheet xlSheet, int pos_row)
        {
            int _ColumnsCount = dt.Columns.Count;
            //set thuoc tinh cho cac header
            Microsoft.Office.Interop.Excel.Range header = xlSheet.get_Range("A" + pos_row.ToString(), Convert.ToChar(_ColumnsCount + 65) + pos_row.ToString());
            header.Select();

            header.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
            header.Font.Bold = true;
            header.Font.Size = 12;

            for (int i = 0; i < dt.Columns.Count; i++)
                xlSheet.Cells[pos_row, i + 1] = dt.Columns[i].ColumnName;

        }

       public static  void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                throw new Exception("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        /// <summary>
        /// Ghi chú
        /// </summary>
        /// <param name="dt">Bảng dữ liệu sẽ xuất ra excel</param>
        /// <param name="pos_row">xuất ra excel từ vị trí dòng này</param>
        /// <param name="pos_column">xuất ra excel từ vị trí cột này</param>
        /// <param name="IsOpen">Xuất xong có mở File ra xem hay không</param>
        /// <param name="sTemplateFile">Đường dẫn đến File Template</param>
        /// <param name="sfilename">Đường dẫn nơi sẽ lưu file</param>
        /// <param name="Show_Column">Có xuất tên cột ra hay không</param>

       public static void ExportExcel(DataTable dt, int pos_row, string pos_column, bool IsOpen, string sTemplateFile, string sfilename, bool Show_Column)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application ReportFile = new Microsoft.Office.Interop.Excel.Application();
                ReportFile.Visible = false;
                Microsoft.Office.Interop.Excel._Workbook WorkBook;
                if (sfilename != "")
                {
                    if (File.Exists(sfilename))
                    {
                        // Configure message box
                        string message = "File đã tồn tại.Bạn muốn lưu chồng lên nó?";
                        string caption = "Thông Báo";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        MessageBoxIcon icon = MessageBoxIcon.Question;
                        // Show message box
                        if (MessageBox.Show(message, caption, buttons, icon, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            File.Copy(sTemplateFile, sfilename, true);
                        }
                    }
                    else
                    {
                        File.Copy(sTemplateFile, sfilename);
                    }
                    WorkBook = (Microsoft.Office.Interop.Excel._Workbook)(ReportFile.Workbooks.Open(sfilename,
                                                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                                Type.Missing, Type.Missing));
                }
                else
                {
                    WorkBook = (Microsoft.Office.Interop.Excel._Workbook)(ReportFile.Workbooks.Add(sTemplateFile));
                }
               Microsoft.Office.Interop.Excel._Worksheet Sheet = (Microsoft.Office.Interop.Excel._Worksheet)WorkBook.ActiveSheet;
              

              //  Microsoft.Office.Interop.Excel._Worksheet Sheet = (Microsoft.Office.Interop.Excel._Worksheet)WorkBook.Sheets;

                //Tinh so luong cot xuat ra
                string MaxColumn = ((String)(Convert.ToChar(dt.Columns.Count / 26 + 64).ToString() + Convert.ToChar(dt.Columns.Count % 26 + 64))).Replace('@', ' ').Trim();
                if (dt.Columns.Count % 26 == 0)
                {
                    MaxColumn = ((String)(Convert.ToChar((dt.Columns.Count) / 26 + 64).ToString() + Convert.ToChar((dt.Columns.Count + 1) % 26 + 64))).Replace('@', ' ').Trim();
                }
                //cac tham so
                int record_count = dt.Rows.Count;
                int record_div = dt.Rows.Count / 1000;
                int record_mod = dt.Rows.Count % 1000;

                string pos_begin1 = pos_column;
                int pos_begin2 = pos_row;

                int Buffer_Size = 100;

                #region move footer
                //move footer
                Microsoft.Office.Interop.Excel.Range srcRange = Sheet.get_Range("A" + (pos_row + 1).ToString(), "AZ" + (pos_row + Buffer_Size + 1).ToString());
                srcRange.Copy(Type.Missing);

                string Cell21 = "A" + (record_count + pos_row + 1 + Buffer_Size).ToString();
                string Cell22 = "AZ" + (record_count + pos_row + 2 * Buffer_Size).ToString();

                Microsoft.Office.Interop.Excel.Range destRange = Sheet.get_Range(Cell21, Cell22);

                Sheet.Paste(destRange, Type.Missing);

                srcRange.Rows.Delete(Microsoft.Office.Interop.Excel.XlDeleteShiftDirection.xlShiftUp);

                //end move footer
                #endregion

                //Xuat cot mac dinh trong table neu Show_Column == true
                if (Show_Column == true)
                {
                    CreateColumnName(dt, Sheet, pos_row);
                    pos_begin2 = pos_row + 1;
                }
                object[,] Array_Record;
                string Cell_Begin, Cell_End;

                if (record_div == 0)    //case record_count<1000
                {
                    Cell_Begin = pos_begin1 + (pos_begin2).ToString();
                    Cell_End = MaxColumn + (record_mod + pos_row - 1).ToString();
                    if (Show_Column == true)
                    {
                        Cell_End = MaxColumn + (record_mod + pos_row).ToString();
                    }
                    Array_Record = new object[record_mod, dt.Columns.Count];
                    for (int l = 0; l < record_mod; l++)
                        for (int m = 0; m < dt.Columns.Count; m++)
                        {
                            Array_Record[l, m] = dt.Rows[l].ItemArray[m];
                        }
                    Sheet.get_Range(Cell_Begin, Cell_End).Value2 = Array_Record;
                    Sheet.get_Range(Cell_Begin, Cell_End).Borders.LineStyle = 1;
                }
                else    //case record_count>1000
                {
                    int pos_end = 1000 + pos_row;
                    int temp = 0;
                    Cell_Begin = pos_begin1 + pos_begin2.ToString();
                    Cell_End = MaxColumn + (pos_end).ToString();
                    for (int i = 0; i < record_div; i++)
                    {
                        Array_Record = new object[1000, dt.Columns.Count];
                        for (int k = temp, l = 0; k < temp + 1000; k++, l++)
                            for (int m = 0; m < dt.Columns.Count; m++)
                            {
                                Array_Record[l, m] = dt.Rows[k].ItemArray[m];
                            }
                        Sheet.get_Range(Cell_Begin, Cell_End).Value2 = Array_Record;
                        Sheet.get_Range(Cell_Begin, Cell_End).Borders.LineStyle = 1;
                        if (i < record_div - 1)
                        {
                            temp += 1000;
                            pos_end += 1000;
                            pos_begin2 += 1000;
                            Cell_Begin = pos_begin1 + pos_begin2.ToString();
                            Cell_End = MaxColumn + pos_end.ToString();
                        }
                    }
                    temp += 1000;
                    pos_end += record_mod;
                    pos_begin2 += 1000;
                    Cell_Begin = pos_begin1 + pos_begin2.ToString();
                    Cell_End = MaxColumn + (pos_end - 1).ToString();
                    if (Show_Column == true)
                    {
                        Cell_End = MaxColumn + pos_end.ToString();
                    }
                    Array_Record = new object[record_mod, dt.Columns.Count];

                    for (int l = 0; l < record_mod; l++)
                        for (int m = 0; m < dt.Columns.Count; m++)
                        {
                            Array_Record[l, m] = dt.Rows[temp + l].ItemArray[m];
                        }
                    Sheet.get_Range(Cell_Begin, Cell_End).Value2 = Array_Record;
                    Sheet.get_Range(Cell_Begin, Cell_End).Borders.LineStyle = 1;
                }
                //save file
                if (sfilename == "")
                {
                    ReportFile.AlertBeforeOverwriting = false;
                    ReportFile.DisplayAlerts = false;
                    ReportFile.Save(Type.Missing);
                    MessageBox.Show("Export Excel Successful !!!");
                }
                else
                {
                    //if (IsOpen)
                    //{
                    //    IsOpen = false;
                    //}
                    WorkBook.Save();
                    MessageBox.Show("Export Excel Successful !!!");
                }

                if (IsOpen)
                {
                    ReportFile.Visible = true;
                    ReportFile.UserControl = true;
                }
                //ReportFile.Quit();
                releaseObject(Sheet);
                releaseObject(WorkBook);
                releaseObject(ReportFile);
                //foreach (Process process in Process.GetProcessesByName("EXCEL"))
                //{
                //    process.Kill();
                //}
            }
            catch (Exception exx)
            {
                string Error = exx.ToString();
            }
        }

       public static void ExportExcel_CTCC(DataTable dt, DataTable dtpb, int pos_row, string pos_column, bool IsOpen, string sTemplateFile, string sfilename, bool Show_Column)
       {
          
               Microsoft.Office.Interop.Excel.Application ReportFile = new Microsoft.Office.Interop.Excel.Application();
               ReportFile.Visible = false;
               Microsoft.Office.Interop.Excel._Workbook WorkBook;
            try
              {
               if (sfilename != "")
               {
                   if (File.Exists(sfilename))
                   {
                       //// Configure message box
                       //string message = "File đã tồn tại.Bạn muốn lưu chồng lên nó?";
                       //string caption = "Thông Báo";
                       //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                       //MessageBoxIcon icon = MessageBoxIcon.Question;
                       //// Show message box
                       //if (MessageBox.Show(message, caption, buttons, icon, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                       //{
                       File.Copy(sTemplateFile, sfilename, true);
                       //}
                   }
                   else
                   {
                       File.Copy(sTemplateFile, sfilename);
                   }
                   WorkBook = (Microsoft.Office.Interop.Excel._Workbook)(ReportFile.Workbooks.Open(sfilename,
                                               Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                               Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                               Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                               Type.Missing, Type.Missing));
               }
               else
               {
                   WorkBook = (Microsoft.Office.Interop.Excel._Workbook)(ReportFile.Workbooks.Add(sTemplateFile));
               }
               Microsoft.Office.Interop.Excel._Worksheet Sheet = (Microsoft.Office.Interop.Excel._Worksheet)WorkBook.ActiveSheet;
               // xu ly xuat theo phong ban
                // begin for phong ban
               DataView dtView = new DataView(dt);
               for (int ii = 0; ii < dtpb.Rows.Count; ii++)
               {
                  
                   dtView.RowFilter = "DepartmentName = '" + dtpb.Rows[ii]["DepartmentName"].ToString() + "'";

                   //  Microsoft.Office.Interop.Excel._Worksheet Sheet = (Microsoft.Office.Interop.Excel._Worksheet)WorkBook.Sheets;

                   //Tinh so luong cot xuat ra
                   string MaxColumn = ((String)(Convert.ToChar(dt.Columns.Count / 26 + 64).ToString() + Convert.ToChar(dt.Columns.Count % 26 + 64))).Replace('@', ' ').Trim();
                   if (dt.Columns.Count % 26 == 0)
                   {
                       MaxColumn = ((String)(Convert.ToChar((dt.Columns.Count) / 26 + 64).ToString() + Convert.ToChar((dt.Columns.Count + 1) % 26 + 64))).Replace('@', ' ').Trim();
                   }
                   //cac tham so
                   int record_count = dtView.Count;
                   int record_mod = record_count;

                   string pos_begin1 = pos_column;
                   int pos_begin2 = pos_row;



                   #region move footer
                   //int Buffer_Size = 100;
                   ////move footer
                   //Microsoft.Office.Interop.Excel.Range srcRange = Sheet.get_Range("A" + (pos_row + 1).ToString(), "AZ" + (pos_row + Buffer_Size + 1).ToString());
                   //srcRange.Copy(Type.Missing);

                   //string Cell21 = "A" + (record_count + pos_row + 1 + Buffer_Size).ToString();
                   //string Cell22 = "AZ" + (record_count + pos_row + 2 * Buffer_Size).ToString();

                   //Microsoft.Office.Interop.Excel.Range destRange = Sheet.get_Range(Cell21, Cell22);

                   //Sheet.Paste(destRange, Type.Missing);

                   //srcRange.Rows.Delete(Microsoft.Office.Interop.Excel.XlDeleteShiftDirection.xlShiftUp);

                   //end move footer
                   #endregion

                   //Xuat cot mac dinh trong table neu Show_Column == true
                   if (Show_Column == true)
                   {
                       CreateColumnName(dt, Sheet, pos_row);
                       pos_begin2 = pos_row + 1;
                   }
                   object[,] Array_Record;
                   string Cell_Begin, Cell_End;

                       Cell_Begin = pos_begin1 + (pos_begin2).ToString();
                       Cell_End = MaxColumn + (record_count + pos_row - 1).ToString();
                       if (Show_Column == true)
                       {
                           Cell_End = MaxColumn + (record_mod + pos_row).ToString();
                       }
                       Array_Record = new object[record_mod, dt.Columns.Count];
                       for (int l = 0; l < record_mod; l++)
                           for (int m = 0; m < dt.Columns.Count; m++)
                           {
                               Array_Record[l, m] = dtView[l][m];
                           }
                       Sheet.get_Range(Cell_Begin, Cell_End).Value2 = Array_Record;
                       Sheet.get_Range(Cell_Begin, Cell_End).Borders.LineStyle = 1;
                    
                   //for (int l = 0; l < record_mod; l++)
                   //        for (int m = 0; m < dt.Columns.Count; m++)
                   //        {
                   //            if (m == 9)
                   //            {
                   //                if (Array_Record[l, m]==DBNull.Value)
                   //                {
                   //                   Sheet.get_Range("J"+l).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkOrange);
                   //                }
                   //            }
                   //        }
                 
                  
                   // copy sheet to new
                   //   Sheet.Copy(WorkBook.Sheets[0], WorkBook.Sheets[1]);
                   //Microsoft.Office.Interop.Excel._Worksheet Sheet2 = (Microsoft.Office.Interop.Excel._Worksheet)WorkBook.Worksheets[2];
                   Sheet.Name = dtpb.Rows[ii]["DepartmentName"].ToString();                   
                   Sheet.Copy(Sheet);
                   
                   // clrear txt
                   Array_Record = new object[record_mod, dt.Columns.Count];
                   for (int l = 0; l < record_mod; l++)
                       for (int m = 0; m < dt.Columns.Count; m++)
                       {
                           Array_Record[l, m] = "";
                       }
                   Sheet.get_Range(Cell_Begin, Cell_End).Value2 = Array_Record;
                   Sheet.get_Range(Cell_Begin, Cell_End).Borders.LineStyle = 0;
                   // end cler text in excel
               }
               // end for phong ban 


               for (int iii = 1; iii < WorkBook.Worksheets.Count; iii++) // xóa số (2) o sheet name
               {
                  Microsoft.Office.Interop.Excel._Worksheet SheetName= (Microsoft.Office.Interop.Excel._Worksheet)WorkBook.Worksheets[iii];
                  string _sheetname = SheetName.Name;
                  _sheetname = _sheetname.Replace("(2)", "");
                  SheetName.Name = _sheetname;
               }
                //save file
               if (sfilename == "")
               {
                   ReportFile.AlertBeforeOverwriting = false;
                   ReportFile.DisplayAlerts = false;
                   ReportFile.Save(Type.Missing);
                   MessageBox.Show("Export Excel Successful !!!");
               }
               else
               {
                   //if (IsOpen)
                   //{
                   //    IsOpen = false;
                   //}
                   WorkBook.Save();
                 //  MessageBox.Show("Export Excel Successful !!!");
               }

               if (IsOpen)
               {
                   ReportFile.Visible = true;
                   ReportFile.UserControl = true;
               }
               //ReportFile.Quit();
               releaseObject(Sheet);
               releaseObject(WorkBook);
               releaseObject(ReportFile);
               //foreach (Process process in Process.GetProcessesByName("EXCEL"))
               //{
               //    process.Kill();
               //}
           }
            catch (Exception ex)
            {
                Class.App.Log_Write(ex.Message);
            }  
       }

       public static void ExportExcel_CTCCByGroup(DataTable dt, DataTable dtpb, DataTable dtgroup, int pos_row, string pos_column, bool IsOpen, string sTemplateFile, string sfilename, bool Show_Column)
       {
           Microsoft.Office.Interop.Excel.Application ReportFile = new Microsoft.Office.Interop.Excel.Application();
           ReportFile.Visible = false;
           Microsoft.Office.Interop.Excel._Workbook WorkBook;
           //Microsoft.Office.Interop.Excel.Range chartRange;
           try
           {
               if (sfilename != "")
               {
                   if (File.Exists(sfilename))
                   {                      
                       File.Copy(sTemplateFile, sfilename, true);                     
                   }
                   else
                   {
                       File.Copy(sTemplateFile, sfilename);
                   }
                   WorkBook = (Microsoft.Office.Interop.Excel._Workbook)(ReportFile.Workbooks.Open(sfilename,
                                               Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                               Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                               Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                               Type.Missing, Type.Missing));
               }
               else
               {
                   WorkBook = (Microsoft.Office.Interop.Excel._Workbook)(ReportFile.Workbooks.Add(sTemplateFile));
               }
               Microsoft.Office.Interop.Excel._Worksheet Sheet = (Microsoft.Office.Interop.Excel._Worksheet)WorkBook.ActiveSheet;
               // xu ly xuat theo phong ban
               // begin for phong ban
               DataView dtView = new DataView(dt);
               DataView dtViewGroup = new DataView(dtgroup);
               for (int ii = 0; ii < dtpb.Rows.Count; ii++)
               {
                   dtView.RowFilter = "DepartmentName = '" + dtpb.Rows[ii]["DepartmentName"].ToString() + "'";
                   // kiem tra trong du lieu group xem co phong ban nay ko
                   dtViewGroup.RowFilter = "DepartmentName = '" + dtpb.Rows[ii]["DepartmentName"].ToString() + "'";
                   if (dtViewGroup.Count > 0)
                   {
                       #region Tim Thay Du lieu
                       for (int tt = 0; tt < dtViewGroup.Count; tt++)
                       {
                           dtView.RowFilter = "DepartmentName = '" + dtpb.Rows[ii]["DepartmentName"].ToString() + "' And GroupName = '" + dtViewGroup[tt]["GroupName"].ToString() + "'";

                           //Tinh so luong cot xuat ra
                           string MaxColumn = ((String)(Convert.ToChar(dt.Columns.Count / 26 + 64).ToString() + Convert.ToChar(dt.Columns.Count % 26 + 64))).Replace('@', ' ').Trim();
                           if (dt.Columns.Count % 26 == 0)
                           {
                               MaxColumn = ((String)(Convert.ToChar((dt.Columns.Count) / 26 + 64).ToString() + Convert.ToChar((dt.Columns.Count + 1) % 26 + 64))).Replace('@', ' ').Trim();
                           }
                           //cac tham so
                           int record_count = dtView.Count;
                           int record_mod = record_count;

                           string pos_begin1 = pos_column;
                           int pos_begin2 = pos_row;

                           object[,] Array_Record;
                           string Cell_Begin, Cell_End;

                           Cell_Begin = pos_begin1 + (pos_begin2).ToString();
                           Cell_End = MaxColumn + (record_count + pos_row - 1).ToString();
                           if (Show_Column == true)
                           {
                               Cell_End = MaxColumn + (record_mod + pos_row).ToString();
                           }
                           Array_Record = new object[record_mod, dt.Columns.Count];
                           for (int l = 0; l < record_mod; l++)
                           {
                               for (int m = 0; m < dt.Columns.Count; m++)
                               {
                                   Array_Record[l, m] = dtView[l][m];                               
                               }
                               // SET MAU KHONG CHAM CONG
                               //if (Array_Record[l, 9] == DBNull.Value)
                               //{
                               //   // Microsoft.Office.Interop.Excel.Range Range = Sheet.get_Range("J" + l, "J" + l);
                               //    // Range.Cells.Interior.Color = System.Drawing.Color.Gainsboro.ToArgb();
                                   
                               //}
                               //if (Array_Record[l, 10] == DBNull.Value)
                               //{
                               //   // Microsoft.Office.Interop.Excel.Range Range = Sheet.get_Range("K" + l, "K" + l);
                               //  //  Range.Cells.Interior.Color = System.Drawing.Color.Gainsboro.ToArgb();

                               //}
                           }
                           Sheet.get_Range(Cell_Begin, Cell_End).Value2 = Array_Record;
                           Sheet.get_Range(Cell_Begin, Cell_End).Borders.LineStyle = 1;

                           Sheet.Name = dtViewGroup[tt]["GroupName"].ToString();
                           Sheet.Copy(Sheet);

                           // clrear txt
                           Array_Record = new object[record_mod, dt.Columns.Count];
                           for (int l = 0; l < record_mod; l++)
                               for (int m = 0; m < dt.Columns.Count; m++)
                               {
                                   Array_Record[l, m] = "";                                 
                               }
                           Sheet.get_Range(Cell_Begin, Cell_End).Value2 = Array_Record;
                           Sheet.get_Range(Cell_Begin, Cell_End).Borders.LineStyle = 0;
                           //Sheet.get_Range(Cell_Begin, Cell_End).Interior.Color = System.Drawing.Color.Transparent.ToArgb();
                           // end cler text in excel

                       }
                       #endregion
                       // xu ly voi du lieu chi phong ban
                          dtView.RowFilter = "DepartmentName = '" + dtpb.Rows[ii]["DepartmentName"].ToString() + "' And GroupName is null";
                          if (dtView.Count > 0)
                          {
                              //Tinh so luong cot xuat ra
                              string _MaxColumn = ((String)(Convert.ToChar(dt.Columns.Count / 26 + 64).ToString() + Convert.ToChar(dt.Columns.Count % 26 + 64))).Replace('@', ' ').Trim();
                              if (dt.Columns.Count % 26 == 0)
                              {
                                  _MaxColumn = ((String)(Convert.ToChar((dt.Columns.Count) / 26 + 64).ToString() + Convert.ToChar((dt.Columns.Count + 1) % 26 + 64))).Replace('@', ' ').Trim();
                              }
                              //cac tham so
                              int _record_count = dtView.Count;
                              int _record_mod = _record_count;

                              string _pos_begin1 = pos_column;
                              int _pos_begin2 = pos_row;

                              object[,] _Array_Record;
                              string _Cell_Begin, _Cell_End;

                              _Cell_Begin = _pos_begin1 + (_pos_begin2).ToString();
                              _Cell_End = _MaxColumn + (_record_count + pos_row - 1).ToString();

                              _Array_Record = new object[_record_mod, dt.Columns.Count];
                              for (int l = 0; l < _record_mod; l++)
                              {
                                  for (int m = 0; m < dt.Columns.Count; m++)
                                  {
                                      _Array_Record[l, m] = dtView[l][m];
                                      
                                  }
                                  // SET MAU KHONG CHAM CONG
                                  //if (_Array_Record[l, 9].ToString() == "")
                                  //{
                                  //    chartRange = Sheet.get_Range("J" + l + pos_row, Type.Missing);
                                  //    chartRange.Interior.Color = System.Drawing.Color.Blue.ToArgb();
                                  //}
                                  //if (_Array_Record[l, 10].ToString() == "")
                                  //{
                                  //    chartRange = Sheet.get_Range("K" + l + pos_row, Type.Missing);
                                  //    chartRange.Interior.Color = System.Drawing.Color.Blue.ToArgb();
                                  //}
                             }
                              Sheet.get_Range(_Cell_Begin, _Cell_End).Value2 = _Array_Record;
                              Sheet.get_Range(_Cell_Begin, _Cell_End).Borders.LineStyle = 1;

                              Sheet.Name = dtpb.Rows[ii]["DepartmentName"].ToString();
                              Sheet.Copy(Sheet);

                              // clrear txt
                              _Array_Record = new object[_record_mod, dt.Columns.Count];
                              for (int l = 0; l < _record_mod; l++)
                                  for (int m = 0; m < dt.Columns.Count; m++)
                                  {
                                      _Array_Record[l, m] = "";
                                  }
                              Sheet.get_Range(_Cell_Begin, _Cell_End).Value2 = _Array_Record;
                              Sheet.get_Range(_Cell_Begin, _Cell_End).Borders.LineStyle = 0;
                           //Sheet.get_Range(_Cell_Begin, _Cell_End).Interior.Color = System.Drawing.Color.Transparent.ToArgb();
                              // end cler text in excel
                          }
                       // Het xu ly voi du lieu chi phong ban
                   }
                   else
                   {
                       //Tinh so luong cot xuat ra
                       string MaxColumn = ((String)(Convert.ToChar(dt.Columns.Count / 26 + 64).ToString() + Convert.ToChar(dt.Columns.Count % 26 + 64))).Replace('@', ' ').Trim();
                       if (dt.Columns.Count % 26 == 0)
                       {
                           MaxColumn = ((String)(Convert.ToChar((dt.Columns.Count) / 26 + 64).ToString() + Convert.ToChar((dt.Columns.Count + 1) % 26 + 64))).Replace('@', ' ').Trim();
                       }
                       //cac tham so
                       int record_count = dtView.Count;
                       int record_mod = record_count;

                       string pos_begin1 = pos_column;
                       int pos_begin2 = pos_row;     
                     
                       object[,] Array_Record;
                       string Cell_Begin, Cell_End;

                       Cell_Begin = pos_begin1 + (pos_begin2).ToString();
                       Cell_End = MaxColumn + (record_count + pos_row - 1).ToString();
                       if (Show_Column == true)
                       {
                           Cell_End = MaxColumn + (record_mod + pos_row).ToString();
                       }
                       Array_Record = new object[record_mod, dt.Columns.Count];
                       for (int l = 0; l < record_mod; l++)
                       {
                           for (int m = 0; m < dt.Columns.Count; m++)
                           {
                               Array_Record[l, m] = dtView[l][m];                               
                           }
                           // SET MAU KHONG CHAM CONG
                           //if (Array_Record[l, 9].ToString()== "")
                           //{
                           //    chartRange = Sheet.get_Range("J" + l+pos_row, Type.Missing);
                           //    chartRange.Interior.Color = System.Drawing.Color.Blue.ToArgb();
                           //}
                           //if (Array_Record[l, 10].ToString() == "")
                           //{
                           //    chartRange = Sheet.get_Range("K" + l + pos_row, Type.Missing);
                           //    chartRange.Interior.Color = System.Drawing.Color.Blue.ToArgb();
                           //}
                       }
                       Sheet.get_Range(Cell_Begin, Cell_End).Value2 = Array_Record;
                       Sheet.get_Range(Cell_Begin, Cell_End).Borders.LineStyle = 1;

                       Sheet.Name = dtpb.Rows[ii]["DepartmentName"].ToString();
                       Sheet.Copy(Sheet);

                       // clrear txt
                       Array_Record = new object[record_mod, dt.Columns.Count];
                       for (int l = 0; l < record_mod; l++)
                           for (int m = 0; m < dt.Columns.Count; m++)
                           {
                               Array_Record[l, m] = "";
                           }
                       Sheet.get_Range(Cell_Begin, Cell_End).Value2 = Array_Record;
                       Sheet.get_Range(Cell_Begin, Cell_End).Borders.LineStyle = 0;
                        //Sheet.get_Range(Cell_Begin, Cell_End).Interior.Color = System.Drawing.Color.Transparent.ToArgb();
                       // end cler text in excel
                   }
               }
               // end for phong ban 
               for (int iii = 1; iii < WorkBook.Worksheets.Count; iii++) // xóa số (2) o sheet name
               {
                   Microsoft.Office.Interop.Excel._Worksheet SheetName = (Microsoft.Office.Interop.Excel._Worksheet)WorkBook.Worksheets[iii];
                   string _sheetname = SheetName.Name;
                   _sheetname = _sheetname.Replace("(2)", "");
                   SheetName.Name = _sheetname;
               }
               //save file
               if (sfilename == "")
               {
                   ReportFile.AlertBeforeOverwriting = false;
                   ReportFile.DisplayAlerts = false;
                   ReportFile.Save(Type.Missing);
                   MessageBox.Show("Export Excel Successful !!!");
               }
               else
               {
                   //if (IsOpen)
                   //{
                   //    IsOpen = false;
                   //}
                   WorkBook.Save();
                   //  MessageBox.Show("Export Excel Successful !!!");
               }

               if (IsOpen)
               {
                   ReportFile.Visible = true;
                   ReportFile.UserControl = true;
               }
               //ReportFile.Quit();
               releaseObject(Sheet);
               releaseObject(WorkBook);
               releaseObject(ReportFile);
               //foreach (Process process in Process.GetProcessesByName("EXCEL"))
               //{
               //    process.Kill();
               //}
           }
           catch (Exception exx)
           {
               string Error = exx.ToString();

           }
       }
        #endregion

    }
}
