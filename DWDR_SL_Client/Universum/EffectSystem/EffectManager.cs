using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWDR_SL_Client.Universum.EffectSystem
{
    class EffectManager
    {
        List<AbstractEffect> effects;
        Dictionary<string, List<List<Modifiers.AbstractModifier>>> modifiers;

        public double getModifiedValue(string key, double baseValue)
        {
            if(modifiers.ContainsKey(key))
            {
                double final = baseValue;
                double add = 0;

                foreach(Modifiers.AbstractModifier mod in modifiers[key][0])
                {
                    add += mod.useModifier(final);
                }
                final += add;

                add = 0;
                foreach (Modifiers.AbstractModifier mod in modifiers[key][1])
                {
                    add += mod.useModifier(final);
                }
                final += add;

                add = 0;
                foreach (Modifiers.AbstractModifier mod in modifiers[key][2])
                {
                    add += mod.useModifier(baseValue);
                }

                return final;
            }
            return baseValue;
        }
    }
}
