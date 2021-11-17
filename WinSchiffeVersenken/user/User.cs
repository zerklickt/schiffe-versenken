using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WinSchiffeVersenken
{
    public class User
    {
        protected string username;
        protected string password;
        protected int score;
        protected IPAddress ipAdress;

        public User(string username, string password, int score = 0)
        {
            this.username = username;
            this.password = password;
            this.score = score;
        }

        public int getScore()
        {
            return this.score;
        }

        public string getUsername()
        {
            return this.username;
        }

        public void setUsername(string username)
        {
            this.username = username;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }
    }
}
