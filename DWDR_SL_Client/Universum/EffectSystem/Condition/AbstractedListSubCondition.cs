using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWDR_SL_Client.Universum.EffectSystem.Condition
{
    abstract class AbstractedListSubCondition : AbstractCondition 
    {
        List<AbstractCondition> conditions;
        public List<AbstractCondition> Conditions { get => conditions; set => conditions = value; }

        public AbstractedListSubCondition(List<AbstractCondition> _Conditions, string type, bool inversion) : base(type, inversion)
        {

        }

        public AbstractedListSubCondition(string type, bool inversion) : base(type, inversion)
        {
            conditions = new List<AbstractCondition>();
        }
    }
}
