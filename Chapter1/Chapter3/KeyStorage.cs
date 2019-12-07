using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    class KeyStorage
    {
        public void GetKeysUser()
        {
            string containerName = "MyKeyStore";

            CspParameters csp = new CspParameters();
            csp.KeyContainerName = containerName;

            // Create a new RSA to encrypt the data
            RSACryptoServiceProvider rsaStore = new RSACryptoServiceProvider(csp);
            Console.WriteLine("Stored keys: {0}",
                               rsaStore.ToXmlString(includePrivateParameters: true));

            RSACryptoServiceProvider rsaLoad = new RSACryptoServiceProvider(csp);
            Console.WriteLine("Loaded keys: {0}",
                               rsaLoad.ToXmlString(includePrivateParameters: true));

            Console.ReadKey();
        }

        public void GetKeysMachine()
        {
            CspParameters cspParams = new CspParameters();
            cspParams.KeyContainerName = "Machine Level Key";

            // Specify that the key is to be stored in the machine level key store
            cspParams.Flags = CspProviderFlags.UseMachineKeyStore;

            // Create a crypto service provider
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspParams);

            Console.WriteLine(rsa.ToXmlString(includePrivateParameters: false));

            // Make sure that it is persisting keys
            rsa.PersistKeyInCsp = true;
            // Clear the provider to make sure it saves the key
            rsa.Clear();
        }
    }
}
