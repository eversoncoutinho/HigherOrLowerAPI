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

        //[HttpPost]
        //public async Task<Deck> StartChallenge( )
        //{
        //    var deck = await _uof.DeckRepository.CreateDeckAsync();
        //    return CreatedAtAction("GetGrain", //precisa ter o mesmo nome da action 
        //                            new { id = deck.Id }, deck);
        //    ;
        //}

        // GET: api/Deck
        [HttpGet]
        public async Task<Deck> GetDeck( )
        {
            return await _uof.DeckRepository.CreateDeckAsync();
        }

        // GET api/Deck/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
