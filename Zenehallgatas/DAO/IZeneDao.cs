using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenehallgatas.Model;

namespace Zenehallgatas.DAO
{
    internal interface IZeneDao
    {
        bool addZene(Zene zene);
        bool modifyZene(Zene zene);
        Zene getZeneById(int zeneId);
        IEnumerable<Zene> getAllZene();
    }
}
