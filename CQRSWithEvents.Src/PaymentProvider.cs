namespace CQRSWithEvents.Src
{
    public interface PaymentProvider
    {
        void Pay(string userId, string orderId);
    }
}