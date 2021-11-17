namespace WinSchiffeVersenken
{
    class Spiel
    {
        private User opponent;
        private User me;
        private Spielfeld sf;


        public Spiel(User me, User opponent)
        {
            this.me = me;
            this.opponent = opponent;
            sf = new Spielfeld(this);
        }

        public User getMe()
        {
            return me;
        }

        public Spielfeld GetSpielfeld()
        {
            return sf;
        }
    }
}
