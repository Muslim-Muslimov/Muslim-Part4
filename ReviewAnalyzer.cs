



    internal class ReviewAnalyzer

    {
        public static void Start()
        {
            Console.WriteLine("Введите ваш положительный отзыв, отрицательных не принимаем!: ");
            string? отзыв = Console.ReadLine();
        // создаем массивы отрицательных и положительных слов.
        string[] положительные = { "прекрас", "отлич", "великолепн", "довол", "рекоменд", "дружелюб" };
        string[] отрицательные = { "ужас", "разочаров", "неприятн", "недовол" };
        // создаем флажки
        bool вПоложительных = false;
        bool вОтрицательных = false;
        
        foreach (string ключевоеСлово in положительные)
        {
            if (отзыв.ToLower().StartsWith(ключевоеСлово)) // сначала использовал метод Contains, но потом Дауд показал этот метод.
            {
                вПоложительных = true;
                break; 
            }
        }
        if (вПоложительных == true)
        {
            Console.WriteLine("Хороший отзыв");
        }
        foreach (string ключевоеСлово in отрицательные)
        {
            if (отзыв.ToLower().StartsWith(ключевоеСлово))
            {
                вОтрицательных = true;
                break;
            }
        }
        if (вОтрицательных == true)
        {
            Console.WriteLine("Плохой отзыв");
        }
        if (вПоложительных == false && вОтрицательных == false)
        {
            Console.WriteLine("Нейтральный отзыв");
        }
        
        }
    }

