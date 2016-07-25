using System;

namespace CQRSWithEvents.Src
{
    public class PaymentEventArgs : EventArgs
    {
        public string Message { get; set; }

        public PaymentEventArgs(string message)
        {
            Message = message;
        }
    }
}