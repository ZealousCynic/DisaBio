using Microsoft.Azure.NotificationHubs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DisaBioAppNotificationDispatcher
{
    class Program
    {
        static int messageCount = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter Notification:");
            string notification = Console.ReadLine();

            WriteSeparator();

            Console.WriteLine($"Press the spacebar to send a message to each tag in {string.Join(", ", DispatcherConstants.SubscriptionTags)}");

            if (notification.Length > 0)
            {
                while (Console.ReadKey().Key == ConsoleKey.Spacebar)
                {
                    SendTemplateNotificationsAsync(notification).GetAwaiter().GetResult();
                }
            }
        }

        private static async Task SendTemplateNotificationsAsync(string notification)
        {
            NotificationHubClient hub = NotificationHubClient.CreateClientFromConnectionString(DispatcherConstants.FullAccessConnectionString, DispatcherConstants.NotificationHubName);
            Dictionary<string, string> templateParameters = new Dictionary<string, string>();

            messageCount++;

            // Send a template notification to each tag. This will go to any devices that
            // have subscribed to this tag with a template that includes "messageParam"
            // as a parameter
            foreach (var tag in DispatcherConstants.SubscriptionTags)
            {
                //templateParameters["messageParam"] = $"Notification #{messageCount} to {tag} category subscribers!";
                templateParameters["messageParam"] = notification;
                try
                {
                    await hub.SendTemplateNotificationAsync(templateParameters, tag);
                    Console.WriteLine($"Sent message to {tag} subscribers.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to send template notification: {ex.Message}");
                }
            }

            Console.WriteLine($"Sent messages to {DispatcherConstants.SubscriptionTags.Length} tags.");
            WriteSeparator();
        }

        private static void WriteSeparator()
        {
            Console.WriteLine("==========================================================================");
        }
    }
}
