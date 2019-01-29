using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace bydz.Repositroy.Models
{ 
    [Table("array")]
    public class array
    {
        //public array(myPoker poker, string userId)
        //{
        //    this.action = poker.action;
        //    this.Aggressivity = poker.Aggressivity;
        //    this.ascription = poker.ascription;
        //    this.crits = poker.crits;
        //    this.Defenses = poker.Defenses;
        //    this.evade = poker.evade;
        //    this.hit = poker.hit;
        //    this.indomitableness = poker.indomitableness;
        //    this.level = poker.level;
        //    this.life = poker.life;
        //    this.PokerId = poker.PokerId;
        //    this.PokerName = poker.PokerName;
        //    this.positionX = poker.positionX;
        //    this.positionY = poker.positionY;
        //    this.skill = poker.skill;
        //    this.survival = poker.survival;
        //    this.UserId = userId;
        //    this.vigour = poker.vigour;
        //}

        public string UserId { get; set; }

        public string PokerId { get; set; }
        [MaxLength(50)]
        public string PokerName { get; set; }

        public Double life { get; set; } //shengming

        public Double Aggressivity { get; set; } //gongji

        public Double Defenses { get; set; }//fangyu

        public Double vigour { get; set; }//qishi

        public Double crits { get; set; }//baoji

        public Double indomitableness { get; set; }//renjin

        public Double evade { get; set; }//shanbi

        public Double hit { get; set; }//mingzhong

        public int skill { get; set; }//jineng

        public int survival { get; set; }//cunhuo

        public string action { get; set; }//dongzuo

        public int ascription { get; set; }//nayifang

        public int positionX { get; set; }

        public int positionY { get; set; }

        public int level { get; set; }
    }
}
