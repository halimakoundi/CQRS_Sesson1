namespace CQRSWithEvents.Src
{
    public class PaymentGateway
    {
        private readonly EventPublisher _eventPublisher;
        private readonly PaymentProvider _externalPaymentProvider;

        public PaymentGateway(EventPublisher eventPublisher, PaymentProvider externalPaymentProvider)
        {
            _eventPublisher = eventPublisher;
            _externalPaymentProvider = externalPaymentProvider;
        }

        public virtual void Pay(string userId, string orderId, string userEmail)
        {
            _externalPaymentProvider.Pay(userId, orderId);
            _eventPublisher.Publish(new PaymentMadeEvent(userEmail));
        }
    }
}