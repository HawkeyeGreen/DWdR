using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWDR_SL_Client.Universum.EffectSystem;
using DWDR_SL_Client.Organization;

namespace DWDR_SL_Client.Universum
{
    class Plane : MappedObject, IEffectable
    {
        private EffectManager effectManager;
        private List<string> resistance;
        private List<string> affectables;
        private IEffectable parent;

        public EffectManager EffectManager => effectManager;
        public List<string> Resistances => resistance;
        public List<string> Affectable => affectables;
        public string Type => MappedType;
        public IEffectable Parent => parent;

        public Plane() : base("PlaneOfExistence")
        {
            effectManager = new EffectManager(this);
            parent = Universe.getInstance();

            resistance = new List<string>();
            affectables = new List<string>()
            {
                "Plane"
            };
        }

        public List<IEffectable> getAllEffectables()
        {
            throw new NotImplementedException();
        }
        public List<IEffectable> getEffectablesByKey(string affectionKey)
        {
            throw new NotImplementedException();
        }
        public List<IEffectable> getEffectablesByKeyTable(Tuple<List<string>, List<string>> table)
        {
            throw new NotImplementedException();
        }
    }
}
