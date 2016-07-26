using System;
using CQRSWithEvents.Src;

namespace CQRS_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventPublisher = new EventPublisher();
            var commandHanlder = new MakePaymentCommandHandler(new UserAccountChecker(),
                                                                new PaymentGateway(eventPublisher,
                                                                new PaypalPaymentProvider()));
            var eventHandler = new PaymentMadeHandler(new EmailSender());
            eventPublisher.AddHandler<PaymentMadeEvent>(typeof(PaymentMadeEvent), eventHandler);

            commandHanlder.Handles(new MakePaymentCommand("User 24353", "OrderId 890", "client@order.com"));

            Console.Read();

        }
    }

    internal class PaypalPaymentProvider : PaymentProvider
    {
        public void Pay(string userId, string orderId)
        {
            Console.WriteLine($"Payment has been made ! {userId} {orderId}");
        }
    }
}
