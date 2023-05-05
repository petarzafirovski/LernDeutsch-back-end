using System.ComponentModel.DataAnnotations;

namespace LernDeutsch_Backend.Models.Stripe
{
	public record AddStripePayment(
		string CustomerId,
		string ReceiptEmail,
		string Description,
		string Currency,
		long Amount);
}

