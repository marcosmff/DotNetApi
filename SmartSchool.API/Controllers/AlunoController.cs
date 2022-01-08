using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using SmartSchool.API.Dtos;
using SmartSchool.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public AlunoController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);
            var alunosResult = _mapper.Map<IEnumerable<AlunoDto>>(result);

            return Ok(alunosResult);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _repo.GetAlunoById(id, true);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(AlunoCadastroDto alunoCadastro)
        {
            var aluno = _mapper.Map<Aluno>(alunoCadastro);

            _repo.Add(aluno);
            if (_repo.SaveChanges())
                return Created($"/api/aluno/{aluno.Id}", _mapper.Map<AlunoDto>(aluno));

            return BadRequest("Não foi possível inserir o aluno");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoCadastroDto alunoCadastro)
        {
            var aluno = _mapper.Map<Aluno>(alunoCadastro);

            _repo.Update(aluno);
            if (_repo.SaveChanges())
                return Ok(aluno);

            return BadRequest("Não foi possível alterar o aluno");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, AlunoCadastroDto alunoCadastro)
        {
            var aluno = _mapper.Map<Aluno>(alunoCadastro);

            _repo.Update(aluno);
            if (_repo.SaveChanges())
                return Ok(aluno);

            return BadRequest("Não foi possível alterar o aluno");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);

            _repo.Remove(aluno);

            if (_repo.SaveChanges())
                return Ok("Aluno removido");

            return BadRequest("Não foi possível alterar o aluno");
        }
    }
}
