using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using SmartSchool.API.V1.Dtos;
using SmartSchool.API.Models;

namespace SmartSchool.API.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);

            var professoresResult = _mapper.Map<IEnumerable<ProfessorDto>>(result);
            
            return Ok(professoresResult);
        }

        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            var result = _repo.GetProfessorById(id, true);

            var professorResult = _mapper.Map<ProfessorDto>(result);

            return Ok(professorResult);
        }

        [HttpPost]
        public IActionResult Post(ProfessorCadastroDto professorCadastro)
        {
            var professor = _mapper.Map<Professor>(professorCadastro);

            _repo.Add(professor);

            if (_repo.SaveChanges())
                return Ok("Professor inserido com sucesso");
            else return BadRequest("Não foi possível inserir o professor");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorCadastroDto professorCadastro)
        {
            var professor = _mapper.Map<Professor>(professorCadastro);

            _repo.Update(professor);

            if (_repo.SaveChanges())
                return Ok("Professor alterado com sucesso");
            else return BadRequest("Não foi possível alterar o professor");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ProfessorCadastroDto professorCadastro)
        {
            var professor = _mapper.Map<Professor>(professorCadastro);

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
