using System;

namespace Lab
{
    class Program
    {
        public static void Main()
        {
            ContextForCiphers contextForCiphers = new ContextForCiphers();

            Console.WriteLine("---Hill Cipher---");
            contextForCiphers.SetCipher(new HillCipher());
            Console.WriteLine(contextForCiphers.CallEncrypt("Somethingwe", "something"));

            Console.WriteLine("\n---Visiner Cipher---");
            contextForCiphers.SetCipher(new VisinerCipher());
            Console.WriteLine(contextForCiphers.CallEncrypt("rofl", "sass"));

            Console.WriteLine("\n---Atbash Cipher---");
            contextForCiphers.SetCipher(new AtbashCipher());
            Console.WriteLine(contextForCiphers.CallEncrypt("minions", ""));

            Console.WriteLine("\n---XOR Cipher---");
            contextForCiphers.SetCipher(new XORCipher());
            Console.WriteLine(contextForCiphers.CallEncrypt("saaaaaaaas", 3));

            Console.WriteLine("\n---ADFGX Cipher---");
            contextForCiphers.SetCipher(new ADFGXCipher());
            Console.WriteLine(contextForCiphers.CallEncrypt("attackatdawn", "battle"));
        }
    }
}