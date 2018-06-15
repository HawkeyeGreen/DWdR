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
    class Sun : ISpaceObject
    {
        //long ID = -1;
        //string myPath;

        public string systematic_name;
        public string name;

        //Vector3D position = new Vector3D();

        public int suntype;
        public int size;
        //public string plane;

        public float radius = 5.0f;

        public AbstractYieldSet yield;

        public Vector3D position
        {
            get
            {
                return position;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string plane
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

        public string type
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

        public string path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }

        public long id
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

        public void createMe(int suntype, string systematicName, string PathForFile, Global_ID_Management GIDM, Random rnd)
        {
            Spaceobject thatsMe;
            id = GIDM.insertEntry("sun").id;
            path = PathForFile;

            this.suntype = suntype;

            yield = new AbstractYieldSet();
            createYield(rnd);

            saveMe();
        }

        public void saveMe()
        {
            StreamWriter writer = new StreamWriter(File.OpenWrite(path + "main.sun"));

            writer.WriteLine(systematic_name);
            writer.WriteLine(name);
            writer.WriteLine(plane);
            writer.WriteLine(position.getStringVersion());

            writer.WriteLine(Convert.ToString(id));
            writer.WriteLine(Convert.ToString(radius));
            writer.WriteLine(Convert.ToString(type));
            writer.WriteLine(Convert.ToString(size));


            writer.Close();

            //yield.saveMe(myPath + "yield.yld");
        }

        public void loadMe(string myPath)
        {
            StreamReader reader = new StreamReader(File.OpenRead(myPath + "main.sun"));

            systematic_name = Convert.ToString(reader.ReadLine());
            name = Convert.ToString(reader.ReadLine());
            plane = Convert.ToString(reader.ReadLine());

            position.FromString(Convert.ToString(reader.ReadLine()));

            id = Convert.ToInt64(reader.ReadLine());
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
