using System.Collections.Generic;

namespace $safeprojectname$
{
    class User
    {
        private string name;
        private string userName;
        private string password;
        private List<string> contacts = new List<string>();
        private List<Message> messages = new List<Message>();
        private List<string> contactRequests = new List<string>();
        public List<string> ContactRequests { get { return contactRequests; } set { contactRequests = value; } }
        public List<Message> Messages { get { return messages; } set { messages = value; } }
        public List<string> Contacts { get { return contacts; } set { contacts = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string UserName { get { return userName; } set { userName = value; } }
        public string Password { get { return password; } set { password = value; } }

        public User()
        {
            contacts = new List<string>();
            messages = new List<Message>();
        }
        public User(string name, string userName, string password)
        {
            this.name = name;
            this.userName = userName;
            this.password = password;
            contacts = new List<string>();
            messages = new List<Message>();
        }
        public override string ToString()
        {
            return name;
        }
        public int findUnreadMessages(string Target)
        {
            int unread = 0;
            if (!contacts.Contains(Target))
            {
                return -1;
            }
            foreach (var item in messages)
            {
                if (item.Sender == Target && item.IsSeen == false && item != null)
                    unread++;
            }
            return unread;
        }
    }
}
