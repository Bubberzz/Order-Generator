using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.Xml;

namespace Order_Generator
{
    class CreateXML
    {
        public static void createXML(System.Data.DataTable dhTable, System.Data.DataTable dlTable)
        {


            //var query =
            //    from row in dt.AsEnumerable()
            //    group row by new
            //    {
            //        ID = row.Field<string>("ID"),
            //        Address1 = row.Field<string>("Address1"),
            //        Address2 = row.Field<string>("Address2")
            //    }
            //    into g
            //    select new XElement("dataheader",
            //        new XAttribute("CompanyId", g.Key.ID),
            //        new XAttribute("DeptId", g.Key.Address1),
            //        new XAttribute("Location", g.Key.Address2),
            //        from row in g
            //        select new XElement(
            //            "datalines",
            //            new XAttribute("id", row.Field<string>("id")),
            //            new XAttribute("EmployeeName", row.Field<string>("EmployeeName")),
            //            new XAttribute("EmployeeAge", row.Field<string>("EmployeeAge"))));

            //var document = new XDocument(new XElement("companies", query));

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.Indent = true;
            settings.IndentChars = ("    ");
            settings.CloseOutput = true;
            settings.OmitXmlDeclaration = true;
            using (XmlWriter writer = XmlWriter.Create("order.xml", settings))
            {
                var a = 1;
                var b = 0;
                writer.WriteStartElement("dcsmergedata");
                writer.WriteStartElement("dataheaders");
                for (var i = 0; i < dhTable.Rows.Count; i++)
                {
                    writer.WriteStartElement("dataheader");
                    writer.WriteElementString("address1", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("address2", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("client_id", dhTable.Rows[i][a++].ToString());
                    writer.WriteStartElement("datalines");
                    for (var j = 0; j < dlTable.Rows.Count; j++)
                    {
                        writer.WriteStartElement("dataline");
                        writer.WriteElementString("client_id", dlTable.Rows[j][b++].ToString());
                        writer.WriteElementString("host_line_id", dlTable.Rows[j][b++].ToString());
                        writer.WriteElementString("host_order_id", dlTable.Rows[i][b++].ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                //foreach (var row in dhTable.Rows)
                //{
                //    foreach (var col in dhTable.Columns)
                //    {
                //        writer.WriteElementString(col.ToString(), row.ToString());

                //    }
                //}

                //writer.WriteStartElement("dataheader");
                //writer.WriteElementString("address1", dhTable.Rows[0][1].ToString());
                //writer.WriteElementString("address2", dhTable.Rows[0][2].ToString());
                //writer.WriteElementString("client_id", dhTable.Rows[0][3].ToString());
                //writer.WriteElementString("contact", dhTable.Rows[0][4].ToString());
                //writer.WriteElementString("contact_email", dhTable.Rows[0][5].ToString());
                //writer.WriteElementString("contact_mobile", dhTable.Rows[0][6].ToString());
                //writer.WriteElementString("contact_phone", dhTable.Rows[0][7].ToString());
                //writer.WriteElementString("country", dhTable.Rows[0][8].ToString());
                //writer.WriteElementString("county", dhTable.Rows[0][9].ToString());
                //writer.WriteElementString("documentation_text_1", dhTable.Rows[0][10].ToString());
                //writer.WriteElementString("documentation_text_2", dhTable.Rows[0][11].ToString());
                //writer.WriteElementString("expected_value", dhTable.Rows[0][12].ToString());
                //writer.WriteElementString("from_site_id", dhTable.Rows[0][13].ToString());
                //writer.WriteElementString("insurance_cost", dhTable.Rows[0][14].ToString());
                //writer.WriteElementString("name", dhTable.Rows[0][15].ToString());
                //writer.WriteElementString("order_date", dhTable.Rows[0][16].ToString());
                //writer.WriteElementString("order_id", dhTable.Rows[0][17].ToString());
                //writer.WriteElementString("order_type", dhTable.Rows[0][18].ToString());
                //writer.WriteElementString("owner_id", dhTable.Rows[0][19].ToString());
                //writer.WriteElementString("postcode", dhTable.Rows[0][20].ToString());
                //writer.WriteElementString("status", dhTable.Rows[0][21].ToString());
                //writer.WriteElementString("time_zone_name", dhTable.Rows[0][22].ToString());
                //writer.WriteElementString("tod", dhTable.Rows[0][23].ToString());
                //writer.WriteElementString("town", dhTable.Rows[0][24].ToString());
                ////writer.WriteElementString("user_def_type_8", dhTable.Rows[0][25].ToString());
                //writer.WriteStartElement("datalines");
                //writer.WriteStartElement("dataline");
                //writer.WriteElementString("client_id", dlTable.Rows[0][0].ToString());
                //writer.WriteElementString("host_line_id", dlTable.Rows[0][1].ToString());
                //writer.WriteElementString("host_order_id", dlTable.Rows[0][2].ToString());
                //writer.WriteElementString("line_id", dlTable.Rows[0][3].ToString());
                //writer.WriteElementString("order_id", dlTable.Rows[0][4].ToString());
                //writer.WriteElementString("owner_id", dlTable.Rows[0][5].ToString());
                //writer.WriteElementString("product_price", dlTable.Rows[0][6].ToString());
                //writer.WriteElementString("qty_ordered", dlTable.Rows[0][7].ToString());
                //writer.WriteElementString("sku_id", dlTable.Rows[0][8].ToString());
                //writer.WriteElementString("tax_1", dlTable.Rows[0][9].ToString());
                //writer.WriteElementString("time_zone_name", dlTable.Rows[0][10].ToString());
                //writer.WriteElementString("user_def_num_2", dlTable.Rows[0][11].ToString());
                //writer.WriteElementString("user_def_type_8", dlTable.Rows[0][12].ToString());
                //writer.WriteEndElement();
                writer.Flush();
            }



            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            

            //ds.WriteXml("testorderfile.xml");

        }



        public static string ToXml(System.Data.DataTable table, int metaIndex = 0)
        {
            var xdoc = new XDocument(
                new XElement(table.TableName,
                    from column in table.Columns.Cast<DataColumn>()
                    where column != table.Columns[metaIndex]
                    select new XElement(column.ColumnName,
                        from row in table.AsEnumerable()
                        select new XElement(row.Field<string>(metaIndex), row[column])
                    )
                )
            );

            return xdoc.ToString();
        }
    }
}
