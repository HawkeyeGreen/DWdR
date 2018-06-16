using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWDR_SL_Client.Organization;

namespace DWDR_SL_Client.Universum.Planets
{
    /* Klasse: Region
     * Eine Region ist ein Gebiet, dass zu einem Relief und einer Klimazone gehört.
     * Es wird dann weiter nur durch sein Ökosystem definiert.
     */
    abstract class Region
    {
        private string region_name = "Walhalla";
        public string Name
        {
            get => region_name;
            set => region_name = value;
        }

        private int size = 1000;
        public int Size
        {
            get => size;
            set => size = value;
        }

        private Relief relief;
        public Relief Relief
        {
            get => relief;
            set => relief = value;
        }

        private Climate climate;
        public Climate Climate
        {
            get => Climate;
            set => Climate = value;
        }

        public Temperature AverageTemperature
        {
            get => Climate.AverageTemperature;
        }
    }
}
