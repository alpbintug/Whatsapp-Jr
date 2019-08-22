using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staj_Projesi
{
    public partial class ChatPage : Form
    {
        private User currentUser = new User();
        private User targetUser = new User();
        private MainPage mainPage;
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "diN9IcACLUhTWXAa9UlhitSJPv11VddARqUnfWNa",
            BasePath = "https://texting-d05e5.firebaseio.com/"
        };
        IFirebaseClient client;

        internal User CurrentUser { get => currentUser; set => currentUser = value; }
        internal User TargetUser { get => targetUser; set => targetUser = value; }
        public MainPage MainPage { get => mainPage; set => mainPage = value; }

        public ChatPage()
        {
            InitializeComponent();
            this.ActiveControl = txtMessage;
            txtMessage.Focus();
        }

        private async void BtnSendMessage_Click(object sender, System.EventArgs e)
        {

            txtMessage.Text = txtMessage.Text.Trim();
            if (txtMessage.Text.Length != 0)
            {
                timerToRefresh.Stop();
                string time = DateTime.Now.ToString();
                Message message = new Message(CurrentUser.UserName, TargetUser.UserName, txtMessage.Text, time);
                System.Console.WriteLine(txtMessage.Text);
                CurrentUser.Messages.Add(message);
                TargetUser.Messages.Add(message);
                string msgToAdd = message.Time + " - You: " + message.Text;
                lstChat.Items.Add(msgToAdd);
                txtMessage.Text = "";
                await SaveCurrentUser();
                await SaveTargetUser();
                timerToRefresh.Start();
            }
        }
        public async Task SaveCurrentUser()
        {
            SetResponse response = await client.SetTaskAsync("User/" + CurrentUser.UserName, CurrentUser);
            User result = response.ResultAs<User>();
        }
        public async Task SaveTargetUser()
        {
            SetResponse response1 = await client.SetTaskAsync("User/" + TargetUser.UserName, TargetUser);
            User result1 = response1.ResultAs<User>();
        }
        private void ChatPage_Load(object sender, System.EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

        }


        private async void TimerToRefresh_Tick(object sender, System.EventArgs e)
        {
            FirebaseResponse response = await client.GetTaskAsync("User/" + CurrentUser.UserName);
            User responseAsUser = response.ResultAs<User>();
            if (CurrentUser.Messages.Count < responseAsUser.Messages.Count)
            {
                //CurrentUser.Messages = response.ResultAs<User>().Messages;
                for (int i = CurrentUser.Messages.Count; i < responseAsUser.Messages.Count; i++)
                {
                    CurrentUser.Messages.Add(responseAsUser.Messages[i]);
                }
                //lstChat.Items.Clear();

                foreach (var item in CurrentUser.Messages)
                {
                    if (item.Sender == CurrentUser.UserName && item.Reciever == TargetUser.UserName && !lstChat.Items.Contains("You: " + item.Text))
                    {
                        lstChat.Items.Add(item.Time + " - You: " + item.Text);
                    }
                    else if (item.Sender == TargetUser.UserName && item.Reciever == CurrentUser.UserName && !lstChat.Items.Contains(item.Sender + ": " + item.Text))
                    {
                        lstChat.Items.Add(item.Time + " - " + item.Sender + ": " + item.Text);
                    }
                }
            }
        }

        private async void BtnQuit_Click(object sender, System.EventArgs e)
        {
            this.timerToRefresh.Stop();
            this.timerToRefresh.Dispose();
            mainPage.CurrentUser = CurrentUser;
            await SaveCurrentUser();
            this.Hide();
        }

        private async void TxtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMessage.Text = txtMessage.Text.Trim();
                if (txtMessage.Text.Length != 0)
                {
                    timerToRefresh.Stop();

                    Message message = new Message(CurrentUser.UserName, TargetUser.UserName, txtMessage.Text, DateTime.Now.ToString());
                    System.Console.WriteLine(txtMessage.Text);
                    CurrentUser.Messages.Add(message);
                    TargetUser.Messages.Add(message);
                    string msgToAdd = message.Time + " - You: " + message.Text;
                    lstChat.Items.Add(msgToAdd);
                    txtMessage.Text = "";
                    await SaveCurrentUser();
                    await SaveTargetUser();
                    timerToRefresh.Start();
                }
            }
        }
    }
}

