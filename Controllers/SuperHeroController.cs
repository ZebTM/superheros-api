using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {


        private static List<SuperHero> heroes = new List<SuperHero> 
            { 
                new SuperHero { 
                    Id = 1,
                    Name = "Spider Man", 
                    FirstName = "Peter", 
                    LastName = "Parker", 
                    Place = "New York City"
                },
                new SuperHero { 
                    Id = 2,
                    Name = "Ironman", 
                    FirstName = "Tony", 
                    LastName = "Stark", 
                    Place = "New York City"
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
            {
                return BadRequest("Hero can not be found");
            };
            return Ok(heroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DestroyHero(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero != null) 
            {
                heroes.Remove(hero);
                return Ok(heroes);
            }
            else {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request) 
        {
            var hero = heroes.Find(h => h.Id == request.Id);
            if (hero == null) {
                return BadRequest("Hero not found");
            }
            
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Name = request.Name;
            hero.Place = request.Place;
            return Ok(heroes);
        }
    }
}