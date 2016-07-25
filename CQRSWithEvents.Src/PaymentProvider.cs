namespace CQRSWithEvents.Src
{
    public interface PaymentProvider
    {
        void Pay(PaymentParams paymentParams);
    }
}