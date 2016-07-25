using System;

namespace CQRSWithEvents.Src
{
    public class EventPublisher
    {
        private readonly Clock _clock;

        public EventPublisher(Clock clock)
        {
            _clock = clock;
        }

        public delegate void PaymentHasBeenMade(PaymentEventArgs args);

        public event PaymentHasBeenMade PaymentMade;

        public void Publish()
        {
            OnPaymentMade(new PaymentEventArgs("Payment has been successful."));
        }

        private void OnPaymentMade(PaymentEventArgs paymentMadeArgs)
        {
            PaymentHasBeenMade handler = PaymentMade;
            if (handler == null) return;
            paymentMadeArgs.Message += $" At {_clock.Now}";

            handler(paymentMadeArgs);
        }
    }
}