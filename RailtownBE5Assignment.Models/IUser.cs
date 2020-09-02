using System;
using System.Collections.Generic;
using System.Text;

namespace RailtownBE5Assignment.Models
{
    public interface IUser
    {
        string Id { get; set; }

        string Name { get; set; }

        string Username { get; set; }

        string Email { get; set; }

        Address Address { get; set; }

        Company Company { get; set; }

        string Phone { get; set; }

        Dictionary<string, object> Properties { get; set; }

        public void PrintUser();
    }
}
