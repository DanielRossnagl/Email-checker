using Email_Checker;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Security.AccessControl;
using IWshRuntimeLibrary;

class Program
{
    static void Main(string[] args)
    {
        string host = "imap.gmx.net";
        int port = 993;
        string username = "rossnagl.daniel@gmx.at";

        StartupManager.AddToStartup();

        EmailChecker emailChecker = new EmailChecker();


        EmailLoginManager loginManager = new EmailLoginManager(host, port, username);
        loginManager.Login();
    }

   
}

