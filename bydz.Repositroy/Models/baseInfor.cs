using bydz.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace bydz.Repositroy.Models
{
    [Table("baseInfor")]
    public class baseInfor
    {
        [Key]
        public string UserId { get; set; }

        public int levelG { get; set; } 

        public int drawNum { get; set; }

        public double gold { get; set; }

        public int fatigueNum { get; set; }

        public string date { get; set; }
    }
}
