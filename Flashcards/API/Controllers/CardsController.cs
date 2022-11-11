using Microsoft.AspNetCore.Mvc;
using Services;
using Models;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly FlashCardService _service;
        private IMemoryCache _cache;

        public CardsController(FlashCardService service, IMemoryCache cache)
        {
            _service = service;
            _cache = cache;
        }

        // GET: api/<CardsController>
        [HttpGet]
        public List<FlashCard> Get(bool? randomOrder, bool? onlyIncorrect)
        {
            bool randOrder = (randomOrder ?? false);
            bool incorrectOnly = (onlyIncorrect ?? false);
            if(!randOrder && !incorrectOnly)
            {
                List<FlashCard> allCards = new();
                // First, try getting the value of allCards key in the memory cache
                //If it succeeds, it will skip over the entire if block
                //if it fails, it will get the data from the service layer
                //and will create a new cache key/value pair with the data
                if(!_cache.TryGetValue("allCards", out allCards))
                {
                    allCards = _service.GetAllCards(randOrder, incorrectOnly);
                    _cache.Set("allCards", allCards, new TimeSpan(0, 0, 20));
                }
                return allCards;
            }
            else return _service.GetAllCards(randOrder, incorrectOnly);
        }

        // GET api/<CardsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CardsController>
        [HttpPost]
        public FlashCard Post([FromBody] FlashCard card)
        {
            FlashCard addedCard = _service.AddNewCard(card);
            List<FlashCard> allCards = new();
            //after you've added the card in the db,
            //you can update the cache (if it exists) to reflect the addition
            _cache.TryGetValue("allCards", out allCards);
            allCards.Add(addedCard);
            _cache.Set("allCards", allCards, new TimeSpan(0, 0, 20));

            return addedCard;
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
