using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Zeus.Hermes;

namespace DWDR_SL_Client.Organization
{
    abstract class MappedObject : HermesLoggable
    {

        private string mainType;
        private long id;

        public long ID { get => id; set => id = value; }
        public string MappedType { get => mainType; set => mainType = value; }
        public string Type => MappedType;

        public MappedObject(string myType, long id = long.MinValue)
        {
            mainType = myType;
            if(id == long.MinValue)
            {
                ID = GIDM.getInstance().register(this);
            }
            else
            {
                ID = id;
                GIDM.getInstance().login(ID, this);
            }
            Hermes.getInstance().log(this, MappedType + " has been created.");
        }

        public virtual void save(StreamWriter writer)
        {
            writer.WriteLine(Convert.ToString(ID));
            writer.WriteLine(MappedType);
        }

        public virtual void load(StreamReader reader)
        {
            GIDM.getInstance().unregister(ID);

            ID = Convert.ToInt64(reader.ReadLine());

            GIDM.getInstance().login(ID, this);
            Hermes.getInstance().log(this, " wurde auf alte ID gesetzt.");

            MappedType = Convert.ToString(reader.ReadLine());
        }
    }
}
