using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        public ProfessorController()
        {
        }

        List<Professor> professores = new List<Professor>()
        {
            new Professor()
            {
                Id = 1,
                Nome = "João"
            },
            new Professor()
            {
                Id = 2,
                Nome = "Carlos"
            },
            new Professor()
            {
                Id = 3,
                Nome = "Manuel"
            }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(professores);
        }

        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            var retorno = professores.Where(professor => professor.Id == id);
            return Ok(retorno);
        }

        [HttpGet("Filter")]
        public IActionResult GetByFilter(string? nome = "", string? sobrenome = "")
        {
            var retorno = professores.Where(professor => professor.Nome.Contains(nome ?? ""));
            return Ok(retorno);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            professores.Add(professor);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            professores.RemoveAll(professor => professor.Id == id);

            return Ok();
        }
    }
}
