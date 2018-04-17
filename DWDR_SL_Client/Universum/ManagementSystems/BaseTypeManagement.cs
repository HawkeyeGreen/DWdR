using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DWDR_SL_Client.Universum.ManagementSystems
{
    /* 
     * Das GenerationProfileManagement behält Listen mit allen Profilen für die Erstellung von:
     * 1. Sonnen
     * 2. Planeten
     * 3. Asteroiden
     * 4. Scherbenwelt-Inseln
     * 5. Orokin-Türmen
     * 
     * bereit.
     * 
     * Die Profile enthalten alle Informationen, die ein entsprechendes Objekt benötigt, um sich selbst
     * zu initiieren.
     */
    class GenerationProfileManagement
    {
        string workingPath = AppDomain.CurrentDomain.BaseDirectory;
        List<SunGenerationProfile> baseSuns = new List<SunGenerationProfile>();
        List<PlanetGenerationProfile> basePlanets = new List<PlanetGenerationProfile>();
        public GenerationProfileManagement()
        {
            if (Directory.Exists(workingPath + "/Content/BaseTypes") == false) { Directory.CreateDirectory(workingPath + "/Content/BaseTypes"); }
            if (File.Exists(workingPath + "/Content/BaseTypes/Types.ov") == false)
            {
                StreamWriter sw = File.CreateText(workingPath + "/Content/BaseTypes/Types.ov");
                sw.WriteLine("0");
                sw.WriteLine("0");
                sw.WriteLine("0");
                sw.Close();
            }

            StreamReader reader = new StreamReader(File.OpenRead(workingPath + "/Content/BaseTypes/Types.ov"));
            int count_sun = Convert.ToInt32(reader.ReadLine());
            int count_planet = Convert.ToInt32(reader.ReadLine());
            int count_asteroid = Convert.ToInt32(reader.ReadLine());

            List<string> pathsSun = new List<string>();
            List<string> pathsPlanet = new List<string>();
            List<string> pathsAsteroid = new List<string>();

            for (int i = 0; i < count_sun; i++ )
            {
                pathsSun.Add(Convert.ToString(reader.ReadLine()));
            }
            for (int i = 0; i < count_planet; i++)
            {
                pathsPlanet.Add(Convert.ToString(reader.ReadLine()));
            }
            for (int i = 0; i < count_asteroid; i++)
            {
                pathsAsteroid.Add(Convert.ToString(reader.ReadLine()));
            }
            reader.Close();


        }

        public List<PlanetGenerationProfile> getAllowedProfiles(string sunType)
        {
            List<PlanetGenerationProfile> Return = new List<PlanetGenerationProfile>();

            foreach(PlanetGenerationProfile profile in basePlanets)
            {
                if (profile.sunAllowed(sunType)) { Return.Add(profile); }
            }

            return Return;
        }
    }


    /********* PlanetGenerationProfile *****************
     * In diesem Profil befinden sich alle wichtigen Informationen,
     * um einen Planeten zu erstellen.
     * Das bedeutet insbesondere Grundtyp, Subtyp, mindest entfernung zur Sonne, erlaubte Sonnen,
     * erlaubte Modifier, erlaubte Chemospheren und erlaubte Ökosysteme.
     * Außerdem kann ein Profile die Modi Ungewöhnlich, Selten oder Legendär enthalten,
     * in denen sich weitere Informationen finden.
     */
    class PlanetGenerationProfile
    {
        public string allowanceMode = "Any";    // Any, None, Whitelist, Blacklist
        public List<string> Allowance = new List<string>();   // Liste aller erlaubten Sonnen, die aus den Eingaben während der Profilerstellung gewonnen wurde.
        public string baseType = "Rock";        //  Rock, Gas
        public string subType = "Barren";       //  Barren, Gas Giant, Extreme, Habitable
        public string specialMode = "Standard"; //  Standard, Uncommon, Rare, Legendary

        public bool sunAllowed(string sunType)
        {
            if(allowanceMode == "Whitelist") // Wenn auf Liste -> erlaubt
            {
                foreach (string allowed in Allowance)
                {
                    if (sunType == allowed) { return true; }
                }
            }
            else if (allowanceMode == "Blacklist")  // Wenn auf Liste -> verboten
            {
                foreach (string allowed in Allowance)
                {
                    if (sunType == allowed) { return false; }
                }
            }
            else if(allowanceMode == "Any") // Immer erlaubt
            {
                return true;
            }
            // Immer verboten Oder Fehler
            return false;
        }
    }

    /*  SunGenerationProfile
     *  Dieses Profil dient dazu aus eine Sonne zu erstellen.
     *  Für Sonnen ist nur wichtig, ob sie gemeinsam mit einer anderen sich im Zentrum eines Sonnensystems befinden.
     *  Das Profil enthält alle Daten zu erträge, möglichen Ressourcen, Leuchtkraft und Abständen für die verschiedenen Zonen (Melting Hot, Lifebearing, Gas Giants, Frozen).
     */
    class SunGenerationProfile
    {
        public string sunName = "";
        public string baseType = "Rock";
        public string subType = "Barren";
        public bool allowsMutliSun = true;
    }
}
