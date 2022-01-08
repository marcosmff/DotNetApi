namespace SmartSchool.API.Models
{
    public class Curso
    {
        public Curso(int id, string nome)
        {
            this.id = id;
            Nome = nome;
        }

        public int id { get; set; }

        public string Nome { get; set; }

        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}
