using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWDR_SL_Client.Universum.EffectSystem.Condition
{
    abstract class AbstractCondition
    {
        private string type;
        public string Type { get; }

        public AbstractCondition(string type)
        {
            this.type = type;
        }

        abstract public bool isMet();
    }
}
