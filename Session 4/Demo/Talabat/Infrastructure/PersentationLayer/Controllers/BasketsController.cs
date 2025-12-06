using Microsoft.AspNetCore.Mvc;
using ServiceAbstractionLayer;
using Shared.DTOS.BasketDtos;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketsController(IServiceManager serviceManager)
        : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<BasketDTO>> Update(BasketDTO basket)
            => Ok(await serviceManager.BasketService.UpdateAsync(basket));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await serviceManager.BasketService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BasketDTO>> Get(string id)
            => Ok(await serviceManager.BasketService.GetAsync(id));
    }
}
