using System;
using System.ComponentModel;

namespace Task.Models
{
    public class User
    {
        public int UserId { get; set; }

        [DisplayName("Name")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        public string LastName { get; set; }

        [DisplayName("Birth date")]
        public DateTime BirthDate { get; set; }

        [DisplayName("Home address")]
        public Address HomeAddress { get; set; }

        [DisplayName("Registred")]
        public bool IsApproved { get; set; }

        [DisplayName("Role")]
        public Role Role { get; set; }
    }
}