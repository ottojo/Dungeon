using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonJonas
{
    public abstract class AGegenstand
    {
        private static int nextId = 0;
        protected int id, goldwert, gewicht, stabilitaet, maxStabilitaet;
        protected string name;

        protected AGegenstand()
        {
            this.id = nextId;
            nextId++;
        }

        public virtual void beschaedigen(int schaden)
        {
            if (schaden <= stabilitaet)
                this.stabilitaet -= schaden;
            else
                this.stabilitaet = 0;
        }

        public virtual void reparieren(int heilung)
        {
            if ((stabilitaet + heilung) <= maxStabilitaet)
                this.stabilitaet += heilung;
            else
                this.stabilitaet = maxStabilitaet;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int Goldwert
        {
            get
            {
                return (int)(goldwert * ((float)stabilitaet / (float)maxStabilitaet));
            }
        }

        public int Gewicht
        {
            get
            {
                return gewicht;
            }
        }

        public override string ToString()
        {
            String output = "Gegenstand " + id + ": " + this.Name + ";" + Goldwert + " Gold; " + stabilitaet + "/" + maxStabilitaet + " Stabilität";
            if (this is IOffensiv)
                output += "; " + (this as IOffensiv).Angriffswert + " Angriff";
            return output;
        }

        public override bool Equals(object obj)
        {
            if (obj is AGegenstand)
            {
                AGegenstand otherGegenstand = (AGegenstand)obj;
                if (this.id == otherGegenstand.id
                        && this.maxStabilitaet == otherGegenstand.maxStabilitaet
                        && this.gewicht == otherGegenstand.gewicht
                        && this.stabilitaet == otherGegenstand.stabilitaet
                        && this.goldwert == otherGegenstand.goldwert)
                    return true;
            }
            return false;
        }
    }
}
