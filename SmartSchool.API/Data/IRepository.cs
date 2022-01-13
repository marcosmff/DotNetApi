using SmartSchool.API.Helpers;
using SmartSchool.API.Models;

namespace SmartSchool.API.Data
{
    public interface IRepository
    {
        public void Add<T>(T entity) where T : class;

        public void Update<T>(T entity) where T : class;

        public void Remove<T>(T entity) where T : class;

        public bool SaveChanges();

        public Task<PageList<Aluno>> GetAllAlunosAsync(PageParams pageParams, bool includeProfessor = false);

        public Aluno[] GetAllAlunos(bool includeProfessor = false);

        public Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false);

        public Aluno GetAlunoById(int alunoId, bool includeProfessor = false);

        public Professor[] GetAllProfessores(bool includeAluno = false);

        public Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAluno = false);

        public Professor GetProfessorById(int alunoId, bool includeAluno = false);


    }
}
