
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Entidades;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("celular")]
    public class CelularesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public CelularesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<List<Celular>>> GetAll()
        {
            return await dbContext.celular.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Celular>> GetByID(int id)
        {
            return await dbContext.celular.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Celular celular)
        {
            var existeMarca = await dbContext.marcas.AnyAsync(x => x.ID == celular.MarcaID);

            if (!existeMarca)
            {
                return BadRequest("No existe la marca");
            }

            dbContext.Add(celular);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Celular celular, int id)
        {
            var existeCelular = await dbContext.celular.AnyAsync(x => x.Id == celular.Id);

            if (!existeCelular)
            {
                return BadRequest("No existe el celular");
            }

            if (celular.Id != id)
            {
                return BadRequest("El ID del celular no coincide");
            }

            dbContext.Update(celular);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await dbContext.celular.AnyAsync(x => x.Id == id);
            if (!exists)
            {
                return NotFound("No existe celular con dicha ID");
            }

            dbContext.Remove(new Celular()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
