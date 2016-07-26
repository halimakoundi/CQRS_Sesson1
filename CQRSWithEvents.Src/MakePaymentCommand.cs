namespace CQRSWithEvents.Src
{
    public class MakePaymentCommand
    {
        public string OrderId { get; }
        public string UserId { get; }
        public string Email { get; set; }

        public MakePaymentCommand(string userId, string orderId, string email)
        {
            OrderId = orderId;
            UserId = userId; ;
            Email = email;
        }
    }
}