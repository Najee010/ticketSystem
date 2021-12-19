using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ticketSystem.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }


        public Employee() { }
        public Employee(int Id, String Username, String Password)
        {
            this.Id = Id;
            this.Username = Username;
            this.Password = Password;
        }
    }
}