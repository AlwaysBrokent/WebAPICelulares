using Microsoft.AspNetCore.Mvc;
using WebAPI.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/Marcas")]
    public class MarcasController : ControllerBase
    {

        private readonly ApplicationDbContext dbContext;
        public MarcasController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<Marca>> Get()
        {
            return new List<Marca>()
            {
                new Marca() { ID = 1, nombre = "Samsung", pais = "Corea del Sur" },
                new Marca() { ID = 2, nombre = "Apple", pais = "Estados Unidos" },
            };

        }

        [HttpPost]
        public async Task<ActionResult> Post(Marca marca)
        {
            dbContext.Add(marca);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("/lista")]

        public async Task<ActionResult<List<Marca>>> GetAll()
        {
            return await dbContext.marcas.Include(x => x.celular).ToListAsync();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Marca marca, int id)
        {
            if (marca.ID != id)
            {
                return BadRequest("El ID de la marca no coincide con el establecido en la url");
            }

            dbContext.Update(marca);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await dbContext.marcas.AnyAsync(x => x.ID == id);
            if (!exists)
            {
                return NotFound("No existe registro con tal ID");
            }

            dbContext.Remove(new Marca()
            {
                ID = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
