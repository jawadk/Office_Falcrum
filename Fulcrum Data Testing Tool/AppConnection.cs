using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Fulcrum_Data_Testing_Tool
{
    public class AppConnection
    {
        public static SqlConnection con;

        public static string AppConnectStringFulcrum()
        {
            string Connection = System.Configuration.ConfigurationSettings.AppSettings["DSN"].ToString();
            return Connection;
        }

        public static string AppConnectStringCSDP()
        {
            string Connection = System.Configuration.ConfigurationSettings.AppSettings["CSDP"].ToString();
            return Connection;
        }

        public void SQLConnectionOpen()
        {
            //string ApplicationConnectionString = AppConnection.AppConnectString();
            if (con == null)
                con = new SqlConnection(AppConnection.AppConnectStringFulcrum());

            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
        }

        public void SQLConnectionClsoed(SqlConnection con)
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
        }

    }
}
