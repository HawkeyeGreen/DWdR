using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DWDR_SL_Client.Organization
{

    // VERALTET!
    /*
    class Global_ID_Management
    {

        /// <summary>
        /// Singleton-Pattern
        /// </summary>

        private static Global_ID_Management instance;
        string workingPath = AppDomain.CurrentDomain.BaseDirectory;
        List<List<ID_Entry>> IDs = new List<List<ID_Entry>>();
        List<ID_Group> groups = new List<ID_Group>();
        public long highestRange = 1000;

        private Global_ID_Management()
        {
            if (Directory.Exists(workingPath + "/uni") == false) { Directory.CreateDirectory(workingPath + "/uni"); }
            if (File.Exists(workingPath + "/uni/m.id") == false)
            {
                StreamWriter sw = File.CreateText(workingPath + "/uni/m.id");
                sw.WriteLine("1");
                sw.WriteLine("1000");
                sw.Close();
            }
            if (File.Exists(workingPath + "/uni/0.id") == false)
            {
                StreamWriter sw = File.CreateText(workingPath + "/uni/0.id");
                sw.WriteLine("0");
                sw.Close();
            }
            if (File.Exists(workingPath + "/uni/grp.id") == false)
            {
                StreamWriter sw = File.CreateText(workingPath + "/uni/grp.id");
                sw.WriteLine("1");
                sw.WriteLine();
                sw.WriteLine("system_reserved");
                sw.WriteLine("-2");
                sw.WriteLine("1");
                sw.WriteLine("0");
                sw.WriteLine("1");
                sw.WriteLine("1000");
                sw.Close();
            }


            StreamReader reader = new StreamReader(File.OpenRead(workingPath + "/uni/m.id"));
            int m_count = Convert.ToInt32(reader.ReadLine());
            highestRange = Convert.ToInt64(reader.ReadLine());
            reader.Close();

            reader = new StreamReader(File.OpenRead(workingPath + "/uni/grp.id"));
            int count = Convert.ToInt32(reader.ReadLine());
            reader.ReadLine();
            for (int i = 0; i < count; i++)
            {
                ID_Group idGroup = new ID_Group();
                idGroup.name = Convert.ToString(reader.ReadLine());
                idGroup.lastIDInserted = Convert.ToInt64(reader.ReadLine());
                int segCount = Convert.ToInt32(reader.ReadLine());
                for (int j = 0; j < segCount; j++)
                {
                    idGroup.segments.Add(Convert.ToInt32(reader.ReadLine()));
                }
                for (int j = 0; j < idGroup.segments.Count; j++)
                {
                    List<long> range = new List<long>();
                    range.Add(Convert.ToInt64(reader.ReadLine()));
                    range.Add(Convert.ToInt64(reader.ReadLine()));
                    idGroup.ranges.Add(range);
                    if (range[1] > highestRange) { highestRange = range[1]; }
                }
                groups.Add(idGroup);
            }
            reader.Close();


            for (int i = 0; i < m_count; i++) 
            {
                IDs.Add(new List<ID_Entry>());

                reader = new StreamReader(File.OpenRead(workingPath + "/uni/" + Convert.ToString(i) + ".id"));
                long IDCount = Convert.ToInt64(reader.ReadLine());
                reader.ReadLine();
                for (long j = 0; j < IDCount; j++)
                {
                    ID_Entry entry = new ID_Entry();
                    entry.type = Convert.ToString(reader.ReadLine());
                    entry.id = Convert.ToInt64(reader.ReadLine());
                    IDs[i].Add(entry);
                }
                reader.Close();
            }
        }

        public static Global_ID_Management getInstance()
        {
            if(instance == null)
            {
                Global_ID_Management.instance = new Organization.Global_ID_Management();
            }
            return instance;
        }

        public ID_Entry getTypeOfID(long ID)
        {
            ID_Group group = getGroupForID(0, ID);
            ID_Entry entry = searchForEntryBinary(group.partOfMySegment(ID), ID);
            return entry;
        }

        public ID_Entry insertEntry(string type)
        {
            ID_Group fittingGrp = getGroupByType(0, type);
            ID_Entry newEntry = new ID_Entry();
            newEntry.type = type;


            if (fittingGrp.name != "system_reserved" && fittingGrp.name != "spare_ids")
            {

                long ID = fittingGrp.lastIDInserted + 1;
                newEntry.id = ID;

                if(fittingGrp.placeAvailable(ID))
                {
                    IDs[fittingGrp.partOfMySegment(ID)].Add(newEntry);
                    fittingGrp.insertNewID(ID);
                }
                else
                {
                    //Füge der passenden Gruppe eine neue Range hinzu, oberhalb der highestRange
                    //Oder erhöhe die Range des obersten Segments
                    if(fittingGrp.ranges[fittingGrp.segments.Count -1][1] == highestRange)
                    {
                        fittingGrp.ranges[fittingGrp.segments.Count - 1][1] += 10000;
                        highestRange += 10000;
                        IDs[fittingGrp.partOfMySegment(ID)].Add(newEntry);
                        fittingGrp.insertNewID(ID);
                    }
                    else
                    {
                        long rangeBase = highestRange + 1;
                        long rangeCap = highestRange + 1 + 10000;
                        highestRange = rangeCap;
                        List<long> range = new List<long>();
                        range.Add(rangeBase);
                        range.Add(rangeCap);

                        fittingGrp.segments.Add(IDs.Count);
                        IDs.Add(new List<ID_Entry>());
                        fittingGrp.ranges.Add(range);

                        IDs[fittingGrp.partOfMySegment(ID)].Add(newEntry);
                        fittingGrp.insertNewID(ID);
                    }
                }
            }
            else
            {
                long ID = highestRange + 1;
                newEntry.id = ID;

                fittingGrp = createGroup(type, 10000);
                IDs[fittingGrp.partOfMySegment(ID)].Add(newEntry);
                fittingGrp.insertNewID(ID);
            }
            return newEntry;
        }

        ID_Group getGroupForID(int grp, long ID)
        {
            if(groups[grp].partOfMySegment(ID) != -1)
            {
                return groups[grp];
            }
            else if((grp +1) < groups.Count)
            {
                return getGroupForID(grp + 1, ID);
            }
            else
            {
                ID_Group group = new ID_Group();
                group.name = "spare_ids";
                group.segments.Add(0);
                List<long> range = new List<long>();
                range.Add(0);
                range.Add(1000);
                group.ranges.Add(range);
                return group;
            }
        }

        ID_Group getGroupByType(int grp, string type)
        {
            if (groups[grp].name == type)
            {
                return groups[grp];
            }
            else if ((grp + 1) < groups.Count)
            {
                return getGroupByType(grp + 1, type);
            }
            else
            {
                ID_Group group = new ID_Group();
                group.segments.Add(0);
                List<long> range = new List<long>();
                range.Add(0);
                range.Add(1000);
                group.name = "spare_ids";
                group.ranges.Add(range);
                return group;
            }
        }

        ID_Entry searchForEntryBinary(int segmentToSearch, long lookUp)
        {
            if (segmentToSearch > 0)
            {
                return binary(IDs[segmentToSearch], lookUp);
            }
            else
            {
                ID_Entry entry = new ID_Entry();
                entry.amIActive = false;
                entry.id = 403;
                entry.type = "ID not given/ not found";
                return entry;
            }
        }

        ID_Entry binary(List<ID_Entry> entries, long lookUp)
        {
            if(entries.Count <= 2 && entries.Count > 0)
            {
                if (entries[0].id == lookUp) 
                { 
                    return entries[0]; 
                }
                else 
                { 
                    return entries[1]; 
                }
            }
            else if(entries.Count <= 0)
            {
                ID_Entry emptyEntry = new ID_Entry();
                emptyEntry.amIActive = false;
                emptyEntry.id = 404;
                emptyEntry.type = "not found";
                return emptyEntry;
            }
            else
            {
                int mid = entries.Count / 2 +1;

                if(entries[0].id <= lookUp && entries[mid -1].id >= lookUp)
                {
                    return binary(entries.GetRange(0, mid), lookUp);
                }
                else
                {
                    return binary(entries.GetRange(mid -1, entries.Count - mid +1 ), lookUp);
                }

            }
        }

        public ID_Group createGroup(string grp_Name, long rangeWidth)
        {
            ID_Group newGrp = new ID_Group();

            long rangeBase = highestRange + 1;
            long rangeCap = highestRange + 1 + rangeWidth;
            highestRange = rangeCap;
            List<long> range = new List<long>();
            range.Add(rangeBase);
            range.Add(rangeCap);

            newGrp.name = grp_Name;
            newGrp.segments.Add(IDs.Count);
            IDs.Add(new List<ID_Entry>());
            newGrp.ranges.Add(range);
            newGrp.lastIDInserted = 0;

            groups.Add(newGrp);
            return newGrp;
        }

        public void saveIDDatabank()
        {
            StreamWriter sw = File.CreateText(workingPath + "/uni/m.id");
            sw.WriteLine(Convert.ToString(IDs.Count));
            sw.WriteLine(Convert.ToString(highestRange));
            sw.Close();

            for(int i = 0; i < IDs.Count; i++)
            {
                sw = File.CreateText(workingPath + "/uni/"+ Convert.ToString(i) +".id");
                sw.WriteLine(Convert.ToString(IDs[i].Count));
                sw.WriteLine();
                for(int j = 0; j < IDs[i].Count; j++)
                {
                    sw.WriteLine(Convert.ToString(IDs[i][j].type));
                    sw.WriteLine(Convert.ToString(IDs[i][j].id));
                }
                sw.Close();
            }

            sw = File.CreateText(workingPath + "/uni/grp.id");
            sw.WriteLine(Convert.ToString(groups.Count));
            sw.WriteLine();
            foreach(ID_Group group in groups)
            {
                sw.WriteLine(group.name);
                sw.WriteLine(Convert.ToString(group.lastIDInserted));
                sw.WriteLine(Convert.ToString(group.segments.Count));
                foreach(int seg in group.segments)
                {
                    sw.WriteLine(Convert.ToString(seg));
                }
                foreach(List<long> range in group.ranges)
                {
                    sw.WriteLine(Convert.ToString(range[0]));
                    sw.WriteLine(Convert.ToString(range[1]));
                }
            }
            sw.Close();
        }

        public int getGrpCount() { return groups.Count; }

        public long getEntryCount()
        {
            long counter = 0;
            foreach(List<ID_Entry> seg in IDs)
            {
                counter += Convert.ToInt64(seg.Count);
            }

            return counter;
        }
    }

    class ID_Group
    {
        public long lastIDInserted = -1;
        public string name = "system_reserved";
        public List<int> segments = new List<int>();
        public List<List<long>> ranges = new List<List<long>>();

        public int partOfMySegment(long lookUp)
        {
            return checkSegment(0, lookUp);
        }

        int checkSegment(int segment, long ID)
        {
            if(ranges[segment][0] <= ID && ranges[segment][1] >= ID)
            {
                return segments[segment];
            }
            else if((segment + 1) < segments.Count)
            {
                return checkSegment(segment + 1, ID);
            }
            else
            {
                return -1;
            }
        }

        public bool placeAvailable(long ID)
        {
            int posSegment = checkSegment(0, ID);
            if(posSegment != -1)
            {
                return true;
            }
            else { return false; }
        }

        public void insertNewID(long ID)
        {
            lastIDInserted = ID;
        }


    }

    class ID_Entry
    {
        public long id = -100;
        public string type = "none";
        public bool amIActive = true;
    }
}

    */

}