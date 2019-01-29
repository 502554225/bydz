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
                return true;
            }
            catch
            {
                return false;
            }      
        }

        [HttpPost("[action]")]
        public bool AddMyPoker([FromServices] IPokerService PokerService, string pokerId)
        {
            var userId = HttpContext.Session.GetString("UserId");
            var result = PokerService.AddMyPoker(pokerId, userId);
            return result;
        }

        [HttpPost("[action]")]
        public bool AddMyArray([FromServices] IPokerService PokerService, Array pokerIdList)
        {
            var userId = HttpContext.Session.GetString("UserId");
            var result = PokerService.AddMyArray(pokerIdList, userId);
            return result;
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