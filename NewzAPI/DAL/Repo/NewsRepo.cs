using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class NewzRepo
    {
        static NZContest db;
        static NewzRepo()
        {
            db = new NZContest();
        }
        public static List<Newz> AllNews()
        {
            return db.News.ToList();
        }
        public static Newz GetNewz(int id)
        {
            return db.News.Find(id);
        }
    }
}
