using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace krestiki_noliki_AI
{
    class Class1
    {
        public static Random random = new Random();
        public static string[,] game = new string[5, 5];

        public static void Main()
        { 
            string[] phrases = {"Хороший ход, кожаный ...", "Неплохо для куска плоти", "Удумал победить меня, человечишко?", "Я хотел туда поставить!",  "Сейчас ты узнаешь что такое Искусственный интеллект"};
            Console.WriteLine("Введите уровень сложности от 1 до 100: ");
            int level = int.Parse(Console.ReadLine());
            if (level > 100 || level < 1)
            {
                Console.WriteLine("Введено неверное значение!");
                Thread.Sleep(500);
                Environment.Exit(0);
            }
            Console.Clear();
            int x = 5;
            int y = 2;
            for (int i = 0; i < 5; i++, Console.WriteLine())
            {
                for (int j = 0; j < 5; j++)
                {
                    game[i, j] = "   ";
                }
            }
            game[1, 1] = game[1, 3] = game[3, 1] = game[3, 3] = game[0, 1] = game[0, 3] = game[2, 1] = game[2, 3] = game[4, 1] = game[4, 3] = "|";
            game[1, 0] = game[1, 2] = game[1, 4] = game[3, 0] = game[3, 2] = game[3, 4] = "---";
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 5; i++, Console.WriteLine())
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(game[i, j]);
                }
            }
            Bot();
            Console.SetCursorPosition(5, 2);
            while (true)
            {
                ConsoleKeyInfo Key = Console.ReadKey();
                if (Key.Key == ConsoleKey.UpArrow && y > 1) { y = y - 2; }
                if (Key.Key == ConsoleKey.DownArrow && y <= 2) { y = y + 2; }
                if (Key.Key == ConsoleKey.LeftArrow && x > 1) { x = x - 4; }
                if (Key.Key == ConsoleKey.RightArrow && x <= 5) { x = x + 4; }
                Console.SetCursorPosition(x, y);
                if (Key.Key == ConsoleKey.Enter && game[y, (x / 2)] == "   ")
                {
                    game[y, (x / 2)] = " X ";
                    if (Win_hu(game) == true)
                    {
                        Draw();
                        Console.Clear();
                        Draw();
                        Console.SetCursorPosition(0, 7);
                        Console.WriteLine("Тебе просто повезло, кожаный...");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                    }
                    int b = random.Next(0, 5);
                    Console.Clear();
                    Draw();
                    Console.SetCursorPosition(0, 7);
                    Console.WriteLine(phrases[b]);
                    Console.SetCursorPosition(x, y);
                    Thread.Sleep(150);
                    int a = random.Next(1, 101);
                    if (level >= a)
                    {
                        AI();
                    }
                    else
                    {
                        Bot();
                    }
                }
                if (Win_ai(game) == true)
                {
                    Console.Clear();
                    Draw();
                    Console.SetCursorPosition(0, 7);
                    Console.WriteLine("Ха-ха-ха, почувствуй вкус поражения!");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                }
                if (game[0, 0] != "   " && game[0, 2] != "   " && game[0, 4] != "   " &&
                    game[2, 0] != "   " && game[2, 2] != "   " && game[2, 4] != "   " &&
                    game[4, 0] != "   " && game[4, 2] != "   " && game[4, 4] != "   ")
                {
                    Console.Clear();
                    Draw();
                    Console.SetCursorPosition(0, 7);
                    Console.WriteLine("Ничья)");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                }
                Draw();
                Console.SetCursorPosition(x, y);
            }
        }

        public static bool Win_hu(string[,] game)
        {
            if ((game[0, 0] == game[0, 2] && game[0, 2] == game[0, 4] && game[0, 2] == " X ") ||
                (game[2, 0] == game[2, 2] && game[2, 2] == game[2, 4] && game[2, 2] == " X ") ||
                (game[4, 0] == game[4, 2] && game[4, 2] == game[4, 4] && game[4, 2] == " X ") ||
                (game[0, 0] == game[2, 0] && game[2, 0] == game[4, 0] && game[2, 0] == " X ") ||
                (game[0, 2] == game[2, 2] && game[2, 2] == game[4, 2] && game[2, 2] == " X ") ||
                (game[0, 4] == game[2, 4] && game[2, 4] == game[4, 4] && game[2, 4] == " X ") ||
                (game[0, 0] == game[2, 2] && game[2, 2] == game[4, 4] && game[2, 2] == " X ") ||
                (game[0, 4] == game[2, 2] && game[2, 2] == game[4, 0] && game[2, 2] == " X "))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool Win_ai(string[,] game)
        {
            if ((game[0, 0] == game[0, 2] && game[0, 2] == game[0, 4] && game[0, 2] == " 0 ") ||
                (game[2, 0] == game[2, 2] && game[2, 2] == game[2, 4] && game[2, 2] == " 0 ") ||
                (game[4, 0] == game[4, 2] && game[4, 2] == game[4, 4] && game[4, 2] == " 0 ") ||
                (game[0, 0] == game[2, 0] && game[2, 0] == game[4, 0] && game[2, 0] == " 0 ") ||
                (game[0, 2] == game[2, 2] && game[2, 2] == game[4, 2] && game[2, 2] == " 0 ") ||
                (game[0, 4] == game[2, 4] && game[2, 4] == game[4, 4] && game[2, 4] == " 0 ") ||
                (game[0, 0] == game[2, 2] && game[2, 2] == game[4, 4] && game[2, 2] == " 0 ") ||
                (game[0, 4] == game[2, 2] && game[2, 2] == game[4, 0] && game[2, 2] == " 0 "))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Draw()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 5; i++, Console.WriteLine())
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(game[i, j]);
                }
            }
        }

        public static void Bot()
        {
            int[] values = { 0, 2, 4 };
            int x = random.Next(0, 3);
            int y = random.Next(0, 3);
            if (game[values[x], values[y]] == "   ")
            {
                game[values[x], values[y]] = " 0 ";
                Draw();
            }
            else
            {
                Bot();
            }
        }

        public static void AI()
        {
            string[,] predict = game;
            bool flag = true;
            for (int i = 0; i < 5; i += 2)
            {
                for (int j = 0; j < 5; j += 2)
                {
                    if (predict[i, j] == "   " && flag == true)
                    {
                        predict[i, j] = " 0 ";
                        if (Win_ai(predict) == true)
                        {
                            game[i, j] = " 0 ";
                            flag = false;
                            Draw();
                        }
                        else
                        {
                            predict[i, j] = "   ";
                        }
                    }
                }
            }

            for (int i = 0; i < 5; i += 2)
            {
                for (int j = 0; j < 5; j += 2)
                {
                    if (predict[i, j] == "   " && flag == true)
                    {
                        predict[i, j] = " X ";
                        if (Win_hu(predict) == true)
                        {
                            game[i, j] = " 0 ";
                            flag = false;
                            Draw();
                        }
                        else
                        {
                            predict[i, j] = "   ";
                        }
                    }
                }
            }

            for (int i = 0; i < 5; i += 2)
            {
                for (int j = 0; j < 5; j += 2)
                {
                    for (int x = 0; x < 5; x += 2)
                    {
                        for (int y = 0; y < 5; y += 2)
                        {
                            if (predict[i, j] == "   " && predict[x, y] == "   " && flag == true)
                            {
                                predict[i, j] = " 0 ";
                                predict[x, y] = " 0 ";
                                if (Win_ai(predict) == true )
                                {
                                    game[x, y] = " 0 ";
                                    game[i, j] = "   "; 
                                    flag = false;
                                    Draw();
                                }
                                else
                                {
                                    predict[i, j] = "   ";
                                    predict[x, y] = "   ";
                                }
                            }
                        }
                    }
                }
            }

            if (flag == true)
            {
                Bot();
            }

        }
    }
}
