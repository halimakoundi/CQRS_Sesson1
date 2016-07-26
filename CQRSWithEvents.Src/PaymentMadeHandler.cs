namespace CQRSWithEvents.Src
{
    public class PaymentMadeHandler : Handler
    {
        private readonly EmailSender _emailSender;

        public PaymentMadeHandler(EmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void Handle(Event evnt)
        {
            _emailSender.Send(((PaymentMadeEvent)evnt).EmailAddress);
            
        }
    }
}