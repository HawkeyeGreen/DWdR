using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWDR_SL_Client.Organization
{
    public class Vector3D
    {
        public bool isNullvector;
        public float x;
        public float y;
        public float z;

        public Vector3D(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;

            isNullvector = false;
        }

        public Vector3D() 
        {
            isNullvector = true;
            x = 0;
            y = 0;
            z = 0;
        }

        public float length()
        {
            double length = 0;
            length = Math.Sqrt(x * x + y * y + z * z);
            return Convert.ToSingle(length);
        }

        public Vector3D vectorProduct (Vector3D vector)
        {
            return new Vector3D(y * vector.z - z * vector.y, z * vector.x - x * vector.z, x * vector.y - y * vector.x);
        }

        public float scalarProduct (Vector3D vector)
        {
            return x * vector.x + y * vector.y + z * vector.z;
        }

        public Vector3D createVectorBetween (Vector3D vector)
        {
            return new Vector3D(vector.x - x, vector.y - y, vector.z - z);
        }

        public string getStringVersion()
        {
            string Return = "(" + Convert.ToString(x) + "|" + Convert.ToString(y) + "|" + Convert.ToString(z) + ")";
            return Return;
        }

        public void FromString(string str)
        {
            str = str.Replace("(", "");
            str = str.Replace(")", "");
            string[] coord = str.Split('|');
            x = Convert.ToSingle(coord[0]);
            y = Convert.ToSingle(coord[1]);
            z = Convert.ToSingle(coord[2]);
        }

        public void addVector(Vector3D vector) 
        {
            x += vector.x;
            y += vector.y;
            z += vector.z;
        }
    }
}
