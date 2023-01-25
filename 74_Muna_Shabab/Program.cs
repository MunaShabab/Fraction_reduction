using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Exercise 74
//written by: Muna Shabab
//date:10-9-2020

namespace _74_Muna_Shabab
{
    class Program
    {
        static void Main(string[] args)
        {
            //Explain the application to the user
            Console.WriteLine("This application accepts two non zero integeres as a numerator and denominator");
            Console.WriteLine("for a fraction and test to see if it can be reduced");

            //prompt the user for the numbers and validate
            Console.WriteLine("Please enter a non zero integer for the numerator:");
            string input = Console.ReadLine();
            int numerator = GetValidInteger(input);

            Console.WriteLine("Please enter a non zero integer for the denominator:");
            input = Console.ReadLine();
            int denominator = GetValidInteger(input);
         
            Console.Write("The fraction " + numerator + "/" +denominator + " is");
            
            if(Reduce(ref numerator,ref denominator))
            {
                if (numerator < 0 ^ denominator < 0)
                {
                    Console.Write(" reducible to -" + Math.Abs(numerator) + "/"
                                        + Math.Abs(denominator));
                }
                else
                {
                    Console.Write(" reducible to " + Math.Abs(numerator) + "/"
                                       + Math.Abs(denominator));
                }
                  
            }
            else
            {
                Console.Write(" not reducible");
            }
           
            
            Console.ReadKey();
        }
        public static int GetValidInteger(string input)
        {
            int num;
            while ((!(int.TryParse(input, out num))) || num ==0)
            {

                Console.WriteLine(input + " is not a valid  input");
                Console.WriteLine("please enter a non zero integer :");
                input = Console.ReadLine();
            }

            return num;
        }
        public static bool Reduce(ref int numeratorIn, ref int denominatorIn)
        {
            int  GCF;
            bool GCFfound = false;
            
            if (Math.Abs(numeratorIn) < Math.Abs(denominatorIn))
            {
                GCF = Math.Abs(numeratorIn);
            }
            else
            {
                GCF = Math.Abs(denominatorIn);
            }
            //loop through the numbers to find the GCF
            for (int i = GCF; i > 1; --i)
            {
                if ((numeratorIn % i == 0) && (denominatorIn % i == 0))
                {
                    GCF = i;
                    GCFfound = true;
                    //reduuce the fraction
                    numeratorIn /= GCF;
                    denominatorIn /= GCF;
                    break;
                    
                }

            }
            return GCFfound;
        }
        

    }
}
