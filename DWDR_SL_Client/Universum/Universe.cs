using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DWDR_SL_Client.Organization;
using DWDR_SL_Client.Universum.EffectSystem;

namespace DWDR_SL_Client.Universum
{
    /// <summary>
    /// IMPORTANT TODO: planes implementieren, um eine gute Kapselung von Objekten auf den verschiedenen
    /// Dimensionsebenen zu erreichen (!)
    /// </summary>


    class Universe : MappedObject, IEffectable
    {
        // SINGLETON IMPLEMENTATION //
        private static Universe instance;

        // Globale System Variablen //
        private static string workingDirectory;
        public static string WorkingDirectory { set => workingDirectory = value; }

        // Galaxie Eigenschaften //
        int gal_Count                   = 0;
        List<Galaxy> galaxies           = new List<Galaxy>();

        // Referenzen auf Raumobjekte
        List<ISpaceObject> wanderingSpaceObjects  = new List<ISpaceObject>();
        List<ISpaceObject> sunsystems = new List<ISpaceObject>();
        List<ISpaceObject> roamingSuns = new List<ISpaceObject>();
        List<ISpaceObject> roamingPlanets = new List<ISpaceObject>();

        List<string> sunsystemPaths     = new List<string>();
        List<string> sunPaths           = new List<string>();
        List<string> planetPaths        = new List<string>();

        public EffectManager EffectManager => throw new NotImplementedException();

        public List<string> Resistances => throw new NotImplementedException();

        public List<string> Affectable => throw new NotImplementedException();

        public IEffectable Parent => null;


        // Universe-wide effectSystem
        EffectManager effectManager;

        private Universe() : base("The Universe")
        {
            effectManager = new EffectManager(this);

            #region Check if all necessary files and folders exists
            #region foldercheck
            if (Directory.Exists(workingDirectory + "/uni") == false) { Directory.CreateDirectory(workingDirectory + "/uni"); }
            if (Directory.Exists(workingDirectory + "/uni/rO") == false) { Directory.CreateDirectory(workingDirectory + "/uni/rO"); }
            if (Directory.Exists(workingDirectory + "/uni/rO/p") == false) { Directory.CreateDirectory(workingDirectory + "/uni/rO/p"); }
            if (Directory.Exists(workingDirectory + "/uni/rO/s") == false) { Directory.CreateDirectory(workingDirectory + "/uni/rO/s"); }
            if (Directory.Exists(workingDirectory + "/uni/ss") == false) { Directory.CreateDirectory(workingDirectory + "/uni/ss"); }
            #endregion
            #region filecheck
            if (File.Exists(workingDirectory + "/uni/galaxies.ov") == false) 
            {
                StreamWriter sw = File.CreateText(workingDirectory + "/uni/galaxies.ov");
                sw.WriteLine("0");
                sw.Close();
            }
            if (File.Exists(workingDirectory + "/uni/sunsystem_paths.ov") == false)
            {
                StreamWriter sw = File.CreateText(workingDirectory + "/uni/sunsystem_paths.ov");
                sw.WriteLine("0");
                sw.Close();
            }
            if (File.Exists(workingDirectory + "/uni/sun_paths.ov") == false)
            {
                StreamWriter sw = File.CreateText(workingDirectory + "/uni/sun_paths.ov");
                sw.WriteLine("0");
                sw.Close();
            }
            if (File.Exists(workingDirectory + "/uni/planet_paths.ov") == false)
            {
                StreamWriter sw = File.CreateText(workingDirectory + "/uni/planet_paths.ov");
                sw.WriteLine("0");
                sw.Close();
            }
            #endregion
            #endregion

            #region load all paths and stuff
            #region Galaxien laden
            StreamReader reader = new StreamReader(File.OpenRead(workingDirectory + "/uni/galaxies.ov"));
            gal_Count = Convert.ToInt16(reader.ReadLine());
            for(int i = 0; i < gal_Count; i++)
            {
                reader.ReadLine();
                Galaxy tmp = new Galaxy();
                tmp.name = Convert.ToString(reader.ReadLine());
                tmp.position.FromString(Convert.ToString((reader.ReadLine())));
                tmp.radius = Convert.ToSingle(reader.ReadLine());
                galaxies.Add(tmp);
            }
            reader.Close();
            #endregion

            #region Sonnensysteme laden
            reader = new StreamReader(File.OpenRead(workingDirectory + "/uni/sunsystem_paths.ov"));
            int count = Convert.ToInt16(reader.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string path = Convert.ToString(reader.ReadLine());
                Sunsystem tmp = new Sunsystem();
                tmp.loadMe(path);

                sunsystemPaths.Add(path);
                sunsystems.Add(tmp);
            }
            reader.Close();
            #endregion

            #region Freie Sonnen laden
            reader = new StreamReader(File.OpenRead(workingDirectory + "/uni/sun_paths.ov"));
            count = Convert.ToInt16(reader.ReadLine());
            for (int i = 0; i < count; i++)
            {
                sunPaths.Add(Convert.ToString(reader.ReadLine()));
            }
            reader.Close();
            #endregion

            #region Freie Planeten laden
            reader = new StreamReader(File.OpenRead(workingDirectory + "/uni/planet_paths.ov"));
            count = Convert.ToInt16(reader.ReadLine());
            for (int i = 0; i < count; i++)
            {
                planetPaths.Add(Convert.ToString(reader.ReadLine()));
                Planet planet = new Planet(new Vector3D(), planetPaths[i]).loadMe(planetPaths[i]);
                //Spaceobject tmp = new Spaceobject(planet.position, "planet", planet.id, planet.systematic_name, new List<string>(), planetPaths[i]);
                roamingPlanets.Add(planet);
                
            }
            reader.Close();
            #endregion
            #endregion
        }


        public static Universe getInstance()
        {
            if(instance == null)
            {
                Universe.instance = new Universe();
            }
            return instance;
        }

        public void reinitialize(string workingDirectory)
        {

        }

        public Galaxy getGalaxyByID(int ID)
        {
                return galaxies[ID];
        }

        public int getGalaxieCount() { return galaxies.Count; }

        public bool isPositionInVeil(Vector3D pos)
        {
            foreach(Galaxy glx in galaxies)
            {
                if (glx.position.createVectorBetween(pos).length() < glx.radius)
                {
                    return false;
                }
            }
            return true;
        }

        public void end_round()
        {
            foreach(string plt in planetPaths)
            {
                Planet planet = new Planet(new Vector3D(), workingDirectory + plt);
                planet.loadMe(workingDirectory + plt);
                planet.update(0);
                planet.saveMe();
            }
        }

        public List<ISpaceObject> getSpaceObjectsByPosition(List<ISpaceObject> spaceObjects,Vector3D checkPosition, float radius)
        {
            List<ISpaceObject> Return = new List<ISpaceObject>();

            foreach (ISpaceObject spaceObject in spaceObjects)
            {
                float distance = spaceObject.Position.createVectorBetween(checkPosition).length();
                if (distance <= radius)
                {
                    Return.Add(spaceObject);
                }
            }

            return Return;
        }

        public List<ISpaceObject> getAnySpaceObjectInRadiusAround(Vector3D checkPosition, float radius)
        {
            List<ISpaceObject> Return = getSpaceObjectsByPosition(wanderingSpaceObjects, checkPosition, radius);
            Return.AddRange(getSpaceObjectsByPosition(sunsystems, checkPosition, radius));
            Return.AddRange(getSpaceObjectsByPosition(roamingSuns, checkPosition, radius));
            Return.AddRange(getSpaceObjectsByPosition(roamingPlanets, checkPosition, radius));
            return Return;
        }

        public List<int> getPossibleSuntypes(bool polySuns)
        {
            List<int> possibleSuntypes = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                possibleSuntypes.Add(3);
                possibleSuntypes.Add(4);
            }
            for (int i = 0; i < 6; i++)
            {
                possibleSuntypes.Add(6);
            }
            if(polySuns == false)
            {
                possibleSuntypes.Add(2);
                possibleSuntypes.Add(7);
                for(int i = 0; i < 3; i++)
                {
                    possibleSuntypes.Add(0);
                    possibleSuntypes.Add(1);
                }
            }
            return possibleSuntypes;
        }

        public List<IEffectable> getAllEffectables()
        {
            throw new NotImplementedException();
        }

        public List<IEffectable> getEffectablesByKey(string affectionKey)
        {
            throw new NotImplementedException();
        }

        public List<IEffectable> getEffectablesByKeyTable(Tuple<List<string>, List<string>> table)
        {
            throw new NotImplementedException();
        }
    }

    class Galaxy : MappedObject
    {
        public string name = "Auriga";
        public Vector3D position = new Vector3D();
        public float radius = 10;

        public Galaxy() : base("Galaxy")
        {

        }
    }
}
