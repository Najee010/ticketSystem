﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ticketSystem.Dao;
using ticketSystem.Entities;

namespace ticketSystem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        String connectionString = null;
        SqlConnection cnn;
        SqlCommand command;
        Employee Employee = new Employee();


        DateTime date = DateTime.Now;
        


        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = "Data Source=NAJEE\\SQLEXPRESS;" + "Initial Catalog= TicketDB;Integrated Security=SSPI; Persist Security Info =false";
            cnn = new SqlConnection(connectionString);

            //Get Exmploee information 
            EmployeeDao eDao = new EmployeeDao();
            Employee = eDao.getEmployee(Request.QueryString["name"]);
            Author.Text = Employee.Username;


            if (Request.QueryString["request"] == "edit")
            {
                //Get Ticket info and fill boxes on edit request
                TicketDao tDao = new TicketDao();
                Ticket Ticket = new Ticket();
                Ticket = tDao.getTicket(int.Parse(Request.QueryString["ticket"]));
                Content.Text = Ticket.Content;
            }

        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                cnn.Open();
                command = new SqlCommand("Insert into dbo.Tickets values(@Author,@Content,@Owner,@Status,@Date)", cnn);
                command.Parameters.AddWithValue("@Author", Employee.Username);
                command.Parameters.AddWithValue("@Content", Content.Text);
                command.Parameters.AddWithValue("@Owner", Employee.Id);
                command.Parameters.AddWithValue("@Status", Status.SelectedValue);
                command.Parameters.AddWithValue("@Date", this.date);

                int i = command.ExecuteNonQuery();
                Label.Text = "Ticket Created Successfully";
                cnn.Close();
            }
            catch (SqlException ex)
            {
                Label.Text = "Error in SQL! " + ex.Message;
            }
            finally
            {
                if(cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.AddHeader("REFRESH", ".5;URL=Home.aspx?name="+Request.QueryString["name"]);
        }
    }
}