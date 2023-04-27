using DAL.Interface;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Repo
{
    internal class ProjectRepo : Repo, IRepo<Project, int, bool>, IRepoSpec<Project, string, DateTime>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Project> Get()
        {
            return db.Projects.ToList();
        }

        public Project Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Project> GetSameStatus(string sts)
        {
            var stsList = (from proj in db.Projects
                           where proj.Status.Equals(sts)
                           select proj).ToList();
            return stsList;
        }

        public List<Project> GetTStat(string sts, DateTime tm)
        {
            var stsList = (from proj in db.Projects
                           where proj.Status.Equals(sts)
                           && proj.StartDate.Equals(tm)
                           select proj).ToList();
            return stsList;
        }

        public bool Insert(Project mem)
        {
            var data=db.Projects.Add(mem);
            return db.SaveChanges()>0;
        }

        public bool Update(Project obj)
        {
            throw new NotImplementedException();
        }
    }
}
