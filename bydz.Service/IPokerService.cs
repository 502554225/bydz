using bydz.Models;
using bydz.Repositroy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace bydz.Service
{
    public interface IPokerService : IBaseService<Poker>
    {
        IEnumerable<Poker> GetAll();
        IEnumerable<myPoker> GetMyAll(string userId);
        bool AddMyPoker(string pokerId, string userId);
        bool AddMyArray(Array pokerIdList, string userId);
    }
}
