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
        Dictionary<string, List<Modifiers.AbstractModifier>> modifiers;
    }
}
