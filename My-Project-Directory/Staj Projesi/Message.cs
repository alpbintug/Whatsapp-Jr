namespace Staj_Projesi
{
    class Message
    {
        private string text;
        private string sender;
        private string reciever;
        private string time;

        public string Text { get { return text; } set { text = value; } }
        public string Sender { get { return sender; } set { sender = value; } }
        public string Reciever { get { return reciever; } set { reciever = value; } }
        public string Time { get { return time; } set { time = value; } }

        public Message(string sender, string reciever, string text, string time)
        {
            this.sender = sender;
            this.reciever = reciever;
            this.text = text;
            this.time = time;
        }
        public Message()
        {

        }
    }
}
