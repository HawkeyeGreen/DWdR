using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DWDR_SL_Client.Organization;
using DWDR_SL_Client.Universum.ManagementSystems;
using DWDR_SL_Client.Universum.EffectSystem;
using DWDR_SL_Client.Universum.Planets;
using DWDR_SL_Client.Universum.Ressources;

namespace DWDR_SL_Client.Universum
{
    class Planet : GenericSpaceObject
    {
        // public EffectManager effectManagement;
        public string systematic_name;
        public string named;
        public string claimed_by;
        private string plane = "main";
        private string descriptionPath;

        public Vector3D direction = new Vector3D();
        public Vector3D magic_vec = new Vector3D();
        public Vector3D carmal_vec = new Vector3D();

        private string type = "planet";
        private string planetType;
        public int size;
        private float radius = 1.0f;

        public bool ecosystem;
        public bool claimed;
        public bool inhabited;

        List<string> communities = new List<string>();

        private List<Deposit> groundDeposits;

        public string Plane { get => plane; set => plane = value; }
        public string Type { get => type; set => type = value; }
        public string PlanetType { get => planetType; set => planetType = value; }
        
        public long ID { get => base.ID; set => base.ID = value; }

        public string Systematic_name { get => systematic_name; set => systematic_name = value; }
        public float Radius { get => radius; set => radius = value; }

        public Planet(Vector3D position, string path) : base("Planet", position, path)
        {
            
        }

        public Planet createMe(string pathForDirectory, float radius, Vector3D position, string systematicName, long ID, Sunsystem sunsystem, List<PlanetGenerationProfile> allowedProfiles)
        {
            this.radius = radius;
            Position = position;

            return this;
        }

        public void update(int simulation_Tier)
        {
            Position.addVector(direction);
        }

        public Planet loadMe(string path)
        {
            Path = path;

            StreamReader reader = new StreamReader(File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + Path));

            Systematic_name = Convert.ToString(reader.ReadLine());
            ID = Convert.ToInt64(reader.ReadLine());
            named = Convert.ToString(reader.ReadLine());
            Type = Convert.ToString(reader.ReadLine());
            claimed = Convert.ToBoolean(reader.ReadLine());


            Position.FromString(Convert.ToString(reader.ReadLine()));
            direction.FromString(Convert.ToString(reader.ReadLine()));
            magic_vec.FromString(Convert.ToString(reader.ReadLine()));
            carmal_vec.FromString(Convert.ToString(reader.ReadLine()));

            reader.Close();
            return this;
        }

        public void saveMe()
        {
            StreamWriter writer = new StreamWriter(File.OpenWrite(AppDomain.CurrentDomain.BaseDirectory + Path));

            writer.WriteLine(Systematic_name);
            writer.WriteLine(named);
            writer.WriteLine(Type);
            writer.WriteLine(claimed);

            writer.WriteLine(Position.getStringVersion());
            writer.WriteLine(direction.getStringVersion());
            writer.WriteLine(magic_vec.getStringVersion());
            writer.WriteLine(carmal_vec.getStringVersion());

            writer.Close();
        }

        public override List<IEffectable> getAllEffectables()
        {
            throw new NotImplementedException();
        }

        public override List<IEffectable> getEffectablesByKey(string affectionKey)
        {
            throw new NotImplementedException();
        }

        public override List<IEffectable> getEffectablesByKeyTable(Tuple<List<string>, List<string>> table)
        {
            throw new NotImplementedException();
        }


        public static Planet getPlanetByID(long ID)
        {
            string path = Universe.getInstance().getPlanetPathByID(ID);
            return new Planet(new Vector3D(), path).loadMe(path);
        }
    }
}
