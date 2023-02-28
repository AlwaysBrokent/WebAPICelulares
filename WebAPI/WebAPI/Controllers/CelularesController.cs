using Microsoft.AspNetCore.Mvc;
using WebAPI.Entidades;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/celulares")]
    public class CelularesController: ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Celular>> Get() 
        {
            return new List<Celular>()
            {
                new Celular() { Id = 1, Nombre = "Xiaomi" },
                new Celular() { Id = 2, Nombre = "Samsung" },
            };
           
        }


    }
}
