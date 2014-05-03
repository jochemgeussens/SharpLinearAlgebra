using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpLinearAlgebra
{
    public class Mat
    {
        #region fields
        VecCollection _collection;
        MatSize _size;
        #endregion fields

        #region properties
        public Vec this[int i]
        {
            get
            {
                return Collection[i];
            }
            set
            {
                Collection[i] = value;
            }

        }

        public MatSize Size
        {
            get { return _size; }
            protected set { _size = value; }
        }
        public virtual VecCollection Collection
        {
            get { return _collection; }
            set 
            {
                if (value != null && value.Count == Size.RowCount && value.LengthVec == Size.ColumnCount)
                {
                    _collection = value;
                    _collection.Lock();
                    Size = new MatSize(_collection);
                }
                else
                {
                    throw new FormatException("The new collection must have the same format as the original one.");
                }
            }
        }

        #endregion properties

        #region constructors
        public Mat(int rowCount, int colCount)
        {
            var collection = new VecCollection(colCount);
            for (int i = 0; i < rowCount; i++)
            {
                collection.Add(new Vec(colCount));
            }

            Size = new MatSize(collection);

            Collection = collection;
        }
        public Mat(int diagonalSize)
            :this(diagonalSize, diagonalSize)
        { }
        public Mat(VecCollection collection)
        {
            if (collection == null || collection.Count < 1)
                throw new ArgumentNullException("Collection cannot be null or empty.");

            Size = new MatSize(collection);

            Collection = collection;
        }

        public static Mat Identity(int size)
        {
            if(size <= 0)
                throw new IndexOutOfRangeException("Size should be more or equal to 1.");

            var mat = new Mat(size);

            for (int i = 0; i < size; i++)
            {
                mat[i][i] = 1;
            }

            return mat;
        }
        #endregion constructors



        #region equality
        public static bool operator ==(Mat m1, Mat m2)
        {
            if (m1.Size != m2.Size)
                return false;

            for (int i = 0; i < m1.Size.RowCount; i++)
            {
                if (m1[i] != m2[i])
                    return false;
            }

            return true;
        }
        public static bool operator !=(Mat m1, Mat m2)
        {
            return !(m1 == m2);
        }

        public override bool Equals(object obj)
        {
            return this == obj as Mat;
        }
        #endregion equality

        /// <summary>
        /// Before: ----------- After:<para/>
        /// |1 - 2 - 3 - 4 | ----- |1 - 5 - 9 - 13|<para/>
        /// |5 - 6 - 7 - 8 | ----- |2 - 6 - 10- 14|<para/>
        /// |9 - 10- 11- 12| ---- |3 - 7 - 11- 15|<para/>
        /// |13- 14- 15- 16| ---- |4 - 8 - 12- 16|<para/>
        /// </summary>
        /// <returns></returns>
        public Mat SwapColumnsAndRows()
        {
            var newVecCol = new VecCollection(Size.RowCount,
                new Vec[]
                {
                    new Vec(Size.ColumnCount),
                    new Vec(Size.ColumnCount),
                    new Vec(Size.ColumnCount),
                    new Vec(Size.ColumnCount),
                });

            for (int i = 0; i < Size.RowCount; i++)
            {
                for (int j = 0; j < Size.ColumnCount; j++)
                {
                    newVecCol[j][i] = Collection[i][j];
                }
            }

            return new Mat(newVecCol);
        }

        #region math overloads
        public static Mat operator +(Mat m1, Mat m2)
        {
            if (m1.Size != m2.Size)
                throw new OverflowException("Can't increment 2 different sized matrices.");

            var resCollection = new VecCollection(m1.Size.ColumnCount);
            for (int i = 0; i < m1.Size.RowCount; i++)
            {
                var vec = new Vec(m1.Size.ColumnCount);
                for (int j = 0; j < m1.Size.ColumnCount; j++)
                {
                    vec[j] = m1[i][j] + m2[i][j];
                }
                resCollection.Add(vec);
            }

            return new Mat(resCollection);
        }
        public static Mat operator -(Mat m1, Mat m2)
        {
            if (m1.Size != m2.Size)
                throw new OverflowException("Can't increment 2 different sized matrices.");

            var resCollection = new VecCollection(m1.Size.ColumnCount);
            for (int i = 0; i < m1.Size.RowCount; i++)
            {
                var vec = new Vec(m1.Size.ColumnCount);
                for (int j = 0; j < m1.Size.ColumnCount; j++)
                {
                    vec[j] = m1[i][j] +- m2[i][j];
                }
                resCollection.Add(vec);
            }

            return new Mat(resCollection);
        }
        public static Mat operator *(Mat m1, Mat m2)
        {
            throw new NotImplementedException();
        }
        public static Mat operator *(Mat m1, Vec v)
        {
            throw new NotImplementedException();
        }
        #endregion math overloads

    }
}
