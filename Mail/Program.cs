using MailKit.Net.Imap;
//using S22.Imap;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

//using AE.Net.Mail;

namespace Mail
{
    [TestClass]
    public class Program
    {
        [TestMethod]
        static void Main(string[] args)
        {
            List<string> messagesList = new List<string>();
            ImapClient client = new ImapClient();

            client.Connect("imap.gmail.com", 993, MailKit.Security.SecureSocketOptions.SslOnConnect);
            client.Authenticate("olena.chernovolyk@gmail.com", "pass");
            //Console.WriteLine("We are connected!");
            //Console.ReadLine();

            client.Inbox.Open(MailKit.FolderAccess.ReadOnly);

            IList<MailKit.UniqueId> uids = client.Inbox.Search(MailKit.Search.SearchQuery.All);

            for (int i = 0; i < uids.Count; i++)
            {
                try
                {
                    foreach (MailKit.UniqueId uid in uids)
                    {
                        MimeKit.MimeMessage message = client.Inbox.GetMessage(uid);


                        string subject = message.Subject.ToString();

                        Console.WriteLine(subject);


                    }

                    Console.ReadLine();
                    client.Disconnect(true);
                }

                catch (NullReferenceException)
                {
                    continue;
                }
            }
            }


        }





} 
    
        
    

