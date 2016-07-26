using CQRSWithEvents.Src;
using NSubstitute;
using NUnit.Framework;

namespace CQRSWithEvents.Tests
{
    [TestFixture]
    class PaymentGatewayShould
    {
        private UserAccountChecker _userAccountChecker;
        private PaymentGateway _paymentGateway;
        private readonly string _userId = "12321";
        private readonly string _orderId = "order id";
        private EventPublisher _eventPublisher;
        private PaymentProvider _externalPaymentProvider;
        private string _emailAddress;

        [SetUp]
        public void SetUp()
        {
            _eventPublisher = Substitute.For<EventPublisher>();
            _userAccountChecker = Substitute.For<UserAccountChecker>();
            _externalPaymentProvider = Substitute.For<PaymentProvider>();
            _emailAddress = "user@ddress";
            _paymentGateway = new PaymentGateway(_eventPublisher, _externalPaymentProvider);
        }

        [Test]
        public void pay_and_fire_up_payment_made_event()
        {
            var handler = new MakePaymentCommandHandler(_userAccountChecker, _paymentGateway);
            handler.Handles(new MakePaymentCommand(_userId, _orderId, _emailAddress));
            _eventPublisher.Received().Publish(new PaymentMadeEvent(_emailAddress));

        }
    }
}
