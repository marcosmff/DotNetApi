using AutoMapper;
using SmartSchool.API.Models;
using SmartSchool.API.Helpers;
using SmartSchool.API.V1.Dtos;

namespace SmartSchool.API.V1.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDto>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}"))
                .ForMember(dest => dest.Idade, opt => opt.MapFrom(src => src.DataNascimento.GetCurrentAge()));

            CreateMap<AlunoCadastroDto, Aluno>().ReverseMap();

            CreateMap<Professor, ProfessorDto>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}"));

            CreateMap<ProfessorCadastroDto, Professor>().ReverseMap();
        }
    }
}
