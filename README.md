# Whatsapp-Jr

In this repository, I tried to create a texting program where you can search for users and contact them, and you can text them freely.
I used Firebase database, a little bit of Regular Expressions, also a bit of Tulpep Notifications.

### How to use

You have to have Internet connection in order to use this program.

You have to create an account in "Sign Up" tab, User names cannot contain special characters -Excluding '_'-, then you can connect freely.

When you get into Main Page, you can search for users, find them and send them a request to contact them, you can text them even when they don't accept your request but they won't be able to see your messages, they will only get a "You have x amount of unread message request" notification.

You will get a popup notication in your screen whenever you get a new message. If you don't have any open chat pages, you will also hear a "new message sound".

Also, you can delete any contact from your list, if you do so, they won't be able to send any more contact requests.


### How does it work

Whatsapp Jr. uses the [Firebase database](https://firebase.google.com/) to store the messages sent from the user. When you send a contact request or a message, it updates your and the target users' info in the database, every few seconds, program updates your info from the Firabase, therefore you can see your new messages and contact requests.

Whenever you get a new message from a user, you get a new notification which shows few unread messages and who sent you those messages. To do so, I used Tulpep Notifications.
