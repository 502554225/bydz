using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bydz.Models;
using bydz.Repositroy.Models;
using bydz.Service;
using bydz.Service.impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace bydz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokerController : ControllerBase
    {
        [HttpGet("[action]")]
        public bool Login([FromServices] IPokerService PokerService,string UserId)
        {
            try
            {
                HttpContext.Session.SetString("UserId", UserId);
                var poker = PokerService.GetMyAll(UserId);
                if (poker.Count() == 0)
                {
                    PokerService.AddMyPoker("3", UserId);
                }
                var ss = HttpContext.Session.GetString("UserId");
                if (ss != null)
                {
                    return true;
                }
                else return false;
                
            }
            catch
            {
                return false;
            }      
        }

        [HttpPost("[action]")]
        public bool AddMyPoker([FromServices] IPokerService PokerService,string pokerId)
        {
            var userId = HttpContext.Session.GetString("UserId");
            var result = PokerService.AddMyPoker(pokerId, userId);
            return result;
        }

        [HttpGet("[action]")]
        public bool AddMyArray([FromServices] IPokerService PokerService,string pokerList)
        {
            var pokers = JsonConvert.DeserializeObject<IEnumerable<Poker>>(pokerList);

            var userId = HttpContext.Session.GetString("UserId");
            var result = PokerService.AddMyArray(pokers, userId);
            return result;
        }

        [HttpGet("[action]")]
        public IEnumerable<array> GetMyArray([FromServices] IPokerService PokerService)
        {
            var userId = HttpContext.Session.GetString("UserId");
            return PokerService.GetMyArray(userId);
        }

        [HttpGet("[action]")]
        public IEnumerable<myPoker> GetMyAll([FromServices] IPokerService PokerService)
        {
            var userId = HttpContext.Session.GetString("UserId");
            return PokerService.GetMyAll(userId);
        }

        [HttpGet("[action]")]
        public IEnumerable<Poker> GetAll([FromServices] IPokerService PokerService)
        {
            return PokerService.GetAll();
        }

    }
}