using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ticketSystem
{
    public class Ticket
    {
        public int Ticketid { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public int Owner { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
       

        public Ticket()
        {

        }

        public Ticket(int ticketId, string Author, string Content,string Status, int Owner, string Date)
        {
            this.Ticketid = ticketId;
            this.Author = Author;
            this.Content = Content;
            this.Status = Status;
            this.Owner = Owner;
            this.Date = Date;
        }
    }
}