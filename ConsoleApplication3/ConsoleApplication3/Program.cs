using System;
using System.Collections.Generic;
using System.Text;


namespace Trial
{
    /*
      * Complete the function below.
      * DO NOT MODIFY CODE OUTSIDE THIS FUNCTION!
      */

    class Program
    {

        //public struct MyStruct
        //{
        //    public int Inteiro; //valor de input
        //    public string Binario; //valor binario
        //    public int CountBinary; //ordem
        //    public int SequeceValidation; //ordem

        //}

        static int[] rearrange(int[] elements)
        {
            string[,] Matrix = new string[elements.Length, 4];

            //converter em binário
            string[] str = new string[elements.Length];
            int CountBinary = 0;
            int Sequece = 0;

            for (int n = 0; n < elements.Length; n++)
            {

                Matrix[n, 0] = elements[n].ToString();
                Matrix[n, 1] = Convert.ToString(elements[n], 2);
                Matrix[n, 2] = "0";
                CountBinary = 0;

                for (int m = 0; m < Convert.ToString(elements[n], 2).Length; m++)
                {
                    if (Convert.ToString(elements[n], 2)[m].ToString() == "1")
                    {
                        CountBinary += int.Parse(Convert.ToString(elements[n], 2)[m].ToString());
                    }
                }

                Matrix[n, 2] = CountBinary.ToString();

                //é o primeiro
                int seq = 0;
                if (n > 0)
                {
                    //validar se o numero atual é menor que anterior e atualizar a sequece, começando de zero
                    if (int.Parse(Matrix[n - 1, 2]) == int.Parse(Matrix[n, 2])) //1's 
                    {
                        if (int.Parse(Matrix[n - 1, 0]) > int.Parse(Matrix[n, 0]))
                        {
                            seq = +1;
                            Matrix[n, 3] = seq.ToString();
                        }
                        else
                        {
                            seq = -1;
                            Matrix[n, 3] = seq.ToString();
                        }

                    }
                    else {
                        seq = int.Parse(Matrix[n-1, 3]);
                        Matrix[n-1, 3] = Matrix[n, 3];
                        Matrix[n, 3] = seq.ToString();
                    }

                }
                else {
                    seq = 0;
                    Matrix[n, 3] = seq.ToString();
                }


                
                
                




            }

            string[] strresultado = new string[elements.Length];
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < Matrix.Length; j++)
                {
                    

                }


            }



           //contador de binário
            int[] binary = new int[Matrix.Length];

            for (int z = 0; z < Matrix.Length; z++)
            {
                binary[z] = int.Parse(Matrix[z, 0]);
            }

            return binary; //new int[] { 1, 2, 3 };
        }


        //static int[] rearrange(int[] elements)
        //{

        //    MyStruct Estrura = new MyStruct();

        //    Estrura.Binario = "";
        //    Estrura.Inteiro = 0;
        //    Estrura.CountBinary = 0;

        //    List<MyStruct> ListaGeral = new List<MyStruct>();

        //    //converter em binário
        //    string[] str = new string[elements.Length];

        //    for (int i = 0; i < elements.Length; i++)
        //    {
        //        Estrura.Inteiro = elements[i];
        //        Estrura.Binario = Convert.ToString(elements[i], 2);
        //        Estrura.CountBinary = 0;

        //        for (int j = 0; j < Convert.ToString(elements[i], 2).Length; j++)
        //        {
        //            if (Convert.ToString(elements[i], 2)[j].ToString() == "1")
        //            {
        //                Estrura.CountBinary += int.Parse(Convert.ToString(elements[i], 2)[j].ToString());
        //            }

        //        }
        //        ListaGeral.Add(Estrura);
        //    }

        //    var ordenado = ListaGeral
        //         .OrderBy(x => x.CountBinary).ThenBy(x => x.Inteiro)
        //         .ToList();

        //    //contador de binário
        //    int[] binary = new int[str.Length];

        //    for (int i = 0; i < ordenado.Count; i++)
        //    {
        //        binary[i] = ordenado[i].Inteiro;
        //    }

        //    return binary; //new int[] { 1, 2, 3 };
        //}

        // DO NOT MODIFY CODE OUTSIDE THE ABOVE FUNCTION!

        //array de inteiros
        //array de binarios/inteiros
        //array de mapeamento


        static void Main(String[] args)
        {


            int[] res;

            int _elements_size = 0;

            _elements_size = Convert.ToInt32(Console.ReadLine());

            int[] _elements = new int[_elements_size];

            int _elements_item;

            for (int _elements_i = 0; _elements_i < _elements_size; _elements_i++)
            {
                _elements_item = Convert.ToInt32(Console.ReadLine());
                _elements[_elements_i] = _elements_item;
            }

            res = rearrange(_elements);
            for (int res_i = 0; res_i < res.Length; res_i++)
            {
                Console.WriteLine(res[res_i]);
            }

            Console.ReadLine();
        }

    }
}
