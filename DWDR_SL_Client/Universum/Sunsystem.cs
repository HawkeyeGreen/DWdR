using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWDR_SL_Client.Organization;
using System.IO;
using DWDR_SL_Client.Universum.ManagementSystems;

namespace DWDR_SL_Client.Universum
{
    /**********************Konzept**********************
     * Sonnensysteme sind eine höhere Zoomstufe im Universum.
     * In ihnen wird alles von der/ den Sonnen aus benannt.
     * 
     ***************************************************/
    class Sunsystem : MappedObject, ISpaceObject
    {
        #region Fields
        private string myDirectory;
        private long id = -1;

        private string systematic_Name = "TBD";
        private string given_Name = "Unbenanntes Sonnensystem";
        private string plane = "main";
        private string type = "sunsystem";

        private int AsteroidBelts;

        private Vector3D position = new Vector3D();

        List<ISpaceObject> sunList = new List<ISpaceObject>();
        List<ISpaceObject> planetList = new List<ISpaceObject>();
        List<ISpaceObject> wanderingObjectList = new List<ISpaceObject>();
        List<List<ISpaceObject>> asteroidBeltObjects = new List<List<ISpaceObject>>();
        #endregion

        #region Eigenschaften
        public Vector3D Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public string Plane
        {
            get
            {
                return plane;
            }

            set
            {
                plane = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public string Path
        {
            get
            {
                return myDirectory;
            }

            set
            {
                myDirectory = value;
            }
        }

        public long ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string SystematicName
        {
            get => systematic_Name;
            set => systematic_Name = value;
        }

        public string GivenName
        {
            get => given_Name;
            set => given_Name = value;
        }

        public int NumberOfAsteroidBelts
        {
            get => AsteroidBelts;
            private set => AsteroidBelts = value;
        }
        #endregion

        public Sunsystem() : base("Sunystem")
        {

        }

        // Die createMe-Funktion erstellt aus den Parametern, die vom Universums-Konstruktor kommen,
        // die Inhalte des Sonnensystems.
        // Diese Funktion erzeugt ein 'normales' Sonnensystem.
        // Für spezielle Sonnensysteme gibt es einen entsprechenden Modus,
        // ebenso für mehrfach Systeme.
        public void createMe(string pathForDirectory,int suns, int planets, float radius, Vector3D position, string systematicName, int createWanderingObjects, long ID, Universe universe)
        {
            // Initialisiere erst einmal dich selbst ^-^
            this.ID = ID;
            myDirectory = pathForDirectory;
            systematic_Name = systematicName;

            // Initialisiere weitere wichtige Elemente
            Random rnd = new Random();

            // Erstelle alle Sonnen, die du enthältst.
            // Kläre, welche Sonnentypen möglich sind.
            List<int> possibleSunstypes = new List<int>();
            if(suns > 1)
            {
                possibleSunstypes = universe.getPossibleSuntypes(true);
            }
            else
            {
                possibleSunstypes = universe.getPossibleSuntypes(false);
            }
            
            for (int i = 0; i < suns; i++)
            {
                Sun newSun = new Sun();
                newSun.createMe(possibleSunstypes[rnd.Next(0, possibleSunstypes.Count)], systematic_Name + "-" + Convert.ToString(i), pathForDirectory + "/s" + Convert.ToString(i) + ".s", rnd);
                sunList.Add(newSun);
            }


        }
        
        public Sunsystem loadMe(string pathForDirectory)
        {
            myDirectory = pathForDirectory;
            StreamReader reader = new StreamReader(File.OpenRead(myDirectory + "sunsystem.ov"));
            ID = Convert.ToInt64(reader.ReadLine());
            systematic_Name = Convert.ToString(reader.ReadLine());
            given_Name = Convert.ToString(reader.ReadLine());
            AsteroidBelts = Convert.ToInt32(reader.ReadLine());
            reader.Close();
            return this;
        }

        public Spaceobject thatsMe(string myPath)
        {
            loadMe(myPath);
            return new Spaceobject(Position, "sunsystem", ID, systematic_Name, new List<string>(), myDirectory);
        }

        public void saveMe()
        {
            // Checke ob ich existiere ^-^
            if (Directory.Exists(myDirectory) == false) { Directory.CreateDirectory(myDirectory); }

            // Hauptdatei erzeugen
            // Hier stehen alle Variablen von oben drinne, die wir brauchen
            StreamWriter sw = File.CreateText(myDirectory + "/me.ov");
            sw.WriteLine(Convert.ToString(ID));
            sw.WriteLine(systematic_Name);
            sw.WriteLine(given_Name);
            sw.WriteLine(Convert.ToString(AsteroidBelts));
            sw.Close();

            // sunlist erzeugen

            // planetList erzeugen

            // wanderingobjectlist erzeugen

            // asteroidbelt erzeugen

        }
    }
}
