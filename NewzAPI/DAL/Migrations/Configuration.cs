namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Model.NZContest>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Model.NZContest context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            Random random = new Random();
            for (int i = 0; i < 100; i++) {
                context.News.AddOrUpdate(

                        new Model.Newz() {
                            Title = Guid.NewGuid().ToString().Substring(0, 4),
                            Description = Guid.NewGuid().ToString().Substring(0, 10),
                            Date = DateTime.Now,
                            CId = random.Next(1, 3)
                        }
                    ); ;
            }
        }

    }
}
