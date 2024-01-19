using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateBrand(CreateBrandCommandRequest request)
    {
        CreatedBrandCommandResponse response = await Mediator.Send(request);
        return Ok(response);
    }
}