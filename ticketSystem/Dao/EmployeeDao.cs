using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ticketSystem.Entities;

namespace ticketSystem.Dao
{
    public class EmployeeDao
    {
        SqlDataAdapter employeeAdapter = null;
        DataTable employeeTable = null;
        String connectionString = null;
        SqlConnection cnn;


        public EmployeeDao()
        {
            connectionString = "Data Source=NAJEE\\SQLEXPRESS;" + "Initial Catalog= TicketDB;Integrated Security=SSPI; Persist Security Info =false";
            cnn = new SqlConnection(connectionString);

            employeeAdapter = new SqlDataAdapter("select * from Employees", Cfactory.CnnString);
            SqlCommandBuilder CommandBuilder = new SqlCommandBuilder(employeeAdapter);
            employeeTable = new DataTable();
            employeeAdapter.Fill(employeeTable);
            

           

        }
        public Employee getEmployee(String name)
        {
            Employee Employee = new Employee();
            DataRow[] rows = employeeTable.Select($"Username like '%{name}%'");
            //Employee employee = new Employee(int.Parse(row["Id"].ToString(),row["Username"].ToString(), row["Password"].ToString());
            foreach (DataRow row in rows)
            {
                Employee.Id = int.Parse(row["Id"].ToString());
                Employee.Username = name;
                Employee.Password = row["Password"].ToString();
            }
            return Employee;
        }
    }
}