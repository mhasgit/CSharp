using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PracticeGround
{
    public class ConnectionHelper
    {

        public static SqlConnection GetSqlConnection(string connectionString, bool useCredential = false)
        {
            if (useCredential)
            {
                SecureString secureString = GetSecureString("abc");
                SqlCredential credentials = new SqlCredential("Foe", secureString);
                return new SqlConnection(connectionString, credentials);
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
