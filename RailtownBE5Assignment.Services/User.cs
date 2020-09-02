using Newtonsoft.Json;
using RailtownBE5Assignment.Models;
using System;
using System.Collections.Generic;

namespace RailtownBE5Assignment.Services
{
    public class User : IUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }

        public Company Company { get; set; }

        public string Phone { get; set; }

        /// <summary>
        /// Captures misc. data for future extension or use.
        /// </summary>
        [JsonExtensionData]
        public Dictionary<string, object> Properties { get; set; }

        public void PrintUser()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Address: {Address.GetFriendlyAddress()}");
            Console.WriteLine($"Company Name: {Company.Name}");
            Console.WriteLine($"Phone: {Phone}");

        }
    }
}
