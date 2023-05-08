using LernDeutsch_Backend.Models.Stripe;

namespace LernDeutsch_Backend.Services.Stripe
{
	public interface IStripeService
	{
		Task<bool> AddStripePaymentAsync(AddStripePayment payment, CancellationToken ct);
	}
}
