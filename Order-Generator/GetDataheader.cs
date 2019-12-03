using System;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace Order_Generator
{
    public static class GetDataheader
    {
        // Reads the first sheet of excel file and writes it to a data table
        public static DataTable getExcelData()
        {
            var excelApp = new Excel.Application();
            var wb = excelApp.Workbooks.Open(FilePaths.PackOrder);
            Excel._Worksheet ws = wb.Sheets[1];
            var range = ws.UsedRange;
            var numCols = range.Columns.Count;
            var numRows = range.Rows.Count;
            var fields = new object[numCols];
            var dt = new DataTable();
            var values = (object[,])range.Value2;

            for (var numCol = 1; numCol <= numCols; numCol++)
            {
                var column = new DataColumn
                {
                    DataType = Type.GetType("System.String"),
                    ColumnName = (values[1, numCol]).ToString()
                };
                dt.Columns.Add(column);
            }

            for (var numRow = 2; numRow <= numRows; numRow++)
            {

                for (var i = 1; i <= numCols; i++)
                {
                    fields[i - 1] = Convert.ToString(values[numRow, i]);
                }
                dt.Rows.Add(fields);
            }
            wb.Close(false, null, null);
            excelApp.Quit();
            return dt;
        }
    }
}
