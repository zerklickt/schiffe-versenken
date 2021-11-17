namespace WinSchiffeVersenken
{

    public struct anz
    {
        public static int anzahl = 0;
    }
    class Schiffe
    {
        private int lang;
        private bool versenkt;
        private int numgetroffen;
        private int id;
        public Schiffe() { }
        public Schiffe(int _lang) : base()
        {
            lang = _lang;
            versenkt = false;
            numgetroffen = 0;
            id = anz.anzahl++;
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

        public bool istversenkt()
        {
            return versenkt;
        }

        public int getAnzahl()
        {
            return anz.anzahl;
        }

        public void istversenktfunct()
        {
            {
                if (numgetroffen == lang)
                {
                    versenkt = true;
                } else
                {
                    versenkt = false;
                }
                
            }
        }
    }
}

