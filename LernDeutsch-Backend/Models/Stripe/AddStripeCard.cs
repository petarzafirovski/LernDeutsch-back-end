using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Models.Stripe
{
	public record AddStripeCard(
		string Name,
		string CardNumber,
		string ExpirationYear,
		string ExpirationMonth,
		string Cvc);
}
