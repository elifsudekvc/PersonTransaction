using AutoMapper;
using PersonTransaction.DtoLayer.ExpenseTransactionDto;
using PersonTransaction.DtoLayer.PersonDto;
using PersonTransaction.EntityLayer.Entities;

namespace PersonTransactionAPI.Mapping
{
    public class ExpenseTransactionMapping :Profile
    {
        public ExpenseTransactionMapping()
        {
            CreateMap<ExpenseTransaction, ResultExpenseTransactionDto>().ReverseMap();
            CreateMap<ExpenseTransaction, CreateExpenseTransactionDto>().ReverseMap();
            CreateMap<ExpenseTransaction, GetExpenseTransactionDto>().ReverseMap();
            CreateMap<ExpenseTransaction, UpdateExpenseTransactionDto>().ReverseMap();
            CreateMap<ExpenseTransaction, ResultExpenseTransactionWithPerson>().ReverseMap();
            CreateMap<ExpenseTransaction, ResultPersonWithExpenseTransactionDto>().ReverseMap();
        }
    }
}
