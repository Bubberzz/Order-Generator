using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;

namespace Order_Generator
{
    public static class GetExcelData
    {
        public static double ConvertVal { get; private set; }

        private static string cellVal;

        public static DataTable getExcelData()
        {

         


            var excelApp = new Excel.Application();
            var WB = excelApp.Workbooks.Open(@"C:\Users\Stan.bubbers\Desktop\PackOrder.xlsx");
            Excel._Worksheet WS = WB.Sheets[1];
            var Range = WS.UsedRange;


            //int NumCols = 31; values.GetLength(0)
            int NumCols = Range.Columns.Count;
            int NumRows = Range.Rows.Count;
            object[] Fields = new string[NumCols];
            //string input = null;
            DataTable dt = new DataTable();
            object[,] values = (object[,])Range.Value2;

            for (int NumCol = 1; NumCol <= NumCols; NumCol++)
            {
                //textBox3.Text = cCnt.ToString();

                var Column = new DataColumn();
                Column.DataType = System.Type.GetType("System.String");
                Column.ColumnName = (values[1, NumCol]).ToString();
                //Column.ColumnName = NumCol.ToString();
                dt.Columns.Add(Column);

                //for (int i = 1; i <= 1; i++)
                //{
                //    //Fields[i - 1] = Convert.ToString(values[1, i]);
                //    dt.Columns.Add(Convert.ToString(values[1, i]));
                //}
            }


            //Microsoft.Office.Interop.Excel.Range range = gXlWs.get_Range("A1", "F188000");
            for (int NumRow = 2; NumRow <= NumRows; NumRow++)
            {
                
                for (int i = 1; i <= NumCols; i++)
                {
                    //set tostring
                    Fields[i - 1] = Convert.ToString(values[NumRow, i]);

                }
                dt.Rows.Add(Fields);

               
            }

            WB.Close(false, null, null);
            excelApp.Quit();

            //var Column = new DataColumn();
            //Column.DataType = System.Type.GetType("System.String");
            //Column.ColumnName = cCnt.ToString();
            //DT.Columns.Add(Column);





            //List<DataTable> List = new List<DataTable>();
            //DataTable DT = new DataTable();

            //// Counting sheets
            //for (int count = 1; count < WB.Worksheets.Count; ++count)
            //{
            //    // Create a new DataTable for every Worksheet

            //   // WS = (Excel.Worksheet)WB.Worksheets.get_Item(count);

            //    //textBox1.Text = count.ToString();

            //    // Get range of the worksheet
            //    //Range = WS.UsedRange;

            //    object[,] data = Range.Value2;

            //    // Create new Column in DataTable
            //    for (int cCnt = 1; cCnt <= Range.Columns.Count; cCnt++)
            //    {
            //        //textBox3.Text = cCnt.ToString();

            //        var Column = new DataColumn();
            //        Column.DataType = System.Type.GetType("System.String");
            //        Column.ColumnName = cCnt.ToString();
            //        DT.Columns.Add(Column);

            //        // Create row for Data Table
            //        for (int rCnt = 1; rCnt < Range.Rows.Count; rCnt++)
            //        {
            //            //textBox2.Text = rCnt.ToString();

            //            string cellVal = String.Empty;
            //            try
            //            {
            //                cellVal = (string)(data[rCnt, cCnt]);
            //            }
            //            catch (Exception)
            //            {
            //                ConvertVal = (double)(data[rCnt, cCnt]);
            //                cellVal = ConvertVal.ToString();
            //            }

            //            DataRow Row;

            //            // Add to the DataTable
            //            if (cCnt == 1)
            //            {

            //                Row = DT.NewRow();
            //                Row[cCnt.ToString()] = cellVal;
            //                DT.Rows.Add(Row);
            //            }
            //            else
            //            {

            //                Row = DT.Rows[rCnt + 1];
            //                Row[cCnt.ToString()] = cellVal;

            //            }
            //        }
            //    }
            //}
            return dt;

        }

    }
}
