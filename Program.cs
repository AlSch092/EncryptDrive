using System;

namespace EncryptDrives
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string root = @"F:\";
            Crypt c = new Crypt(root);

            if (args.Length > 1)
            {
                string flag = args[0];
                Console.WriteLine(flag);

                string _root = args[1];

                Console.WriteLine(_root);

                if (flag == "/E") //Right now we're using a simple xor cipher, thus we don't need both encrypt and decrypt
                {
                    c.CipherDrive(_root); //see https://learn.microsoft.com/en-us/dotnet/standard/security/walkthrough-creating-a-cryptographic-application for an Encryption/Decrypt example
                }
            }
            else
            {
                Console.WriteLine("Usage: ./EncryptDrives flag drive");
                Console.WriteLine("Example: ./EncryptDrives /E C:");
            }
        }
    }
}
