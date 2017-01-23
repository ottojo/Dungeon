using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DungeonJonas
{
    public partial class Form1 : Form
    {

        Dungeon dungeon = new Dungeon();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            progressBarHealth.Maximum = dungeon.Held.MaxLebensPunkte;
            progressBarHealth.Value = dungeon.Held.LebensPunkte;

            /* Test File opening
             * 
             * OpenFileDialog file = new OpenFileDialog();
             if (file.ShowDialog() == DialogResult.OK)
             {
                 AGegenstand fromFile = GegenstandUtil.fromFile(file.FileName).ElementAt(0);
                 Console.WriteLine(fromFile.ToString());
             }*/

            Console.WriteLine("Done");
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            dungeon.handleKeyPress(e);
            Refresh();
            zeichnen();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            zeichnen();
        }

        private void zeichnen()
        {
            dungeon.zeichnen(this);
            progressBarHealth.Value = dungeon.Held.LebensPunkte;
            textBoxInventar.Text = dungeon.Held.Inventar.ToString();
            if (dungeon.Spielfeld.getFeld(dungeon.Held.X, dungeon.Held.Y).Gegenstand != null)
                textBoxInfo.Text = dungeon.Spielfeld.getFeld(dungeon.Held.X, dungeon.Held.Y).Gegenstand.ToString();
            else if (dungeon.getMonsterAt(dungeon.Held.X, dungeon.Held.Y) != null)
                textBoxInfo.Text = dungeon.getMonsterAt(dungeon.Held.X, dungeon.Held.Y).ToString();
            else
                textBoxInfo.Text = "";
        }
    }
}
