using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonJonas
{
    class Langschwert : AGegenstand, IOffensiv
    {
        //TODO Mehr Gegenstände, evtl rand properties
        int angriffswert = 23;
        public Langschwert()
            : base()
        {

            this.maxStabilitaet = 100;
            this.stabilitaet = maxStabilitaet;
            this.goldwert = 10;
            this.name = "Langschwert";
        }

        int IOffensiv.Angriffswert
        {
            get
            {
                return angriffswert;
            }
            set { }
        }
    }
}
