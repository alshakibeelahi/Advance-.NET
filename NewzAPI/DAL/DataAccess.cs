using DAL.Interfaces;
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
        public static IRepo<Newz,int, bool> NewsContent()
        {
            return new NewzRepo();
        }
    }
}
