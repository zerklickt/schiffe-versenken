using System;
using System.Net;

namespace WinSchiffeVersenken
{
    class User
    {
        protected string username;
        protected string password;
        protected int score;
        protected IPAddress ipAdress;
        private Schiffe[] ships;

        public User(string username, string password, int score = 0)
        {
            ships = new Schiffe[10];
            this.username = username;
            this.password = password;
            this.score = score;
        }

        public bool addShip(Schiffe s)
        {
            try
            {
                ships[s.getid()] = s;
                return true;
            } catch (Exception e)
            {
                return false;
            }
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

        public Schiffe[] getShips()
        {
            return this.ships;
        }
    }
}
