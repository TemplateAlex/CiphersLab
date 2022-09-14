using System;

namespace Lab
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("---Hill Cipher---");
            ICipher cipher = new HillCipher();
            Console.WriteLine(cipher.Encrypt("somethingwe", "something"));

            Console.WriteLine("\n---Visiner Cipher---");
            ICipher cipher2 = new VisinerCipher();
            Console.WriteLine(cipher2.Encrypt("rofl", "sass"));

            Console.WriteLine("\n---Atbash Cipher---");
            ICipher cipher3 = new AtbashCipher();
            Console.WriteLine(cipher3.Encrypt("padla", ""));

            Console.WriteLine("\n---XOR Cipher---");
            ICipher cipher4 = new XORCipher();
            Console.WriteLine(cipher4.Encrypt("saaaaaaas", 3));

            Console.WriteLine("\n---ADFGX Cipher---");
            ICipher cipher5 = new ADFGXCipher();
            Console.WriteLine(cipher5.Encrypt("attackatdawn", "battle"));
        }
    }
}