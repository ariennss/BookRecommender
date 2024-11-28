using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRecommender.Authentication
{
    public static class CurrentUser
    {
        public static string Username { get; set; }
        public static string Password { get; set; }
    }
}
