using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Call
    {
        public int ID { get; set; }
        public int Abonent_A_ID { get; set; }
        public int Abonent_B_ID { get; set; }
        public int Duration { get; set; }
        public bool IsNight { get; set; }
    }
}