using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Dal
{
    public class TelComContext : DbContext
    {
        public DbSet<Abonent> Abonents { get; set; }
        public DbSet<Call> Calls { get; set; }
        public DbSet<Tarif> Tarifs { get; set; }



    }
}