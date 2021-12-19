using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace ticketSystem
{
    public partial class Login : System.Web.UI.Page
    {

        String connectionString = null;
        SqlConnection cnn;
        SqlCommand command;

        protected void Page_Load(object sender, EventArgs e)
        {
                connectionString = "Data Source=NAJEE\\SQLEXPRESS;" + "Initial Catalog= TicketDB;Integrated Security=SSPI; Persist Security Info =false";
                cnn = new SqlConnection(connectionString);

        }

        //Login Button Handler
        protected void Logins_Click(object sender, EventArgs e)
        {
            try
            {
                //Attempting to connect to SQL Database
                String queryString = "select * from dbo.Employees where Username ='" + this.txtUser.Text + "';";
                cnn.Open();
                command = new SqlCommand(queryString, cnn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (txtUser.Text == reader["Username"].ToString() && txtPass.Text == reader["Password"].ToString())
                    {
                        //if login is successful, take cookies
                        Response.Cookies["Username"].Value = txtUser.Text;
                        Response.Cookies["Username"].Expires = DateTime.Now.AddDays(1);

                        Response.Cookies["Password"].Value = txtPass.Text;
                        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(1);

                        // Then redirect to profile page
                        Response.Redirect("Home.aspx?name=" + Response.Cookies["Username"].Value);
                    }
                    else
                    {
                        info.Text = ("Incorrect Username Or Password, Try again");
                    }
                }
            }catch (SqlException ex)
            {
                info.Text = ("Error in SQL!" + ex.Message);
            }
            finally
            {
                if (cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

        //Register Button Handler
        protected void Register_Click(object sender, EventArgs e)
        {
            Response.Cookies["Username"].Value = txtUser.Text;
            Response.Cookies["Username"].Expires = DateTime.Now.AddDays(1);

            Response.Cookies["Password"].Value = txtPass.Text;
            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(1);

            Response.Redirect("Register.aspx?name=" + Response.Cookies["Username"].Value + "&pass=" + Response.Cookies["Password"].Value);
        }
    }
}