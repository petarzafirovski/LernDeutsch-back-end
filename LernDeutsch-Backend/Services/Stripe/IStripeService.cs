using LernDeutsch_Backend.Models.Stripe;

namespace LernDeutsch_Backend.Services.Stripe
{
	public interface IStripeService
	{
		Task<StripeCustomer> AddStripeCustomerAsync(AddStripeCustomer customer, CancellationToken ct);
		Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken ct);
	}
}
