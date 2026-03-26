using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalksAPI.Controllers
{
    //test_controller url: http://localhost:5213/api/entity
    //test_controller url: https://localhost:7083/api/entity
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : ControllerBase
    {
        [HttpGet(Name = "GetEntities")]
        public IActionResult GetEntities()
        {
            string[] entities = { "Entity1", "Entity2", "Entity3", "Entity4", "Entity5" };

            return Ok(entities);
        }
    }
}
