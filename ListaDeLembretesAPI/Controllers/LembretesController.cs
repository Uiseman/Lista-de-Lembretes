using ListaDeLembretesAPI.Context;
using ListaDeLembretesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeLembretesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LembretesController : Controller
    {
        private readonly AppDbContext? _context;

        public LembretesController(AppDbContext contexto)
        {
            _context = contexto;
        }


        [HttpGet]

        public ActionResult<IEnumerable<Lembrete>> Get()
        {
            try
            {
                var lembretes = _context.Lembretes.ToList();

                if (lembretes is null)
                {
                    return NotFound();
                }
                return lembretes;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Problema no tratamento da solicitação");
            }

        }

        [HttpGet("{id:int}", Name = "ObterLembretePeloId")]
        public ActionResult<Lembrete> Get(int id)
        {
            try
            {
                var lembrete = _context.Lembretes.FirstOrDefault(l => l.LembreteId == id);
                if (lembrete is null)
                {
                    return NotFound("Lembrete não encontrado");
                }
                return lembrete;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Problema no tratamento da solicitação");
            }

        }

        [HttpPost]

        public ActionResult Post([FromBody] Lembrete lembrete)
        {
            try
            {
                _context.Lembretes.Add(lembrete);
                _context.SaveChanges();
                return new CreatedAtRouteResult("ObterLembretePeloId",
                    new { id = lembrete.LembreteId }, lembrete);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Problema no tratamento da solicitação");
            }

        }

        [HttpDelete("{id:int}")]

        public ActionResult Delete(int id)
        {
            try
            {
                var lembrete = _context.Lembretes.FirstOrDefault(l => l.LembreteId == id);
                if (lembrete is null)
                {
                    return NotFound("Lembrete não localizado");
                }
                _context.Lembretes.Remove(lembrete);
                _context.SaveChanges();

                return Ok();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Problema no tratamento da solicitação");

            }
        }

        [HttpGet("lembretesPorData")]
        public ActionResult<IEnumerable<List<Lembrete>>> GetGroupedByDate()
        {
            try
            {
                var lembretesPorData = _context.Lembretes.OrderBy(l => l.Data).GroupBy(l => l.Data).
                                Select(group => group.ToList()).ToList();

                return lembretesPorData;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Problema no tratamento da solicitação");
            }

        }
    }
}