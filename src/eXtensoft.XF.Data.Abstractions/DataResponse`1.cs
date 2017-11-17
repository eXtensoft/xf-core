using eXtensoft.XF.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace eXtensoft.XF.Data.Abstractions
{
    public class DataResponse<T> : IResponse<T> where T : class, new()
    {
        private List<T> _Items = new List<T>();
        public List<T> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }

        public T Model
        {
            get { return _Items.Count > 0 ? _Items[0] : default(T); }
        }

        private bool _IsOkay;
        bool IResponse<T>.IsOkay { get { return _IsOkay; } }

        private IStatus _Status;
        IStatus IResponse<T>.Status { get { return _Status; } }

        int IResponse<T>.Count { get { return Items.Count; } }

        private int _Elapsed;
        long IResponse<T>.Elapsed { get { return _Elapsed; } }
        T IResponse<T>.Model
        {
            get { return _Items.Count > 0 ? _Items[0] : default(T); }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)_Items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)_Items).GetEnumerator();
        }
    }
}
