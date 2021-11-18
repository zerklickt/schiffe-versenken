using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WinSchiffeVersenken
{
    class User
    {
        protected string username;
        protected int score;
        protected IPAddress ipAdress;
        private Schiffe[] ships;
        private int amountships;

        public User(string username, int score = 0)
        {
            ships = new Schiffe[Settings.SHIPS_2 + Settings.SHIPS_3 + Settings.SHIPS_4];
            this.username = username;
            this.score = score;
            amountships = 0;
        }

        public bool addShip(int count)
        {
            try
            {
                this.ships[amountships] = new Schiffe(count, amountships);
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

        public Schiffe[] getShips()
        {
            return this.ships;
        }

        public bool hatverloren()
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