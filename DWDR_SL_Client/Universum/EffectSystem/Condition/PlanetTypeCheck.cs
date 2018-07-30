using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWDR_SL_Client.Universum.EffectSystem.Condition
{
    class PlanetTypeCheck : AbstractCondition
    {
        private Planet target;
        private string expectedType;

        public PlanetTypeCheck(Planet planet, string type, bool inversion = false) : base("PlanetTypeCheck", inversion)
        {
            target = planet;
            expectedType = type;
        }

        public override bool isMet()
        {
            if (target.PlanetType == expectedType) { return Inversion ^ true; }
            return Inversion ^ false;
        }
    }
}
