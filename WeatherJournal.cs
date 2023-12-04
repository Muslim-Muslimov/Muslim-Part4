using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Muslim_Part4
{
    internal class WeatherJournal
    {
        const string PATH = @"Weather.txt";
        const string DATE_FORMAT = "dd.MM.yyyy";
        public static void Start()

        {

            int? режим = SelectMode();
            switch (режим)
            {
                case 1:
                    Console.WriteLine("Введите дату: ");
                    string? selectDate = Console.ReadLine();
                    string? contents;
                    try
                    {
                        contents = File.ReadAllText(PATH);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Нет данных");
                        Console.ReadKey();
                        Start();
                        return;
                    }
                    string[] entries = contents.Split("\r\n");
                    bool found = false;
                    for (int i = 0; i < entries.Length - 1; i++)
                    {
                        string entry = entries[i];
                        if (entry.Contains(selectDate))
                        {
                            found = true;
                            string[] itog = entry.Split(" ");
                            Console.WriteLine($"Дата {itog[0]}, Погода {itog[3]}, Температура {itog[1]}°C, Влажность {itog[2]}");
                        }
                    }
                    if (found == false)
                    {
                        Console.WriteLine("Нет данных");
                    }
                    Console.ReadKey();
                    Start();

                    break;


                case 2:
                    Console.WriteLine("Введите информацию о погоде: ");
                    DateTime date = GetDate();
                    decimal temperature = GetTemperature();
                    int humidity = GetHumidity();
                    string description = GetDescription();
                    try
                    {
                        File.AppendAllText(PATH, $"{date.ToString(DATE_FORMAT)} {temperature} {humidity} {description}\r\n");
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
                    Console.WriteLine("Строка успешно добавлена в файл");
                    Console.ReadKey();
                    Start();
                    break;





            }


        }
        private static int SelectMode() // создаем метод для выбора режима.
        {
            Console.Clear();
            Console.WriteLine("Выберите режим: ");
            Console.WriteLine("1. Режим для чтения.");
            Console.WriteLine("2. Режим для записи.");
            try
            {
                int режим = Convert.ToInt32(Console.ReadLine());
                if (режим != 1 && режим != 2)
                {
                    return SelectMode();
                }
                return режим;
            }
            catch (Exception)
            {
                return SelectMode();
            }
            
        }
        private static DateTime GetDate() // создаем метод для даты.
        {
            Console.WriteLine("Введите дату: ");

            string? rawDate = Console.ReadLine();
            DateTime date;
            bool dateOk = DateTime.TryParse(rawDate, out date);
            if (dateOk == false)
            {
                return GetDate();
            }
            return date;

        }
        private static decimal GetTemperature() // создаем метод для температуры.
        {
            Console.WriteLine("Введите температуру: ");
            decimal temperature;

            try
            {
                temperature = Convert.ToDecimal(Console.ReadLine());
            }
            catch (Exception)
            {
                return GetTemperature();
            }
            return temperature;
        }
        private static int GetHumidity() // создаем метод для влажности.
        {
            Console.WriteLine("Введите влажность: ");
            int humidity;
            try
            {
                humidity = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                return GetHumidity();
            }
            return humidity;
        }
        private static string GetDescription() // создаем метод для ввода описания погоды
        {
            Console.WriteLine("Введите описание погоды: ");
            string description = Console.ReadLine();
            string[] descriptionWords = { "солнечно", "облачно", "дождь", "снег", "туман" };
            if (descriptionWords.Contains(description.ToLower()))
            {
                return description;
            }
            else
            {
                return GetDescription();
            }



        }
    }
}
