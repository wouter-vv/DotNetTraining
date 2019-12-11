using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter4
{
    class Streams
    {
        public void SetupStream() {
            // Writing to a file
            FileStream outputStream = new FileStream("OutputText.txt", FileMode.
            OpenOrCreate, FileAccess.Write);
            byte[] outputMessageBytes = Encoding.UTF8.GetBytes("Hello world");

            outputStream.Write(outputMessageBytes, 0, outputMessageBytes.Length);
            outputStream.Close();

            FileStream inputStream = new FileStream("OutputText.txt", FileMode.Open,
            FileAccess.Read);
            long fileLength = inputStream.Length;
            byte[] readBytes = new byte[fileLength];
            inputStream.Read(readBytes, 0, (int)fileLength);
            string readString = Encoding.UTF8.GetString(readBytes);
            inputStream.Close();
            Console.WriteLine("Read message: {0}", readString);

            Console.ReadKey();
        }


    }
}
