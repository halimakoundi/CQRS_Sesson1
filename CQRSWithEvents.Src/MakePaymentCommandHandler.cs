namespace CQRSWithEvents.Src
{
    public class MakePaymentCommandHandler
    {
        private readonly PaymentGateway _paymentGateway;
        private readonly UserAccountChecker _userAccountChecker;

        public MakePaymentCommandHandler(UserAccountChecker userAccountChecker, PaymentGateway paymentGateway)
        {
            _userAccountChecker = userAccountChecker;
            _paymentGateway = paymentGateway;
        }

        public void Handles(MakePaymentCommand command)
        {
            _userAccountChecker.Check(command.UserId);
            _paymentGateway.Pay(command.UserId, command.OrderId, command.Email);
        }
    }
}
