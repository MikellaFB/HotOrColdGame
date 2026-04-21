using System;

namespace HotOrColdGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool IsgameStarting = false;
            Random randomNumber = new Random();

            do
            {
                Console.WriteLine("Давай поиграем в горячо или холодно! Обещаю, тебе понравится >=3");
                Console.WriteLine("Согласен? да-Y, нет-N");
                string? input = Console.ReadLine()?.ToUpper();

                switch (input)
                {
                    case "Y":
                        Console.Clear();
                        Console.WriteLine("\n Отлично! Мелкий урод не ссыкло");
                        IsgameStarting = true;
                        break;
                    case "N":
                        Console.Clear();
                        Console.WriteLine("Жаль что ты такое ссыкло как и твой отец >=3 ");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Ты что тупой ? я же сказал что да-Y, нет-N попробуй снова");
                        break;
                }
            }
            while (!IsgameStarting);

            Console.WriteLine("\n \n Ну что-же вот правила игры. \n Я загадываю число по оси X и Y. От 1 до 15 по каждой оси и твоя задача найти точку пересичения. \n Ну надеюсь ты понял дальше мне в падлу всё рассказывать. В общем удачи >=3");
            int NumberX = randomNumber.Next(1, 16);
            int NumberY = randomNumber.Next(1, 16);
            int? lastDistance = null;
            bool win = false;
            int attempts = 0;

            // Основной цикл игры
            while (!win)
            {
                Console.Write("\nВведите число X (1-15): ");
                if (!int.TryParse(Console.ReadLine(), out int userX)) continue;

                Console.Write("Введите число Y (1-15): ");
                if (!int.TryParse(Console.ReadLine(), out int userY)) continue;

                if (userX > 0 && userX < 16 && userY > 0 && userY < 16)
                {
                    int currentDistance = Math.Abs(userX - NumberX) + Math.Abs(userY - NumberY);

                    if (currentDistance == 0)
                    {
                        attempts++;
                        Console.WriteLine($"Опа! Угадал. Ну иди гуляй теперь. \nТебе понадобилось всего то { attempts} попыток. Ты молодец гордись с собою =3");
                        win = true;
                    }
                    else
                    {
                        string message = (lastDistance, currentDistance) switch
                        {
                            (null, <= 3) => "Первый ход — и сразу ЖАРКО!",
                            (null, _) => "Первый выстрел — мимо. Холодно.",
                            (int last, int curr) when curr < last => "Теплее... Ты подкрадываешься!",
                            (int last, int curr) when curr > last => "Холоднее. Ты уходишь в туман...",
                            _ => "Ты стоишь на месте. Соберись!"
                        };

                        Console.WriteLine(message);
                        lastDistance = currentDistance; // Запоминаем дистанцию для следующего шага
                        attempts++;
                    }
                }
                else
                {
                    Console.WriteLine("ты что вообще дурак? тебе же сказали от 1 до 15 ты что вообще тупой ?_?");
                }
            }

            Console.WriteLine("Нажми любую кнопку, чтобы свалить...");
            Console.ReadKey();
        }
    }
}