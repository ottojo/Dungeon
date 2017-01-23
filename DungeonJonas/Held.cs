using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonJonas
{
    class Held : Kreatur, IKampf
    {

        public Held(int x, int y, int lebensPunkte) : base(x, y, lebensPunkte)
        {
            this.name = "Held";
            this.Color = System.Drawing.Color.Yellow;
        }

        int IKampf.LebensPunkte
        {
            get; set;
        }

        public void bekaempfe(Kreatur feind)
        {
            IOffensiv waffe = default(IOffensiv);
            foreach(AGegenstand gegenstand in Inventar)
            {
                if(gegenstand is IOffensiv)
                {
                    if(waffe == default(IOffensiv) || (gegenstand as IOffensiv).Angriffswert > waffe.Angriffswert)
                    {
                        waffe = gegenstand as IOffensiv;
                    }
                }
            }
            if(waffe != default(IOffensiv)){
                feind.verletzen(waffe.Angriffswert);
            }
        }
    }
}
