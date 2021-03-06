﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWDR_SL_Client.Organization;

/************************ Konzept ************************
 * Spaceobjects enthalten alle nötigen Informationen, um das enthaltene Objekt
 * über die Universums-Klasse zu laden. Dadurch können deutlich kompaktere Klassen
 * vorgehalten werden an Stelle großer, komplexerer Klassen.
 * Ein SpaceObject kann für ALLES stehen d.h. Raumschiffe, Sonnensysteme, Planeten, Sonnen, Asteroiden usw.
 ************************ Konzept ************************/

namespace DWDR_SL_Client.Universum
{
    // Veraltet
    class Spaceobject
    {
        public Vector3D position;
        public string plane = "main";

        StringedReference reference;
        string type;
        string path;

        public Spaceobject(Vector3D Position, string _Type, long _Id, string _name, List<string> tags, string _Path)
        {
            position = Position;
            plane = "main";
            type = _Type;
            reference = new StringedReference();
            reference.construct(_name, _Id);

            path = _Path;
        }

        public string getType() { return type; }
        public string getPath() { return path; }
    }

    // Als Interface bedeutend besser ^-^
    interface ISpaceObject
    {
        // Muss Vektor für Position enthalten
        // Muss Pfad zum "echten" Objekt enthalten
        // Muss einen type haben
        // Muss einer plane zu geordnet sein
        
        Vector3D Position
        {
            get;
            set;
        }

        string Plane
        {
            get;
            set;
        }

        string Type
        {
            get;
            set;
        }

        string Path
        {
            get;
            set;
        }

        long ID
        {
            get;
            set;
        }
    }
}
