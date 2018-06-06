﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DWDR_SL_Client.Organization;
using DWDR_SL_Client.Universum.ManagementSystems;

namespace DWDR_SL_Client.Universum
{
    class Planet : ISpaceObject
    {
        string path;
        long ID;

        public string systematic_name;
        public string named;
        public string claimed_by;
        string plane = "main";
        string type = "planet";

        public Vector3D position
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
        public Vector3D direction = new Vector3D();
        public Vector3D magic_vec = new Vector3D();
        public Vector3D carmal_vec = new Vector3D();

        public int typeNumber = -1;
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

        Vector3D ISpaceObject.position
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

        string ISpaceObject.plane
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

        string ISpaceObject.type
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

        string ISpaceObject.path
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
                return ID;
            }

            set
            {
                ID = value; ;
            }
        }

        public Planet()
        {
            position = new Organization.Vector3D();
        }

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
            path = Path;

            StreamReader reader = new StreamReader(File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + path));

            systematic_name = Convert.ToString(reader.ReadLine());
            ID = Convert.ToInt64(reader.ReadLine());
            named = Convert.ToString(reader.ReadLine());
            typeNumber = Convert.ToInt16(reader.ReadLine());
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
            StreamWriter writer = new StreamWriter(File.OpenWrite(AppDomain.CurrentDomain.BaseDirectory + path));

            writer.WriteLine(systematic_name);
            writer.WriteLine(named);
            writer.WriteLine(typeNumber);
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
                return typeNumber;
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
