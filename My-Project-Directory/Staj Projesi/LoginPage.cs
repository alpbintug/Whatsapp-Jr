using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Windows.Forms;

namespace Staj_Projesi
{
    public partial class LoginPage : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "diN9IcACLUhTWXAa9UlhitSJPv11VddARqUnfWNa",
            BasePath = "https://texting-d05e5.firebaseio.com/"
        };
        IFirebaseClient client;
        public object Application { get; internal set; }
        public MainPage mainPage;
        public LoginPage()
        {
            InitializeComponent();
            txtUserName.Select();
        }

        private async void BtnLogIn_Click(object sender, EventArgs e)
        {
            if (txtUserName.TextLength == 0 || txtPassword.TextLength == 0)
            {
                MessageBox.Show("Username or password area cannot be empty!");
                return;
            }
            if (txtUserName.Text.Contains("."))
            {
                MessageBox.Show("Username cannot contain '.' character");
                return;
            }
            FirebaseResponse response = new FirebaseResponse();

            response = await client.GetTaskAsync("User/" + txtUserName.Text);
            User getUser = null;
            try
            {
                getUser = response.ResultAs<User>();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Cannot find the user name.");
            }
            if (getUser != null)
            {
                getUser.Messages = response.ResultAs<User>().Messages;
                getUser.Contacts = response.ResultAs<User>().Contacts;
                if (getUser.Password != txtPassword.Text)
                {
                    Console.WriteLine(getUser.Password + " - " + txtPassword.Text);
                    MessageBox.Show("Wrong password!");
                    return;
                }
                this.Hide();
                mainPage = new MainPage();
                mainPage.Text = getUser.Name;
                mainPage.CurrentUser = getUser;
                mainPage.lstContacts.Items.Clear();
                foreach (var item in getUser.Contacts)
                {
                    int unread = mainPage.CurrentUser.findUnreadMessages(item);
                    if (unread > 0)
                    {
                        mainPage.lstContacts.Items.Add(item + "(" + unread + " Unread Messsages)");

                    }
                    else
                        mainPage.lstContacts.Items.Add(item);
                }
                mainPage.login = this;
                int unreadMessages = 0;
                int unreadMessageRequests = 0;
                foreach (var item in mainPage.CurrentUser.Messages)
                {
                    if (item.Reciever == mainPage.CurrentUser.UserName && !item.IsSeen && mainPage.CurrentUser.Contacts.Contains(item.Sender))
                        unreadMessages++;
                    else if (item.Reciever == mainPage.CurrentUser.UserName && !item.IsSeen)
                        unreadMessageRequests++;
                    Console.WriteLine(unreadMessages + " " + item.IsSeen);
                }
                mainPage.unreadMessages = unreadMessages;
                mainPage.unreadMessageRequests = unreadMessageRequests;
                mainPage.updateUnreadMessageInfo();
                mainPage.Show();
            }
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            Console.WriteLine(client);
            if (client == null)
            {
                MessageBox.Show("Cannot connect to server.");
                this.Close();
            }

        }

        private void LoginPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program pr = new Program();
            pr.LoginPage_FormClosing(sender, e);
        }

        private async void BtnSignUp_Click(object sender, EventArgs e)
        {
            if (txtAddUserName.Text.Contains("."))
            {
                MessageBox.Show("Username cannot contain '.' character.");
                return;
            }
            string name = txtAddName.Text;
            if (name.Length == 0)
            {
                MessageBox.Show("You must enter a name!");
                return;
            }
            string role = txtAddRole.Text;
            if (role.Length == 0)
            {
                MessageBox.Show("You must enter a role!");
                return;
            }
            string userName = txtAddUserName.Text;
            if (userName.Length < 5)
            {
                MessageBox.Show("User name must contain atleast 5 characters");
                return;
            }
            else
            {
                FirebaseResponse response = await client.GetTaskAsync("User/" + txtAddUserName.Text);
                User test = null;
                try
                {
                    test = response.ResultAs<User>();
                }
                catch (NullReferenceException)
                {


                }
                if (test != null)
                {
                    MessageBox.Show("User name is taken!");
                    return;
                }
            }
            string password = txtAddPassword.Text;
            if (password.Length < 5)
            {
                MessageBox.Show("Password must contain atleast 5 characters!");
                return;
            }
            else if (password.Contains(userName) || password.Contains(userName.ToLower()) || password.Contains(userName.ToUpper()))
            {
                MessageBox.Show("Password cannot contain your user name!");
                return;
            }
            Console.WriteLine(userName + " " + password + " " + name + " " + role);
            if (name.Length != 0 && role.Length != 0 && password.Length != 0 && userName.Length != 0)
            {
                User userToAdd = new User(name, role, userName, password);
                SetResponse response = await client.SetTaskAsync("User/" + userToAdd.UserName, userToAdd);
                User result = response.ResultAs<User>();
            }
            else
            {
                MessageBox.Show("Wrong Entry");
            }
            txtAddName.Text = "";
            txtAddRole.Text = "";
            txtAddUserName.Text = "";
            txtAddPassword.Text = "";

        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                txtUserName.Select();
            }
            else
            {
                txtAddUserName.Select();
            }
        }
    }
}
