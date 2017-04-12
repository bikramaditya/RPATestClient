using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

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

            RPAMicroServices.Ticket ticket = new RPAMicroServices.Ticket()
            {
                TicketId = "111",
                TicketNumber = "222",
                TicketTitle = "a lazy dog",
                TicketDescription = "jumps over",
                userID = "608847"
            };

            // Create a brokered message based on the order.
            BrokeredMessage ticketInMsg = new BrokeredMessage(ticket);

            Console.WriteLine("Sending order for {0}...", ticket.TicketId);

            // Send the message to the queue.
            queueClient.Send(ticketInMsg);

            Console.WriteLine("Done!");
            Console.WriteLine();

        }
    }
}
