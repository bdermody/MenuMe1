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
        public OrdersController(IRepository<Orden> repository)
        {
            Repository = repository;
        }

        readonly IRepository<Orden> Repository;

        [HttpGet]
        [Route("getall")]
        public JsonResult GetAll()
        {
            return new JsonResult(Repository.GetAll());
        }


        [HttpPost]
        [Route("create")]
        public JsonResult Create(CreateOrden co)
        {
            Orden orden = new Orden(co);
            Repository.Insert(orden);
            Repository.Save();

            return new JsonResult(Repository.Get(orden.Id));

        }
    }
}
