using bydz.Models;
using bydz.Repositroy;
using bydz.Repositroy.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bydz.Service.impl
{
    public class PokerService : BaseService<Poker>, IPokerService
    {
        private readonly context _context;
        public PokerService(context context)
        {
            _context = context;

        }

        public IEnumerable<Poker> GetAll()
        {
            try
            {
                IEnumerable<Poker> Pokers = _context.Pokers.ToList();
                return Pokers;
            }
            catch (Exception e)
            {
                var pokers = new LinkedList<Poker>();
                return pokers;
            }
        }

        public IEnumerable<myPoker> GetMyAll(string userId)
        {
            try
            {
                IEnumerable<myPoker> myPokers = _context.myPokers.Where(b => b.UserId == userId).ToList();
                return myPokers;
            }
            catch (Exception e)
            {
                var myPokers = new LinkedList<myPoker>();
                return myPokers;
            }
        }

        public Poker AddMyPoker(string pokerId, string userId)
        {
            try
            {
                Poker poker;
                poker = _context.Pokers.First(b => b.PokerId == pokerId);
                _context.myPokers.Add(new myPoker()
                {
                    action = poker.action,
                    Aggressivity = poker.Aggressivity,
                    ascription = poker.ascription,
                    crits = poker.crits,
                    Defenses = poker.Defenses,
                    evade = poker.evade,
                    hit = poker.hit,
                    indomitableness = poker.indomitableness,
                    level = poker.level,
                    life = poker.life,
                    PokerId = poker.PokerId,
                    PokerName = poker.PokerName,
                    positionX = poker.positionX,
                    positionY = poker.positionY,
                    skill = poker.skill,
                    survival = poker.survival,
                    UserId = userId,
                    vigour = poker.vigour
            });
                _context.SaveChanges();
                return poker;
            }
            catch(Exception e)
            {
                return new Poker();
            }
        }

        public bool AddMyArray(IEnumerable<myPoker> pokerIdList, string userId)
        {
            try
            {
                var myArray = _context.array.Where(b => b.UserId == userId).ToList();
                foreach (var item in myArray)
                {
                    _context.array.Remove(item);
                }
                foreach (var item in pokerIdList)
                {
                    _context.array.Add(new array()
                    {
                        action = item.action,
                        Aggressivity = item.Aggressivity,
                        ascription = item.ascription,
                        crits = item.crits,
                        Defenses = item.Defenses,
                        evade = item.evade,
                        hit = item.hit,
                        indomitableness = item.indomitableness,
                        level = item.level,
                        life = item.life,
                        PokerId = item.PokerId,
                        PokerName = item.PokerName,
                        positionX = item.positionX,
                        positionY = item.positionY,
                        skill = item.skill,
                        survival = item.survival,
                        UserId = userId,
                        vigour = item.vigour
                    });
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<array> GetMyArray(string userId)
        {
            try
            {
                IEnumerable<array> array = _context.array.Where(b => b.UserId == userId).ToList();
                return array;
            }
            catch (Exception e)
            {
                var array = new LinkedList<array>();
                return array;
            }
        }
        public IEnumerable<Poker> ToArray(IEnumerable<opponent> opList)
        {
            List<Poker> list = new List<Poker>();
            var count = 0;
            foreach(var item in opList)
            {
                var op = _context.Pokers.First(b => b.PokerId == item.pokerId);
                list.Add(new Poker()
                {
                    action = op.action,
                    Aggressivity = op.Aggressivity,
                    ascription = 1,
                    crits = op.crits,
                    Defenses = op.Defenses,
                    evade = op.evade,
                    hit = op.hit,
                    indomitableness = op.indomitableness,
                    level = item.level,
                    life = op.life,
                    PokerId = op.PokerId,
                    PokerName = op.PokerName,
                    positionX = item.x,
                    positionY = item.y,
                    skill = op.skill,
                    survival = op.survival,
                    vigour = op.vigour
                });
            }
            return list;
        }

        public baseInfor GetMyInfor(string userId)
        { 
            try
            {
                var infor = _context.baseInfors.First(b => b.UserId == userId);
                return infor;
            }
            catch(Exception e)
            {
                return new baseInfor();
            }
            
        }

        public bool SaveMyInfor(string userId, baseInfor infor)
        {
            try
            {
                 var item = _context.baseInfors.First(b => b.UserId == infor.UserId);
                item.levelG = infor.levelG;
                item.gold = infor.gold;
                item.drawNum = infor.drawNum;
                item.fatigueNum = infor.fatigueNum;
                item.date = infor.date;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                _context.baseInfors.Add(infor);
                _context.SaveChanges();
                return false;
            }
           
        }

        public bool AddLevel(string userId,int level)
        {
            try
            {
                var pokerList = _context.array.Where(b => b.UserId == userId);
                foreach(var item in pokerList)
                {
                    var poker = _context.myPokers.First(b => b.PokerId == item.PokerId&&b.UserId == userId);
                    poker.level += level;
                }
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
                        
        }

        public int UpMyInfor(string userId,string timeStar,string timeNow)
        {
            try
            {
                var now = DateTime.Parse(timeNow);
                var star = DateTime.Parse(timeStar);
                TimeSpan dis = now - star;
                double getMinute = dis.TotalMinutes;
                int num = (int)Math.Floor(getMinute / 5);
                if (num < 1)
                {
                    return 0;
                }
                else
                {
                    return num;
                }
            }
            catch
            {
                return 0;
            }
        }
    }

}
