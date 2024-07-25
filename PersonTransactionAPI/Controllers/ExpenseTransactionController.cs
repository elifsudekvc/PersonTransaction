using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonTransaction.BusinessLayer.Abstract;
using PersonTransaction.DataAccessLayer.Concrete;
using PersonTransaction.DtoLayer.ExpenseTransactionDto;
using PersonTransaction.DtoLayer.PersonDto;
using PersonTransaction.EntityLayer.Entities;

namespace PersonTransactionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseTransactionController : ControllerBase
    {
            private readonly IExpenseTransactionService _expenseTransactionService;
            private readonly IMapper _mapper;

            public ExpenseTransactionController(IExpenseTransactionService expenseTransactionService, IMapper mapper)
            {
                _expenseTransactionService = expenseTransactionService;
                _mapper = mapper;
            }

            [HttpGet]
            public IActionResult ExpenseTransactionList()
            {
                var values = _mapper.Map<List<ResultExpenseTransactionDto>>(_expenseTransactionService.TGetListAll());
                return Ok(values);
            }


            [HttpPost]
            public IActionResult CreateExpenseTransaction(CreateExpenseTransactionDto createExpenseTransactionDto)
            {
                _expenseTransactionService.TAdd(new ExpenseTransaction()
                {
                    Amount = createExpenseTransactionDto.Amount,
                    Date = createExpenseTransactionDto.Date,
                    Description = createExpenseTransactionDto.Description,
                    PersonID = createExpenseTransactionDto.PersonID,
                });
                return Ok("Transaction Added.");
            }
            [HttpDelete]
            public IActionResult DeleteExpenseTransaction(int id)
            {
                var value = _expenseTransactionService.TGetByID(id);
                _expenseTransactionService.TDelete(value);
                return Ok("Transaction Deleted");

            }
            [HttpGet("GetExpenseTransaction")]
            public IActionResult GetExpenseTransaction(int id)
            {
                var value = _expenseTransactionService.TGetByID(id);
                return Ok(value);
            }
            [HttpPut]
            public IActionResult UpdateExpenseTransaction(UpdateExpenseTransactionDto updateExpenseTransactionDto)
            {
                _expenseTransactionService.TUpdate(new ExpenseTransaction()
                {
                    Amount = updateExpenseTransactionDto.Amount,
                    Date = updateExpenseTransactionDto.Date,
                    Description = updateExpenseTransactionDto.Description,
                    ExpenseTransactionID = updateExpenseTransactionDto.ExpenseTransactionID
                });
                return Ok("Person Updated.");
            }


            [HttpGet("ExpenseTransactionListWithPerson")]
            public IActionResult ExpenseTransactionListWithPerson()
            {
                var context = new PersonTransactionContext();
                var values = context.ExpenseTransactions.Include(x => x.Person).Select(y => new ResultExpenseTransactionWithPerson
                {
                    Amount = y.Amount,
                    Date = y.Date,
                    Description = y.Description,
                    ExpenseTransactionID = y.ExpenseTransactionID,
                    Name = y.Person.Name
                }).ToList();
                return Ok(values.ToList());
            }

            [HttpGet("PersonWithExpenseTransaction")]
            public IActionResult PersonWithExpenseTransaction()
            {
                var context = new PersonTransactionContext();
                var personsWithExpenses = context.Persons.Include(p => p.ExpenseTransactions).Select(person => new ResultPersonWithExpenseTransactionDto
                {
                    PersonID = person.PersonID,
                    Name = person.Name,
                    ExpenseTransactions = person.ExpenseTransactions.Select(exp => new ResultExpenseTransactionWithPerson
                    {
                        ExpenseTransactionID = exp.ExpenseTransactionID,
                        Description = exp.Description,
                        Amount = exp.Amount,
                        Date = exp.Date,
                        Name = person.Name
                    }).ToList()
                }).ToList();
                return Ok(personsWithExpenses);
            }
    }
}
