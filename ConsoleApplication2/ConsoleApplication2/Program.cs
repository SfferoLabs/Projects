using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{

    public class Person
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    class MyFun
    {

        //private static int[] SortIntArray(int[] intArray)
        //{
        //    var sorted_intArray = intArray.OrderBy(i => i < 0 ? 0 : 1).ToArray();
        //    return sorted_intArray;
        //}

        //H[0]
        //Retornar o menor número válido [0-2]

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

        //public class Customer
        //{
        //    public int Discount()
        //    {
        //        return 0;
        //    }
        //}

        //public class PrivilegedCustomer : Customer
        //{
        //    public new int Discount()
        //    {
        //        return 10;
        //    }
        //}

        //public int OldWaySum(int a, int b)
        //{
        //    return a + b;
        //}


        //public int NewWaySum (int a, int b) => return a + b;


        //   public static void foo(int bb)
        //  {

        //     bb = 20;
        // }

        //    interface IInterface
        //{
        //    void fun();
        //        void fun(int x);
        //        void fun(ref int x);
        //        String fun(int x);
        //}


        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("try");
                throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("cacth");
            }
            finally
            {
                Console.WriteLine("finally");

            }


            tempdata



            //Person p = new Person { Name = "John", DateOfBirth = new DateTime(1975, 6, 21) };
            //string text = string.Format("{0} was born on {1:D}", p.Name, p.DateOfBirth);


            //Person p = new Person { Name = "John", DateOfBirth = new DateTime(1975, 6, 21) };
            //string text = $"{p.Name} was born on {p.DateOfBirth:D}";

            //Person p = new Person { Name = "John", DateOfBirth = new DateTime(1975, 6, 21) };
            //string text = "{Name} was born on {DateOfBirth:D}".Format(p);

            //Person p = new Person { Name = "John", DateOfBirth = new DateTime(1975, 6, 21) };
            //string text = p.Format("{Name} was born on {DateOfBirth:D}");

            //Person p = new Person { Name = "John", DateOfBirth = new DateTime(1975, 6, 21) };
            //string text = StringTemplate.Format("{Name} was born on {DateOfBirth:D}", p);


            //int bb = 10;
            //foo(bb);
            //Console.WriteLine(bb);

            //              public static void Main()
            //         {
            ////        Customer cust = new PrivilegedCustomer();
            ////        Console.WriteLine(cust.Discount());
            //////    }


            //458129
            //183264
            //000789

            int A = 0;
            int B = 0;
            int C = 0;
            int D = 7;
            int E = 8;
            int F = 9;

            int[] res = { A, B, C, D, E, F };
            //Array.Sort(res);

            //HH:MM:SS - 24h
            string[] Hora = new string[6];

            int len = res.Length;

            //Firts Test
            //183264

            //sort
            //123468
            //461728
            //172846
            //183264
            //123468

            //return Hora = res;

            //23:59:59

            //0-2 0,1,2
            //0-3

            //0-9 0,1,2,3,4,5,6,7,8,9
            //0-9

            //lista de numeros
            for (int i = 0; i < len; i++)
            {
                //lista de posicao
                for (int j = 0; j < len; j++)
                {
                    //Hour
                    //primeira posicão 0: 0-9
                    if ((j == 0) && (Hora[0] == null))
                    {
                        if (((res[i]) >= 0) && (res[i] <= 2)) //0-2
                        {
                            Hora[0] = res[i].ToString();
                            break;
                        }

                    }
                    //Hour
                    //primeira posicão 0: 0-9
                    if ((j == 1) && (Hora[1] == null))
                    {
                        if (((res[i]) >= 0) && (res[i] <= 9)) //0-2
                        {
                            Hora[1] = res[i].ToString();
                            break;
                        }

                    }
                    //Hour
                    //primeira posicão 0: 0-9
                    if ((j == 2) && (Hora[2] == null))
                    {
                        if (((res[i]) >= 0) && (res[i] <= 5)) //0-2
                        {
                            Hora[2] = res[i].ToString();
                            break;
                        }

                    }

                    //Hour
                    //primeira posicão 0: 0-9
                    if ((j == 3) && (Hora[3] == null))
                    {
                        if (((res[i]) >= 0) && (res[i] <= 9)) //0-2
                        {
                            Hora[3] = res[i].ToString();
                            break;
                        }

                    }

                    //Hour
                    //primeira posicão 0: 0-9
                    if ((j == 4) && (Hora[4] == null))
                    {
                        if (((res[i]) >= 0) && (res[i] <= 5)) //0-2
                        {
                            Hora[4] = res[i].ToString();
                            break;
                        }

                    }

                    //Hour
                    //primeira posicão 0: 0-9
                    if ((j == 5) && (Hora[5] == null))
                    {
                        if (((res[i]) >= 0) && (res[i] <= 9)) //0-2
                        {
                            Hora[5] = res[i].ToString();
                            break;
                        }

                    }
                }

                //primeira posicão 1: 0-9
                //primeira posicão 2: 0-3

                //Min
                //primeira posicão 0: 0-9
                //primeira posicão 1: 0-9
                //primeira posicão 2: 0-9
                //primeira posicão 3: 0-9
                //primeira posicão 4: 0-9
                //primeira posicão 5: 0-9

                //Sec
                //primeira posicão 0: 0-9
                //primeira posicão 1: 0-9
                //primeira posicão 2: 0-9
                //primeira posicão 3: 0-9
                //primeira posicão 4: 0-9
                //primeira posicão 5: 0-9
            }

            //Array.Sort(Hora);
            //  Console.WriteLine(Hora[0].ToString() + Hora[1].ToString() + ":" + Hora[2].ToString() + Hora[3].ToString() + ":" + Hora[4].ToString() + Hora[5].ToString());
            Console.ReadLine();

        }
    }
}
