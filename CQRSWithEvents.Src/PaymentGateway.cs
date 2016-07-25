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

        public virtual void Pay(PaymentParams paymentParams)
        {
            _externalPaymentProvider.Pay(paymentParams);
            _eventPublisher.Publish();
        }
    }
}