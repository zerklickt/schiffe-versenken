namespace WinSchiffeVersenken
{
    class Schiffe
    {
        private int lang;
        private bool versenkt;
        private int numgetroffen;
        private int id;
        public Schiffe() { }
        public Schiffe(int _lang, int _id) : base()
        {
            lang = _lang;
            versenkt = false;
            numgetroffen = 0;
            id = _id;
        }

        public int getlang()
        {
            return lang;
        }

        public int getid()
        {
            return id;
        }

        public void getroffen()
        {
            numgetroffen++;
        }

        public int getGetroffen()
        {
            return numgetroffen;
        }

        public bool istversenkt()
        {
            return versenkt;
        }

        public void istversenktfunct()
        {
            {
                if (numgetroffen == lang)
                {
                    versenkt = true;
                }
                else
                {
                    versenkt = false;
                }

            }
        }
    }
}