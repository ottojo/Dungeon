using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonJonas
{
    class Helm : AGegenstand, IDefensiv
    {
        int ruestungswert = 10;
        public Helm() : base()
        {
            this.maxStabilitaet = 100;
            this.stabilitaet = maxStabilitaet;
            this.goldwert = 5;
            this.name = "Helm";
        }

        public int Ruestungswert
        {
            get
            {
                return ruestungswert;
            }

            set { }
        }
    }
}
