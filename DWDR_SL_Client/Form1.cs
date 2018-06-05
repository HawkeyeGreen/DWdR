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

namespace DWDR_SL_Client
{
    public partial class Form1 : Form
    {
        // Klassen initialisieren //
        Universe universe;
        Global_ID_Management GIDM = Global_ID_Management.getInstance();
        List<Spaceobject> spaceObjects = new List<Spaceobject>();

        public Form1()
        {
            InitializeComponent();
        }

        private void neuladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            universe = Universe.getInstance(AppDomain.CurrentDomain.BaseDirectory);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            universe = Universe.getInstance(AppDomain.CurrentDomain.BaseDirectory);
            spaceObjects = universe.getAnySpaceObjectInRadiusAround(new Vector3D(), 1.0f);
            actualizetollStripInfoGIDM();
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GIDM.saveIDDatabank();
            this.Close();
        }

        private void aktualisiereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            actualizetollStripInfoGIDM();
        }

        void actualizetollStripInfoGIDM()
        {
            toolStripTextBoxGIDMGrp.Text = "Anzahl: Gruppen";
            toolStripTextBoxGIDMGrp.ToolTipText = Convert.ToString(GIDM.getGrpCount());

            toolStripTextBoxGIDMHR.Text = "Höchste Stelle";
            toolStripTextBoxGIDMHR.ToolTipText = Convert.ToString(GIDM.highestRange);

            toolStripTextBoxGIDMCount.Text = "Anzahl: Einträge";
            toolStripTextBoxGIDMCount.ToolTipText = Convert.ToString(GIDM.getEntryCount());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Modifier tmp = new Modifier();
            tmp.mode = Modus.Text;
            tmp.type = Typ.Text;
            tmp.value = Convert.ToDouble(Wert.Text);
            WertAnzeige.Text = Convert.ToString(tmp.value);
            int vergangeneRunden = Convert.ToInt32(Runden.Text);
            label5.Text = Convert.ToString(tmp.conglomerateModifier(vergangeneRunden));
        }
    }
}
