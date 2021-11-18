using System.Collections.Generic;

namespace WinSchiffeVersenken
{
    class Spiel
    {
        private User opponent;
        private User me;
        private Spielfeld sf;

        private bool myTurn;
        private bool linksEingeloggt;
        private bool rechtsEingeloggt;

        public Spiel(User me, User opponent)
        {
            this.linksEingeloggt = false;
            this.rechtsEingeloggt = false;
            this.me = me;
            myTurn = true;
            this.opponent = opponent;
            sf = new Spielfeld(this);
        }

        public bool istLinksEingeloggt()
        {
            return linksEingeloggt;
        }

        public void setLinksEingeloggt(bool s)
        {
            this.linksEingeloggt = s;
        }

        public bool istRechtsEingeloggt()
        {
            return linksEingeloggt;
        }

        public void setRechtsEingeloggt(bool s)
        {
            this.linksEingeloggt = s;
        }

        public User getMe()
        {
            return me;
        }

        public Spielfeld GetSpielfeld()
        {
            return sf;
        }

        public User getOpponent()
        {
            return opponent;
        }
        public User getcurrUser()
        {
            if (myTurn)
            {
                return me;
            }
            else
            {
                return opponent;
            }
        }

        public bool checkshipequal()
        {
            if (me.getamountships() != opponent.getamountships())
            {
                return false;
            }
            List<int> shiplengthplayerme = new List<int>();
            for (int i = 0; i < me.getShips().Length; i++)
            {
                shiplengthplayerme.Add(me.getShips()[i].getlang());
            }
            shiplengthplayerme.Sort();
            List<int> shiplengthplayeropp = new List<int>();
            for (int i = 0; i < me.getShips().Length; i++)
            {
                shiplengthplayeropp.Add(me.getShips()[i].getlang());
            }
            shiplengthplayeropp.Sort();
            for (int i = 0; i < me.getShips().Length; i++)
            {
                if (shiplengthplayerme[i] != shiplengthplayeropp[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
