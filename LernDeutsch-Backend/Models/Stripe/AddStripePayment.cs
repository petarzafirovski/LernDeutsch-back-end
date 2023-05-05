using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Models.Stripe
{
	public record AddStripePayment(
		string Email,
		string Name,
		string Description,
		string Currency,
		long Amount,
		AddStripeCard CreditCard);
}

