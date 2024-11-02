using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenehallgatas.Model;

namespace Zenehallgatas.DAO
{
    internal class ZeneMemoryDao: IZeneDao
    {
        public bool addZene(Zene zene)
        {
            return true;
        }

        public bool modifyZene(Zene zene)
        {
            return true;
        }

        public Zene getZeneById(int zeneId)
        {
            return new Zene();
        }

        public IEnumerable<Zene> getAllZene()
        {
            return new List<Zene> { };
        }
    }
}
