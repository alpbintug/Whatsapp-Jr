namespace Staj_Projesi
{
    class Message
    {
        private string text;
        private string sender;
        private string reciever;
        private string time;
        private bool isSeen;

        public string Text { get { return text; } set { text = value; } }
        public string Sender { get { return sender; } set { sender = value; } }
        public string Reciever { get { return reciever; } set { reciever = value; } }
        public string Time { get { return time; } set { time = value; } }
        public bool IsSeen { get { return isSeen; } set { isSeen = value; } }

        public Message(string sender, string reciever, string text, string time,bool isSeen)
        {
            this.sender = sender;
            this.reciever = reciever;
            this.text = text;
            this.time = time;
            this.isSeen = isSeen;
        }
        public Message()
        {

        }
    }
}
