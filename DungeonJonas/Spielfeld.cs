using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonJonas
{
    class Spielfeld
    {
        Feld[,] feld;

        public Spielfeld(int hoehe, int breite, int prob = 10)
        {
            Random random = new Random();
            feld = new Feld[breite, hoehe];
            for (int zeile = 0; zeile < hoehe; zeile++)
            {
                for (int spalte = 0; spalte < breite; spalte++)
                    if ((zeile == 0 || zeile == hoehe - 1) || (spalte == 0 || spalte == breite - 1))
                    {
                        feld[spalte, zeile] = new Feld(FeldTyp.Wand, Constants.feldGroesse);
                    }
                    else
                    {
                        feld[spalte, zeile] = new Feld(FeldTyp.Leer, Constants.feldGroesse);
                        if (random.Next(0, prob) == 0)
                            feld[spalte, zeile].Gegenstand = GegenstandUtil.randomGegenstand();
                    }
            }
        }

        public int Hoehe
        {
            get
            {
                return feld.GetLength(1) * Constants.feldGroesse;
            }
        }

        public int Breite
        {
            get
            {
                return feld.GetLength(0) * Constants.feldGroesse;
            }
        }

        public void zeichnen(Form form)
        {
            Graphics graphics = form.CreateGraphics();
            for (int zeile = 0; zeile < feld.GetLength(1); zeile++)
            {
                for (int spalte = 0; spalte < feld.GetLength(0); spalte++)

                    feld[spalte, zeile].zeichnen(Constants.feldDeltaX + Constants.feldGroesse * spalte,
                        Constants.feldDeltaY + Constants.feldGroesse * zeile,
                        graphics,
                        new System.Drawing.Pen(Color.Black, 1),
                        new SolidBrush(Color.Black));
            }
            graphics.Dispose();
        }

        public Feld getFeld(int x, int y)
        {
            return feld[x, y];
        }
    }
}
