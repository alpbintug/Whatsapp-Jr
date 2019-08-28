using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace Staj_Projesi
{
    public partial class MainPage : Form
    {
        public int unreadMessages = 0;
        public int unreadMessageRequests = 0;
        public int lastNotificationMessageIndex = -1;
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
            Regex Rgx = new Regex(@"^\w*$");
            if (!Rgx.IsMatch(txtSearchUserName.Text))
            {
                MessageBox.Show("Username cannot contain special characters.");
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
                User user = response.ResultAs<User>();
                foreach (var item in CurrentUser.Contacts)
                {
                    if (item == user.UserName)
                        return;
                }

                CurrentUser.Contacts.Add(user.UserName);
                user.ContactRequests.Add(CurrentUser.UserName);
                SetResponse response1 = await client.SetTaskAsync("User/" + currentUser.UserName, currentUser);
                User result = response1.ResultAs<User>();
                SetResponse response2 = await client.SetTaskAsync("User/" + user.UserName, user);
                User result1 = response2.ResultAs<User>();
                lstContacts.Items.Clear();
                foreach (var item in CurrentUser.Contacts)
                {
                    lstContacts.Items.Add(item);
                }
                unreadMessageRequests -= CurrentUser.findUnreadMessages(CurrentUser.Contacts[CurrentUser.Contacts.Count - 1]);
                unreadMessages += CurrentUser.findUnreadMessages(CurrentUser.Contacts[CurrentUser.Contacts.Count - 1]);
                updateUnreadMessageInfo();
            }
            else
                MessageBox.Show("Select a valid user");
        }

        private async void BtnStartChat_Click(object sender, EventArgs e)
        {
            if (lstContacts.SelectedIndex >= 0 && lstContacts.SelectedIndex < lstContacts.Items.Count)
            {
                FirebaseResponse response = new FirebaseResponse();
                string userToStartChatWith;
                if (lstContacts.SelectedItem.ToString().Contains("("))
                {
                    userToStartChatWith = lstContacts.SelectedItem.ToString().Substring(0, lstContacts.SelectedItem.ToString().LastIndexOf('('));

                }
                else
                {
                    userToStartChatWith = lstContacts.SelectedItem.ToString();
                }
                unreadMessages -= CurrentUser.findUnreadMessages(userToStartChatWith);
                response = await client.GetTaskAsync("User/" + userToStartChatWith);
                ChatPage chatPage = new ChatPage();
                chatPage.TargetUser = response.ResultAs<User>();
                chatPage.lstChat.Items.Clear();
                foreach (var item in currentUser.Messages)
                {
                    if (item.Sender == currentUser.UserName && item.Reciever == chatPage.TargetUser.UserName)
                    {
                        string msg = item.Time + " - You: " + item.Text;
                        chatPage.lstChat.Items.Add(msg);
                    }
                    else if (item.Sender == chatPage.TargetUser.UserName && item.Reciever == currentUser.UserName)
                    {
                        if (!item.IsSeen)
                        {
                            item.IsSeen = true;
                            Console.WriteLine(1);
                        }

                        string msg = item.Time + " - " + item.Sender + ": " + item.Text;
                        chatPage.lstChat.Items.Add(msg);
                    }
                }
                FirebaseResponse response1 = await client.SetTaskAsync("User/" + CurrentUser.UserName, CurrentUser);
                chatPage.CurrentUser = CurrentUser;
                chatPage.timerToRefresh.Enabled = true;
                chatPage.Text = "Chat with " + chatPage.TargetUser.Name;
                lstContacts.Items[lstContacts.SelectedIndex] = chatPage.TargetUser.UserName;
                updateUnreadMessageInfo();
                chatPage.Show();
                chatPage.MainPage = this;
            }
            else
                MessageBox.Show("Select a valid user");
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {

            this.Close();
            login.Show();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            client = new FireSharp.FirebaseClient(config);
        }
        public void updateUnreadMessageInfo()
        {
            if (unreadMessages > 0 && unreadMessageRequests == 0)
            {
                lblUnreadMessages.Text = "You have " + unreadMessages + " unread messages.";
                lblUnreadMessages.Font = new System.Drawing.Font(DefaultFont.FontFamily, DefaultFont.Size, System.Drawing.FontStyle.Bold);
            }
            else if (unreadMessageRequests > 0 && unreadMessages > 0)
            {
                lblUnreadMessages.Text = "You have " + unreadMessages + " unread messages and " + unreadMessageRequests + "message requests.";
                lblUnreadMessages.Font = new System.Drawing.Font(DefaultFont.FontFamily, DefaultFont.Size, System.Drawing.FontStyle.Bold);

            }
            else if (unreadMessageRequests > 0 && unreadMessages == 0)
            {
                lblUnreadMessages.Text = "You have " + unreadMessageRequests + " unread message requests.";
                lblUnreadMessages.Font = new System.Drawing.Font(DefaultFont.FontFamily, DefaultFont.Size, System.Drawing.FontStyle.Regular);

            }
            else
            {
                lblUnreadMessages.Text = "You have no unread messages";
                lblUnreadMessages.Font = new System.Drawing.Font(DefaultFont.FontFamily, DefaultFont.Size, System.Drawing.FontStyle.Regular);
            }
        }

        private async void TimerRefresh_Tick(object sender, EventArgs e)
        {
            unreadMessages = 0;
            unreadMessageRequests = 0;
            FirebaseResponse response = await client.GetTaskAsync("User/" + CurrentUser.UserName);
            User responseAsUser = response.ResultAs<User>();
            if (CurrentUser.Messages.Count < responseAsUser.Messages.Count)
            {
                var popupNotifier = new PopupNotifier();
                if (responseAsUser.Messages.Count - CurrentUser.Messages.Count > 1)
                    popupNotifier.TitleText = "You have " + (responseAsUser.Messages.Count - CurrentUser.Messages.Count) + " new messages.";
                else
                    popupNotifier.TitleText = "You have one unread message.";
                string content = null;
                for (int i = 0; i < responseAsUser.Messages.Count; i++)
                {
                    if (!responseAsUser.Messages[i].IsSeen && responseAsUser.Messages[i].Sender != CurrentUser.UserName && CurrentUser.Contacts.Contains(responseAsUser.Messages[i].Sender))
                    {
                        if (i > lastNotificationMessageIndex)
                        {
                            lastNotificationMessageIndex = i;
                            content += "-" + responseAsUser.Messages[i].Sender + ": " + responseAsUser.Messages[i].Text + "\n";
                        }
                        unreadMessages++;
                    }
                    else if (!responseAsUser.Messages[i].IsSeen && responseAsUser.Messages[i].Sender != CurrentUser.UserName && !CurrentUser.Contacts.Contains(responseAsUser.Messages[i].Sender))
                    {
                        unreadMessageRequests++;
                    }
                }
                popupNotifier.ContentText = content;
                popupNotifier.IsRightToLeft = false;
                popupNotifier.BodyColor = System.Drawing.Color.LightBlue;
                popupNotifier.Popup();
                for (int i = CurrentUser.Messages.Count; i < responseAsUser.Messages.Count; i++)
                {
                    CurrentUser.Messages.Add(responseAsUser.Messages[i]);
                }
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"newmessage.wav");
                player.Play();
                updateUnreadMessageInfo();

            }
        }

        private async void BtnAcceptContactRequest_Click(object sender, EventArgs e)
        {
            if (lstContactRequests.SelectedIndex >= 0 && lstContactRequests.SelectedIndex < lstContactRequests.Items.Count)
            {
                CurrentUser.Contacts.Add(lstContactRequests.SelectedItem.ToString());
                lstContacts.Items.Add(lstContactRequests.SelectedItem.ToString());
                foreach (var item in CurrentUser.Messages)
                {
                    if (item.Sender == lstContactRequests.SelectedItem.ToString())
                    {
                        unreadMessageRequests--;
                        unreadMessages++;
                        updateUnreadMessageInfo();
                    }
                }
                SetResponse response1 = await client.SetTaskAsync("User/" + CurrentUser.UserName, CurrentUser);
            }
            else
                MessageBox.Show("Select a valid item from the list");
        }

        private async void BtnRemoveRequest_Click(object sender, EventArgs e)
        {
            if (lstContactRequests.SelectedIndex >= 0 && lstContactRequests.SelectedIndex < lstContactRequests.Items.Count)
            {
                CurrentUser.ContactRequests.Remove(lstContactRequests.SelectedItem.ToString());
                lstContactRequests.Items.Remove(lstContactRequests.SelectedItem);
                SetResponse response1 = await client.SetTaskAsync("User/" + CurrentUser.UserName, CurrentUser);
            }
            else
                MessageBox.Show("Select a valid item from the list");
        }

        private async void BtnRemoveContact_Click(object sender, EventArgs e)
        {

            if (lstContacts.SelectedIndex >= 0 && lstContacts.SelectedIndex < lstContacts.Items.Count)
            {
                CurrentUser.Contacts.Remove(lstContacts.SelectedItem.ToString());
                lstContacts.Items.Remove(lstContacts.SelectedItem);
                SetResponse response = await client.SetTaskAsync("User/" + CurrentUser.UserName, CurrentUser);

            }
        }
    }
}
