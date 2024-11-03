using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenehallgatas.Model
{
    internal class Zene
    {
        public int ID { get; set; }
        public string Cim {  get; set; }
        public string Eloado {  get; set; }
        public int Kiadas {  get; set; }
        public int Hossz { get; set; }
        public int Prioritas { get; set; }

        public Zene()
        {
            this.ID = -1;
            this.Cim = string.Empty;
            this.Eloado = string.Empty;
            this.Kiadas = -1;
            this.Hossz = -1;
            this.Prioritas = -1;
        }

        public Zene(int id, string cim, string eloado, int kiadas, int hossz, int priorotas)
        {
            this.ID = id;
            this.Cim = cim;
            this.Eloado = eloado;
            this.Kiadas = kiadas;
            this.Hossz = hossz;
            this.Prioritas = priorotas;
        }

        public string[] getTableData()
        {
            return new string[] { this.Cim, this.Eloado, this.Kiadas.ToString(), this.Hossz.ToString(), this.Prioritas.ToString() };
        }
    }
}
