using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HeroSchool.Model;
using HeroSchool.Repository;

namespace HeroSchool.Rest.Controllers
{
    [Route("[controller]")]
    public class PlayersController : Controller
    {
        MongoRepository<Player> playerRepo;

        public PlayersController(MongoRepository<Player> p_PlayerRepo)
        {
            playerRepo = p_PlayerRepo;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Player> Get()
        {
            return playerRepo.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Player Get(string id)
        {
            return playerRepo.Get(new Tuple<string, string>("_id", id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
