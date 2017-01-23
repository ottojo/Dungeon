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
    public partial class KampfForm : Form
    {
        Kreatur kreatur0, kreatur1;
        const int roundTime = 1000;
        public KampfForm(Kreatur kreatur0, Kreatur kreatur1)
        {
            InitializeComponent();
            this.kreatur0 = kreatur0;
            this.kreatur1 = kreatur1;
        }


        private void KampfForm_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = kreatur0.Color;
            pictureBox2.BackColor = kreatur1.Color;
            progressBar1.Maximum = kreatur0.MaxLebensPunkte;
            progressBar2.Maximum = kreatur1.MaxLebensPunkte;
            updateHealth();
        }

        void updateHealth()
        {
            progressBar1.Value = kreatur0.LebensPunkte;
            progressBar2.Value = kreatur1.LebensPunkte;
        }

        private void KampfForm_Shown(object sender, EventArgs e)
        {
            start();
        }

        async Task RoundDelayTask()
        {
            await Task.Delay(roundTime);
        }


        public async void start()
        {
            await RoundDelayTask();
            while (kreatur0.LebensPunkte > 0 && kreatur1.LebensPunkte > 0)
            {
                if (kreatur0 as IKampf != null)
                {
                    (kreatur0 as IKampf).bekaempfe(kreatur1);
                    updateHealth();
                    await RoundDelayTask();
                }
                if (kreatur0.LebensPunkte <= 0 || kreatur1.LebensPunkte <= 0)
                    break;
                if (kreatur1 as IKampf != null)
                {
                    (kreatur1 as IKampf).bekaempfe(kreatur0);
                    updateHealth();
                    await RoundDelayTask();
                }
            }
            Console.WriteLine("Kampf is over!");
            this.Close();
        }
    }
}
