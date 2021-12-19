using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ticketSystem.Dao
{
    public class TicketDao
    {
        SqlDataAdapter EntryAdapter = null;
        DataTable EntryTable = null;
        String connectionString = null;
        SqlConnection cnn;

        public TicketDao()
        {
            connectionString = "Data Source=NAJEE\\SQLEXPRESS;" + "Initial Catalog= TicketDB;Integrated Security=SSPI; Persist Security Info =false";
            cnn = new SqlConnection(connectionString);

            
            EntryAdapter = new SqlDataAdapter("select * from Tickets", Cfactory.CnnString);
            SqlCommandBuilder CommandBuilder = new SqlCommandBuilder(EntryAdapter);
            //string insertStatement = "Insert into Tickets( Author, Content, Owner, Status, Date) values(@Name, @Date, @Description, @Title)";
            //EntryAdapter.InsertCommand = new SqlCommand(insertStatement);
            EntryTable = new DataTable();
            EntryAdapter.Fill(EntryTable);
        }

        //Method to populate the Listbox with users tickets
        public List<Ticket> MyTickets(string name)
        {
            List<Ticket> Tickets = new List<Ticket>();
            DataRow[] rows = EntryTable.Select($"Author like '%{name}%'");

            foreach(DataRow row in rows)
            {
                Ticket Ticket = new Ticket(
                    int.Parse(row["TicketId"].ToString()), row["Author"].ToString(), row["Content"].ToString(), row["Status"].ToString(), int.Parse(row["Owner"].ToString()), row["Date"].ToString()
                    );
                Tickets.Add(Ticket);
            }
            return Tickets;
        }

        //Method to populate Listbox of all unowned tickets;
        public List<Ticket> AllTickets()
        {
            List<Ticket> Tickets = new List<Ticket>();
            //DataRow[] rows = EntryTable.Select($"Status like '%{status}%");
            DataRow[] rows = EntryTable.Select();


            foreach (DataRow row in rows)
            {
                Ticket Ticket = new Ticket(
                    int.Parse(row["TicketId"].ToString()), row["Author"].ToString(), row["Content"].ToString(), row["Status"].ToString(), int.Parse(row["Owner"].ToString()), row["Date"].ToString()
                    );
                Tickets.Add(Ticket); 
            }
            return Tickets;
        }

        public Ticket getTicket(int Id)
        {
            Ticket Ticket = new Ticket();
            DataRow[] rows = EntryTable.Select($"TicketId = '{Id}'");

            foreach (DataRow row in rows)
            {
                Ticket.Ticketid = int.Parse(row["TicketId"].ToString());
                Ticket.Author = row["Author"].ToString();
                Ticket.Content = row["Content"].ToString();
                Ticket.Status = row["Status"].ToString();
                Ticket.Owner = int.Parse(row["Owner"].ToString());
                Ticket.Date = row["Date"].ToString();
            }
            return Ticket;
        }
    }

   
}