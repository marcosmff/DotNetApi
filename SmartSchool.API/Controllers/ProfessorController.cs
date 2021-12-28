using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        public ProfessorController(SmartContext context)
        {
            _context = context;
        }

        private readonly SmartContext _context;

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            var retorno = _context.Professores.Where(professor => professor.Id == id);
            return Ok(retorno);
        }

        [HttpGet("Filter")]
        public IActionResult GetByFilter(string? nome = "", string? sobrenome = "")
        {
            var retorno = _context.Professores.Where(professor => professor.Nome.Contains(nome ?? ""));
            return Ok(retorno);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            _context.Update(professor);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            _context.Update(professor);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _context.Professores.FirstOrDefault(professor => professor.Id == id);

            _context.Remove(professor);

            return Ok();
        }
    }
}
