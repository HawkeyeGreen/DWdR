using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWDR_SL_Client.Organization;

namespace DWDR_SL_Client.Universum.Planets
{
    class Climate
    {
        private Temperature averageTemperature = new Temperature(20, "Celsius");
        public Temperature AverageTemperature
        {
            get => averageTemperature;
            set => averageTemperature = value;
        }
    }
}
