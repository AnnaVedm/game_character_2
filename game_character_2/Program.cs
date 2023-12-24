using System;

namespace game_character_2
{
    class program
    {
        static void Main(string[] args)
        {
            Console.Title = ("Игровой персонаж");
            Character[] characters = new Character[6];
            Character character = new Character("", false, 0, 0, 0, 0, 0, 0, 0);
            Random rnd = new Random();

            string name;
            bool lager;
            int dx;
            int dy;
            int health;

            Console.Write("ВНИМАНИЕ! Сначала заполняется лагерь союзников (3 персонажа). Для них вы можете сами опеределить урон!");
            for (int i = 0; i < characters.Length; i++)
            {
                Console.Write("\nВведите имя персонажа: ");
                name = Console.ReadLine();

                Console.Write("x (от 1 до 9): ");
                dx = Convert.ToInt32(Console.ReadLine());

                if (i < 3) //определение лагеря
                {
                    lager = true;
                }
                else
                {
                    lager = false;
                }

                while (dx <= 0 || dx >= 10) //проверка на дурака
                {
                    Console.WriteLine("Вы ввели неверное число для координаты. Нужно ввести число от 1 до 9: ");
                    dx = Convert.ToInt32(Console.ReadLine());
                }

                Console.Write("y (от 1 до 9): ");
                dy = Convert.ToInt32(Console.ReadLine());

                while (dy <= 0 || dy >= 10) //проверка на дурака
                {
                    Console.WriteLine("Вы ввели неверное число для координаты. Нужно ввести число от 1 до 9: ");
                    dy = Convert.ToInt32(Console.ReadLine());
                }

                int uron;

                if (lager == false)
                {
                    uron = rnd.Next(20, 50);
                }
                else
                {
                    Console.Write("Введите желаемый урон для своих союзниов(не более 50)");
                    uron = Convert.ToInt32(Console.ReadLine());
                    while (uron <= 0 || uron > 50)
                    {
                        Console.Write("Это неверное количество урона. Попробуйте ввести другое: ");
                        uron = Convert.ToInt32(Console.ReadLine());
                    }
                }
                int full_health = rnd.Next(200, 500);
                int full_heal_number = 1;
                int HP = full_health;
                int heal_counter = 3;

                characters[i] = new Character(name, lager, dx, dy, uron, full_health, full_heal_number, heal_counter, HP);
            }
            character.Igra(characters);
        }
    }
}

