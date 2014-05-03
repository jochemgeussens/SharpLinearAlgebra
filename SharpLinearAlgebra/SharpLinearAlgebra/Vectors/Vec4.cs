using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpLinearAlgebra
{
    public class Vec4 : Vec
    {
        #region fields
        #endregion fields

        #region properties
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float W { get; set; }

        #endregion properties

        #region events
        #endregion events

        #region constructors
        public Vec4()
            :base(4)
        { }
        public Vec4(float x, float y, float z, float w)
            :this()
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
        public Vec4(float defaultVal)
            :this(defaultVal,defaultVal,defaultVal,defaultVal)
        {

        }
        public Vec4(Vec3 xyz, float w = 0)
            : this(xyz.X, xyz.Y, xyz.Z, w)
        {

        }
        public Vec4(Vec2 xy, float z = 0, float w = 0)
            : this(xy.X, xy.Y, z, w)
        {
        }
        #endregion constructors


    }
}
