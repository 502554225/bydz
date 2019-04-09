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
        Poker AddMyPoker(string pokerId, string userId);
        bool AddMyArray(IEnumerable<myPoker> pokerIdList, string userId);
        IEnumerable<array> GetMyArray(string userId);
        IEnumerable<Poker> ToArray(IEnumerable<opponent> opList);
        baseInfor GetMyInfor(string userId);
        bool SaveMyInfor(string userId, baseInfor infor);
        bool AddLevel(string userId, int level);
        int UpMyInfor(string userId,string timeStar,string timeNow);

    }
}
