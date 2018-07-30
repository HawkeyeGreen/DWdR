using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWDR_SL_Client.Universum.EffectSystem.Condition
{
    class ORCondition : AbstractDualSubCondition
    {
        public ORCondition(AbstractCondition cond0, AbstractCondition cond1, bool inversion = false) : base(cond0, cond1, "ORCondition", inversion)
        {

        }

        public ORCondition(bool inversion = false) : base("ORCondition", inversion)
        {

        }


        public override bool isMet()
        {
            if(Condition0.isMet())
            {
                return Inversion ^ true;
            }

            if (Condition1.isMet())
            {
                return Inversion ^ true;
            }

            return Inversion ^ false;
        }
    }
}
