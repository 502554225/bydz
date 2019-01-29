using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bydz.Models
{
    [Table("Pokers")]
    public class Poker
    {
        [Key]
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
