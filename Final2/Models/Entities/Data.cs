using System;
using System.Collections.Generic;

#nullable disable

namespace Final2.Models.Entities
{
    public partial class Data
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime? Birthday { get; set; }
        public string Email { get; set; }
        public string Major { get; set; }
        public string Address { get; set; }
        public string Quarter { get; set; }
        public string Password { get; set; }
    }
}
