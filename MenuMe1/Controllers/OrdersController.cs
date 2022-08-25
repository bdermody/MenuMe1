using MenuMe1.Models;
using MenuMe1.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MenuMe1.Controllers
{
    [ApiController]
    [Route("api/ordenes")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        public OrdersController(IRepository<Orden> respository)
        {
            Respository = respository;
        }

        readonly IRepository<Orden> Respository;

        [HttpGet]
        [Route("getall")]
        public JsonResult GetAll()
        {
            return new JsonResult(Respository.GetAll());
        }
    }
}
