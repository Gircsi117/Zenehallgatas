using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenehallgatas.DAO;
using Zenehallgatas.Model;

namespace Zenehallgatas.Controller
{
    internal class ZeneController
    {
        private static ZeneController instance; 
        private static IZeneDao dao;

        public ZeneController()
        {
            dao = new ZeneMemoryDao();
        }

        public static ZeneController getInstance()
        {
            if (instance == null)
            {
                instance = new ZeneController();
            }
            return instance;
        }

        public bool addZene(Zene zene)
        {
            return dao.addZene(zene);
        }

        public bool modifyZene(Zene zene)
        {
            return dao.modifyZene(zene);
        }

        public Zene getZeneById(int id)
        {
            return dao.getZeneById(id);
        }

        public IEnumerable<Zene> getAllZene()
        {
            return dao.getAllZene();
        }
    }
}
