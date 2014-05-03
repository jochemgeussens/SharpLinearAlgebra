using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpLinearAlgebra
{
    public class Vec2 : EqualityComparer<Vec2>
    {
        #region fields
        #endregion fields

        #region properties
        public float X { get; set; }
        public float Y { get; set; }

        #endregion properties

        #region events
        #endregion events

        #region constructors
        public Vec2()
        {

        }
        public Vec2(float x, float y)
        {
            X = x;
            Y = y;
        }
        public Vec2(float defaultVal)
            :this(defaultVal,defaultVal)
        {

        }
        #endregion constructors

        public override bool Equals(Vec2 x, Vec2 y)
        {
            return x.X == y.X && x.Y == y.Y;
        }

        public override int GetHashCode(Vec2 obj)
        {
            throw new NotImplementedException();
        }
    }
}
