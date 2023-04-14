using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeGround
{
    public class EmployeeMapper
    {
        public static Employee MapEmployee(SqlDataReader reader)
        {
            return new Employee
            {
                EmployeeId = (int)reader["EmployeeId"],
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"],
                Email = (string)reader["Email"],
                Phone = (string)reader["Phone"]
            };
        }
    }
}
