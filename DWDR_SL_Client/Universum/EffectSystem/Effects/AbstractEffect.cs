using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWDR_SL_Client.Organization;

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
        }

        abstract public bool update();

        abstract public bool isAValidTarget(IEffectable target);

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
