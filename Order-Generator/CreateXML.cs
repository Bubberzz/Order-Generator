using System;
using System.Linq;
using System.Text;
using System.Xml;

namespace Order_Generator
{
    internal static class CreateXML
    {
        // This method creates an XML schema, which can then be populated by with a data table
        public static string createXML(System.Data.DataTable dhTable, System.Data.DataTable dlTable)
        {
            var settingsList = GetSettings.getSettings();

            var settings = new XmlWriterSettings
            {
                Encoding = Encoding.UTF8,
                Indent = true,
                IndentChars = "    ",
                CloseOutput = true,
            };
            var fileName = $"Order{DateTime.Now:yyyyMMddHHmmss}.xml";
            using (var writer = XmlWriter.Create(FilePaths.OrdersFolder + fileName, settings))
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
                    writer.WriteElementString("instructions", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("insurance_cost", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("name", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("order_date", dhTable.Rows[i][a++].ToString());
                    writer.WriteElementString("order_id", settingsList[0].ToString());
                    writer.WriteElementString("order_type", dhTable.Rows[i][++a].ToString());
                    writer.WriteElementString("owner_id", dhTable.Rows[i][++a].ToString());
                    writer.WriteElementString("postcode", dhTable.Rows[i][++a].ToString());
                    writer.WriteElementString("ship_by_date", dhTable.Rows[i][++a].ToString());
                    writer.WriteElementString("soh_id", dhTable.Rows[i][++a].ToString());
                    writer.WriteElementString("status", dhTable.Rows[i][++a].ToString());
                    writer.WriteElementString("time_zone_name", dhTable.Rows[i][++a].ToString());
                    writer.WriteElementString("tod", dhTable.Rows[i][++a].ToString());
                    writer.WriteElementString("town", dhTable.Rows[i][++a].ToString());
                    writer.WriteElementString("User_Def_Date_1", dhTable.Rows[i][++a].ToString());
                    writer.WriteElementString("user_def_type_8", fileName);
                    writer.WriteStartElement("datalines");
                    a = 1;
                    for (var j = 0; j < dlTable.Rows.Count; j++)
                    {
                        writer.WriteStartElement("dataline");
                        writer.WriteAttributeString("transaction", "add");
                        writer.WriteElementString("client_id", dlTable.Rows[j][0].ToString());
                        writer.WriteElementString("host_line_id", settingsList[1].ToString());
                        writer.WriteElementString("host_order_id", settingsList[0].ToString());
                        writer.WriteElementString("line_id", settingsList[2].ToString());
                        writer.WriteElementString("order_id", settingsList[0].ToString());
                        writer.WriteElementString("owner_id", dlTable.Rows[j][b = 5].ToString());
                        writer.WriteElementString("product_price", dlTable.Rows[j][++b].ToString());
                        writer.WriteElementString("qty_ordered", dlTable.Rows[j][++b].ToString());
                        writer.WriteElementString("sku_id", dlTable.Rows[j][++b].ToString());
                        writer.WriteElementString("tax_1", dlTable.Rows[j][++b].ToString());
                        writer.WriteElementString("time_zone_name", dlTable.Rows[j][b++].ToString());
                        writer.WriteElementString("user_def_num_2", settingsList[1].ToString());
                        writer.WriteElementString("user_def_type_8", settingsList[2].ToString());
                        writer.WriteEndElement();
                        b = 0;
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    settingsList = settingsList.Select(x => x + 1).ToList();
                }
                writer.Flush();
            }
            // Increments the settings file by 1, for all values
            GetSettings.setSettings(settingsList);
            return fileName;
        }
    }
}
