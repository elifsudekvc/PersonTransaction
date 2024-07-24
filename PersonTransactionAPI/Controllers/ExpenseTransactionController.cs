using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonTransaction.BusinessLayer.Abstract;
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
    }
}
