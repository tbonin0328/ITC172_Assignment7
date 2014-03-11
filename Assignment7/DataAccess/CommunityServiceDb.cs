using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Assignment7.DataAccess
{
    public class CommunityServiceDb
    {
        SqlConnection connect;

        public CommunityServiceDb()
        {
            connect = new SqlConnection(ConfigurationManager.ConnectionStrings["CommunityAssistConnectionString"].ConnectionString);
        }

        public DataTable GetServices()
        {
            string sql = "Select ServiceName, ServiceDescription From CommunityService";

            SqlCommand cmd = new SqlCommand(sql, connect);
            SqlDataReader reader;
            DataTable table = new DataTable();
            connect.Open();
            reader = cmd.ExecuteReader();
            table.Load(reader);
            reader.Close();
            connect.Close();

            return table;
        }

    }
}