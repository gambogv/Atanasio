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

        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Ingresos.ToListAsync());
        }


        [HttpPost]
        public async Task<ActionResult> Post(Ingreso ingreso)
        {
            _context.Add(ingreso);
            await _context.SaveChangesAsync();
            return Ok(ingreso);
        }


    }
}
