using System;
using System.Collections.Generic;

namespace _01Adapter
{
    public class MessageTestService : IMessageService
    {
        //ne használj null-t: null object pattern
        private List<Message> messages = new List<Message>();

        public MessageTestService()
        {
        }

        public void AddMessage(string to, string subject, string text)
        {
            messages.Add(new Message { To = to, Subject = subject, Text = text });
        }

        public void SendMessages()
        {
            foreach (var message in messages)
            {
                Console.WriteLine("To = {0}, Subject = {1}, Text = {2}", message.To, message.Subject, message.Text);
            }
        }
    }
}