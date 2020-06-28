using System;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Игра угадай число.");
            Console.WriteLine("Участвуют двое игроков. Это могут быть как люди, так и компьютер.");
            Console.WriteLine("Игра угадай число заключается в том, что один игрок загадывает число\n" +
                "от 0 до 100, а второй должен его отгадать. Дается 5 попыток.\n");

            Console.Write("Превый игрок человек? Введите Да/Нет: ");
            string gamer1_Info = Console.ReadLine().ToUpper();
            if (gamer1_Info == "ДА")
                gamer1_Info = "Человек";
            else if (gamer1_Info == "НЕТ")
                gamer1_Info = "Компьютер";
            else
            {
                Console.WriteLine("Введен некорректный ответ. Игра будет закрыта полсле нажатия любой кнопки!");
                Console.ReadKey();
                Environment.Exit(0);
            }

            Console.Write("Второй игрок человек? Введите Да/Нет: ");
            string gamer2_Info = Console.ReadLine().ToUpper();
            if (gamer2_Info == "ДА")
                gamer2_Info = "Человек";
            else if (gamer2_Info == "НЕТ")
                gamer2_Info = "Компьютер";
            else
            {
                Console.WriteLine("Введен некорректный ответ. Игра будет закрыта полсле нажатия любой кнопки!");
                Console.ReadKey();
                Environment.Exit(0);
            }

            Console.WriteLine($"Первым игроком выбран - {gamer1_Info}, вторым игроком выбран - {gamer2_Info}.");

            Game(gamer1_Info, gamer2_Info); //игра

            Console.ReadKey();
        }

        private static void Game(string user1, string user2)
        {
            Random random = new Random();
            int numberMemory = 0;
            int number = 0;
            if (user1 == "Человек")
            {
                Console.Write($"\nПоскольку первый игрок {user1},\nон должен ввести целое число от 1 до 100 : ");
                try
                {
                    numberMemory = int.Parse(Console.ReadLine());//число введеное первым игроком
                    Console.Clear();
                }
                catch
                {

                }

                if(user2 == "Человек")//первый и второй игрок люди
                {
                    Console.WriteLine("Число загадано!");
                    for (int i = 1; i <= 5; i++)
                    {
                        Console.Write($"\nВторой игрок у вас {i} попытка: ");
                        try
                        {
                            number = int.Parse(Console.ReadLine());//число введеное 2 игроком
                            if(number > numberMemory)
                            {
                                Console.WriteLine($"Число {number} больше загаданного!");
                            }
                            if (number < numberMemory)
                            {
                                Console.WriteLine($"Число {number} меньше загаданного!");
                            }
                            if (number == numberMemory)
                            {
                                Console.WriteLine($"Ура! Было загадано число {number}! Вы победили!");
                                break;
                            }
                            if(i == 5)
                            {
                                Console.WriteLine($"\nБыло загадано число {numberMemory}, вы не смогли угадать.");
                            }
                        }
                        catch
                        {

                        }
                    }
                    Console.WriteLine("\nИгра окончена!");
                }
                if (user2 == "Компьютер")//первый игрок человек, а второй компьютер
                {
                    Console.WriteLine("Число загадано!\nКомпьютер начинает отгадывать с помощью бинарного алгоритма.");
                    int workNumber = 50;
                    number = 50;
                    for (int i = 1; i <= 5; i++)
                    {
                        Console.WriteLine($"\nКомпьютер делает {i} попытку.");
                        if (number > numberMemory)
                        {
                            Console.WriteLine($"Компьютер загадал число {number} - оно больше загаданного!");
                            workNumber /= 2;
                            number -= workNumber;
                            if (i == 5)
                            {
                                Console.WriteLine($"\nБыло загадано число {numberMemory}, компьютер не смог его отгадать.");
                                break;
                            }
                            continue;
                        }
                        if (number < numberMemory)
                        {
                            Console.WriteLine($"Компьютер загадал число {number} - оно меньше загаданного!");
                            workNumber /= 2;
                            number += workNumber;
                            if (i == 5)
                            {
                                Console.WriteLine($"\nБыло загадано число {numberMemory}, компьютер не смог его отгадать.");
                                break;
                            }
                            continue;
                        }
                        if (number == numberMemory)
                        {
                            Console.WriteLine($"Ура! Было загадано число {number}! И компьютер его отгадал!");
                            break;
                        }
                    }
                    Console.WriteLine("\nИгра окончена!");
                }
            }
            if (user1 == "Компьютер")
            {
                Console.Clear();
                Console.Write($"Поскольку первый игрок {user1},\nкомпьютер автоматически загадывает целое число от 0 до 100.\n");
                numberMemory = random.Next(101);//число загаданное компьютером

                if (user2 == "Человек")//первый игрок компьютер, а второй человек
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        Console.Write($"\nВторой игрок у вас {i} попытка: ");
                        try
                        {
                            number = int.Parse(Console.ReadLine());//число введеное 2 игроком
                            if (number > numberMemory)
                            {
                                Console.WriteLine($"Число {number} больше загаданного!");
                            }
                            if (number < numberMemory)
                            {
                                Console.WriteLine($"Число {number} меньше загаданного!");
                            }
                            if (number == numberMemory)
                            {
                                Console.WriteLine($"Ура! Было загадано число {number}! Вы победили!");
                                break;
                            }
                            if (i == 5)
                            {
                                Console.WriteLine($"\nБыло загадано число {numberMemory}, вы не смогли угадать.");
                            }
                        }
                        catch
                        {

                        }
                    }
                    Console.WriteLine("\nИгра окончена!");
                }
                if (user2 == "Компьютер")//первый и второй игрок компьютеры
                {
                    Console.WriteLine("\nЧисло загадано первым компьютером!\nВторой компьютер начинает отгадывать с помощью бинарного алгоритма.");
                    numberMemory = random.Next(101);//число загаданное компьютером
                    int workNumber = 50;
                    number = 50;
                    for (int i = 1; i <= 5; i++)
                    {
                        Console.WriteLine($"\nВторой компьютер делает {i} попытку.");
                        if (number > numberMemory)
                        {
                            Console.WriteLine($"Второй компьютер загадал число {number} - оно больше загаданного!");
                            workNumber /= 2;
                            number -= workNumber;
                            if (i == 5)
                            {
                                Console.WriteLine($"\nБыло загадано число {numberMemory},второй компьютер не смог его отгадать.");
                                break;
                            }
                            continue;
                        }
                        if (number < numberMemory)
                        {
                            Console.WriteLine($"Второй компьютер загадал число {number} - оно меньше загаданного!");
                            workNumber /= 2;
                            number += workNumber;
                            if (i == 5)
                            {
                                Console.WriteLine($"\nБыло загадано число {numberMemory},второй компьютер не смог его отгадать.");
                                break;
                            }
                            continue;
                        }
                        if (number == numberMemory)
                        {
                            Console.WriteLine($"Ура! Было загадано число {number}! И второй компьютер его отгадал!");
                            break;
                        }
                    }
                    Console.WriteLine("\nИгра окончена!");
                }
            }
        }
    }
}
