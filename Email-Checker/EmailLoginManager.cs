using System;
using System.Diagnostics;

namespace Email_Checker
{
    public class EmailLoginManager
    {
        // Responsible for managing user login to check unread emails.

        private EmailChecker _emailChecker; 
        private string _host;
        private int _port;
        private string _username;

        public EmailLoginManager(string host, int port, string username)
        {
            _emailChecker = new EmailChecker();
            _host = host;
            _port = port;
            _username = username;
        }

        
        public void Login()
        {
            bool validPassword = false;
            int attempts = 0;

            do
            {
                Console.Write("Bitte geben Sie Ihr Passwort ein: ");
                string password = ConsolePasswordReader.ReadPassword();

                int unreadEmails = _emailChecker.CheckEmails(_host, _port, _username, password);

                if (unreadEmails >= 0)
                {
                    validPassword = true;
                    Console.WriteLine($"Sie haben {unreadEmails} ungelesene E-Mails.");

                    
                        Console.Write("Schreiben Sie 'einsteigen', um in Ihre E-Mail einzusteigen oder aussteigen um das Program zu schließen: ");
                        string userInput = Console.ReadLine();

                        if (userInput == "einsteigen")
                        {
                            Console.WriteLine("Öffne Ihre E-Mail in Ihrem Standard-Browser...");
                            Process.Start(new ProcessStartInfo("cmd", $"/c start https://www.gmx.at/") { CreateNoWindow = true });
                        } else if (userInput == "aussteigen")
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Ungültige Eingabe");
                        }
                    
                }
                else
                {
                    attempts++;
                    Console.WriteLine($"Falsches Passwort. Versuch {attempts}/5. Bitte versuchen Sie es erneut.");
                }

                if (attempts >= 5)
                {
                    Console.WriteLine("Zu viele fehlgeschlagene Versuche. Das Programm wird beendet.");
                    return;
                }
            } while (!validPassword);

            Console.WriteLine("Erfolgreich eingeloggt!");
        }
    }
}
