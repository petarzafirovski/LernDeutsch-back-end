using LernDeutsch_Backend.Models.Stripe;
using Stripe;

namespace LernDeutsch_Backend.Services.Stripe
{
    public class StripeService : IStripeService
    {
        private readonly ChargeService _chargeService;
        private readonly CustomerService _customerService;
        private readonly TokenService _tokenService;

        public StripeService(
            ChargeService chargeService,
            CustomerService customerService,
            TokenService tokenService)
        {
            _chargeService = chargeService;
            _customerService = customerService;
            _tokenService = tokenService;
        }

        public async Task<StripeCustomer> AddStripeCustomerAsync(string Email, string Name, AddStripeCard card, CancellationToken ct)
        {
            TokenCreateOptions tokenOptions = new()
            {
                Card = new TokenCardOptions
                {
                    Name = Name,
                    Number = card.CardNumber,
                    ExpYear = card.ExpirationYear,
                    ExpMonth = card.ExpirationMonth,
                    Cvc = card.Cvc
                }
            };

            Token stripeToken = await _tokenService.CreateAsync(tokenOptions, null, ct);

            CustomerCreateOptions customerOptions = new()
            {
                Name = Name,
                Email = Email,
                Source = stripeToken.Id
            };

            Customer createdCustomer = await _customerService.CreateAsync(customerOptions, null, ct);

            return new StripeCustomer(createdCustomer.Name, createdCustomer.Email, createdCustomer.Id);
        }


        public async Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken ct)
        {
            var getStripeCustomer = await AddStripeCustomerAsync(payment.Email, payment.Name, payment.CreditCard, ct);

            ChargeCreateOptions paymentOptions = new()
            {
                Customer = getStripeCustomer.CustomerId,
                ReceiptEmail = getStripeCustomer.Email,
                Description = payment.Description,
                Currency = payment.Currency,
                Amount = payment.Amount
            };

            var createdPayment = await _chargeService.CreateAsync(paymentOptions, null, ct);

            return new StripePayment(
              createdPayment.CustomerId,
              createdPayment.ReceiptEmail,
              createdPayment.Description,
              createdPayment.Currency,
              createdPayment.Amount,
              createdPayment.Id);
        }


    }
}
