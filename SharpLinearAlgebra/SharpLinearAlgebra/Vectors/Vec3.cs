using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpLinearAlgebra
{
    public class Vec3 : IEqualityComparer<Vec3>
    {
        #region fields
        #endregion fields

        #region properties
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        #endregion properties

        #region events
        #endregion events

        #region constructors
        public Vec3()
        {

        }
        public Vec3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Vec3(float defaultVal)
            :this(defaultVal,defaultVal,defaultVal)
        {

        }
        public Vec3(Vec2 xy, float z = 0)
            :this(xy.X, xy.Y, z)
        {

        }
        #endregion constructors

        public bool Equals(Vec3 x, Vec3 y)
        {
            return x.X == y.X && x.Y == y.Y && x.Z == y.Z;
        }

        public int GetHashCode(Vec3 obj)
        {
            throw new NotImplementedException();
        }
    }
}
