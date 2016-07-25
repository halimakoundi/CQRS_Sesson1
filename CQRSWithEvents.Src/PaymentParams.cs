namespace CQRSWithEvents.Src
{
    public class PaymentParams
    {

        public PaymentParams(string userId, string orderId)
        {
            OrderId = orderId;
            UserId = userId;
        }

        public string OrderId { get; }

        public string UserId { get; }
    }
}