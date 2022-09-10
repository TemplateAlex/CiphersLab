﻿using System;

namespace Lab
{
    class Program
    {
        public static void Main()
        {
            ICipher cipher = new HillCipher();
            Console.WriteLine(cipher.Encrypt("somethingwe", "something"));

            ICipher cipher2 = new VisinerCipher();
            Console.WriteLine(cipher2.Encrypt("rofl", "sass")); ;
        }
    }
}