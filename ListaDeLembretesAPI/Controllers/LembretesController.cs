using ListaDeLembretesAPI.Context;
using ListaDeLembretesAPI.Models;
using ListaDeLembretesAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeLembretesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LembretesController : Controller
    {
        private readonly IUnitOfWork? _unitOfWork;

        public LembretesController(IUnitOfWork? unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]

        public ActionResult<IEnumerable<Lembrete>> Get()
        {
            try
            {
                var lembretes = _unitOfWork.LembreteRepository.Get().ToList();

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
                var lembrete = _unitOfWork.LembreteRepository.GetById(l => l.LembreteId == id);
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
                _unitOfWork.LembreteRepository.Add(lembrete);
                _unitOfWork.Commit();
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
                var lembrete = _unitOfWork.LembreteRepository.GetById(l => l.LembreteId == id);
                if (lembrete is null)
                {
                    return NotFound("Lembrete não localizado");
                }
                _unitOfWork.LembreteRepository.Delete(lembrete);
                _unitOfWork.Commit();

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
                var lembretesPorData = _unitOfWork.LembreteRepository.GetGroupedByDate().ToList();

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