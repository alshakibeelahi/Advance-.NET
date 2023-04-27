using DAL.Interface;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class MemberRepo : Repo, IRepo<Member, int, bool>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Member> Get()
        {
            throw new NotImplementedException();
        }

        public Member Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Member obj)
        {
            var data = db.Members.Add(obj);
            return db.SaveChanges()>0;
        }

        public bool Update(Member obj)
        {
            throw new NotImplementedException();
        }
    }
}
