using System;

namespace CQRSWithEvents.Src
{
    public class EmailSender
    {
        public virtual void Send(string emailAddress)
        {
            Console.WriteLine($"Email has been sent to {emailAddress}");
        }
    }
}