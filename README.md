# EncryptDrive
Lightweight application in C# to quickly encrypt an entire drive (where permissions are possible)

Currently uses a simple XOR cipher, if you want to be fancier you could generate a keypair and save it to some file to implement Encrypt and Decrypt.

Usage: ./EncryptDrives <flag> <drive>
Example:  ./EncryptDrives /E C:

Thanks for reading!
