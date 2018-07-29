using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWDR_SL_Client.Universum.EffectSystem.Condition
{
    class ANDCondition : AbstractDualSubCondition
    {
        public ANDCondition(AbstractCondition cond0, AbstractCondition cond1) : base(cond0, cond1, "ANDCondition")
        {
        }

        public ANDCondition() : base("ANDCondition")
        {
        }

        public override bool isMet()
        {
            if(Condition0.isMet())
            {
                if(Condition1.isMet())
                {
                    return true;
                }
            }
            return false;
        }


    }
}
