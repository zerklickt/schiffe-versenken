using System;
using System.Collections.Generic;
using System.Text;

namespace WinSchiffeVersenken
{
    class Spielfeld
    {
        private int size;
        private Feld[][] buttons;

        public Spielfeld()
        {

        }

        public Feld[][] getButtons()
        {
            return buttons;
        }

        public bool fire(int x, int y)
        {
            
            return false;
        }
    }
}
