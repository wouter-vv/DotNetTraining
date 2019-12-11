using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter2
{
    class Strings
    {
        public void Start()
        {
            StringBuilder fullNameBuilder = new StringBuilder();
            fullNameBuilder.Append("test");
            fullNameBuilder.Append(" ");
            fullNameBuilder.Append("testdetest");
            Console.WriteLine(fullNameBuilder.ToString());

            string informalString = "Rob Miles Rob";
            string formalString = informalString.Replace("Rob", "Robert");
            Console.WriteLine(formalString);


            // Default comparison fails because the strings are different
            if (!"encyclopædia".Equals("encyclopaedia"))
                Console.WriteLine("Unicode encyclopaedias are not equal");
            // Set the curent culture for this thread to EN-US
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            // Using the current culture the strings are equal
            if ("encyclopædia".Equals("encyclopaedia", StringComparison.CurrentCulture))
                Console.WriteLine("Culture comparison encyclopaedias are equal");
            // We can use the IgnoreCase option to perform comparisions that ignore case
            if ("encyclopædia".Equals("ENCYCLOPAEDIA", StringComparison.CurrentCultureIgnoreCase))
                Console.WriteLine("Case culture comparison encyclopaedias are equal");
            if (!"encyclopædia".Equals("ENCYCLOPAEDIA", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine("Ordinal comparison encyclopaedias are not equal");


            int i = 99;
            double pi = 3.141592654;

            Console.WriteLine(" {0,-10:D}{0, -10:X}{1,1:N2}", i, pi);
        }
    }
}
