using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ticketSystem.Dao;

namespace ticketSystem
{
    public partial class Home : System.Web.UI.Page
    {
        String connectionString = null;
        SqlConnection cnn;
        TicketDao tDao = new TicketDao();
        string date = DateTime.Now.ToString("M/d/yyyy");


        public Home()
        {
            //InitializeComponent();
            connectionString = "Data Source=NAJEE\\SQLEXPRESS;" + "Initial Catalog= TicketDB;Integrated Security=SSPI; Persist Security Info =false";
            cnn = new SqlConnection(connectionString);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            String Username = Request.QueryString["name"];

            //Welcomes user to the Home
            Welcome.Text = "Welcome "+ Username;

            //Populate listbox with user owned Tickets
            List<Ticket> Tickets = tDao.MyTickets(Username);
            foreach(Ticket T in Tickets)
            {
                userTickets.Items.Add(T.Ticketid.ToString()+", "+ T.Content);
            }

            //Populate unowned ticket Listbox
            List<Ticket> Unowned = tDao.AllTickets();
            foreach(Ticket T in Unowned)
            {
                unownedTickets.Items.Add(T.Ticketid.ToString()+", "+T.Content);
            }
            
        }

        protected void createButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ticket.aspx?name="+Request.QueryString["name"]+"&request=create");

        }

        //Edit button for Owned Tickets
        protected void editButton_Click(object sender, EventArgs e)
        {
            Ticket ticket = new Ticket();
            
            //Null Checker for selected listbox
            if(userTickets.SelectedValue == "")
            {
                Response.Redirect("Home.aspx?name=" + Request.QueryString["name"]);
                Welcome.Text = "you gotta select a ticket first :p";
            }
            else {
                //pull the ticket from sql then redirect to Ticket page to edit
                String selected = userTickets.SelectedValue;
                String[] values = selected.Split(',');
                ticket = tDao.getTicket(int.Parse(values[0]));
                Response.Redirect("Ticket.aspx?name=" + ticket.Author+"&ticket="+ticket.Ticketid+"&request=edit");
            }
        }

        //Delete button for Owned Tickets
        protected void deleteButton_Click(object sender, EventArgs e)
        {
            Ticket ticket = new Ticket();

            String selected = userTickets.SelectedValue;
            String[] values = selected.Split(',');
            ticket = tDao.getTicket(int.Parse(values[0]));
            Welcome.Text = tDao.deleteTicket(ticket.Ticketid);
            Response.Redirect("Home.aspx?name=" + Request.QueryString["name"]);

        }

        //Edit button for unowned Tickets
        protected void Edit_Click(object sender, EventArgs e)
        {
            Ticket ticket = new Ticket();

            //null checker for selected listbox
            if (unownedTickets.SelectedValue == "")
            {
                Welcome.Text = "you gotta select a ticket first :p";
            }
            else
            {
                //pull the ticket from sql then redirect to Ticket page to edit
                String selected = unownedTickets.SelectedValue;
                String[] values = selected.Split(',');
                ticket = tDao.getTicket(int.Parse(values[0]));
                Response.Redirect("Ticket.aspx?user="+Request.QueryString["name"]+"&name="+ticket.Author+"&ticket="+ticket.Ticketid+"&request=edit");
            }
        }

        protected void userTickets_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void unownedTickets_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Delete for unowned Tickets
        protected void Delete_Click(object sender, EventArgs e)
        {
            Ticket ticket = new Ticket();
            String selected = unownedTickets.SelectedValue;
            String[] values = selected.Split(',');
            ticket = tDao.getTicket(int.Parse(values[0]));
            Welcome.Text = tDao.deleteTicket(ticket.Ticketid);
            Response.Redirect("Home.aspx?name=" + Request.QueryString["name"]);
        }
    }
}