using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muslim_Part4
{
    internal class CakesImproved
    {
        const string PATH = @"Cakes.txt";
        public static void Start()
        {
            Console.WriteLine("Введите название торта: ");
            string? Name = Console.ReadLine();


            



        
            Console.Clear();
            Console.WriteLine("1. Выбрать торт: ");
            Console.WriteLine("2. Внести новый торт: ");
            int? mode = Convert.ToInt32(Console.ReadLine());
            if (mode != 1 && mode != 2)
            {
                
            }

          
            
           
        }



    }


    
}
