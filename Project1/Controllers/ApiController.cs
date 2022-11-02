using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project1.Models;

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly GuardiansContext _dbContext;
        public ApiController(GuardiansContext Context)
        {
            _dbContext = Context;
        }
        //api para heroes
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Listaheroe(){

            List<Heroe> heroes = await _dbContext.Heroes.OrderByDescending(c => c.IdHero).ToListAsync();
      
            return StatusCode(StatusCodes.Status200OK, heroes);
        }

        // GET: api/Heroes/5
        [HttpGet("Heroeid/{id}")]
        public async Task<ActionResult<Heroe>> GetHeroe(int id)
        {

            var heroe = await _dbContext.Heroes.FindAsync(id);

            if (heroe == null)
            {
                return NotFound();
            }

            return heroe;
        }

        [HttpGet("heroenombre/{nombre}")]
        public async Task<ActionResult<IEnumerable<Heroe>>> GetHeroeN(String nombre)
        {
            var heroess = await _dbContext.Heroes.Where(x => x.NombreCompleto.Equals(nombre)).ToListAsync();

            if (heroess == null)
            {
                return NotFound();
            }

            return heroess;
        }

        [HttpGet("heroehabilidad/{habilidad}")]
        public async Task<ActionResult<IEnumerable<Heroe>>> GetHeroH(String habilidad)
        {

            var heroess = await _dbContext.Heroes.Where(x => x.HabilidadesPoderes.Equals(habilidad)).ToListAsync();

            if (heroess == null)
            {
                return NotFound();
            }

            return heroess;
        }

        [HttpGet]
        [Route("RelacionesHeroe/{id}")]
        public async Task<IActionResult> Listaheroe(int id)
        {
            List<Heroe> heroes = await _dbContext.Heroes.OrderByDescending(c => c.IdHero).ToListAsync();
            List<Relacione> lista = await _dbContext.Relaciones.ToListAsync();
            List<Relacione> listaRelaciones = new List<Relacione>();
            List<Heroe> listaHeroes = new List<Heroe>();

            foreach (Heroe heroe in heroes)
            {
                foreach (var item in lista)
                {
                    if (item.IdHero.Value == heroe.IdHero)
                    {
                        
                        listaRelaciones.Add(item);
                    }
                };

                
            }
            
            return StatusCode(StatusCodes.Status200OK, lista);
        }

    
        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> guardarheroe([FromBody] Heroe request)
        {
            await _dbContext.Heroes.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpPost]
        [Route("editar")]
        public async Task<IActionResult> editarheroe([FromBody] Heroe request)
        {
             _dbContext.Heroes.Update(request);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpDelete]
        [Route("eliminar/{id:int}")]
        public async Task<IActionResult> eliminarheroe(int id)
        {
           Heroe heroe = _dbContext.Heroes.Find(id);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }
        //------------------------------------------------------------------------------------------//
        //api para villanos
        [HttpGet]
        [Route("ListaV")]
        public async Task<IActionResult> Listavillano()
        {

            List<Villano> villanos = await _dbContext.Villanos.OrderByDescending(c => c.IdVillain).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, villanos);
        }
        [HttpPost]
        [Route("GuardarV")]
        public async Task<IActionResult> guardarvillano([FromBody] Villano request)
        {
            await _dbContext.Villanos.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpPost]
        [Route("editarV")]
        public async Task<IActionResult> editarvillano([FromBody] Villano request)
        {
            _dbContext.Villanos.Update(request);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpDelete]
        [Route("eliminarV/{id:int}")]
        public async Task<IActionResult> eliminarvillano(int id)
        {
            Villano villano = _dbContext.Villanos.Find(id);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }
        //------------------------------------------------------------------------------------------//
        //api para enfrentamiento
        [HttpGet]
        [Route("enfrentamientos")]
        public async Task<IActionResult> Listaenfrentamientos()
        {
            List<Enfrentamiento> enfrentamientos = await _dbContext.Enfrentamientos.OrderByDescending(c => c.IdRegistro).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, enfrentamientos);
        }
        [HttpGet]
        [Route("enfrentamientos/{idhero}")]
        public async Task<IActionResult> Listaenfrentamientos(int idhero)
        {
            List<Enfrentamiento> enfrentamientos = await _dbContext.Enfrentamientos.Where(x => x.IdHero.Equals(idhero)).ToListAsync();
            var numero = enfrentamientos.GroupBy(c => c.IdVillain).Select(x => new { }).Count();
            return StatusCode(StatusCodes.Status200OK, numero);
        }
        [HttpPost]
        [Route("GuardarE")]
        public async Task<IActionResult> guardarenfrentamientos([FromBody] Enfrentamiento request)
        {
            await _dbContext.Enfrentamientos.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpPost]
        [Route("editarE")]
        public async Task<IActionResult> editarenfrentamientos([FromBody] Enfrentamiento request)
        {
            _dbContext.Enfrentamientos.Update(request);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpDelete]
        [Route("eliminarE/{id:int}")]
        public async Task<IActionResult> eliminarenfrentamientos(int id)
        {
            Enfrentamiento enfrentamientos = _dbContext.Enfrentamientos.Find(id);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        //------------------------------------------------------------------------------------------//
        //api para relaciones
        [HttpGet]
        [Route("relaciones")]
        public async Task<IActionResult> Listarelaciones()
        {

            List<Relacione> relaciones = await _dbContext.Relaciones.OrderByDescending(c => c.IdRelacion).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, relaciones);
        }
        [Route("relaciones/{idhero}")]
        public async Task<IActionResult> Listarelacionesheroe(int idhero)
        {

            List<Relacione> relaciones = await _dbContext.Relaciones.Where(x=>x.IdHero.Equals(idhero)).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, relaciones);
        }
        [HttpPost]
        [Route("GuardarR")]
        public async Task<IActionResult> guardarrelaciones([FromBody] Relacione request)
        {
            await _dbContext.Relaciones.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpPost]
        [Route("editarR")]
        public async Task<IActionResult> editarrelaciones([FromBody] Relacione request)
        {
            _dbContext.Relaciones.Update(request);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpDelete]
        [Route("eliminarR/{id:int}")]
        public async Task<IActionResult> eliminarrelaciones(int id)
        {
            Relacione relaciones = _dbContext.Relaciones.Find(id);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        //------------------------------------------------------------------------------------------//
        //api para Patrocinador
        [HttpGet]
        [Route("patrocinador")]
        public async Task<IActionResult> Listapatrocinador()
        {

            List<Patrocinador> patrocinador = await _dbContext.Patrocinadors.OrderByDescending(c => c.IdPatrocinador).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, patrocinador);
        }
        [HttpPost]
        [Route("GuardarP")]
        public async Task<IActionResult> guardarpatrocinador([FromBody] Patrocinador request)
        {
            await _dbContext.Patrocinadors.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpPost]
        [Route("editarP")]
        public async Task<IActionResult> editarpatrocinador([FromBody] Patrocinador request)
        {
            _dbContext.Patrocinadors.Update(request);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpDelete]
        [Route("eliminarP/{id:int}")]
        public async Task<IActionResult> eliminarpatrocinador(int id)
        {
            Patrocinador patrocinador = _dbContext.Patrocinadors.Find(id);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }
        //------------------------------------------------------------------------------------------//
        //api para Patrocina
        [HttpGet]
        [Route("patrocina")]
        public async Task<IActionResult> Listapatrocina()
        {

            List<Patrocina> patrocina = await _dbContext.Patrocinas.OrderByDescending(c => c.IdPatrocinio).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, patrocina);
        }
        [HttpPost]
        [Route("GuardarP")]
        public async Task<IActionResult> guardarpatrocina([FromBody] Patrocina request)
        {
            await _dbContext.Patrocinas.AddAsync(request);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpPost]
        [Route("editarP")]
        public async Task<IActionResult> editarpatrocina([FromBody] Patrocina request)
        {
            _dbContext.Patrocinas.Update(request);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpDelete]
        [Route("eliminarP/{id:int}")]
        public async Task<IActionResult> eliminarpatrocina(int id)
        {
            Patrocina patrocina = _dbContext.Patrocinas.Find(id);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

    }
}
