using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ticketSystem
{
    public partial class Register : System.Web.UI.Page
    {
        String connectionString = null;
        SqlConnection cnn;
        SqlCommand command;

        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = "Data Source=NAJEE\\SQLEXPRESS;" + "Initial Catalog= TicketDB;Integrated Security=SSPI; Persist Security Info =false";
            cnn = new SqlConnection(connectionString);

            //Adding values from Login page to Registration page
            txtUsername.Text = Request.QueryString["name"];
            txtPass1.Text = Request.QueryString["pass"];
        }

        //Event handler for Register Button
        protected void registerButton_Click(object sender, EventArgs e)
        {
            //Try to add user given values to the database
            try
            {
                cnn.Open();
                command = new SqlCommand("Insert into dbo.Employees values(@Username,@Password)", cnn);
                command.Parameters.AddWithValue("@Username", this.txtUsername.Text);
                command.Parameters.AddWithValue("@Password", this.txtPass1.Text);
                int r = command.ExecuteNonQuery();
                cnn.Close();
                Label4.Text = "Successfully added " + txtUsername.Text + " to the system. Returning to Login Page";
                Response.AddHeader("REFRESH", "5;URL=Login.aspx");
            }catch(SqlException ex)
            {
                Label4.Text = "Error in SQL! " + ex.Message;
            }
            finally
            {
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.AddHeader("REFRESH", "1;URL=Login.aspx");
        }
    }
}