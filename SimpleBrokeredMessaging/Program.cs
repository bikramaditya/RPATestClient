using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using RPA;

namespace SimpleBrokeredMessaging
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating queue client...");


            QueueClient queueClient = QueueClient.CreateFromConnectionString(AccountDetails.connectionString, AccountDetails.QName);

            Console.WriteLine("QClient created!");
            Console.WriteLine();

            RPATicket ticket = new RPATicket()
            {
                TicketId = "",
                TicketNumber = "222",
                TicketTitle = "Please change my password",
                TicketDescription = "Please reset my pw for user id 608847",
                Categories = new List<string>{ "pass", "word" ,"remote"},
                userID = "608847"
            };

            // Create a brokered message based on the order.
            BrokeredMessage ticketInMsg = new BrokeredMessage(ticket);

            Console.WriteLine("Sending order for {0}...", ticket.TicketId);

            // Send the message to the queue.
            queueClient.Send(ticketInMsg);
            
            Console.WriteLine("Done!");
            
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ticket.GetType());
            x.Serialize(Console.Out, ticket);
            Console.WriteLine();
            Thread.Sleep(1000);
           // Console.ReadLine();
        }
    }
}
