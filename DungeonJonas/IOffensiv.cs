using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonJonas
{
    interface IOffensiv     //Interface: Vereinbarung über Implementierung von Methoden etc, siehe KampfForm, IKampf
    {
        int Angriffswert { get; set; }
    }
}
