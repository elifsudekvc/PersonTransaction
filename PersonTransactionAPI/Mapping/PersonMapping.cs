using AutoMapper;
using PersonTransaction.DtoLayer.PersonDto;
using PersonTransaction.EntityLayer.Entities;

namespace PersonTransactionAPI.Mapping
{
    public class PersonMapping : Profile
    {
        public PersonMapping()
        {
            CreateMap<Person, ResultPersonDto>().ReverseMap();
            CreateMap<Person, CreatePersonDto>().ReverseMap();
            CreateMap<Person, GetPersonDto>().ReverseMap();
            CreateMap<Person, UpdatePersonDto>().ReverseMap();
            CreateMap<Person, PersonTotalExpenseTransactionDto>()
            .ForMember(dest => dest.TotalExpense, opt => opt.MapFrom(src => src.ExpenseTransactions.Sum(e => e.Amount)));
        }
    }
}
