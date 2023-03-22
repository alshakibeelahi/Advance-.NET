using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Z_Hunger.EF.Model
{
    public class ZHContext : DbContext
    {
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectRequest> CollectRequests { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Donor> Donors { get; set; }

    }
}