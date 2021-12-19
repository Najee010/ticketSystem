using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ticketSystem.Dao
{
    public class Cfactory 
    {
        public static string CnnString;

        static Cfactory()
        {
            CnnString = "Data Source = NAJEE\\SQLEXPRESS; Initial Catalog = TicketDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";


        }
        public static SqlConnection getConnection()
        {
            SqlConnection cnn = new SqlConnection(CnnString);
            return cnn;
        }

    }
}