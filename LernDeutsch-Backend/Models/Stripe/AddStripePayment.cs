using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Models.Stripe
{
	public record AddStripePayment(
		string Username,
		string CourseId,
		AddStripeCard CreditCard);
}

