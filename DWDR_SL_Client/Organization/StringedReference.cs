using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWDR_SL_Client.Organization
{
    class StringedReference
    {
        public bool active = false;
        public string name;
        public List<string> taggedWith;
        public long boundID;

        public void construct(string Name, long ID)
        {
            active = true;
            taggedWith = new List<string>();

            name = Name;
            boundID = ID;
        }

        public void tagWith(List<string> tags) { taggedWith = tags; }
        public void addTag(string Tag) { taggedWith.Add(Tag); }
        public bool isTaggedWith(string Tag){ return taggedWith.Contains(Tag); }
        public bool removeTag(string Tag)
        {
            if(isTaggedWith(Tag))
            {
                taggedWith.Remove(Tag);
                return true;
            }
            return false;
        }
    }
}
