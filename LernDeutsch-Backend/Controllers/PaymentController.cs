using LernDeutsch_Backend.Models.Stripe;
using LernDeutsch_Backend.Services.Stripe;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LernDeutsch_Backend.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IStripeService _stripeService;

        public PaymentController(IStripeService stripeService)
        {
            _stripeService = stripeService;
        }

        [HttpPost]
        public async Task<ActionResult<StripePayment>> AddStripePayment(
            [FromBody] AddStripePayment payment,
            CancellationToken ct)
        {
            bool IsPaymentAndEnrollmentSucc =  await _stripeService.AddStripePaymentAsync(
                payment,
                ct);

            if (!IsPaymentAndEnrollmentSucc)
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to buy course and enroll.");

            return StatusCode(StatusCodes.Status200OK, "Successfully enrolled and bought course.");
        }
    }
}

