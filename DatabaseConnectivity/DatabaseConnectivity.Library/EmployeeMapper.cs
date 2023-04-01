using System.Data.SqlClient;

namespace DatabaseConnectivity.Library
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
