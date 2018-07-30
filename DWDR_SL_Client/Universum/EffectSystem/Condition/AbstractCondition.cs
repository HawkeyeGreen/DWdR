using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWDR_SL_Client.Universum.EffectSystem.Condition
{
    abstract class AbstractCondition
    {
        private bool inverted = false;
        private string type;

        public string Type { get => type; set => type = value; }
        public bool Inversion { get => inverted; set => inverted = value; }

        public AbstractCondition(string type, bool inverted)
        {
            this.type = type;
            this.inverted = inverted;
        }

        abstract public bool isMet();
    }
}
