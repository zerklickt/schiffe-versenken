using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WinSchiffeVersenken
{
    class User
    {
        protected string username;
        protected string password;
        protected int score;
        protected IPAddress ipAdress;
        private Schiffe[] ships;
        private int amountships;

        public User(string username, string password, int score = 0)
        {
            ships = new Schiffe[2];
            this.username = username;
            this.password = password;
            this.score = score;
            amountships = 0;
        }

        public bool addShip(int count)
        {
            try
            {
                ships[amountships] = new Schiffe(count, amountships);
                amountships++;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public int getScore()
        {
            return this.score;
        }
        public int getamountships()
        {
            return this.amountships;
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

        public bool hatgewonnen()
        {
            for (int i = 0; i < ships.Length; i++)
            {
                if (ships[i].istversenkt() == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}