using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpLinearAlgebra
{
    public class VecCollection : ICollection<Vec>
    {
        #region fields
        int _lengthVec = 1;
        bool _locked = false;

        string _lockedMessage = "This collection has been locked and its size can no longer be changed.";
        #endregion fields

        #region properties

        public int LengthVec
        {
            get { return _lengthVec; }
            protected set
            {
                if (value < 1)
                    throw new FormatException("LengthVec must be more or equal to 1.");
                _lengthVec = value;
            }
        }
        protected List<Vec> Collection { get; set; }

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
        #endregion properties

        #region events
        #endregion events

        #region constructors
        public VecCollection(int lengthVec, IEnumerable<Vec> data = null)
        {
            LengthVec = lengthVec;
            Collection = new List<Vec>();

            if(data != null)
            {
                AddRange(data);
            }
        }
        #endregion constructors

        public void Lock()
        {
            _locked = true;
        }


        public void Add(Vec vec)
        {
            if (_locked)
                throw new Exception(_lockedMessage);
            if (vec.Count != LengthVec)
                throw new FormatException("Vector length must equal LengthVec (=" + LengthVec + ")");
            Collection.Add(vec);
        }

        public void AddRange(IEnumerable<Vec> vecs)
        {
            if (_locked)
                throw new Exception(_lockedMessage);
            foreach (var vec in vecs)
            {
                Add(vec);
            }
        }
        public void AddRange(IEnumerable<Vec> vecs, bool ignoreInvalidLength = false)
        {
            if (_locked)
                throw new Exception(_lockedMessage);
            foreach (var vec in vecs)
            {
                if (vec.Count != LengthVec)
                {
                    if (ignoreInvalidLength)
                        continue;
                    else
                        throw new FormatException("Vector length must equal LengthVec (=" + LengthVec + ")");
                }

                Collection.Add(vec);
            }
        }

        public void Clear()
        {
            if (_locked)
                throw new Exception(_lockedMessage);
            Collection.Clear();
        }

        public bool Contains(Vec item)
        {
            return Collection.Contains(item);
        }

        public void CopyTo(Vec[] array, int arrayIndex)
        {
            for (int i = 0; i < Collection.Count; i++)
            {
                array[i + arrayIndex] = Collection[i];
            }
        }

        public int Count
        {
            get { return Collection.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Vec item)
        {
            if (_locked)
                throw new Exception(_lockedMessage);
            return Collection.Remove(item);
        }

        public IEnumerator<Vec> GetEnumerator()
        {
            return Collection.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Collection.GetEnumerator();
        }
    }
}
