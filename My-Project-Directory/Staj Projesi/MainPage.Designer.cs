namespace Staj_Projesi
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabMenu = new System.Windows.Forms.TabControl();
            this.Contacts = new System.Windows.Forms.TabPage();
            this.btnRemoveContact = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnStartChat = new System.Windows.Forms.Button();
            this.lstContacts = new System.Windows.Forms.ListBox();
            this.Search = new System.Windows.Forms.TabPage();
            this.btnAddContacts = new System.Windows.Forms.Button();
            this.lstSearchUsers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchUserName = new System.Windows.Forms.TextBox();
            this.tabContactRequests = new System.Windows.Forms.TabPage();
            this.btnRemoveRequest = new System.Windows.Forms.Button();
            this.btnAcceptContactRequest = new System.Windows.Forms.Button();
            this.lstContactRequests = new System.Windows.Forms.ListBox();
            this.lblUnreadMessages = new System.Windows.Forms.Label();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.tabMenu.SuspendLayout();
            this.Contacts.SuspendLayout();
            this.Search.SuspendLayout();
            this.tabContactRequests.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMenu
            // 
            this.tabMenu.Controls.Add(this.Contacts);
            this.tabMenu.Controls.Add(this.Search);
            this.tabMenu.Controls.Add(this.tabContactRequests);
            this.tabMenu.Location = new System.Drawing.Point(12, 29);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(577, 459);
            this.tabMenu.TabIndex = 0;
            this.tabMenu.TabStop = false;
            // 
            // Contacts
            // 
            this.Contacts.BackColor = System.Drawing.Color.RoyalBlue;
            this.Contacts.Controls.Add(this.btnRemoveContact);
            this.Contacts.Controls.Add(this.btnLogOut);
            this.Contacts.Controls.Add(this.btnStartChat);
            this.Contacts.Controls.Add(this.lstContacts);
            this.Contacts.Location = new System.Drawing.Point(4, 25);
            this.Contacts.Name = "Contacts";
            this.Contacts.Padding = new System.Windows.Forms.Padding(3);
            this.Contacts.Size = new System.Drawing.Size(569, 430);
            this.Contacts.TabIndex = 1;
            this.Contacts.Text = "Contacts";
            // 
            // btnRemoveContact
            // 
            this.btnRemoveContact.BackColor = System.Drawing.Color.DarkBlue;
            this.btnRemoveContact.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRemoveContact.Location = new System.Drawing.Point(453, 305);
            this.btnRemoveContact.Name = "btnRemoveContact";
            this.btnRemoveContact.Size = new System.Drawing.Size(110, 50);
            this.btnRemoveContact.TabIndex = 4;
            this.btnRemoveContact.Text = "Remove Contact";
            this.btnRemoveContact.UseVisualStyleBackColor = false;
            this.btnRemoveContact.Click += new System.EventHandler(this.BtnRemoveContact_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.DarkBlue;
            this.btnLogOut.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLogOut.Location = new System.Drawing.Point(453, 361);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(110, 63);
            this.btnLogOut.TabIndex = 3;
            this.btnLogOut.Text = "Log out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // btnStartChat
            // 
            this.btnStartChat.BackColor = System.Drawing.Color.DarkBlue;
            this.btnStartChat.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStartChat.Location = new System.Drawing.Point(453, 6);
            this.btnStartChat.Name = "btnStartChat";
            this.btnStartChat.Size = new System.Drawing.Size(110, 63);
            this.btnStartChat.TabIndex = 2;
            this.btnStartChat.Text = "Start Chat";
            this.btnStartChat.UseVisualStyleBackColor = false;
            this.btnStartChat.Click += new System.EventHandler(this.BtnStartChat_Click);
            // 
            // lstContacts
            // 
            this.lstContacts.FormattingEnabled = true;
            this.lstContacts.ItemHeight = 16;
            this.lstContacts.Location = new System.Drawing.Point(3, 4);
            this.lstContacts.Name = "lstContacts";
            this.lstContacts.Size = new System.Drawing.Size(444, 420);
            this.lstContacts.TabIndex = 0;
            // 
            // Search
            // 
            this.Search.BackColor = System.Drawing.Color.RoyalBlue;
            this.Search.Controls.Add(this.btnAddContacts);
            this.Search.Controls.Add(this.lstSearchUsers);
            this.Search.Controls.Add(this.label1);
            this.Search.Controls.Add(this.btnSearch);
            this.Search.Controls.Add(this.txtSearchUserName);
            this.Search.Location = new System.Drawing.Point(4, 25);
            this.Search.Name = "Search";
            this.Search.Padding = new System.Windows.Forms.Padding(3);
            this.Search.Size = new System.Drawing.Size(569, 430);
            this.Search.TabIndex = 2;
            this.Search.Text = "Search Users";
            // 
            // btnAddContacts
            // 
            this.btnAddContacts.BackColor = System.Drawing.Color.DarkBlue;
            this.btnAddContacts.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddContacts.Location = new System.Drawing.Point(459, 79);
            this.btnAddContacts.Name = "btnAddContacts";
            this.btnAddContacts.Size = new System.Drawing.Size(104, 68);
            this.btnAddContacts.TabIndex = 4;
            this.btnAddContacts.Text = "Add Contact";
            this.btnAddContacts.UseVisualStyleBackColor = false;
            this.btnAddContacts.Click += new System.EventHandler(this.BtnAddContacts_Click);
            // 
            // lstSearchUsers
            // 
            this.lstSearchUsers.FormattingEnabled = true;
            this.lstSearchUsers.ItemHeight = 16;
            this.lstSearchUsers.Location = new System.Drawing.Point(9, 79);
            this.lstSearchUsers.Name = "lstSearchUsers";
            this.lstSearchUsers.Size = new System.Drawing.Size(444, 308);
            this.lstSearchUsers.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "User Name:";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DarkBlue;
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.Location = new System.Drawing.Point(206, 36);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtSearchUserName
            // 
            this.txtSearchUserName.Location = new System.Drawing.Point(9, 37);
            this.txtSearchUserName.Name = "txtSearchUserName";
            this.txtSearchUserName.Size = new System.Drawing.Size(191, 22);
            this.txtSearchUserName.TabIndex = 0;
            // 
            // tabContactRequests
            // 
            this.tabContactRequests.BackColor = System.Drawing.Color.RoyalBlue;
            this.tabContactRequests.Controls.Add(this.btnRemoveRequest);
            this.tabContactRequests.Controls.Add(this.btnAcceptContactRequest);
            this.tabContactRequests.Controls.Add(this.lstContactRequests);
            this.tabContactRequests.Location = new System.Drawing.Point(4, 25);
            this.tabContactRequests.Name = "tabContactRequests";
            this.tabContactRequests.Padding = new System.Windows.Forms.Padding(3);
            this.tabContactRequests.Size = new System.Drawing.Size(569, 430);
            this.tabContactRequests.TabIndex = 3;
            this.tabContactRequests.Text = "Contact Requests";
            // 
            // btnRemoveRequest
            // 
            this.btnRemoveRequest.BackColor = System.Drawing.Color.DarkBlue;
            this.btnRemoveRequest.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRemoveRequest.Location = new System.Drawing.Point(462, 68);
            this.btnRemoveRequest.Name = "btnRemoveRequest";
            this.btnRemoveRequest.Size = new System.Drawing.Size(101, 49);
            this.btnRemoveRequest.TabIndex = 2;
            this.btnRemoveRequest.Text = "Remove Request";
            this.btnRemoveRequest.UseVisualStyleBackColor = false;
            this.btnRemoveRequest.Click += new System.EventHandler(this.BtnRemoveRequest_Click);
            // 
            // btnAcceptContactRequest
            // 
            this.btnAcceptContactRequest.BackColor = System.Drawing.Color.DarkBlue;
            this.btnAcceptContactRequest.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAcceptContactRequest.Location = new System.Drawing.Point(462, 6);
            this.btnAcceptContactRequest.Name = "btnAcceptContactRequest";
            this.btnAcceptContactRequest.Size = new System.Drawing.Size(101, 49);
            this.btnAcceptContactRequest.TabIndex = 1;
            this.btnAcceptContactRequest.Text = "Accept Request";
            this.btnAcceptContactRequest.UseVisualStyleBackColor = false;
            this.btnAcceptContactRequest.Click += new System.EventHandler(this.BtnAcceptContactRequest_Click);
            // 
            // lstContactRequests
            // 
            this.lstContactRequests.FormattingEnabled = true;
            this.lstContactRequests.ItemHeight = 16;
            this.lstContactRequests.Location = new System.Drawing.Point(6, 6);
            this.lstContactRequests.Name = "lstContactRequests";
            this.lstContactRequests.Size = new System.Drawing.Size(450, 420);
            this.lstContactRequests.TabIndex = 0;
            // 
            // lblUnreadMessages
            // 
            this.lblUnreadMessages.AutoSize = true;
            this.lblUnreadMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUnreadMessages.Location = new System.Drawing.Point(16, 9);
            this.lblUnreadMessages.Name = "lblUnreadMessages";
            this.lblUnreadMessages.Size = new System.Drawing.Size(58, 17);
            this.lblUnreadMessages.TabIndex = 1;
            this.lblUnreadMessages.Text = "Hehehe";
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 5000;
            this.timerRefresh.Tick += new System.EventHandler(this.TimerRefresh_Tick);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(601, 500);
            this.ControlBox = false;
            this.Controls.Add(this.lblUnreadMessages);
            this.Controls.Add(this.tabMenu);
            this.Name = "MainPage";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.tabMenu.ResumeLayout(false);
            this.Contacts.ResumeLayout(false);
            this.Search.ResumeLayout(false);
            this.Search.PerformLayout();
            this.tabContactRequests.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabMenu;
        private System.Windows.Forms.TabPage Contacts;
        public System.Windows.Forms.ListBox lstContacts;
        private System.Windows.Forms.TabPage Search;
        public System.Windows.Forms.Button btnAddContacts;
        public System.Windows.Forms.ListBox lstSearchUsers;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchUserName;
        public System.Windows.Forms.Button btnStartChat;
        public System.Windows.Forms.Button btnLogOut;
        public System.Windows.Forms.Label lblUnreadMessages;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.TabPage tabContactRequests;
        private System.Windows.Forms.Button btnRemoveRequest;
        private System.Windows.Forms.Button btnAcceptContactRequest;
        public System.Windows.Forms.ListBox lstContactRequests;
        private System.Windows.Forms.Button btnRemoveContact;
    }
}
