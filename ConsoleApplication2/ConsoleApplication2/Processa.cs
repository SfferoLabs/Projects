using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;





namespace ConsoleApplication2
{
    class Processa
    {
        //Array
        //Nulo
        //Tamanho
        //Indefinido
        //> que 6


        public class MyData
        {
            public string H1 { get; set; }
             public string M1 { get; set; }
            public string M2 { get; set; }
            public string S1 { get; set; }
            public string S2 { get; set; }

            public List<int> HoraExtenso { get; set; }
            public List<int> HoraEntrada { get; set; }

            //H[0]
            ////Retornar o menor número válido [0-2]
            //private static int MenorNumeroValido(int[] intArray, int Num)
            //{

            //    for (int i = 0; i < intArray.Length; i++)
            //    {
                    
            //    }
                
            /////    var sorted_intArray = intArray.OrderBy(i => i < 0 ? 0 : 1).ToArray();
            //    return sorted_intArray[0];
            //}



            //H[1]
            //Retornar o menor número válido [0-5]
            //Retornar o menor número válido, se o H[0]=0, retornar [1-9]
            //Retornar o menor número válido, se o H[0]=1, retornar [0-9]
            //Retornar o menor número válido, se o H[0]=2, retornar [0-3]


            //H[2]
            //Retornar o menor número válido [0-5]

            //H[3]
            //Retornar o menor número válido, se o H[2]=0, retornar [0-9]
            //Retornar o menor número válido, se o H[2]>0<5, retornar [0-9]


            //H[4]
            //Retornar o menor número válido [0-5]


            //H[5]
            //Retornar o menor número válido, se o H[4]=0, retornar [0-9]
            //Retornar o menor número válido, se o H[4]>0<5, retornar [0-9]


            //Critérios Gerais
            //Avaliar minutos e segundos e retornar o balanceado entre os 4 números.
            //Se vier números compostos com zero, retornar por exemplo: 0,0,0,7,8,9, retornar 07:08:09

            //Outras situações, retornar NOT IMPOSSIBLE, exemplo: 24,59,59



        }







    }

}
