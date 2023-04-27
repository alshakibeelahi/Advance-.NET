using DAL.Interface;
using DAL.Model;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccess
    {
        public static IRepo<Project, int, bool> ProjectContext()
        {
            return new ProjectRepo();
        }
        public static IRepoSpec<Project, string, DateTime> ProjectContextSpec()
        {
            return new ProjectRepo();
        }
    }
}
