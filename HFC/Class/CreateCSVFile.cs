using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace HFC.Class
{
    class CreateCSVFile
    {
       public void CreateCSVFiles(DataTable dt, string strFilePath)
        {
            try
            {
                StreamWriter sw = new StreamWriter(strFilePath, false);
                int columnCount = dt.Columns.Count;

                for (int i = 0; i < columnCount; i++)
                {
                    sw.Write(dt.Columns[i]);

                    if (i < columnCount - 1)
                    {
                        sw.Write(",");
                    }
                }

                sw.Write(sw.NewLine);

                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < columnCount; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            sw.Write(dr[i].ToString());
                        }

                        if (i < columnCount - 1)
                        {
                            sw.Write(",");
                        }
                    }

                    sw.Write(sw.NewLine);
                }

                sw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

    }
}
