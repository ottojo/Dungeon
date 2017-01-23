using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonJonas
{
    public class Inventar : IEnumerable
    {
        private List<AGegenstand> gegenstaende;

        public Inventar(int maxSize = 100)
        {
            gegenstaende = new List<AGegenstand>();
        }

        

        public void Hinzufuegen(AGegenstand gegenstand)
        {
            gegenstaende.Add(gegenstand);
        }

        public void Entfernen(AGegenstand gegenstand)
        {
            gegenstaende.Remove(gegenstand);
        }

        public void Entfernen(int i)
        {
            gegenstaende.RemoveAt(i);
        }

        public bool Enthaelt(AGegenstand gegenstand)
        {
            return gegenstaende.Contains(gegenstand);
        }

        public int Gewicht
        {
            get
            {
                int gewicht = 0;
                foreach (AGegenstand gegenstand in gegenstaende)
                    gewicht += gegenstand.Gewicht;
                return gewicht;
            }
        }

   

        public AGegenstand Gegenstand(int i)
        {
            return gegenstaende.ElementAt(i);
        }

        public override string ToString()
        {
            string result = "Inventar enthält " + gegenstaende.Count + " Gegenstände:" + Environment.NewLine + Environment.NewLine;
            foreach (AGegenstand gegenstand in gegenstaende)
            {
                result += gegenstand.ToString() + Environment.NewLine + Environment.NewLine;
            }
            return result;
        }

        public IEnumerator GetEnumerator()
        {
            return gegenstaende.GetEnumerator();
        }
    }
}
