using CQRSWithEvents.Src;
using NSubstitute;
using NUnit.Framework;

namespace CQRSWithEvents.Tests
{
    [TestFixture]
    public class MakePaymentCommandHandlerShould
    {
        private UserAccountChecker _userAccountChecker;
        private PaymentGateway _paymentGateway;
        private string UserId = "12321";
        private string OrderId = "Halima order id";
        private Clock _clock=Substitute.For<Clock>();
        private string email = "email";

        [Test]
        public void pay_if_user_account_is_valid()
        {
            _userAccountChecker = Substitute.For<UserAccountChecker>();
            var eventPublisher  = Substitute.For<EventPublisher>();
            var paymentProvider= Substitute.For<PaymentProvider>();
            _paymentGateway = Substitute.For<PaymentGateway>(eventPublisher, paymentProvider);

            var handler = new MakePaymentCommandHandler(_userAccountChecker, _paymentGateway);

            handler.Handles(new MakePaymentCommand(UserId, OrderId,email));

            Received.InOrder(() =>
            {
                _userAccountChecker.Received().Check(UserId);
                _paymentGateway.Received().Pay(UserId, OrderId, email);
            });
        }
    }
}
