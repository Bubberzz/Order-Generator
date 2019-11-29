using System;
using System.Text;
using System.Windows.Navigation;
using System.Xml;

namespace Order_Generator
{
    internal static class CreateXML
    {
        public static string createXML(System.Data.DataTable dhTable, System.Data.DataTable dlTable)
        {
            var settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                Indent = true,
                IndentChars = ("    "),
                CloseOutput = true,
                //OmitXmlDeclaration = true
            };
            var fileName = $"order{DateTime.Now:yyyyMMddHHmmss}.xml";
            using (var writer = XmlWriter.Create($@"orders\{fileName}", settings))
            {
                var a = 1;
                var b = 0;
                writer.WriteStartElement("dcsmergedata");
                writer.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
                writer.WriteAttributeString("headertable", "interface_order_header");
                writer.WriteAttributeString("headersequence", "if_oh_pk_seq");
                writer.WriteAttributeString("linetable", "interface_order_line");
                writer.WriteAttributeString("linesequence", "if_ol_pk_seq");
                writer.WriteAttributeString("updatecolumns", "yes");
                writer.WriteAttributeString("xsi", "noNamespaceSchemaLocation", null, "../lib/interface_order_header.xsd");
                writer.WriteStartElement("dataheaders");
                for (var i = 0; i < dhTable.Rows.Count; i++)
                {
                    writer.WriteStartElement("dataheader");
                    writer.WriteAttributeString("transaction", "add");
                    writer.WriteElementString("address1", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("address2", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("client_id", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("contact", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("contact_email", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("contact_mobile", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("contact_phone", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("country", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("county", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("documentation_text_1", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("documentation_text_2", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("expected_value", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("from_site_id", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("insurance_cost", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("name", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("order_date", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("order_id", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("order_type", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("owner_id", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("postcode", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("status", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("time_zone_name", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("tod", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("town", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("user_def_type_8", dhTable.Rows[i][a++].ToString());
                    writer.WriteStartElement("datalines");
                    a = 1;
                    for (var j = 0; j < dlTable.Rows.Count; j++)
                    {
                        writer.WriteStartElement("dataline");
                        writer.WriteAttributeString("transaction", "add");
                        writer.WriteElementString("client_id", dlTable.Rows[j][b++].ToString());
                        writer.WriteElementString("host_line_id", dlTable.Rows[j][b++].ToString());
                        writer.WriteElementString("host_order_id", dlTable.Rows[j][b++].ToString());
                        writer.WriteElementString("line_id", dlTable.Rows[j][b++].ToString());
                        writer.WriteElementString("order_id", dlTable.Rows[j][b++].ToString());
                        writer.WriteElementString("owner_id", dlTable.Rows[j][b++].ToString());
                        writer.WriteElementString("product_price", dlTable.Rows[j][b++].ToString());
                        writer.WriteElementString("qty_ordered", dlTable.Rows[j][b++].ToString());
                        writer.WriteElementString("sku_id", dlTable.Rows[j][b++].ToString());
                        writer.WriteElementString("tax_1", dlTable.Rows[j][b++].ToString());
                        writer.WriteElementString("time_zone_name", dlTable.Rows[j][b++].ToString());
                        writer.WriteElementString("user_def_num_2", dlTable.Rows[j][b++].ToString());
                        writer.WriteElementString("user_def_type_8", dlTable.Rows[j][b++].ToString());
                        writer.WriteEndElement();
                        b = 0;
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
                writer.Flush();
            }
            return fileName;
        }
    }
}
