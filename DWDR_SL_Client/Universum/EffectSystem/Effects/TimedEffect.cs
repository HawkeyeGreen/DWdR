using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


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

        public TimedEffect() : base("TimedEffec")
        {
           
        }

        public override bool isAValidTarget(IEffectable target)
        {
            return targetCondition.isMet();
        }

        public override void load(StreamReader reader)
        {
            base.load(reader);
            Tuple<long, string> _Target = new Tuple<long, string>(Convert.ToInt64(reader.ReadLine()), Convert.ToString(reader.ReadLine()));
            lastRound = Convert.ToInt32(reader.ReadLine());
            threshold = Convert.ToInt32(reader.ReadLine());
            rounds = Convert.ToInt32(reader.ReadLine());
        }

        public override void save(StreamWriter writer)
        {
            writer.WriteLine("TimedEffect");
            base.save(writer);
            writer.WriteLine(Convert.ToString(target.ID));
            writer.WriteLine(Convert.ToString(target.Type));
            writer.WriteLine(Convert.ToString(lastRound));
            writer.WriteLine(Convert.ToString(threshold));
            writer.WriteLine(Convert.ToString(rounds));
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
