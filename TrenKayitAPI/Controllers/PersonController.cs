using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using DatabaseProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrenKayitAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _PersonRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _PersonRepository = personRepository;
        }

        [HttpGet]

        public ActionResult GetPersons()
        {
            try
            {
                var persons = _PersonRepository.GetPerson();
                return Ok(persons);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }
        
        [HttpGet]

        public ActionResult GetPersonById(int Id)
        {
            try
            {
                var person = _PersonRepository.GetPersonById(Id);
                return Ok(person);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }
        }

        [HttpPost]

        public ActionResult AddPerson(Person person)
        {
            try
            {
                var addedPerson = _PersonRepository.AddPerson(person);
                return Ok(addedPerson);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status417ExpectationFailed, ex.Message);
            }

        }
    }

}
