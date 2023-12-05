using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Muslim_Part4
{
    internal class CakesImproved
    {
        const string PATH = @"Cakes.txt";
        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("Выберите режим: ");
            Console.WriteLine("1. Выбрать торт.");
            Console.WriteLine("2. Внести новый торт.");
            int? mode = Convert.ToInt32(Console.ReadLine());
            switch (mode)
            {
                case 1:
                    Console.WriteLine("Выберите торт");
                    string? selectedName = Console.ReadLine();
                    try
                    {
                        string? contents = File.ReadAllText(PATH);
                        string[] entries = contents.Split("\r\n");
                        bool found = false;
                        for (int i = 0; i < entries.Length; i++)
                        {
                            string entry = entries[i].ToLower();
                            if (entry.Contains(selectedName.ToLower()))
                            {
                                found = true;
                                string[] itog = entry.Split(" ");
                                Console.WriteLine($"Название {itog[0]}, Цена {itog[1]}");
                            }
                        }
                        if (found == false)
                        {
                            Console.WriteLine("Нет такого торта.");
                            Console.ReadKey();

                        }
                    }
                    catch
                    {
                        Console.WriteLine("Возникла непонятная ошибка.");
                        
                    }
                    Console.ReadKey();
                    Start();
                    break;

                    case 2:
                    Console.WriteLine("Введите название нового торта:");
                    string newName = Console.ReadLine();

                    Console.WriteLine("Введите цену:");
                    int cakePrice = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        File.AppendAllText(PATH, $"{newName} {cakePrice}\r\n");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine("Нет доступа к указанному пути");
                        return;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Возникла непонятная ошибка");
                        return;
                    }
                    Console.WriteLine("Данные о торте внесены.");
                    Console.ReadKey();
                    Start();
                    break;

            }
                

        }
    }
}
