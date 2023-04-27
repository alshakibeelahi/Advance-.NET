using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepoSpec<Type, DT, RT>
    {
        List<Type> GetSameStatus(DT sts); 
        List<Type> GetTStat(DT sts,RT tm);
    }
}
