using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpLinearAlgebra
{
    public class Vec
    {
        #region fields
        #endregion fields

        #region properties
        public float this[int i]
        {
            get
            {
                return Array[i];
            }
            set
            {
                Array[i] = value;
            }

        }
        public int Count { get { return Array.Length; } }
        public float[] Array { get; protected set; }
        #endregion properties

        #region events
        #endregion events

        #region constructors
        public Vec(int count)
        {
            Array = new float[count];
        }
        public Vec(float[] array)
        {
            if (array == null || !array.Any())
                throw new ArgumentNullException("Array cannot be null or empty.");

            Array = array;
        }
        #endregion constructors



        #region equality
        public static bool operator ==(Vec v1, Vec v2)
        {
            if (v1.Count != v2.Count)
                return false;

            for (int i = 0; i < v1.Count; i++)
            {
                if (v1[i] != v2[i])
                    return false;
            }

            return true;
        }
        public static bool operator !=(Vec v1, Vec v2)
        {
            return !(v1 == v2);
        }

        public override bool Equals(object obj)
        {
            return this == obj as Vec;
        }
        #endregion equality




        #region math overloads
        public static Vec operator +(Vec v1, Vec v2)
        {
            if (v1.Count != v2.Count)
                throw new OverflowException("Can't increment 2 different sized vectors.");

            var res = new Vec(v1.Count);
            for (int i = 0; i < res.Count; i++)
            {
                res[i] = v1[i] + v2[i];
            }

            return res;
        }
        public static Vec operator -(Vec v1, Vec v2)
        {
            if (v1.Count != v2.Count)
                throw new OverflowException("Can't substract 2 different sized vectors.");

            var res = new Vec(v1.Count);
            for (int i = 0; i < res.Count; i++)
            {
                res[i] = v1[i] - v2[i];
            }

            return res;
        }

        #endregion math overloads
        /// <summary>
        /// Multiply as 1 x L * L x 1, resulting in a single (1x1) value.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public float MultiplyToSingle(Vec4 v2)
        {
            var sum = 0f;

            for (int i = 0; i < Count; i++)
            {
                sum += this[i] * v2[i];
            }

            return sum;
        }
        /// <summary>
        /// Multiplies as L x 1 * 1 x L, resulting in a L x L matrix.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public Mat MultiplyToMat(Vec v2)
        {
            throw new NotImplementedException("");
            //return new Vec(v1.X * v2.X, v1.Y * v2.Y, v1.Z + v2.Z, v1.W * v2.W);
        }

    }
}
