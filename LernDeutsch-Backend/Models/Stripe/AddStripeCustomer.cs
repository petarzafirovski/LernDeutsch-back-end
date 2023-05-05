using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Models.Stripe
{
	public record AddStripeCustomer(
		string Email,
		string Name,
		AddStripeCard CreditCard);
}
