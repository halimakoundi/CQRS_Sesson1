namespace CQRSWithEvents.Src
{
    public class PaymentMadeEvent : Event
    {
        public readonly string EmailAddress;

        public PaymentMadeEvent(string emailAddress)
        {
            EmailAddress = emailAddress;
        }

        public override bool Equals(object obj)
        {
            var otherEvent = (PaymentMadeEvent)obj;
            return EmailAddress == otherEvent.EmailAddress;
        }
    }
}