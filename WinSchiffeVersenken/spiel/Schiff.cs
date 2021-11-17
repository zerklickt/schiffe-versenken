﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinSchiffeversenken
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

        public int getnumber()
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

        public void istversenktfunct()
        {
            {
                if (numgetroffen == lang)
                {
                    versenkt = true;
                }
                versenkt = false;
            }
        }
    }
}

