using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonJonas
{
    class GenericGegenstand : AGegenstand, IOffensiv, IDefensiv, IHeilend
    {
        int angriffswert, ruestungswert, heilungswert;
        public GenericGegenstand(string name, int angriffswert, int ruestungswert, int heilungswert, int goldwert, int gewicht, int stabilitaet, int maxStabilitaet)
            : base()
        {
            this.angriffswert = angriffswert;
            this.ruestungswert = ruestungswert;
            this.heilungswert = heilungswert;
            this.goldwert = goldwert;
            this.gewicht = gewicht;
            this.stabilitaet = stabilitaet;
            this.maxStabilitaet = maxStabilitaet;
            this.name = name;
        }

        public int Angriffswert
        {
            get; set;
        }

        public int Heilungswert
        {
            get; set;
        }

        public int Ruestungswert
        {
            get; set;
        }
    }
}
