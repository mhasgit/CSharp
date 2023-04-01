using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectivity.Library
{
    public class ConnectionHelper
    {
        public static SqlConnection GetSqlConnection(string connectionString, bool useCredentials = true)
        {
            if (useCredentials)
            {
                SecureString secureString = GetSecureString("P@ssw0rd");
                SqlCredential credential = new SqlCredential("sa", secureString);
                return new SqlConnection(connectionString, credential);
            }

            return new SqlConnection(connectionString);
        }

        private static SecureString GetSecureString(string password)
        {
            SecureString secureString = new SecureString();
            for (int i = 0; i < password.Length; i++)
            {
                secureString.AppendChar(password[i]);
            }
            secureString.MakeReadOnly();
            return secureString;
        }
    }
}
