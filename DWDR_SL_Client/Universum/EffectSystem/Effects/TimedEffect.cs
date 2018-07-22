using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWDR_SL_Client.Universum.EffectSystem.Effects
{
    // Ein Effekt, der zu Beginn seine Bedingung erfüllen muss
    // Ab dann läuft nur noch ein Zähler herunter
    class TimedEffect : AbstractEffect
    {
        private IEffectable target;
        private int rounds;
        private int lastRound;
        private int threshold;
       
        private Condition.AbstractCondition targetCondition;

        public TimedEffect (IEffectable setTarget, int th, Dictionary<string, List<List<Modifiers.AbstractModifier>>> modifiers, Condition.AbstractCondition cond, bool refresh = true, bool stack = false) :base("TimedEffect", modifiers)
        {
            target = setTarget;
            threshold = th;
            targetCondition = cond;

            lastRound = Organization.Round.currentRound;
        }

        public override bool isAValidTarget(IEffectable target)
        {
            return targetCondition.isMet();
        }

        public override bool update()
        {
           if(lastRound < Organization.Round.currentRound)
            {
                rounds++;
                lastRound = Organization.Round.currentRound;
            }
           if(rounds >= threshold)
            {
                return false;
            }
            return true;
        }
    }
}
