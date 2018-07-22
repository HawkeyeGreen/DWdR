using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DWDR_SL_Client.Organization;
using DWDR_SL_Client.Universum;
using DWDR_SL_Client.Universum.EffectSystem.Effects;
using DWDR_SL_Client.Universum.EffectSystem.Condition;
using DWDR_SL_Client.Universum.EffectSystem.Modifiers;
using Zeus.Hermes;

namespace DWDR_SL_Client
{
    public partial class Form1 : Form
    {
        // Klassen initialisieren //
        Universe universe;

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

            Dictionary<string, List<List<AbstractModifier>>> _Modifiers = new Dictionary<string, List<List<AbstractModifier>>>();

            AbstractEffect testEffect = new TimedEffect(universe, 5, _Modifiers, new PlanetTypeCheck(new Planet(new Vector3D(), ""), "Barren"));
            StreamWriter writer = new StreamWriter(File.OpenWrite(AppDomain.CurrentDomain.BaseDirectory + "/Test.txt"));
            testEffect.save(writer);
            writer.Close();

            new Planet(new Vector3D(), "");
            new Planet(new Vector3D(), "");
            new Planet(new Vector3D(), "");
            new Planet(new Vector3D(), "");
            new Planet(new Vector3D(), "");
            new Planet(new Vector3D(), "");
            new Planet(new Vector3D(), "");

            testEffect = new TimedEffect(universe, 10, _Modifiers, new PlanetTypeCheck(new Planet(new Vector3D(), ""), "Frozen"));

            StreamReader reader = new StreamReader(File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + "/Test.txt"));
            reader.ReadLine();
            testEffect.load(reader);
            reader.Close();
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
