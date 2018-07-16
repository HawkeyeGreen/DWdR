using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWDR_SL_Client.Universum.EffectSystem
{
    /*  ModifierEnvelop
     *  Diese Klasse stellt Mittel zu korrekten Verrechnung von EffectModifiern bereit.
     *  
     *  Wichtige Funktionen:
     *  void Collect(Modifier mod)
     *  int Release(double value)
     */

    //public class ModifierEnvelope
    //{
    //    public bool amINeutral = false; //Kann gesetzt werden, wenn ein Effekt keine Wirkung mehr haben soll, weil er inaktiv geworden ist
    //    public int roundsGone = 0;

    //    double add_1 = 0;
    //    double add_2 = 0;
    //    double add_3 = 0;

    //    double mult_1 = 1;
    //    double mult_2 = 1;

    //    public void Collect(Modifier mod)
    //    {
    //        if(mod.type == "Additiv I ")
    //        {
    //            add_1 += mod.conglomerateModifier(roundsGone);
    //        }
    //        else if (mod.type == "Multiplikativ I")
    //        {
    //            mult_1 *= mod.conglomerateModifier(roundsGone);
    //        }
    //        else if (mod.type == "Additiv II")
    //        {
    //            add_2 += mod.conglomerateModifier(roundsGone);
    //        }
    //        else if (mod.type == "Multiplikativ II")
    //        {
    //            mult_2 *= mod.conglomerateModifier(roundsGone);
    //        }
    //        else if (mod.type == "Additiv III")
    //        {
    //            add_3 += mod.conglomerateModifier(roundsGone);
    //        }
    //    }

    //    public double Release(double value)
    //    {
    //        return ((((value + add_1) * mult_1) + add_2) * mult_2) + add_3;
    //    }
    //}

}
