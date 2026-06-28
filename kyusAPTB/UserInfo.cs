using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyusAPTB
{
    public class UserInfo
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public UserInfo(int userID, string username, string password)
        {
            UserID = userID;
            Username = username;
            Password = password;
        }
    }

    public static class Session
    {
        public static UserInfo CurrentUser;
    }
}