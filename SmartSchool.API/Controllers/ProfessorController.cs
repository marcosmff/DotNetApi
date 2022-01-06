using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            var result = _repo.GetProfessorById(id, true);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);

            if (_repo.SaveChanges())
                return Ok("Professor inserido com sucesso");
            else return BadRequest("Não foi possível inserir o professor");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            _repo.Update(professor);

            if (_repo.SaveChanges())
                return Ok("Professor alterado com sucesso");
            else return BadRequest("Não foi possível alterar o professor");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            _repo.Update(professor);

            if (_repo.SaveChanges())
                return Ok("Professor alterado com sucesso");
            else return BadRequest("Não foi possível alterar o professor");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessorById(id);

            _repo.Remove(professor);

            if (_repo.SaveChanges())
                return Ok("Professor alterado com sucesso");
            else return BadRequest("Não foi possível alterar o professor");
        }
    }
}
