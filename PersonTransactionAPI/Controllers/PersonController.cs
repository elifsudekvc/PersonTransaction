using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonTransaction.BusinessLayer.Abstract;
using PersonTransaction.DtoLayer.PersonDto;
using PersonTransaction.EntityLayer.Entities;

namespace PersonTransactionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }
        [HttpGet("GetAllPerson")]
        public IActionResult PersonList()
        {
            var values = _mapper.Map<List<ResultPersonDto>>(_personService.TGetListAll());
            return Ok(values);
        }
        [HttpGet("PersonTotalExpenses")]
        public IActionResult GetPersonTotalExpenses()
        {
            var totalExpenses = _personService.GetPersonTotalExpenseTransaction();
            return Ok(totalExpenses);
        }
        [HttpPost("CreatePerson")]
        public IActionResult CreatePerson([FromBody] CreatePersonDto createPersonDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_personService.IsTCKimlikExists(createPersonDto.TCKimlik))
            {
                return BadRequest("Bu TC Kimlik Zaten Var.");
            }

            _personService.TAdd(new Person()
            {
                Name = createPersonDto.Name,
                TCKimlik = createPersonDto.TCKimlik
            });
            return Ok("Person Added.");
        }
        [HttpDelete("DeletePerson")]
        public IActionResult DeletePerson(string tcKimlik)
        {
            var person = _personService.GetPersonByTCKimlik(tcKimlik);
            if (person == null)
            {
                return NotFound("Person not found.");
            }

            _personService.TDelete(person);
            return Ok("Person Deleted");
        }

        [HttpGet("GetPersonByTCKimlik")]
        public IActionResult GetPersonByTCKimlik(string tcKimlik)
        {
            var person = _personService.GetPersonByTCKimlik(tcKimlik);
            if (person != null)
            {
                var result = _mapper.Map<ResultPersonDto>(person);
                return Ok(result);
            }
            else
            {
                return NotFound("Person not found.");
            }
        }

        [HttpPut("UpdatePerson")]
        public IActionResult Uppp(UpdatePersonDto updatePersonDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _personService.UpdatePersonByTCKimlik(updatePersonDto.TCKimlik, new Person()
                {
                    Name = updatePersonDto.Name,
                    TCKimlik = updatePersonDto.TCKimlik
                });
                return Ok("Person Updated.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
