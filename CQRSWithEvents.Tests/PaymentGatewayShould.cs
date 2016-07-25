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
        private readonly string _orderId = "Halima order id";
        private EventPublisher _eventPublisher;
        private PaymentProvider _externalPaymentProvider;
        private Clock _clock;

        [SetUp]
        public void SetUp()
        {
            _clock = Substitute.For<Clock>();
            _eventPublisher = new EventPublisher(_clock);
            _userAccountChecker = Substitute.For<UserAccountChecker>();
            _externalPaymentProvider = Substitute.For<PaymentProvider>();
            _paymentGateway = new PaymentGateway(_eventPublisher, _externalPaymentProvider);
        }

        [Test]
        public void pay_and_fire_up_payment_made_event()
        {
            bool raised = false;
            _clock.Now.Returns("25/07/2016 23:17:47");
            _eventPublisher.PaymentMade += (args) =>
            {
                var paymentEventArgs    = new PaymentEventArgs("Payment has been successful. At 25/07/2016 23:17:47");
                raised = true;
                Assert.That(args.Message, Is.EqualTo(paymentEventArgs.Message));
            };
            var handler = new MakePaymentCommandHandler(_userAccountChecker, _paymentGateway);
            var paymentParams = new PaymentParams(_userId, _orderId);
            handler.Handles(new MakePaymentCommand(paymentParams));

            Assert.That(raised, Is.EqualTo(true));
        }
    }
}
