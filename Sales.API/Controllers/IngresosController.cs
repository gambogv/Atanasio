using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.Shared.Entites;

namespace Sales.API.Controllers
{

    [ApiController]
    [Route("/api/ingresos")]
    
    public class IngresosController : ControllerBase
    {

        private readonly DataContext _context;

        public IngresosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Ingresos.ToListAsync());
        }

      
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var ingreso = await _context.Ingresos.FirstOrDefaultAsync(x => x.Id == id);
            if (ingreso is null)
            {
                return NotFound();
            }

            return Ok(ingreso);
        }


        [HttpPost]
        public async Task<ActionResult> PostAsync(Ingreso ingreso)
        {
            _context.Add(ingreso);
            await _context.SaveChangesAsync();
            return Ok(ingreso);
        }


        [HttpPut]
        public async Task<ActionResult> PutAsync(Ingreso ingreso)
        {
            _context.Update(ingreso);
            await _context.SaveChangesAsync();
            return Ok(ingreso);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _context.Ingresos
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (afectedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }



    }
}
