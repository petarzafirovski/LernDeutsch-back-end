using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Models.Stripe
{
	public record AddStripeCard(
		string Name,
		long CardNumber,
		int ExpirationYear,
		int ExpirationMonth,
		string Cvc);
}
