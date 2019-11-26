using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;

namespace Order_Generator
{
    public static class GetDatalines
    {
        public static DataTable getExcelData()
        {
            var excelApp = new Excel.Application();
            var WB = excelApp.Workbooks.Open(@"C:\Users\Stan.bubbers\Desktop\PackOrder.xlsx");
            Excel._Worksheet WS = WB.Sheets[2];
            var Range = WS.UsedRange;
            var NumCols = Range.Columns.Count;
            var NumRows = Range.Rows.Count;
            object[] Fields = new string[NumCols];
            var dt = new DataTable();
            var values = (object[,])Range.Value2;

            for (var NumCol = 1; NumCol <= NumCols; NumCol++)
            {
                var Column = new DataColumn();
                Column.DataType = System.Type.GetType("System.String");
                Column.ColumnName = (values[1, NumCol]).ToString();
                dt.Columns.Add(Column);
            }

            for (var NumRow = 2; NumRow <= NumRows; NumRow++)
            {

                for (var i = 1; i <= NumCols; i++)
                {
                    //set tostring
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