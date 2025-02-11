using index_engine.Models;
using index_engine.Services;
using Microsoft.AspNetCore.Mvc;

namespace index_engine.Controllers;

[ApiController]
[Route("[controller]")]
public class PricingController(IPricingService pricing) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Get([FromBody]PricingRequest request)
    {
        var result = await pricing.Get(request);
        return Ok(result);
    }
}
