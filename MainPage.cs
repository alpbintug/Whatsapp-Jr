using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Windows.Forms;

namespace $safeprojectname$
{
    public partial class MainPage : Form
    {
        private User currentUser = new User();
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "diN9IcACLUhTWXAa9UlhitSJPv11VddARqUnfWNa",
            BasePath = "https://texting-d05e5.firebaseio.com/"
        };
        IFirebaseClient client;
        public LoginPage login = new LoginPage();
        public MainPage()
        {
            InitializeComponent();
        }

        internal User CurrentUser { get => currentUser; set => currentUser = value; }

        private async void BtnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchUserName.Text.Contains("."))
            {
                MessageBox.Show("Username cannot contain '.' character.");
                return;
            }
            if (txtSearchUserName.TextLength != 0)
            {
                FirebaseResponse response = new FirebaseResponse();
                User userToSearch = null;
                try
                {
                    response = await client.GetTaskAsync("User/" + txtSearchUserName.Text);
                    userToSearch = response.ResultAs<User>();

                }
                catch (NullReferenceException)
                {
                }
                if (userToSearch != null)
                {
                    if (userToSearch.UserName != currentUser.UserName)
                    {
                        lstSearchUsers.Items.Add(userToSearch.UserName);
                        return;
                    }
                }
                MessageBox.Show("User cannot be found!");
            }
            else
                MessageBox.Show("Enter the user name.");
        }

        private async void BtnAddContacts_Click(object sender, EventArgs e)
        {
            if (lstSearchUsers.SelectedIndex >= 0 && lstSearchUsers.SelectedIndex < lstSearchUsers.Items.Count)
            {
                FirebaseResponse response = new FirebaseResponse();
                response = await client.GetTaskAsync("User/" + lstSearchUsers.SelectedItem.ToString());
                foreach (var item in CurrentUser.Contacts)
                {
                    if (item == response.ResultAs<User>().UserName)
                        return;
                }


                CurrentUser.Contacts.Add(response.ResultAs<User>().UserName);
                response.ResultAs<User>().Contacts.Add(CurrentUser.UserName);
                SetResponse response1 = await client.SetTaskAsync("User/" + currentUser.UserName, currentUser);
                SetResponse response2 = await client.SetTaskAsync("User/" + response.ResultAs<User>().UserName, response.ResultAs<User>());
                User result = response1.ResultAs<User>();
                User result1 = response2.ResultAs<User>();
                lstContacts.Items.Clear();
                foreach (var item in CurrentUser.Contacts)
                {
                    lstContacts.Items.Add(item);
                }

            }
            else
                MessageBox.Show("Select a valid user");
        }

        private async void BtnRefreshContacts_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.GetTaskAsync("User/" + CurrentUser.UserName);
            CurrentUser = response.ResultAs<User>();
            lstContacts.Items.Clear();
            foreach (var item in CurrentUser.Contacts)
            {
                lstContacts.Items.Add(item);
            }
        }

        private async void BtnStartChat_Click(object sender, EventArgs e)
        {
            if (lstContacts.SelectedIndex >= 0 && lstContacts.SelectedIndex < lstContacts.Items.Count)
            {
                FirebaseResponse response = new FirebaseResponse();
                response = await client.GetTaskAsync("User/" + lstContacts.SelectedItem.ToString());
                ChatPage chatPage = new ChatPage();
                chatPage.CurrentUser = CurrentUser;
                chatPage.TargetUser = response.ResultAs<User>();
                chatPage.lstChat.Items.Clear();
                foreach (var item in currentUser.Messages)
                {
                    if (item.Sender == chatPage.CurrentUser.UserName && item.Reciever == chatPage.TargetUser.UserName)
                    {
                        string msg = item.Time + " - You: " + item.Text;
                        chatPage.lstChat.Items.Add(msg);
                    }
                    else if (item.Sender == chatPage.TargetUser.UserName && item.Reciever == chatPage.CurrentUser.UserName)
                    {

                        string msg = item.Time + " - " + item.Sender + ": " + item.Text;
                        chatPage.lstChat.Items.Add(msg);
                    }
                }
                chatPage.timerToRefresh.Enabled = true;
                chatPage.Text = "Chat with " + chatPage.TargetUser.Name;
                chatPage.Show();
                chatPage.MainPage = this;
            }
            else
                MessageBox.Show("Select a valid user");
        }

        private async void BtnLogout_Click(object sender, EventArgs e)
        {
            SetResponse response = await client.SetTaskAsync("User/" + CurrentUser.UserName, CurrentUser);
            User result = response.ResultAs<User>();
            this.Close();
            login.Show();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

            client = new FireSharp.FirebaseClient(config);
        }
    }
}
