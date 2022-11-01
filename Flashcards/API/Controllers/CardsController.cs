using Microsoft.AspNetCore.Mvc;
using Services;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private FlashCardService _service;
        public CardsController(FlashCardService service)
        {
            _service = service;
        }

        // GET: api/<CardsController>
        [HttpGet]
        public List<FlashCard> Get(bool? randomOrder, bool? onlyIncorrect)
        {
            return _service.GetAllCards(randomOrder ?? false, onlyIncorrect ?? false);
        }

        // GET api/<CardsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CardsController>
        [HttpPost]
        public void Post([FromBody] FlashCard card)
        {
            _service.AddNewCard(card);
        }

        // PUT api/<CardsController>
        [HttpPut]
        public void Put([FromBody] FlashCard cardToUpdate)
        {
            _service.UpdateCard(cardToUpdate);
        }

        // DELETE api/<CardsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
