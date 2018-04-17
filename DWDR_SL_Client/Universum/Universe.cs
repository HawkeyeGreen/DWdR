using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DWDR_SL_Client.Organization;

namespace DWDR_SL_Client.Universum
{
    class Universe
    {
        // Globale System Variablen //
        string workingDirectory;

        // Galaxie Eigenschaften //
        int gal_Count                   = 0;
        List<Galaxy> galaxies           = new List<Galaxy>();

        // Referenzen auf Raumobjekte
        List<Spaceobject> wanderingSpaceObjects  = new List<Spaceobject>();
        List<Spaceobject> sunsystems = new List<Spaceobject>();
        List<Spaceobject> roamingSuns = new List<Spaceobject>();
        List<Spaceobject> roamingPlanets = new List<Spaceobject>();

        List<string> sunsystemPaths     = new List<string>();
        List<string> sunPaths           = new List<string>();
        List<string> planetPaths        = new List<string>();

        public Universe(string workingPath)
        {
            workingDirectory = workingPath;
            #region Check if all necessary files and folders exists
            #region foldercheck
            if (Directory.Exists(workingPath + "/uni") == false) { Directory.CreateDirectory(workingPath + "/uni"); }
            if (Directory.Exists(workingPath + "/uni/rO") == false) { Directory.CreateDirectory(workingPath + "/uni/rO"); }
            if (Directory.Exists(workingPath + "/uni/rO/p") == false) { Directory.CreateDirectory(workingPath + "/uni/rO/p"); }
            if (Directory.Exists(workingPath + "/uni/rO/s") == false) { Directory.CreateDirectory(workingPath + "/uni/rO/s"); }
            if (Directory.Exists(workingPath + "/uni/ss") == false) { Directory.CreateDirectory(workingPath + "/uni/ss"); }
            #endregion
            #region filecheck
            if (File.Exists(workingPath + "/uni/galaxies.ov") == false) 
            {
                StreamWriter sw = File.CreateText(workingPath + "/uni/galaxies.ov");
                sw.WriteLine("0");
                sw.Close();
            }
            if (File.Exists(workingPath + "/uni/sunsystem_paths.ov") == false)
            {
                StreamWriter sw = File.CreateText(workingPath + "/uni/sunsystem_paths.ov");
                sw.WriteLine("0");
                sw.Close();
            }
            if (File.Exists(workingPath + "/uni/sun_paths.ov") == false)
            {
                StreamWriter sw = File.CreateText(workingPath + "/uni/sun_paths.ov");
                sw.WriteLine("0");
                sw.Close();
            }
            if (File.Exists(workingPath + "/uni/planet_paths.ov") == false)
            {
                StreamWriter sw = File.CreateText(workingPath + "/uni/planet_paths.ov");
                sw.WriteLine("0");
                sw.Close();
            }
            #endregion
            #endregion

            #region load all paths and stuff
            #region Galaxien laden
            StreamReader reader = new StreamReader(File.OpenRead(workingPath + "/uni/galaxies.ov"));
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
            reader = new StreamReader(File.OpenRead(workingPath + "/uni/sunsystem_paths.ov"));
            int count = Convert.ToInt16(reader.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string path = Convert.ToString(reader.ReadLine());
                Sunsystem tmp = new Sunsystem();
                Spaceobject spaceObj = tmp.thatsMe(path);

                sunsystemPaths.Add(path);
                sunsystems.Add(spaceObj);
            }
            reader.Close();
            #endregion

            #region Freie Sonnen laden
            reader = new StreamReader(File.OpenRead(workingPath + "/uni/sun_paths.ov"));
            count = Convert.ToInt16(reader.ReadLine());
            for (int i = 0; i < count; i++)
            {
                sunPaths.Add(Convert.ToString(reader.ReadLine()));
            }
            reader.Close();
            #endregion

            #region Freie Planeten laden
            reader = new StreamReader(File.OpenRead(workingPath + "/uni/planet_paths.ov"));
            count = Convert.ToInt16(reader.ReadLine());
            for (int i = 0; i < count; i++)
            {
                planetPaths.Add(Convert.ToString(reader.ReadLine()));
                Planet planet = new Planet().loadMe(planetPaths[i]);
                Spaceobject tmp = new Spaceobject(planet.position, "planet", planet.ID, planet.systematic_name, new List<string>(), planetPaths[i]);
                roamingPlanets.Add(tmp);
                
            }
            reader.Close();
            #endregion
            #endregion
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
                Planet planet = new Planet();
                planet.loadMe(workingDirectory + plt);
                planet.update(0);
                planet.saveMe();
            }
        }

        public List<Spaceobject> getSpaceObjectsByPosition(List<Spaceobject> spaceObjects,Vector3D checkPosition, float radius)
        {
            List<Spaceobject> Return = new List<Spaceobject>();

            foreach (Spaceobject spaceObject in spaceObjects)
            {
                float distance = spaceObject.position.createVectorBetween(checkPosition).length();
                if (distance <= radius)
                {
                    Return.Add(spaceObject);
                }
            }

            return Return;
        }

        public List<Spaceobject> getAnySpaceObjectInRadiusAround(Vector3D checkPosition, float radius)
        {
            List<Spaceobject> Return = getSpaceObjectsByPosition(wanderingSpaceObjects, checkPosition, radius);
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
    }

    class Galaxy
    {
        public string name = "Auriga";
        public Vector3D position = new Vector3D();
        public float radius = 10;
    }
}
