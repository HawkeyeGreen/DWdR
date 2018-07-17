using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWDR_SL_Client.Organization;

namespace DWDR_SL_Client.Universum.EffectSystem
{
    abstract class AbstractEffect : MappedObject
    {
        private string effectMode = "abstract";
        private List<string> targets;

        public string Mode { get => effectMode; set => effectMode = value; }
        public List<string> Targets { get => targets; set => targets = value; }

        public AbstractEffect(string effectType) : base(effectType)
        {

        }

        public bool isAValidTarget(string target) { return targets.Contains(target); }
    }
}
