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
            catch
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
            catch
            {
                var myPokers = new LinkedList<myPoker>();
                return myPokers;
            }
        }

        public bool AddMyPoker(string pokerId, string userId)
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
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddMyArray(Array pokerIdList, string userId)
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
                    var poker = _context.myPokers.First(b => b.PokerId == item);
                    _context.array.Add(new array()
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
                }
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
