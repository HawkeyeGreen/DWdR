using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DWDR_SL_Client.Organization;
using DWDR_SL_Client.Universum.ManagementSystems;

namespace DWDR_SL_Client.Universum
{
    class Planet
    {
        string myPath;
        public long ID;

        public string systematic_name;
        public string named;
        public string claimed_by;
        public string plane = "main";

        public Vector3D position = new Vector3D();
        public Vector3D direction = new Vector3D();
        public Vector3D magic_vec = new Vector3D();
        public Vector3D carmal_vec = new Vector3D();

        public int type = -1;
        public int size;
        public int surface;
        public int humidity_level;
        public int temperature;
        public int carmal;
        public int magic;

        public float radius = 1.0f;

        public bool ecosystem;
        public bool claimed;
        public bool inhabited;

        List<string> communities = new List<string>();

        public Planet createMe(string pathForDirectory, float radius, Vector3D position, string systematicName, long ID, Global_ID_Management GIDM, Sunsystem sunsystem, List<PlanetGenerationProfile> allowedProfiles)
        {
            

            return this;
        }

        public void update(int simulation_Tier)
        {
            position.addVector(direction);
        }

        public Planet loadMe(string Path)
        {
            myPath = Path;

            StreamReader reader = new StreamReader(File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + myPath));

            systematic_name = Convert.ToString(reader.ReadLine());
            ID = Convert.ToInt64(reader.ReadLine());
            named = Convert.ToString(reader.ReadLine());
            type = Convert.ToInt16(reader.ReadLine());
            claimed = Convert.ToBoolean(reader.ReadLine());

            humidity_level = Convert.ToInt32(reader.ReadLine());

            position.FromString(Convert.ToString(reader.ReadLine()));
            direction.FromString(Convert.ToString(reader.ReadLine()));
            magic_vec.FromString(Convert.ToString(reader.ReadLine()));
            carmal_vec.FromString(Convert.ToString(reader.ReadLine()));

            reader.Close();
            return this;
        }

        public void saveMe()
        {
            StreamWriter writer = new StreamWriter(File.OpenWrite(AppDomain.CurrentDomain.BaseDirectory + myPath));

            writer.WriteLine(systematic_name);
            writer.WriteLine(named);
            writer.WriteLine(type);
            writer.WriteLine(claimed);

            writer.WriteLine(position.getStringVersion());
            writer.WriteLine(direction.getStringVersion());
            writer.WriteLine(magic_vec.getStringVersion());
            writer.WriteLine(carmal_vec.getStringVersion());

            writer.Close();
        }

        public int getIntegerValue(string attribute)
        {
            if(attribute == "type")
            {
                return type;
            }
            else if(attribute == "size")
            {
                return size;
            }
            else if (attribute == "surface")
            {
                return surface;
            }
            else if (attribute == "humidity_level")
            {
                return humidity_level;
            }
            else if (attribute == "temperature")
            {
                return temperature;
            }
            else if (attribute == "carmal")
            {
                return carmal;
            }
            else if (attribute == "magic")
            {
                return magic;
            }
            else
            {
                return -1;
            }
        }
    }
}
