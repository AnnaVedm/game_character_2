using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace game_character_2
{
    internal class Character
    {
    private string name;
    private bool lager;
    private int dx;
    private int dy;
    private int uron;
    private int full_health;
    private int full_heal_number;
    private int heal_counter;
    private int HP;
    private int index;

    public Character(string name, bool lager, int dx, int dy, int uron, int full_health, int full_heal_number, int heal_counter, int HP)
    {
        this.name = name;
        this.lager = lager;
        this.dx = dx;
        this.dy = dy;
        this.uron = uron;
        this.full_health = full_health;
        this.heal_counter = heal_counter;
        this.HP = HP;
        this.full_heal_number = full_heal_number;
    }

    public void Igra(Character[] characters) //Тут будет весь процесс игры
    {
        while (true)
        {
            ////for (int i = 0; i < characters.Length; i++)
            //{
            //    characters[i].characters_info(characters, i);
            //    Console.WriteLine();
            //}
            lager = vybor_lager(lager); //если return,то нужна переменная
            vybor_character(characters);
        }
    }

    public void characters_info(Character[] characters, int i)
    {
        Console.WriteLine("\nИНФОРМАЦИЯ О ПЕРСОНАЖЕ");
        Console.WriteLine("________________________");
        Console.WriteLine($"Имя: {characters[i].name}");
        Console.WriteLine($"Лагерь: {characters[i].lager}");
        Console.WriteLine($"х: {characters[i].dx}");
        Console.WriteLine($"y: {characters[i].dy}");
        Console.WriteLine($"Здоровьe: {characters[i].HP}/{characters[i].full_health}♥");
        Console.WriteLine($"Урон: {characters[i].uron}");
        Console.WriteLine($"Лечения: {characters[i].heal_counter}♥♥♥");
        Console.WriteLine($"Восстановления: {characters[i].full_heal_number}♥♥♥");
    }
    public void menu(Character[] characters, int i)
    {
        Console.WriteLine("\nВыберите действие: ");
        Console.WriteLine("1. Сражение");
        Console.WriteLine("2. Смена лагеря");
        Console.WriteLine("3. Полное восстановление♥");
        Console.WriteLine("4. Смена персонажа");
        Console.WriteLine("5. Вывод информации о всех персонажах");
        Console.WriteLine("6. Выход");
        int vybor = Convert.ToInt32(Console.ReadLine());

        switch (vybor)
        {
            case 1:
                Console.WriteLine("Вы выбрали сражение");
                lager = !characters[i].lager;
                protivniki(characters, lager, i);
                break;
            case 2:
                Console.WriteLine("Вы выбрали смену лагеря");
                Smena_lager(characters, i);
                break;
            case 3:
                Console.WriteLine("Вы выбрали полное восстановление♥");
                fullheal(characters, i);
                break;
            case 4:
                Console.WriteLine("Вы выбрали смену персонажа");
                lager = vybor_lager(lager);
                vybor_character(characters);
                break;
            case 5:
                Console.WriteLine("Вы выбрали вывод всех персонажей с информацией");
                vyvod_characters(characters, i);
                menu(characters, i);
                break;
            case 6:
                Environment.Exit(0);
                break;
        }
    }
    private bool vybor_lager(bool lager)
    {
        Console.Write("Выберите лагерь: \n1. true  \n2. false");
        int vybor = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        switch (vybor)
        {
            case 1:
                lager = true;   //союзники
                break;

            case 2:
                lager = false;  //враги
                break;
        }

        return lager;
    }
    private void character_lager(Character[] characters, bool lager) //Вывод игроков по лагерям
    {
        Console.WriteLine("Доступные для выбора персонажи (имя / координаты расположения): \n");
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].lager == lager)
            {
                if (characters[i].HP == 0) //уничтожение(пропуск персонажа)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine($"{i + 1}. {characters[i].name} ({characters[i].dx}, {characters[i].dy})");  // вывод персонажей списком
                }
            }
        }
    }
    private void Smena_lager(Character[] characters, int i)
    {
        characters[i].lager = !characters[i].lager;

        Console.Write($"Лагерь для персонажа {characters[i].name} успешно сменён");

        menu(characters, i);
        //lager = vybor_lager(lager);
    }
    private void vybor_character(Character[] characters)
    {
        character_lager(characters, lager);
        Console.WriteLine("Выберите персонажа: ");
        int vybor = Convert.ToInt32(Console.ReadLine());
        int index = vybor - 1;
        switch (vybor)
        {
            case 1:
                Console.Write($"Вы выбрали персонажа {characters[index].name}. Что вы хотите сделать?");
                characters_info(characters, index);
                menu(characters, index);
                break;
            case 2:
                Console.Write($"Вы выбрали персонажа {characters[index].name}. Что вы хотите сделать?");
                characters_info(characters, index);
                menu(characters, index);
                break;
            case 3:
                Console.Write($"Вы выбрали персонажа {characters[index].name}. Что вы хотите сделать?");
                characters_info(characters, index);
                menu(characters, index);
                break;
            case 4:
                Console.Write($"Вы выбрали персонажа {characters[index].name}. Что вы хотите сделать?");
                characters_info(characters, index);
                menu(characters, index);
                break;
            case 5:
                Console.Write($"Вы выбрали персонажа {characters[index].name}. Что вы хотите сделать?");
                characters_info(characters, index);
                menu(characters, index);
                break;
            case 6:
                Console.Write($"Вы выбрали персонажа {characters[index].name}. Что вы хотите сделать?");
                characters_info(characters, index);
                menu(characters, index);
                break;
        }
    }
    private void protivniki(Character[] characters, bool lager, int k) //Вывод списка противников
    {
        int counter = 0;
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i].HP != 0 && characters[i].lager == lager)
            {
                continue;
            }
            else if (characters[i].HP == 0 && characters[i].lager == lager)
            {
                counter++;
                if (i == characters.Length - 1 && counter == 0)
                {
                    Console.WriteLine("Противников больше не осталось!");
                    menu(characters, k);
                    //Конец игры
                }
            }
        }
        character_lager(characters, lager);
        Console.WriteLine("Выберите противника");
        int vybor = Convert.ToInt32(Console.ReadLine());
        int index = vybor - 1;

        Console.WriteLine("\nВы переместились к противнику. Желаете сразиться с ним?\n1. Да\n2. Нет");
        characters[k].dx = characters[index].dx;
        characters[k].dy = characters[index].dy;
        // Console.WriteLine("Новые координаты: ");
        //Console.WriteLine($"X: {characters[i].dx}");
        //Console.WriteLine($"Y: {characters[i].dy}");

        Console.Write("\nВаш выбор: ");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("Вы выбрали сражение. Начинаем");
                Fight(characters, k, index); //запустили метод сражения и закинули туда нашего игрока с индексом k и противника - i
                break;
            case 2:
                Console.Clear();
                Console.WriteLine("Вы отказались от сражения. Возвращаемся в меню действий");
                menu(characters, k);
                break;
        }
    }
    private void Fight(Character[] characters, int k, int i)
    {
        Console.WriteLine($"\nFIGHT!\n ");
        Console.Write("Нажмите любую клавишу: ");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("ИЗНАЧАЛЬНАЯ ИНФОРМАЦИЯ О ПЕРСОНАЖАХ");
        Console.Write("\n=========================================");
        Console.WriteLine("\nВаш персонаж: \n");
        characters_info(characters, k);
        Console.Write("\n=========================================\n");
        Console.WriteLine("\nПротивник: \n");
        characters_info(characters, i);
        Console.Write("\n=========================================\n");
        Console.WriteLine("\nМЕНЮ БОЯ");
        while (true) //до смерти
        {
            characters[k].HP -= characters[i].uron; //урон от врага
            Console.WriteLine($"Персонаж {characters[k].name} получает от игрока {characters[i].name} в {characters[i].uron} единиц");

            if (characters[k].HP <= 0) //если убит игрок
            {
                characters[k].HP = 0;

                Console.WriteLine($"Ваш уровень здоровья♥: {characters[k].HP}/{characters[k].full_health}");
                Console.WriteLine($"Уровень здоровья противника♥: {characters[i].HP}/{characters[i].full_health}\n");

                Console.WriteLine("\nВаш персонаж убит! :с");
                characters[k].dx = 0;
                characters[k].dy = 0;

                Console.Write("\nНажмите любую клавишу для выхода к главному меню: ");
                Console.ReadKey();
                Console.Clear();

                Igra(characters);  //метод игры заново
            }

            characters[i].HP -= characters[k].uron; //враг наносит урон
            Console.WriteLine($"Персонаж {characters[i].name} получает от игрока {characters[k].name} в {characters[k].uron} единиц\n");

            if (characters[i].HP <= 0)  //если враг убит игроком
            {
                characters[i].HP = 0;

                Console.WriteLine($"Уровень здоровья выбранного персонажа♥: {characters[k].HP}/{characters[k].full_health}");
                Console.WriteLine($"Уровень здоровья противника♥: {characters[i].HP}/{characters[i].full_health}\n");

                Console.WriteLine($"\nВы уничтожили {characters[i].name}! ");
                characters[i].dx = 0;
                characters[i].dy = 0;

                Console.Write("\nНажмите любую клавишу для выхода к меню: ");
                Console.ReadKey();
                Console.Clear();

                menu(characters, k);
            }

            else  //никто еще не умер
            {
                Console.WriteLine($"Ваш уровень здоровья♥: {characters[k].HP}/{characters[k].full_health}");
                Console.WriteLine($"Уровень здоровья противника♥: {characters[i].HP}/{characters[i].full_health}\n");

                Console.WriteLine("\nЧто хотите сделать?\n1. Полечиться♥\n2. Полностью восстановить здоровье♥♥♥\n3. Продолжить бой");

                Console.Write("\nВыбор: ");
                int vybor = Convert.ToInt32(Console.ReadLine());

                switch (vybor)
                {
                    case 1:
                        Console.WriteLine("Вы выбрали Лечение♥");
                        Heal(characters, k);
                        break;
                    case 2:
                        Console.WriteLine("Вы выбрали Полное восстановление♥♥♥");
                        fullheal(characters, k);
                        break;
                    case 3:
                        Console.WriteLine("Вы продолжаете бой\n");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
    private void Heal(Character[] characters, int i)
    {
        if (characters[i].heal_counter == 0)
        {
            Console.WriteLine("Вы больше не можете лечиться. Вы исзрасходовали все свои попытки!♥\n");
        }

        else if (characters[i].HP > 50 && characters[i].heal_counter > 0)
        {
            Console.WriteLine("Ваш уровень здоровья♥ высок для применения лечения (необходимо 50 или ниже). Попробуйте позже\n");
        }

        else
        {
            Random rnd = new Random();
            int healVolume = rnd.Next(10, 30);

            characters[i].HP += healVolume;

            characters[i].heal_counter -= 1; //счётчик возможных восстановлений

            Console.WriteLine($"Вы восстановили {healVolume} здоровья!♥♥♥\n");
            Console.WriteLine($"Уровень здоровья♥: {characters[i].HP}/{characters[i].full_health}");
            Console.WriteLine($"Осталось лечений♥: {characters[i].heal_counter}\n");
        }
    }

    private void fullheal(Character[] characters, int i)  //полное восстановление
    {
        if (characters[i].full_heal_number == 0)
        {
            Console.WriteLine("Вы не можете выбрать полное восстановление, т.к. уже использовали его ранее\n");
        }
        else
        {
            if (characters[i].HP <= 200)
            {
                Console.WriteLine("Вы выбрали Полное восстановление♥♥♥"); //хп меньше 20
                characters[i].HP = characters[i].full_health;
                characters[i].full_heal_number -= 1;

                Console.WriteLine($"Вы полностью восстановили здоровье!♥♥♥\n");
                Console.WriteLine($"Уровень здоровья♥: {characters[i].HP}/{characters[i].full_health}");
                Console.WriteLine($"Осталось восстановлений♥: {characters[i].full_heal_number}\n");
            }
            else
            {
                Console.WriteLine("Вы не можете применить полное восстановление, т.к. уровень вашего здоровья выше 200♥\n");
            }
        }
    }
    private void vyvod_characters(Character[] characters, int i)
    {
        for (i = 0; i < characters.Length; i++)
        {
            if (characters[i].dx != 0)
            {
                characters[i].characters_info(characters, i);
                Console.WriteLine();
            }
        }
    }
}
}
