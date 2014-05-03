using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpLinearAlgebra
{
    public class MatSize
    {
        public int RowCount { get; private set; }
        public int ColumnCount { get; private set; }

        public MatSize()
        {

        }

        public MatSize(VecCollection mat)
        {
            RowCount = mat.Count;
            ColumnCount = mat.LengthVec;
        }

        public MatSize(int rowCount, int colCount)
        {
            RowCount = rowCount;
            ColumnCount = colCount;
        }


        #region equality
        public static bool operator ==(MatSize ms1, MatSize ms2)
        {
            return ms1.ColumnCount == ms2.ColumnCount && ms1.RowCount == ms2.RowCount;
        }
        public static bool operator !=(MatSize v1, MatSize v2)
        {
            return !(v1 == v2);
        }

        public override bool Equals(object obj)
        {
            return this == obj as MatSize;
        }
        #endregion equality

    }
}
