using System;
using System.Collections.Generic;
using System.Text;

namespace WinSchiffeVersenken
{
    [Serializable]
    class Message
    {
        private int type;
        private string payload;
        public Message(int type, string payload)
        {
            this.type = type;
            this.payload = payload;
        }

        public int getType()
        {
            return this.type;
        }

        public string getPayload()
        {
            return this.payload;
        }

        public void setType(int type)
        {
            this.type = type;
        }

        public void setPayload(string s)
        {
            this.payload = s;
        }
    }
}
