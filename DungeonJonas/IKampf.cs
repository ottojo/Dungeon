using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonJonas
{
    interface IKampf
    {
        void bekaempfe(Kreatur feind);
        int LebensPunkte { get; set; }
    }
}
