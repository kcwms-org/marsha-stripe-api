using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace marsha_stripe_api.Controllers;

[Route("create-checkout-session")]
[ApiController]
public class CheckoutApiController : Controller
{
  internal class StripeSessionInfo{
    public string Url { get; set; } = string.Empty;
  }

    [HttpPost]
    [ProducesResponseType(typeof(StripeSessionInfo), 200)]
    public IActionResult Create(StripePaymentSubmissionDto payment)
    {
        var domain = payment.Domain;
        var options = new SessionCreateOptions
        {
            LineItems = new List<SessionLineItemOptions>
                {
                  new SessionLineItemOptions
                  {
                    // Provide the exact Price ID (for example, pr_1234) of the product you want to sell
                    Price = payment.ProductId,
                    Quantity = payment.Quantity,
                  },
                },
            Mode = "payment",
            SuccessUrl = domain + "/striperesult/success",
            CancelUrl = domain + "/striperesult/fail",
        };
        var service = new SessionService();
        Session session = service.Create(options);


        return  Ok(new {session.Url});
    }
}