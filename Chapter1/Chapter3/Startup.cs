﻿using Chapter3;
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

            CreateJSON cj = new CreateJSON();

            KeyStorage ks = new KeyStorage();
            ks.GetKeysUser();
            ks.GetKeysMachine();

        }
    }
}
