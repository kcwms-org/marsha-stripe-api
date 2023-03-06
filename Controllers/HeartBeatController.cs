using Microsoft.AspNetCore.Mvc;
using NLipsum;


namespace marsha_stripe_api.Controllers;

[Route("heart-beat")]
[ApiController]
public class HeartBeatController : Controller 
{

    [HttpGet("")]
    [ProducesResponseType(typeof(string), 200)]
    public IActionResult Index()
    {
        var loremipsum =  new NLipsum.Core.LipsumGenerator().GenerateSentences(1);
        return Ok(new { DateTime.UtcNow ,loremipsum});
    }
}