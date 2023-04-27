using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    internal class PAContest : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}
