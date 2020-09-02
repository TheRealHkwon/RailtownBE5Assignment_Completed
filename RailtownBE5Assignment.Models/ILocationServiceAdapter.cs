using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RailtownBE5Assignment.Models
{
    /// <summary>
    /// Get user data from a url
    /// </summary>
    public interface ILocationServiceAdapter
    {
        public Task<IUser[]> GetUsers(string url);
    }
}
