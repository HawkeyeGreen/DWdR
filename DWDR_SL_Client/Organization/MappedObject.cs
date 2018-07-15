using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zeus.Hermes;

namespace DWDR_SL_Client.Organization
{
    abstract class MappedObject : HermesLoggable
    {

        private string mainType;
        private long id;
        private static long nextID = 0;

        public long ID { get => id; set => id = value; }
        public string MappedType { get => mainType; set => mainType = value; }

        public string Type => MappedType;

        public MappedObject(string myType)
        {
            mainType = myType;
            id = nextID;
            nextID++;

            Hermes.getInstance().log(this, MappedType + " has been created.");
        }
    }
}
