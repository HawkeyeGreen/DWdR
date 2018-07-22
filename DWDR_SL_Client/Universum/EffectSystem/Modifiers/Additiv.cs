using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWDR_SL_Client.Universum.EffectSystem.Modifiers
{
    class Additiv : AbstractModifier
    {
        private double value = 0;

        public double Value => value;

        public Additiv(string ModifierType, double value) : base(ModifierType)
        {
            this.value = value;
        }

        public override double useModifier(double baseValue) => Value;

        public override void save(StreamWriter writer)
        {
            writer.WriteLine("Additiv");
            base.save(writer);
            writer.WriteLine(Convert.ToString(value));
        }

        public override void load(StreamReader reader)
        {
            base.load(reader);
            value = Convert.ToDouble(reader.ReadLine());
        }
    }
}
