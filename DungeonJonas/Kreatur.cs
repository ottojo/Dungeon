using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonJonas
{

    public abstract class Kreatur       //Abstrakt: Kann nicht instanziiert werden
    {
        protected int x = 1;
        protected int y = 1;
        protected int lebensPunkte;
        protected int maxLebensPunkte;
        public Color Color { get; set; }
        protected String name = "Kreatur";
        private static int nextId = 0;
        protected int id;

        public Inventar Inventar { get; set; }

        public int MaxLebensPunkte { get { return maxLebensPunkte; } }

        public int LebensPunkte { get { return lebensPunkte; } }

        public int X { get { return x; } }

        public int Y { get { return y; } }

        protected Kreatur(int x, int y, int lebensPunkte)
        {
            this.x = x;
            this.y = y;
            this.lebensPunkte = lebensPunkte;
            this.maxLebensPunkte = lebensPunkte;
            this.Inventar = new Inventar();
            this.id = nextId;
            nextId++;
        }

        public void bewegen(Richtung richtung)
        {
            switch (richtung)
            {
                case Richtung.oben:
                    y--;
                    break;
                case Richtung.unten:
                    y++;
                    break;
                case Richtung.links:
                    x--;
                    break;
                case Richtung.rechts:
                    x++;
                    break;
            }
            Console.WriteLine("Held: " + X + ", " + Y);
        }

        public void bewegen(int x, int y)
        {
            this.x = x;
            this.y = y;
            Console.WriteLine(name + X + ", " + Y);
        }

        public virtual void zeichnen(Form form)         //Virtual: Subklasse kann eigenes Verhalten für zeichnen() spezifizieren
        {
            Pen pen = new Pen(Color, 1);
            SolidBrush brush = new SolidBrush(Color);
            Graphics graphics = form.CreateGraphics();
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            Rectangle kreis = new Rectangle(x * Constants.feldGroesse + Constants.feldDeltaX,
                y * Constants.feldGroesse + Constants.feldDeltaY,
                30, 30);
            graphics.DrawEllipse(pen, kreis);
            graphics.FillEllipse(brush, kreis);
            graphics.Dispose();
            brush.Dispose();
        }

        public void verletzen(int schaden)
        {
            int ruestung = 1;
            foreach (AGegenstand gegenstand in Inventar)
            {
                if (gegenstand is IDefensiv)
                {
                    ruestung += (gegenstand as IDefensiv).Ruestungswert;
                }
            }

            schaden = (int)Math.Floor(schaden * (Math.Pow(Math.E, 0.01 * Math.Log(2)*ruestung)));

            this.lebensPunkte -= schaden;
            if (lebensPunkte < 0)
                lebensPunkte = 0;
            Console.WriteLine("Kreatur " + id + ": " + lebensPunkte);
        }

        public override string ToString()
        {
            return "Kreatur " + id + ": " + name + "; " + lebensPunkte + "/" + maxLebensPunkte + "HP; " + Inventar.Gewicht + " Gewicht";
        }


    }
}
