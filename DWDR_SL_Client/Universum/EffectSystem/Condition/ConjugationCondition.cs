using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWDR_SL_Client.Universum.EffectSystem.Condition
{
    class ConjugationCondition : AbstractedListSubCondition
    {
        public ConjugationCondition(List<AbstractCondition> conditions) : base(conditions, "ConjugationCondition")
        {

        }

        public ConjugationCondition() : base("ConjugationCondition")
        {

        }

        public override bool isMet()
        {
            foreach(AbstractCondition cond in Conditions)
            {
                if(!cond.isMet())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
