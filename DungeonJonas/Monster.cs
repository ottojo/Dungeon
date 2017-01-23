using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonJonas
{
    class Monster : Kreatur, IKampf
    {
        public Monster(int x, int y, int lebensPunkte) : base(x, y, lebensPunkte)
        {
            this.Color = System.Drawing.Color.IndianRed;
            this.name = "Monster";
        }

        int IKampf.LebensPunkte
        {
            get; set;
        }

        public void bekaempfe(Kreatur feind)
        {
            feind.verletzen(10);
        }
    }
}
