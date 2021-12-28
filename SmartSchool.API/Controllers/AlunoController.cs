using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;

        public AlunoController(SmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            return Ok(_context.Alunos);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Add(aluno);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            _context.Update(aluno);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            _context.Update(aluno);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            _context.Remove(aluno);

            return Ok();
        }
    }
}
