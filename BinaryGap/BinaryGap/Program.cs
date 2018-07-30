using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryGap
{
    class Program
    {
        static void Main(string[] args)
        {
            //Array valido, >= 2 elementos inteiros
            

            //Array <> null


            //K deve ser inteiro


     


        }

        public int GetBinaryGap(int N)
        {
            string binaryValue = Convert.ToString(N, 2);

            int longestBinaryGap = 0;
            int binaryGapLenght = 0;
            for (int i = 1; i < binaryValue.Length; i++)
            {
                if (binaryValue[i - 1] == '1' && binaryValue[i] == '0')
                {
                    binaryGapLenght = 1;
                }
                else if (binaryValue[i - 1] == '0' && binaryValue[i] == '0')
                {
                    binaryGapLenght++;
                }
                else if (binaryValue[i - 1] == '0' && binaryValue[i] == '1')
                {
                    longestBinaryGap = Math.Max(longestBinaryGap, binaryGapLenght);
                }
            }

            return longestBinaryGap;
        }
    
    
    
    }
}
