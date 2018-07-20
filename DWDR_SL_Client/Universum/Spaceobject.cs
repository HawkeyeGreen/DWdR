﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DWDR_SL_Client.Organization;
using DWDR_SL_Client.Universum.EffectSystem;

/************************ Konzept ************************
 * Spaceobjects enthalten alle nötigen Informationen, um das enthaltene Objekt
 * über die Universums-Klasse zu laden. Dadurch können deutlich kompaktere Klassen
 * vorgehalten werden an Stelle großer, komplexerer Klassen.
 * Ein SpaceObject kann für ALLES stehen d.h. Raumschiffe, Sonnensysteme, Planeten, Sonnen, Asteroiden usw.
 ************************ Konzept ************************/

namespace DWDR_SL_Client.Universum
{
    // Veraltet
    //class Spaceobject
    //{
    //    public Vector3D position;
    //    public string plane = "main";

    //    StringedReference reference;
    //    string type;
    //    string path;

    //    public Spaceobject(Vector3D Position, string _Type, long _Id, string _name, List<string> tags, string _Path)
    //    {
    //        position = Position;
    //        plane = "main";
    //        type = _Type;
    //        reference = new StringedReference();
    //        reference.construct(_name, _Id);

    //        path = _Path;
    //    }

    //    public string getType() { return type; }
    //    public string getPath() { return path; }
    //}

    // Als Interface bedeutend besser ^-^

    abstract class GenericSpaceObject : MappedObject, ISpaceObject, IEffectable
    {
        private IEffectable parent;

        private Vector3D position;
        private Vector3D trajectory;

        private string path;
        private string planeOfExistence;

        private EffectManager effectManager;

        private List<string> resistances;
        private List<string> affectable;


        #region Fields
        public Vector3D Position { get => position; set => position = value; }
        public string Plane { get => planeOfExistence; set => planeOfExistence = value; }
        public string Path { get => path; set => path = value; }
        public EffectManager EffectManager { get; }
        public List<string> Resistances => resistances;
        public List<string> Affectable => affectable;
        public string Type { get => MappedType; set => MappedType = value; }
        public IEffectable Parent { get => parent; set => parent = value; }
        #endregion

        public GenericSpaceObject(string myType, Vector3D position, string path) : base(myType)
        {
            this.position = position;
            this.path = path;

            trajectory = new Vector3D();
            planeOfExistence = "main";

            effectManager = new EffectManager(this);

            resistances = new List<string>();
            affectable = new List<string>
            {
                "GameMaster"
            };
        }

        public void Move()
        {
            position += trajectory;
        }

        public abstract List<IEffectable> getAllEffectables();
        public abstract List<IEffectable> getEffectablesByKey(string affectionKey);
        public abstract List<IEffectable> getEffectablesByKeyTable(Tuple<List<string>, List<string>> table);
    }

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
