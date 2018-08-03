using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWDR_SL_Client.Universum.EffectSystem.Condition
{
    abstract class AbstractDualSubCondition : AbstractCondition
    {
        AbstractCondition condition_0;
        AbstractCondition condition_1;

        public AbstractCondition Condition0 { get => condition_0; set => condition_0 = value; }
        public AbstractCondition Condition1 { get => condition_1; set => condition_1 = value; }

        public AbstractDualSubCondition(AbstractCondition cond0, AbstractCondition cond1, string type, bool inversion) : base(type, inversion)
        {
            condition_0 = cond0;
            condition_1 = cond1;
        }

        public AbstractDualSubCondition(string type, bool inversion) : base(type, inversion)
        {

        }

        public void replaceCondition0(AbstractCondition cond0) => condition_0 = cond0;

        public void replaceCondition1(AbstractCondition cond1) => condition_1 = cond1;

        public override void setTarget(long ID, string type)
        {
            condition_0.setTarget(ID, type);
            condition_1.setTarget(ID, type);
        }
    }
}
