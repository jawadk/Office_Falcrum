using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Collections.Specialized;

namespace Fulcrum_Data_Testing_Tool
{
    public class DBQuery
    {
        //public static DataTable dtDB;

        public static DataTable EmptyDataTableHeaders()
        {
            DataTable dtDB = new DataTable();
            AppConnection appcon = new AppConnection();
            appcon.SQLConnectionOpen();

            SqlDataAdapter DataAdapt = new SqlDataAdapter("select * from Fulcrum_XML_Data where messageid = ''", AppConnection.AppConnectStringFulcrum());

            DataAdapt.Fill(dtDB);

            return dtDB;
        }


        public static void InsertInterfaceData(DataTable Datatable)
        {
            //string SQL_Query = null;

            AppConnection appcon = new AppConnection();
            appcon.SQLConnectionOpen();

            SqlDataAdapter DataAdapt = new SqlDataAdapter();

            

            for (int i = 0; i < Datatable.Rows.Count; i++)
            {
                //Datatable.Rows[i].ItemArray[0].ToString(); //MessageID
                //Datatable.Rows[i].ItemArray[1].ToString(); //InterFaceName
                //Datatable.Rows[i].ItemArray[2].ToString(); //TagNAme
                //Datatable.Rows[i].ItemArray[3].ToString(); //Inferface
                
                string values = string.Empty;
                
                foreach(string value in Datatable.Rows[i].ItemArray){

                    values += "'"+value+"',";
                }

                values = values.Substring(0,values.Length-1);
                using (SqlConnection conn = new SqlConnection(AppConnection.AppConnectStringFulcrum()))
                {
                    if (conn.State == ConnectionState.Closed) {
                        conn.Open();
                    }
                    DataAdapt.InsertCommand = new SqlCommand("INSERT INTO dbo.Fulcrum_XML_Data (MESSAGEID, IF_NAME, IF_TEXT, IF_DATA) VALUES (" + values + ")", conn);
                    DataAdapt.InsertCommand.ExecuteNonQuery();
                }                
            }
            //AppConnection appcon = new AppConnection();
            //appcon.SQLConnectionOpen();

            //SqlDataAdapter DataAdapt = new SqlDataAdapter("", AppConnection.AppConnectString());
            //DataAdapt.Update(dt);
        }

        public static DataTable GetDatafromDataBase()
        {
            DataTable FilledData = new DataTable();
            

            using (SqlConnection con = new SqlConnection(AppConnection.AppConnectStringFulcrum()))
            {
                using (SqlCommand cmd = new SqlCommand("select * from dbo.Fulcrum_XML_Data", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    FilledData.Load(reader);                    
                }

            }

            FilledData.Columns.Remove("MessageID");
            FilledData.Columns.Remove("IF_Name");

            FilledData.Columns.Add("Result");


            return FilledData;
        }

        public static DataTable GetMappingsWithValues(string InterfaceName, string MessageID)
        {
            DataTable FilledData = new DataTable();
            
            using (SqlConnection con = new SqlConnection(AppConnection.AppConnectStringFulcrum()))
            {
                using (SqlCommand cmd = new SqlCommand("select IF_TEXT, IF_DATA_MAPPING from dbo.IF_TEXT_MAPPING where IF_name = '" + InterfaceName + "'", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    FilledData.Load(reader);
                    FilledData.Columns.Add("CSDP_Data");
                }
            }

            using (SqlConnection con = new SqlConnection(AppConnection.AppConnectStringCSDP()))
            {
                con.Open();
                for (int i = 0; i < FilledData.Rows.Count; i++)
                {
                    //call method which will retun a query which have data replaced with parameters
                    string query = FilledData.Rows[i]["IF_DATA_MAPPING"].ToString();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        
                        FilledData.Rows[i]["CSDP_Data"] = cmd.ExecuteScalar();
                    }
                }
            }

            return FilledData;
        }


        public static string ExecuteQuery(string Query)
        {
            //DataTable Query = new DataTable();
            string QueryResult = null;
            using (SqlConnection con = new SqlConnection(AppConnection.AppConnectStringCSDP()))
            {
                //string test = Query.Rows.ToString();
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    object reader = cmd.ExecuteScalar();
                    if (object.ReferenceEquals(reader, null) == false)
                    {
                        QueryResult = reader.ToString();                        
                    }
                    else
                    {
                        QueryResult = string.Empty;
                    }
                    
                    //QueryResult.Load(reader);
                }

            }
            return QueryResult;
        }


        public static DataTable GetMappingQueries(string InterfaceName, string MessageID = "")
        {
            DataTable Queries = new DataTable();

            using (SqlConnection con = new SqlConnection(AppConnection.AppConnectStringFulcrum()))
            {
                using (SqlCommand cmd = new SqlCommand("select IF_TEXT, IF_DATA_MAPPING from dbo.IF_TEXT_MAPPING where IF_name = '" + InterfaceName + "'", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Queries.Load(reader);
                }

            }
            return Queries;
        }

        /*public static DataTable ReplaceText(DataTable dt, string CurrentText, string ReplacedText)
        {
            DataTable dt_replace = new DataTable();
            foreach (DataRow row in dt.Rows)
            {
                dt.Rows = row[2].ToString().Replace(CurrentText, ReplacedText);
                //Mappingquery.Add((string)row[1]);
            }

            return dt_replace; 
        }
         */

        public static List<string> MappedInterFaceValues(DataTable dt)
        {
            List<string> ls = new List<string>();

            NameValueCollection collection = new NameValueCollection();

            foreach (DataRow row in dt.Rows)
            {
                string Mappedcode = row[1].ToString();
                string MappedText = row[1].ToString();

                //string text1 = 

                //Mappedcode.StartsWith("@")

                //string code = string.Empty;//MappedText = MappedText.Split('@')[1];
                //if (Mappedcode.IndexOf('@') >= 0)
                //{
                    //code = Mappedcode.Substring(Mappedcode.IndexOf('@'));
                    //int lastIndex = code.LastIndexOf('@');
                    //code = code.Substring(0);
                collection.Add(Mappedcode.StartsWith("@").ToString(), MappedText.Replace("@", "").ToString());
               
            }
            return ls;               
        }

        public static void CheckMessageIDExist(string MessageID)
        {
            string Result  = null;
            using (SqlConnection con = new SqlConnection(AppConnection.AppConnectStringFulcrum()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM DBO.FULCRUM_XML_DATA WHERE MESSAGEID = '" + MessageID + "'", con))
                {
                    cmd.ExecuteNonQuery();                    
                }
            }
            //return true;
        }
    }
}
