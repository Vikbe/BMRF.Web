using BMRF.WEB.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMRF.WEB.Server.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
      

        private static GameServer[] GameServers = new GameServer[] {
            new GameServer {
                Game = "Rust",
                Name = "RustySpoon 1", 
                PlayerCap = 70
            },
             new GameServer {
                Game = "Rust",
                Name = "RustySpoon 2",
                PlayerCap = 70
            },
              new GameServer {
                Game = "Rust",
                Name = "RustySpoon 3",
                PlayerCap = 70
            }
        };

        private static string[] Rules = new string[] {
            "Don't be a dick!",
            "Join the army",
            "Don't smoke the devils lettuce",
            "No premarital sex"
        };


        // Example to populate a server list, randomly changes playercount
        [HttpGet("[action]")]
        public IEnumerable<GameServer> GetServers()
        {
            Random rnd = new Random();
           
            return Enumerable.Range(0, GameServers.Length).Select(index => {
                var server = GameServers[index];
                server.PlayerCount = rnd.Next(server.PlayerCount <= 4 ? server.PlayerCount : server.PlayerCount - 5, server.PlayerCount == server.PlayerCap - 5 ? server.PlayerCap : server.PlayerCount + 5);
                return server;
            }
             
            );
        }


        // mOCK RULES
        [HttpGet("[action]")]
        public IEnumerable<string> GetRules()
        {
            return Enumerable.Range(0, Rules.Length).Select(index =>
                Rules[index]);
        }

       

    }
}
