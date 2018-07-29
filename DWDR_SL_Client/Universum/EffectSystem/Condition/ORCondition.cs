using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWDR_SL_Client.Universum.EffectSystem.Condition
{
    class ORCondition : AbstractDualSubCondition
    {
        public ORCondition(AbstractCondition cond0, AbstractCondition cond1) : base(cond0, cond1, "ORCondition")
        {

        }

        public ORCondition() : base("ORCondition")
        {

        }


        public override bool isMet()
        {
            if(Condition0.isMet())
            {
                return true;
            }

            if (Condition1.isMet())
            {
                return true;
            }

            return false;
        }
    }
}
