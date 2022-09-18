using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    class ContextForCiphers
    {
        private ICipher _cipher;

        public ContextForCiphers()
        {

        }

        public void SetCipher(ICipher cipher)
        {
            this._cipher = cipher;
        }
        
        public string CallEncrypt(string word, string key = "")
        {
            if (_cipher == null) throw new Exception("Context don't find cipher object");

            return _cipher.Encrypt(word, key);
        }

        public string CallEncrypt(string word, int key = 1)
        {
            if (_cipher == null) throw new Exception("Context don't find cipher object");

            return _cipher.Encrypt(word, key);
        }
    }
    interface ICipher
    {
        string Encrypt(string word, string key);
        string Encrypt(string word, int key);
    }

    class HillCipher: ICipher
    {
        StringBuilder sbWord = new StringBuilder();
        StringBuilder sbKey = new StringBuilder();
        int matrixSize;
        int[,]? matrix;
        int[]? arrKeys;
        public string Encrypt(string word, string key)
        {
            sbWord.Append(word);
            sbKey.Append(key);

            matrixSize = (int)(Math.Ceiling(Math.Sqrt(sbWord.Length)));
            matrix = new int[matrixSize, matrixSize];
            arrKeys = new int[matrixSize];

            int k = 0;

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    if (k >= sbWord.Length) matrix[i, j] = 25;
                    else matrix[i, j] = sbWord[k] - ((int)'a');

                    k++;

                }
            }

            int wallKey = 0;
            int[] arrTmp = new int[matrixSize];


            int[,] matrixOfNewEncryptedValues = new int[matrixSize, matrixSize];
            
            for (int i = 0; i < matrixSize; i++)
            {
                for (int ind = 0; ind < matrixSize; ind++) arrTmp[ind] = 0;

                for (int j = 0; j < matrixSize; j++)
                {
                    if (wallKey >= sbKey.Length) arrKeys[j] = 25;
                    else arrKeys[j] = sbKey[wallKey] - ((int)'a');
                    wallKey++;
                }


                for(int j = 0; j < matrixSize; j++)
                {
                    for(int ind = 0; ind < matrixSize; ind++)
                    {
                        arrTmp[j] += matrix[ind, j] * arrKeys[ind]; 
                    }
                }

                for (int ind = 0; ind < matrixSize; ind++)
                {
                    matrixOfNewEncryptedValues[i, ind] = arrTmp[ind] % 26;
                }
            }

            StringBuilder sbResult = new StringBuilder();

            for(int i = 0; i < matrixSize; i++)
            {
                for(int j = 0; j < matrixSize; j++)
                {
                    sbResult.Append((char)(matrixOfNewEncryptedValues[i, j] + (int)'a'));
                }
            }
            return sbResult.ToString();
        }

        public string Encrypt(string word, int key)
        {
            return "";
        }
    } 

    class CaesarCipher: ICipher
    {
        public string Encrypt(string word, string key)
        {
            return "";
        }
        public string Encrypt(string word, int key)
        {
            return "";
        }
    }

    class VisinerCipher: ICipher
    {
        public string Encrypt(string word, string key)
        {
            StringBuilder sbWord = new StringBuilder(word);
            StringBuilder sbKey = new StringBuilder(key);
            StringBuilder sbResult = new StringBuilder();

            int wallForKey = 0;
            int lengthSbKey = sbKey.Length;

            if (sbWord.Length > sbKey.Length)
            {
                for (int i = lengthSbKey; i < sbWord.Length; i++)
                {
                    if (wallForKey >= lengthSbKey) wallForKey = 0;
                    sbKey.Append(sbKey[wallForKey]);
                    wallForKey++;
                }
            }
            

            for(int i = 0; i < sbWord.Length; i++)
            {
                char modifiedChar;
                int delta = (int)sbKey[i] - (int)'a';

                if (delta + sbWord[i] > (int)'z')
                {
                    modifiedChar = (char)(delta - ((int)'z' - (int)sbWord[i]) + (int)'a');
                }
                else modifiedChar = (char)((int)sbWord[i] + delta);

                sbResult.Append(modifiedChar);
            }
                
            return sbResult.ToString();
        }

        public string Encrypt(string word, int key)
        {
            return "";
        }
    }

    class AtbashCipher: ICipher
    {
        public string Encrypt(string word, string key)
        {
            StringBuilder sbResult = new StringBuilder();

            for(int i = 0; i < word.Length; i++)
            {
                sbResult.Append((char)((int)'z' - ((int)word[i] - (int)'a')));
            }

            return sbResult.ToString();
        }

        public string Encrypt(string word, int key)
        {
            return "";
        }
    }

    class XORCipher: ICipher
    {
        public string Encrypt(string word, string key)
        {
            return "";
        }

        public string Encrypt(string word, int key)
        {
            StringBuilder sbResult = new StringBuilder();

            Console.WriteLine("Binary code for our chars");
            for(int i = 0; i < word.Length; i++)
            {
                Console.WriteLine(this.CreateBinaryValueFromInteger((int)(word[i])));
            }

            Console.WriteLine("Binary code for changed chars");
            for(int i = 0; i < word.Length; i++)
            {
                int codeASCIIForChangedChar = (int)((int)word[i] ^ key);
                Console.WriteLine(this.CreateBinaryValueFromInteger(codeASCIIForChangedChar));
                sbResult.Append((char)codeASCIIForChangedChar);
            }

            return sbResult.ToString();
        }

        private string CreateBinaryValueFromInteger(int value)
        {
            int degree = 0;
            StringBuilder sbResult = new StringBuilder();

            while ((int)Math.Pow(2, degree) < value) degree++;

            for(int i = degree; i >= 0; i--)
            {
                if (value - (int)Math.Pow(2, i) >= 0)
                {
                    value -= (int)Math.Pow(2, i);
                    sbResult.Append("1");
                }
                else sbResult.Append("0");
            }

            return sbResult.ToString();
        }
    }

    class ADFGXCipher: ICipher
    {
        public string Encrypt(string word, string key)
        {
            StringBuilder sbResult = new StringBuilder("");
            StringBuilder firstStepString = new StringBuilder();

            char[,] cipherMatrix = new char[6, 6] { {'-', 'a', 'd', 'f', 'g', 'x' },
                                                    {'a', 'f', 'n', 'h', 'e', 'q' },
                                                    {'d', 'r', 'd', 'z', 'o', 'c' },
                                                    {'f', 'i', 's', 'a', 'g', 'u' },
                                                    {'g', 'b', 'v', 'k', 'p', 'w'},
                                                    {'x', 'x', 'm', 'y', 't', 'l'} };

            for (int i = 0; i < word.Length; i++)
            {
                char tmpChar = word[i];

                for (int j = 1; j < 6; j++)
                {
                    for (int k = 1; k < 6; k++)
                    {
                        if (cipherMatrix[j, k] == tmpChar)
                        {
                            firstStepString.Append(cipherMatrix[j, 0]);
                            firstStepString.Append(cipherMatrix[0, k]);
                        }
                    }
                }
            }

            int lengthKey = key.Length;
            int tmpRows = (int)Math.Ceiling((double)firstStepString.Length / (double)lengthKey);
            int wall = 0;

            char[,] secondCipherMatrix = new char[tmpRows + 1, lengthKey];

            for (int i = 0; i < lengthKey; i++)
            {
                secondCipherMatrix[0, i] = key[i];
            }

            for (int i = 1; i < tmpRows + 1; i++)
            {
                for(int j = 0; j < lengthKey; j++)
                {
                    if (wall < firstStepString.Length) secondCipherMatrix[i, j] = firstStepString[wall];
                    else secondCipherMatrix[i, j] = 'x';
                    wall++;
                }
            }

            bool flag = true;

            while(flag)
            {
                flag = false;

                for (int i = 1; i < lengthKey; i++)
                {
                    if ((int)secondCipherMatrix[0, i - 1] > (int)secondCipherMatrix[0, i])
                    {
                        for (int j = 0; j < tmpRows + 1; j++)
                        {
                            char tmp = secondCipherMatrix[j, i - 1];
                            secondCipherMatrix[j, i - 1] = secondCipherMatrix[j, i];
                            secondCipherMatrix[j, i] = tmp;
                        }
                        flag = true;
                    }
                }

            }

            
            for (int i = 0; i < lengthKey; i++)
            {
                for (int j = 1; j < tmpRows + 1; j++)
                {
                    sbResult.Append(secondCipherMatrix[j, i]);
                }
            }

            return sbResult.ToString();
        }

        public string Encrypt(string word, int key)
        {
            return "";
        }
    }
}
