namespace CQRSWithEvents.Src
{
    public interface Handler
    {
        void Handle(Event evnt);
    }
}