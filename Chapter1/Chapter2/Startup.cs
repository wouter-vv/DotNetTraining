using Chapter2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    class Startup
    {
        static void Main(string[] args)
        {

            SmallTests st = new SmallTests();
            st.StructVsEnum();

            NewStruct ns = new NewStruct();
            ns.create();

        }
    }
}
