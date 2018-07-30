using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWDR_SL_Client.Universum.EffectSystem.Condition
{
    class ConjugationCondition : AbstractedListSubCondition
    {
        public ConjugationCondition(List<AbstractCondition> conditions, bool inversion = false) : base(conditions, "ConjugationCondition", inversion)
        {

        }

        public ConjugationCondition(bool inversion = false) : base("ConjugationCondition", inversion)
        {

        }

        public override bool isMet()
        {
            foreach(AbstractCondition cond in Conditions)
            {
                if(!cond.isMet())
                {
                    return Inversion ^ false;
                }
            }

            return Inversion ^ true;
        }
    }
}
