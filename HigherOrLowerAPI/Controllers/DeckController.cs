using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HigherOrLowerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeckController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public DeckController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        // GET: api/Deck
        [HttpGet]
        public async Task<Deck> GetDeck( )
        {
            return await _uof.DeckRepository.CreateDeckAsync();
        }

        // GET api/Deck/5
        [HttpGet("{id}")]
        public async Task<Deck> Get(int id)
        {
            return await _uof.DeckRepository.GetDeckAsync(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
