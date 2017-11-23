using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.IO;

namespace Fulcrum_Data_Testing_Tool
{
    class XMLOperation
    {
        public DataSet ReadXml(string XML_File_Path)
        {
            XmlReader XMLFile;
            XMLFile = XmlReader.Create(XML_File_Path, new XmlReaderSettings());
            DataSet dsXml = new DataSet();
            dsXml.ReadXml(XML_File_Path);
            
            return dsXml;
        }

        public static bool FileValidation(string FileName)
        {
            bool Result;
            if (FileName == String.Empty){
                Result = false;
            }
            else{
                Result = true;
            }
            return Result; 
        }

        private static void RemoveRelationalFields(DataSet dsXml)
        {
            foreach (DataTable dt in dsXml.Tables)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    if (col.ColumnName.EndsWith("_Id"))
                        dt.Columns.Remove(col);
                }
            }
        }

        public DataTable GetDataFromXmlDataSet(string InterfaceName, string MessageID, DataSet dsXml, DataTable dtToFill)
        {
            foreach (DataTable dt in dsXml.Tables)
            {
                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (dt.Columns[i].ColumnName.EndsWith("_Id") == false)
                        {
                            
                            string name = dt.Columns[i].ColumnName;

                            //string value = row[i];// != DBNull.Value ? row[i].ToString() : "";
                            DataRow r = dtToFill.NewRow();
                            r["IF_TEXT"] = name;
                            r["IF_DATA"] = row[i];
                            r["IF_NAME"] = InterfaceName;
                            r["MESSAGEID"] = MessageID;

                            dtToFill.Rows.Add(r);
                        }
                        else
                        { }
                    }
                }
            }
            return dtToFill;
        }

        //public static XmlDocument LoadXMLDocument(XmlDocument xDoc, string FilePath)
        //{
        //    xDoc = new XmlDocument();
        //    xDoc.Load(FilePath);

        //    return xDoc;
        //}


        public static string TransformQuery(string query, XmlDocument xDoc, string File)
        {
            string[] parameters = query.Split(' ').ToList<string>().Where(x => x.StartsWith("@")).ToArray<string>();
            //string[] values = new string[parameters.Count()];

            for (int i = 0; i < parameters.Count(); i++)
            {
                string value = GetNodValue(xDoc, parameters[i].Replace("@", ""), File);
                query = query.Replace(parameters[i], "'" + value + "'");
            }

            return query;

            //parameters.ToList().ForEach(x => nvc.Add(x, ""));

            //return nvc;
        }

        public static string GetNodValue(XmlDocument xDoc, string NodeName, string DefaultValue = "")
        {
            xDoc = new XmlDocument();
            xDoc.Load(DefaultValue);
            string TagValue = xDoc.GetElementsByTagName(NodeName).Item(0).InnerXml;
            return TagValue;
        }


        public static string InferfaceName(string XML_File_Path)
        {
            /* This method is pick the InterfaceName from given file name*/
            string InterFaceName = Path.GetFileName(XML_File_Path).Split('_')[1]; 
            return InterFaceName; 
        }

        public static DataTable GenerateData(DataTable XML_DataTable, DataTable XML_Mapping_DataTable, XmlDocument xDoc, string File)
        {
            //DataTable NewQue = new DataTable();
            XML_DataTable.Columns.Add("CSDP_Data");


            foreach (DataRow row in XML_DataTable.Rows)
            {
                DataRow[] r = XML_Mapping_DataTable.Select("IF_TEXT = '" + row["IF_TEXT"] + "'");
                if (r != null && r.Count() > 0)
                {
                    string data = string.Empty;
                    string query = XMLOperation.TransformQuery(r[0]["IF_DATA_MAPPING"].ToString(), xDoc, File);
                    //data = r[0]["IF_DATA_MAPPING"].ToString();

                    try
                    {
                        data = DBQuery.ExecuteQuery(query);
                        row["CSDP_Data"] = data;
                    }
                    catch (Exception)
                    {
                        row["CSDP_Data"] = Tools.ResultText.SQLExecutionError.ToString();
                    }
                    
                }
                else
                    row["CSDP_Data"] = Tools.ResultText.MappingNotFound.ToString();
            }

            XML_DataTable.Columns.Remove("MessageID");
            XML_DataTable.Columns.Remove("IF_Name");
            
            return XML_DataTable;
        }
    }
}
