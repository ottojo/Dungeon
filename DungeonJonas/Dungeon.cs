using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonJonas
{
    public enum Richtung
    {
        oben, unten, links, rechts
    }

    class Dungeon
    {

        public Held Held;
        public Spielfeld Spielfeld;
        private List<Monster> monsters = new List<Monster>();

        public Dungeon(int hoehe = 10, int breite = 20)
        {
            Held = new Held(1, 1, 100);
            Spielfeld = new Spielfeld(hoehe, breite);
            Random random = new Random(DateTime.Now.Ticks.GetHashCode());
            for (int i = 0; i < 5; i++)
            {
                //TODO Check for empty field
                Monster monster = new Monster(random.Next(1, breite - 1), random.Next(1, hoehe - 1), random.Next(50, 100));
                monsters.Add(monster);
            }
        }

        public Monster getMonsterAt(int x, int y)
        {
            foreach (Monster monster in monsters)
            {
                if (monster.X == x && monster.Y == y)
                    return monster;
            }
            return null;
        }

        public bool handleKeyPress(KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'w':
                    if (Spielfeld.getFeld(Held.X, Held.Y - 1).Typ == FeldTyp.Leer)
                        Held.bewegen(Richtung.oben);
                    else
                        Held.verletzen(2);
                    break;
                case 'a':
                    if (Spielfeld.getFeld(Held.X - 1, Held.Y).Typ == FeldTyp.Leer)
                        Held.bewegen(Richtung.links);
                    else
                        Held.verletzen(2);
                    break;
                case 's':
                    if (Spielfeld.getFeld(Held.X, Held.Y + 1).Typ == FeldTyp.Leer)
                        Held.bewegen(Richtung.unten);
                    else
                        Held.verletzen(2);
                    break;
                case 'd':
                    if (Spielfeld.getFeld(Held.X + 1, Held.Y).Typ == FeldTyp.Leer)
                        Held.bewegen(Richtung.rechts);
                    else
                        Held.verletzen(2);
                    break;
                case 'e':
                    if (Spielfeld.getFeld(Held.X, Held.Y).Gegenstand != null)
                    {
                        Held.Inventar.Hinzufuegen(Spielfeld.getFeld(Held.X, Held.Y).Gegenstand);
                        Spielfeld.getFeld(Held.X, Held.Y).Gegenstand = null;
                    }

                    Monster monster = getMonsterAt(Held.X, Held.Y);
                    if (monster != null)
                    {
                        KampfForm form = new KampfForm(Held, monster);
                        form.ShowDialog();
                        if (monster.LebensPunkte <= 0)
                            monsters.Remove(monster);
                        if (Held.LebensPunkte <= 0)
                        {
                            MessageBox.Show("You Died.");
                        }
                    }

                    break;
                case 'r':
                    if (Spielfeld.getFeld(Held.X, Held.Y).Gegenstand == null)
                    {
                        Spielfeld.getFeld(Held.X, Held.Y).Gegenstand = Held.Inventar.Gegenstand(0);
                        Held.Inventar.Entfernen(0);
                    }
                    break;
                case 'f':

                    break;
                default:
                    return false;
            }
            return true;
        }

        public void zeichnen(Form form)
        {
            Spielfeld.zeichnen(form);
            foreach (Monster monster in monsters)
            {
                monster.zeichnen(form);
            }

            Held.zeichnen(form);
        }


    }
}
