using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWDR_SL_Client.Universum.Ecosystem;

namespace DWDR_SL_Client.Universum.Ressources
{
    class Ressource
    {
        public int ressourceID = 0;

        public string name = "";
        public string type = "0";
        public string pathToDescr = "/base/empty.rtf";
        public List<int> neededTechs = new List<int>();
        public bool fluid = false;
        public bool gas = false;
        public bool eco_bound = false;
        public Lifeform boundLifeform;
    }
}
