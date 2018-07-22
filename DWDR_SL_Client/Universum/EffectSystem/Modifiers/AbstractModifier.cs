using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using DWDR_SL_Client.Organization;

namespace DWDR_SL_Client.Universum.EffectSystem.Modifiers
{
    abstract class AbstractModifier : MappedObject
    {

        public AbstractModifier(string ModifierType):base(ModifierType)
        {

        }

        public abstract double useModifier(double baseValue);

        public override void save(StreamWriter writer)
        {
            base.save(writer);
        }

        public override void load(StreamReader reader)
        {
            
        }
    }
}
