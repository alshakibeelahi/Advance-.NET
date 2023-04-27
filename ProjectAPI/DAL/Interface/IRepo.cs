using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepo<Type,Id,Rtn>
    {
        List<Type> Get();
        Type Get(Id id);
        Rtn Insert(Type obj);
        Rtn Update(Type obj);
        bool Delete(Id id);
    }
}
