using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    internal class NZContest : DbContext
    {
        public DbSet<Newz> News { get; set; }
        public DbSet<Category> Categories { get; set; } 
    }
}
