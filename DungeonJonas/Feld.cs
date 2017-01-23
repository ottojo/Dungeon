using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonJonas
{

    public enum FeldTyp
    {
        Leer, Wand
    }

    class Feld
    {
        private FeldTyp typ;
        private int groesse;
        private AGegenstand gegenstand;     //TODO Auslagern in List in Dungeon, siehe Dungeon.monsters

        public AGegenstand Gegenstand
        {
            get { return gegenstand; }
            set { gegenstand = value; }
        }

        public Feld(FeldTyp typ, int groesse)
        {
            this.typ = typ;
            this.groesse = groesse;
        }

        public FeldTyp Typ { get { return typ; } }

        public void zeichnen(int x, int y, Graphics graphics, Pen pen, Brush brush)
        {
            Rectangle rectangle = new Rectangle(new Point(x, y), new Size(groesse, groesse));
            graphics.DrawRectangle(pen, rectangle);
            if (typ == FeldTyp.Wand)
                graphics.FillRectangle(brush, rectangle);
            if (gegenstand != null)
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                Rectangle kreis = new Rectangle(x, y, 30, 30);
                graphics.DrawEllipse(new Pen(Color.Green, 1), kreis);
                graphics.FillEllipse(new SolidBrush(Color.Green), kreis);
            }
        }
    }
}
