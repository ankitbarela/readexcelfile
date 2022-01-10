using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FileWatcherApp
{
    public  class ReadExcal
    {   
        string connString = "Data Source = .; Initial Catalog =FileWatcher ;Integrated Security=true;";


        public void  ReadExcalData(string excalPath)
            {
              SqlConnection conn = new SqlConnection(connString);
              conn.Open();

            Application excelApp = new Application();

            if (excelApp == null)
            {
                Console.WriteLine("Excel is not installed!!");
                return;
            }

            Workbook excelBook = excelApp.Workbooks.Open(excalPath);
                _Worksheet excelSheet = excelBook.Sheets[1];
                Microsoft.Office.Interop.Excel.Range excelRange = excelSheet.UsedRange;

                int rows = excelRange.Rows.Count;
                int cols = excelRange.Columns.Count;
                StringBuilder strBuilder = new StringBuilder();
                for (int i = 1; i <= rows; i++)
                {
                    Console.Write("\r\n");
                    for (int j = 1; j <= cols; j++)
                    {
                        if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
                            {
                               Console.Write(excelRange.Cells[i, j].Value2.ToString() + "\t");
                            }
                     }
                    strBuilder.Append("INSERT INTO Persons (FirstName) VALUES ");
                    strBuilder.Append($@"(N'{excelRange.Cells[i].Value2}') ");
                    string sqlQuery = strBuilder.ToString();
                    using SqlCommand command = new(sqlQuery, conn);
                    command.ExecuteNonQuery();
                }
                excelBook.Close();
                excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelSheet);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelBook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }
    }
}
