using DatabaseConnectivity.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseConnectivity.FormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DataSet dataSet = GetData();
            this.gridEmployees.DataSource = dataSet.Tables["Employees"];
            this.gridEmployees.DefaultCellStyle.Font = new Font("Consolas", 10);
            this.gridEmployees.Columns["EmployeeID"].Visible = false;

            this.gridLocations.DataSource = dataSet.Tables["Locations"]; ;
            this.gridLocations.DefaultCellStyle.Font = new Font("Consolas", 10);
        }


        private static DataSet GetData()
        {
            DataTable dt = new DataTable();
            DataSet dataSet = new DataSet();
            using (SqlConnection connection = ConnectionHelper.GetSqlConnection(ConfigurationManager.ConnectionStrings["SQL2022"].ConnectionString))
            {
                // SqlDataAdapter sqlAdapter = new SqlDataAdapter("SELECT * FROM Employees", connection);

                using (SqlCommand command = connection.CreateCommand())
                {
                    // command.BeginExecuteReader(CommandBehavior.SchemaOnly);
                    // SELECT * FROM Locations;
                    command.CommandText = "SELECT * FROM Employees;SELECT * FROM Locations;";
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(command);

                    // sqlAdapter.Fill(dt);

                    sqlAdapter.Fill(dataSet);
                    // sqlAdapter.FillSchema(dataSet, SchemaType.Source);
                }
            }

            dataSet.Tables[0].TableName = "Employees";
            dataSet.Tables[1].TableName = "Locations";

            string tables = dataSet.GetXml();

            return dataSet;
        }
    }
}
