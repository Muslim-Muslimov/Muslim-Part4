using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muslim_Part4
{
    internal class LogAnalyzer
    {
        const string PROBEL = " ";
        static string GetTime(string log) // выводим время
        {
            int firstIndex = log.IndexOf(PROBEL);
            int secondIndex = log.IndexOf(PROBEL, firstIndex+1);
            int timeLenght = secondIndex - firstIndex;
            string time = log.Substring(firstIndex+1, timeLenght);

            return time;
        }


        static string GetDate(string log) // метод для вывода даты
        {
            int firstIndex = log.IndexOf(PROBEL);
            int dateLenght = firstIndex;
            string date = log.Substring(0, dateLenght);
            return date;
        }
        
        static string GetLevel(string log)
            
        {
            int firstIndex =log.IndexOf(PROBEL);
            int secondIndex = log.IndexOf(PROBEL,firstIndex+1);
            int thirdIndex = log.IndexOf(PROBEL,secondIndex+1);
            int levelLenght = thirdIndex - secondIndex;
            string level = log.Substring(secondIndex+1, levelLenght);
            return level;
        }

        static string GetMessage(string log)
        {
            int firstIndex = log.IndexOf(PROBEL);
            int secondIndex = log.IndexOf(PROBEL, firstIndex + 1);
            int thirdIndex = log.IndexOf(PROBEL, secondIndex + 1);
            string message = log.Substring(thirdIndex + 1); 


            return message;
        }

        public static void Start()
        {
           // создаем массив
            string[] logs = new string[] {
                "2023-11-12 08:30:00 INFO Application started successfully",
                "2023-11-12 08:45:23 WARNING Low memory warning detected",
                "2023-11-12 09:15:45 ERROR Failed to connect to database",
                "2023-11-12 09:45:10 INFO User 'admin' logged in",
                "2023-11-12 10:00:00 ERROR Unexpected exception occurred",
                "2023-11-12 10:30:33 WARNING Disk space is almost full",
                "2023-11-12 11:00:05 INFO New user 'john_doe' created",
                "2023-11-12 11:30:00 INFO Scheduled maintenance started",
                "2023-11-12 12:00:00 ERROR Email service is not responding",
                "2023-11-12 12:30:45 WARNING High CPU usage detected" };

            foreach (string log in logs) // перебираем массив
            {
                string date = GetDate(log);
                string time = GetTime(log);
                string level = GetLevel(log);
                string message = GetMessage(log);
                Console.WriteLine($"Date: {date} Time: {time} Level: {level.PadRight(8)} Message: {message}");


            }

        }
    }
}
