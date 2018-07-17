using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWDR_SL_Client.Organization;

namespace DWDR_SL_Client.Universum.EffectSystem.Modifiers
{
    abstract class AbstractModifier : MappedObject
    {
        public AbstractModifier(string ModifierType):base(ModifierType)
        {

        }

        public abstract double useModifier(double baseValue);
    }
}
