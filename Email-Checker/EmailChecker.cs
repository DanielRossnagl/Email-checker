using System;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Security;


namespace Email_Checker
{
    class EmailChecker
    {
        
        // Checks and returns the amount of unread messages.       
        public int CheckEmails(string host, int port, string username, string password)
        {

            try
            {
                using (var client = new ImapClient())
                {
                    client.Connect(host, port, SecureSocketOptions.SslOnConnect);
                    client.Authenticate(username, password);

                    var inbox = client.Inbox;
                    inbox.Open(FolderAccess.ReadOnly);

                    // Suche nach ungelesenen E-Mails
                    var unread = inbox.Search(SearchQuery.NotSeen);

                    return unread.Count;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Abrufen der E-Mails: {ex.Message}");
                return -1; // Rückgabewert für Fehler
            }
        }
    }
}

