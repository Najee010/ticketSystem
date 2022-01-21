using System;
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
        TicketDao tDao = new TicketDao();
        
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
                if (string.IsNullOrEmpty(Content.Text))
                {
                    Content.Text = Ticket.Content;
                    Status.Text = Ticket.Status;
                }
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
            if (string.IsNullOrEmpty(Request.QueryString["user"])){
                Response.AddHeader("REFRESH", ".5;URL=Home.aspx?name=" + Request.QueryString["name"]);
            }
            else
            {
                Response.AddHeader("REFRESH", ".5;URL=Home.aspx?name=" + Request.QueryString["user"]);
            }
        }

        protected void editButton_Click(object sender, EventArgs e)
        {
            Ticket ticket = new Ticket();
            ticket = tDao.getTicket(int.Parse(Request.QueryString["ticket"]));
            ticket.Content = Content.Text;
            try
            {
                cnn.Open();
                command = new SqlCommand("Update dbo.Tickets set Author = @Author, Content = @Content, Owner = @Owner, Status = @Status, Date = @Date Where TicketId = @TicketId;" , cnn);
                command.Parameters.AddWithValue("@Author", this.Employee.Username);
                command.Parameters.AddWithValue("@Content", this.Content.Text);
                command.Parameters.AddWithValue("@Owner", this.Employee.Id);
                command.Parameters.AddWithValue("@Status", this.Status.SelectedValue);
                command.Parameters.AddWithValue("@Date", this.date);
                command.Parameters.AddWithValue("@TicketId", ticket.Ticketid);

                int i = command.ExecuteNonQuery();

                cnn.Close();
                //Redirect("home.aspx?name="+Request.QueryString["name"]);
            }
            catch (SqlException ex)
            {
                Label.Text = "Error in SQL! " + ex.Message;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {

                }
                Label.Text = "Ticket changed Successfully";
            }
        }
    }
}