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
    class Sun
    {
        long ID = -1;
        string myPath;

        public string systematic_name;
        public string name;

        public Vector3D position = new Vector3D();

        public int type;
        public int size;
        public string plane;

        public float radius = 5.0f;

        public AbstractYieldSet yield;

        public Spaceobject createMe(int suntype, string systematicName, string PathForFile, Global_ID_Management GIDM, Random rnd)
        {
            Spaceobject thatsMe;
            ID = GIDM.insertEntry("sun").id;
            myPath = PathForFile;

            type = suntype;

            yield = new AbstractYieldSet();
            createYield(rnd);

            thatsMe = new Spaceobject(position, "sun", ID, systematic_name, new List<string>(), myPath);
            saveMe();
            return thatsMe;
        }

        public void saveMe()
        {
            StreamWriter writer = new StreamWriter(File.OpenWrite(myPath + "main.sun"));

            writer.WriteLine(systematic_name);
            writer.WriteLine(name);
            writer.WriteLine(plane);
            writer.WriteLine(position.getStringVersion());

            writer.WriteLine(Convert.ToString(ID));
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

            ID = Convert.ToInt64(reader.ReadLine());
            radius = Convert.ToSingle(reader.ReadLine());

            type = Convert.ToInt32(reader.ReadLine());
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
