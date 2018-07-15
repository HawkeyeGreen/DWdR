using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DWDR_SL_Client.Organization;
using DWDR_SL_Client.Universum.Ressources;

namespace DWDR_SL_Client.Universum
{
    class Sun : MappedObject, ISpaceObject
    {
        private long id = -1;
        private string myPath;

        private Temperature temperature = new Temperature(5800);

        public string systematic_name;
        public string name;

        private Vector3D position = new Vector3D();

        public int suntype;
        public int size;
        private string plane = "main";
        private string type = "sun";

        public float radius = 5.0f;

        public AbstractYieldSet yield;

        #region GetterSetter

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
                return myPath;
            }

            set
            {
                myPath = value;
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

        public Temperature Temperature
        {
            get => temperature;
            set => temperature = value;
        }
        #endregion

        public Sun() : base("Sun")
        {

        }

        public void createMe(int suntype, string systematicName, string PathForFile,  Random rnd)
        {
            Path = PathForFile;

            this.suntype = suntype;

            yield = new AbstractYieldSet();
            createYield(rnd);

            saveMe();
        }

        public void saveMe()
        {
            StreamWriter writer = new StreamWriter(File.OpenWrite(Path + "main.sun"));

            writer.WriteLine(systematic_name);
            writer.WriteLine(name);
            writer.WriteLine(Plane);
            writer.WriteLine(Position.getStringVersion());

            writer.WriteLine(Convert.ToString(ID));
            writer.WriteLine(Convert.ToString(radius));
            writer.WriteLine(Convert.ToString(Type));
            writer.WriteLine(Convert.ToString(size));


            writer.Close();

            //yield.saveMe(myPath + "yield.yld");
        }

        public void loadMe(string myPath)
        {
            StreamReader reader = new StreamReader(File.OpenRead(myPath + "main.sun"));

            systematic_name = Convert.ToString(reader.ReadLine());
            name = Convert.ToString(reader.ReadLine());
            Plane = Convert.ToString(reader.ReadLine());

            Position.FromString(Convert.ToString(reader.ReadLine()));

            ID = Convert.ToInt64(reader.ReadLine());
            radius = Convert.ToSingle(reader.ReadLine());

            suntype = Convert.ToInt32(reader.ReadLine());
            size = Convert.ToInt32(reader.ReadLine());

            reader.Close();

            yield = new AbstractYieldSet();
            //yield = yield.loadMe(myPath + "yield.yld");
        }

        public void createYield(Random rnd)
        {
           
        }
    }
}
