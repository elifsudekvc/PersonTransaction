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

            [HttpGet("GetAllExpenseTransaction")]
            public IActionResult ExpenseTransactionList()
            {
                var values = _mapper.Map<List<ResultExpenseTransactionDto>>(_expenseTransactionService.TGetListAll());
                return Ok(values);
            }


        [HttpPost("CreateExpenseTransaction")]
        public IActionResult CreateExpenseTransaction(CreateExpenseTransactionDto createExpenseTransactionDto)
        {
            // Kişiyi TC Kimlik numarasına göre bul
            var context = new PersonTransactionContext();
            var person = context.Persons.SingleOrDefault(p => p.TCKimlik == createExpenseTransactionDto.TCKimlik);

            if (person == null)
            {
                return BadRequest("Person with provided TC Kimlik not found.");
            }

            // ExpenseTransaction oluştur ve ekleyeceğin kişinin ID'sini ata
            var expenseTransaction = new ExpenseTransaction()
            {
                Amount = createExpenseTransactionDto.Amount,
                Date = createExpenseTransactionDto.Date,
                Description = createExpenseTransactionDto.Description,
                PersonID = person.PersonID, // Kişinin ID'sini ata
            };

            try
            {
                _expenseTransactionService.TAdd(expenseTransaction);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding transaction: {ex.Message}");
            }

            return Ok("Transaction Added.");
        }

            [HttpDelete("DeleteExpenseTransaction")]
            public IActionResult DeleteExpenseTransaction(int id)
            {
                var value = _expenseTransactionService.TGetByID(id);
                _expenseTransactionService.TDelete(value);
                return Ok("Transaction Deleted");

            }
            [HttpGet("GetExpenseTransactionById")]
            public IActionResult GetExpenseTransaction(int id)
            {
                var expenseTransaction = _expenseTransactionService.TGetByID(id);

                if (expenseTransaction == null)
                {
                    return NotFound("Expense transaction not found.");
                }

                // DTO'ya dönüştür
                var expenseTransactionDto = _mapper.Map<GetExpenseTransactionDto>(expenseTransaction);

                return Ok(expenseTransactionDto);
            }

        [HttpPut("UpdateExpenseTransaction")]
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
                    Name = y.Person.Name,
                    TCKimlik=y.Person.TCKimlik,

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
                    TCKimlik = person.TCKimlik,
                    ExpenseTransactions = person.ExpenseTransactions.Select(y => new ResultExpenseTransactionWithPerson
                    {
                        ExpenseTransactionID = y.ExpenseTransactionID,
                        Description = y.Description,
                        Amount = y.Amount,
                        Date = y.Date,
                        Name = person.Name,
                        TCKimlik = person.TCKimlik,
                    }).ToList()
                }).ToList();
                return Ok(personsWithExpenses);
            }
    }
}
