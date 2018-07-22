using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DWDR_SL_Client.Organization;
using DWDR_SL_Client.Universum;
using DWDR_SL_Client.Universum.EffectSystem;
using Zeus.Hermes;

namespace DWDR_SL_Client
{
    public partial class Form1 : Form
    {
        // Klassen initialisieren //
        Universe universe;
        //Global_ID_Management GIDM = Global_ID_Management.getInstance();
        List<ISpaceObject> spaceObjects = new List<ISpaceObject>();

        public Form1()
        {
            InitializeComponent();
        }

        private void neuladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            universe = Universe.getInstance();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Universe.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            universe = Universe.getInstance();
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hermes.getInstance().shutdownHermes();
            this.Close();
        }

        private void aktualisiereToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

    }
}
