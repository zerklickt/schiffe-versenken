using System;
using System.Collections.Generic;
using System.Text;

namespace WinSchiffeVersenken
{
    class Spiel
    {
        private User opponent;
        private User me;

        public Spiel(User me, User opponent)
        {
            this.me = me;
            this.opponent = opponent;
        }
    }
}
