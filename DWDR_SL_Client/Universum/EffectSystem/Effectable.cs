using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWDR_SL_Client.Universum.EffectSystem
{
    interface IEffectable
    {
        List<IEffectable> Parents { get; }
        List<IEffectable> Children { get; }
        List<string> Resistances { get; }
        List<string> Affectable { get; }
        string Type { get; }
    }
}
