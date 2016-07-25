namespace CQRSWithEvents.Src
{
    public class MakePaymentCommand
    {
        public PaymentParams PaymentParams { get; set; }
        public string UserId => PaymentParams.UserId;

        public MakePaymentCommand(PaymentParams paymentParams)
        {
            PaymentParams = paymentParams;
        }
    }
}