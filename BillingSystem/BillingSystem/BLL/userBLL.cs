using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillingSystem.BLL
{
    class userBLL
    {
        //type prop and hit tab to create the following getter setter (business logic)
        //This is called business logic layer
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string UserType { get; set; }
        public DateTime AddedDate { get; set; }
        public int AddedBy { get; set; }

    }
}
