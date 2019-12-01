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
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook WB = excelApp.Workbooks.Open(@"C:\Users\Stan.bubbers\Desktop\PackOrder.xlsx");
            Excel._Worksheet WS = WB.Sheets[1];
            Excel.Range Range = WS.UsedRange;
            int NumCols = Range.Columns.Count;
            int NumRows = Range.Rows.Count;
            object[] Fields = new string[NumCols];
            DataTable dt = new DataTable();
            object[,] values = (object[,])Range.Value2;

            for (int NumCol = 1; NumCol <= NumCols; NumCol++)
            {
                DataColumn Column = new DataColumn
                {
                    DataType = Type.GetType("System.String"),
                    ColumnName = (values[1, NumCol]).ToString()
                };
                dt.Columns.Add(Column);
            }

            for (int NumRow = 2; NumRow <= NumRows; NumRow++)
            {

                for (int i = 1; i <= NumCols; i++)
                {
                    Fields[i - 1] = Convert.ToString(values[NumRow, i]);
                }
                dt.Rows.Add(Fields);
            }
            WB.Close(false, null, null);
            excelApp.Quit();
            return dt;
        }
    }
}
