using System.Collections.Generic;

namespace Staj_Projesi
{
    class User
    {
        private string name;
        private string role;
        private string userName;
        private string password;
        private List<string> contacts = new List<string>();
        private List<Message> messages = new List<Message>();
        public List<Message> Messages { get { return messages; } set { messages = value; } }
        public List<string> Contacts { get { return contacts; } set { contacts = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Role { get { return role; } set { role = value; } }
        public string UserName { get { return userName; } set { userName = value; } }
        public string Password { get { return password; } set { password = value; } }

        public User()
        {
            contacts = new List<string>();
            messages = new List<Message>();
        }
        public User(string name, string role, string userName, string password)
        {
            this.name = name;
            this.role = role;
            this.userName = userName;
            this.password = password;
            contacts = new List<string>();
            messages = new List<Message>();
        }
        public override string ToString()
        {
            return name + " " + role;
        }
    }
}
