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
                    PokerService.AddMyPoker("2", UserId);
                    List<myPoker> pokers = new List<myPoker>();
                    var mypoker = PokerService.GetMyAll(UserId).ToList()[0];
                    mypoker.positionX = 1;
                    mypoker.positionY = 1;
                    pokers.Add(mypoker);
                    PokerService.AddMyArray(pokers, UserId);
                }
                var myInfor = PokerService.GetMyInfor(UserId);
                if (myInfor.UserId == null)
                {
                    string dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    PokerService.SaveMyInfor(UserId, new baseInfor()
                    {
                        UserId = UserId,
                        levelG = 1,
                        drawNum = 0,
                        gold = 0,
                        fatigueNum = 200,
                        date = dt
                    });
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
        public Poker AddMyPoker([FromServices] IPokerService PokerService,[FromForm]string pokerId)
        {
            var userId = HttpContext.Session.GetString("UserId");
            HttpContext.Session.SetString("UserId", userId);
            var result = PokerService.AddMyPoker(pokerId, userId);
            return result;
        }

        [HttpPost("[action]")]
        public bool AddMyArray([FromServices] IPokerService PokerService,[FromForm]string pokerList)
        {
            var pokers = JsonConvert.DeserializeObject<IEnumerable<myPoker>>(pokerList);

            var userId = HttpContext.Session.GetString("UserId");
            HttpContext.Session.SetString("UserId", userId);
            var result = PokerService.AddMyArray(pokers, userId);
            return result;
        }

        [HttpGet("[action]")]
        public IEnumerable<array> GetMyArray([FromServices] IPokerService PokerService)
        {
            var userId = HttpContext.Session.GetString("UserId");
            HttpContext.Session.SetString("UserId", userId);
            return PokerService.GetMyArray(userId);
        }

        [HttpGet("[action]")]
        public IEnumerable<myPoker> GetMyAll([FromServices] IPokerService PokerService)
        {
            var userId = HttpContext.Session.GetString("UserId");
            HttpContext.Session.SetString("UserId", userId);
            return PokerService.GetMyAll(userId);
        }

        [HttpGet("[action]")]
        public IEnumerable<Poker> GetAll([FromServices] IPokerService PokerService)
        {
            return PokerService.GetAll();
        }

        [HttpPost("[action]")]
        public IEnumerable<Poker> ToArray([FromServices] IPokerService PokerService, [FromForm]string opList)
        {
            var list = JsonConvert.DeserializeObject<IEnumerable<opponent>>(opList);
            return PokerService.ToArray(list);
        }

        [HttpGet("[action]")]
        public int GetLevel([FromServices] IPokerService PokerService)
        {
            var userId = HttpContext.Session.GetString("UserId");
            HttpContext.Session.SetString("UserId", userId);
            return PokerService.GetMyInfor(userId).levelG;
        }

        [HttpGet("[action]")]
        public baseInfor GetMyInfor([FromServices] IPokerService PokerService)
        {
            var userId = HttpContext.Session.GetString("UserId");
            HttpContext.Session.SetString("UserId", userId);
            var result = PokerService.GetMyInfor(userId);
            return result;
        }

        [HttpPost("[action]")]
        public bool SaveMyInfor([FromServices] IPokerService PokerService,[FromForm]string infor)
        {
            var myinfor = JsonConvert.DeserializeObject<baseInfor>(infor);
            var userId = HttpContext.Session.GetString("UserId");
            HttpContext.Session.SetString("UserId", userId);
            return PokerService.SaveMyInfor(userId, myinfor);
        }

        [HttpPost("[action]")]
        public bool AddLevel([FromServices] IPokerService PokerService, [FromForm]int level)
        {
            var userId = HttpContext.Session.GetString("UserId");
            HttpContext.Session.SetString("UserId", userId);
            return PokerService.AddLevel(userId, level);
        }

        [HttpPost("[action]")]
        public bool UpMyInfor([FromServices] IPokerService PokerService)
        {
            var userId = HttpContext.Session.GetString("UserId");
            HttpContext.Session.SetString("UserId", userId);
            var myInfor = PokerService.GetMyInfor(userId);
            var timeStar = myInfor.date;
            var timeNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var num = PokerService.UpMyInfor(userId,timeStar,timeNow);
            if (num != 0)
            {
                myInfor.fatigueNum += num * 5;
                if (myInfor.fatigueNum >= 200) myInfor.fatigueNum = 200;
                myInfor.date = DateTime.Parse( myInfor.date).AddMinutes(num*5).ToString();
            }
            return PokerService.SaveMyInfor(userId, myInfor);
        }
    }
}