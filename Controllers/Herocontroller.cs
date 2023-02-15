using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RobinAPI.Models;

namespace RobinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Herocontroller : ControllerBase
    {
        private static List<Hero> _heroes =new List<Hero>()
        {
            new Hero(){id = 1, Name = "Tony Stark", SuperHeroName = "Ironman",Team = "Avengers"},
            new Hero(){id = 2, Name = "Bruce Wayne", SuperHeroName = "Läderlappen",Team = "Justice league"} 
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_heroes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_heroes.FirstOrDefault(x => x.id == id));
        }

        [HttpPost]
        public IActionResult Post(Hero hero)
        {
            _heroes.Add(hero);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Hero hero)
        {
            var heroToUpdate = _heroes.FirstOrDefault(x => x.id == hero.id);
            if (heroToUpdate == null)
            {
                return NotFound();
            }
            heroToUpdate.Name = hero.Name;
            heroToUpdate.Team=hero.Team;
            heroToUpdate.SuperHeroName=hero.SuperHeroName;
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var heroToDelete=_heroes.FirstOrDefault(x => x.id == id);
            if (heroToDelete == null)
            {
                return NotFound();
            }

            _heroes.Remove(heroToDelete);
            return Ok();
        }

    }
}
