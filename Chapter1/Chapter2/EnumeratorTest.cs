using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{
    class EnumeratorTest : IEnumerator<int>, IEnumerable
    {

        int count;
        int limit;

        public int Current
        {
            get
            {
                return count;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return count;
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (++count == limit)
                return false;
            else
                return true;
        }

        public void Reset()
        {
            count = 0;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public EnumeratorTest(int limit)
        {
            count = 0;
            this.limit = limit;
        }

    }
}
