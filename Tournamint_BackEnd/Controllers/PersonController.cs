using CA_API_01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CA_API_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        List<Person> persons = new List<Person>
            {
                new Person { Id = 1, Name = "Jonas", Surname = "Jonaitis" },
                new Person { Id = 2, Name = "Petras", Surname = "Petraitis" },
                new Person { Id = 3, Name = "Tomas", Surname = "Tomaitis" },
            };

        [HttpGet("ThreeAmigos")]
        public List<Person> GetMyPersons()
        {
            return persons;
        }

        [HttpGet("persons/{id:int}")] // galima tiesiog {id}, ":int" dalis yra apribojimas
        public Person GetPersonByID(int id)
        {
            return persons.FirstOrDefault(p => p.Id == id);
        }
    }
}
