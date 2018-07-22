using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DWDR_SL_Client.Organization;
using System.IO;

namespace DWDR_SL_Client.Universum.EffectSystem.Effects
{
    abstract class AbstractEffect : MappedObject
    {
        private string effectMode = "abstract";
        private List<string> affectedKeys;
        private bool special = false;
        private Dictionary<string, List<List<Modifiers.AbstractModifier>>> modifiers;
        private bool refreshable = true;
        private bool stackable = false;

        public string Mode { get => effectMode; set => effectMode = value; }
        public List<string> AffectedKeys { get => affectedKeys; set => affectedKeys = value; }
        public bool Special { get => special; set => special = value; }
        public bool Refreshable { get => refreshable; set => refreshable = value; }
        public bool Stackable { get => stackable; set => stackable = value; }

        public AbstractEffect(string effectType, Dictionary<string, List<List<Modifiers.AbstractModifier>>> _Modifiers) : base(effectType)
        {
            modifiers = _Modifiers;
            affectedKeys = _Modifiers.Keys.ToList<string>();
        }

        abstract public bool update();

        abstract public bool isAValidTarget(IEffectable target);

        public override void save(StreamWriter writer)
        {
            base.save(writer);
            writer.WriteLine(effectMode);
            foreach(string key in affectedKeys) { writer.WriteLine(key); }
            writer.WriteLine("keys-end");
            writer.WriteLine(Convert.ToString(special));
            writer.WriteLine(Convert.ToString(refreshable));
            writer.WriteLine(Convert.ToString(stackable));

            foreach(string key in affectedKeys) // Entspricht den Keys im Dictionary
            {
                writer.WriteLine(key); // Besprochener Key

                List<Modifiers.AbstractModifier> modifiers_0 = modifiers[key][0]; //mods level 0
                foreach(Modifiers.AbstractModifier mod in modifiers_0) { mod.save(writer); }
                writer.WriteLine("mod-lvl0-end");

                List<Modifiers.AbstractModifier> modifiers_1 = modifiers[key][1]; // mods level 1
                foreach (Modifiers.AbstractModifier mod in modifiers_1) { mod.save(writer); }
                writer.WriteLine("mod-lvl1-end");

                List<Modifiers.AbstractModifier> modifiers_2 = modifiers[key][2]; // mods level 2
                foreach (Modifiers.AbstractModifier mod in modifiers_2) { mod.save(writer); }
                writer.WriteLine("mod-lvl2-end");
            }
            writer.WriteLine("modifiers-end");
        }

        public override void load(StreamReader reader)
        {
            base.load(reader);
            effectMode = Convert.ToString(reader.ReadLine());
            string tmpKey = Convert.ToString(reader.ReadLine());
            while(tmpKey != "keys-end")
            {
                affectedKeys.Add(tmpKey);
                tmpKey = Convert.ToString(reader.ReadLine());
            }

            special = Convert.ToBoolean(reader.ReadLine());
            refreshable = Convert.ToBoolean(reader.ReadLine());
            stackable = Convert.ToBoolean(reader.ReadLine());

            string line = Convert.ToString(reader.ReadLine());
            while(line != "modifiers-end")
            {
                List<List<Modifiers.AbstractModifier>> _Modifiers = new List<List<Modifiers.AbstractModifier>>();
                List<Modifiers.AbstractModifier> mod0 = new List<Modifiers.AbstractModifier>();
                List<Modifiers.AbstractModifier> mod1 = new List<Modifiers.AbstractModifier>();
                List<Modifiers.AbstractModifier> mod2 = new List<Modifiers.AbstractModifier>();


                string key = line;
                
                string mod_0 = Convert.ToString(reader.ReadLine());
                while(mod_0 != "mod-lvl0-end")
                {
                    switch (mod_0)
                    {
                        case "Additiv":
                            Modifiers.Additiv additiv = new Modifiers.Additiv("", 0);
                            additiv.load(reader);
                            mod0.Add(additiv);
                            break;
                    }
                    mod_0 = Convert.ToString(reader.ReadLine());
                }

                string mod_1 = Convert.ToString(reader.ReadLine());
                while (mod_1 != "mod-lvl1-end")
                {
                    switch (mod_1)
                    {
                        case "Additiv":
                            Modifiers.Additiv additiv = new Modifiers.Additiv("", 0);
                            additiv.load(reader);
                            mod1.Add(additiv);
                            break;
                    }
                    mod_1 = Convert.ToString(reader.ReadLine());
                }

                string mod_2 = Convert.ToString(reader.ReadLine());
                while (mod_2 != "mod-lvl2-end")
                {
                    switch (mod_2)
                    {
                        case "Additiv":
                            Modifiers.Additiv additiv = new Modifiers.Additiv("", 0);
                            additiv.load(reader);
                            mod2.Add(additiv);
                            break;
                    }
                    mod_2 = Convert.ToString(reader.ReadLine());
                }

                line = Convert.ToString(reader.ReadLine());
            }
        }

        public List<List<Modifiers.AbstractModifier>> addModifiers(string key, List<List<Modifiers.AbstractModifier>> currentMods)
        {
            List<List<Modifiers.AbstractModifier>> myMods = modifiers[key];
            currentMods[0].AddRange(myMods[0]);
            currentMods[1].AddRange(myMods[1]);
            currentMods[2].AddRange(myMods[2]);
            return currentMods;
        }
    }
}
