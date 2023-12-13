using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
namespace ЭТО_ЧТО_ИГРА
{
    internal class Program
    {
        static int mapSize = 25; //размер карты
        static char[,] map; //карта
        //координаты на карте игрока
        static int playerY = 12;
        static int playerX = 12;
        static byte enemies = 10; //количество врагов
        static byte buffs = 5; //количество усилений
        static int health = 5;  // количество аптечек   
        static int PlayerHealth = 50;//хп игрока
        static int EnemyHealth = 30;//хп врага
        static int EnemyCount = 0;//количество врагов
        static int impacForcePlayer = 10;//действие баффа
        static int stepPlayer = 0;// шаги игрока
        static int oldStepToBaff = 0; //шаги для подсчета баффов
        static int remainEnemy = enemies - EnemyCount; //подсчет убитых врагов
        //предыдущие координаты игрока
        static int playerOldY = 0;
        static int playerOldX = 0;

        static void Main(string[] args)
        {
            StartGame();
        }

        /// генерация карты с расставлением врагов, аптечек, баффов
        static void GenerationMap()
        {
            map = new char[mapSize, mapSize]; //карта
            Random random = new Random();
            //создание пустой карты
            for (int i = 0; i < mapSize - 1; i++)
            {
                for (int j = 0; j < mapSize - 1; j++)
                {
                    map[i, j] = '_';
                }
            }

            //В cередину карты ставится игрок
            map[playerY, playerX] = 'P';

            //Временные координаты для проверки занятости ячейки
            int x;
            int y;

            //добавление врагов
            while (enemies > 0)
            {
                x = random.Next(0, mapSize - 1);
                y = random.Next(0, mapSize - 1);

                //если ячейка пуста  - туда добавляется враг
                if (map[x, y] == '_')
                {
                    map[x, y] = 'E';
                    enemies--; //при добавлении врагов уменьшается количество нерасставленных врагов
                }
            }

            //добавление баффов
            while (buffs > 0)
            {
                x = random.Next(0, mapSize - 1);
                y = random.Next(0, mapSize - 1);
                if (map[x, y] == '_')
                {

                    map[x, y] = '^';
                    buffs--;
                }
            }

            //добавление аптечек
            while (health > 0)
            {
                x = random.Next(0, mapSize - 1);
                y = random.Next(0, mapSize - 1);

                if (map[x, y] == '_')
                {

                    map[x, y] = '+';
                    health--;
                }
            }
            UpdateMap(); //отображение заполненной карты на консоли
        }

        //перемещение персонажа
        static void Move()
        {
            while (true)
            {
                playerOldX = playerX;
                playerOldY = playerY;

                //вывод всей нужной информации для пользователя
                Console.ResetColor();
                if (PlayerHealth < 10)
                {
                    Console.SetCursorPosition(mapSize + 5, mapSize / 2 + 1);
                    Console.WriteLine(new String(' ', Console.BufferWidth));
                    Console.WriteLine("Здоровье игрока: " + "0" + PlayerHealth);
                }
                Console.SetCursorPosition(mapSize + 5, mapSize / 2);
                Console.WriteLine("количество шагов: " + stepPlayer);
                Console.SetCursorPosition(mapSize + 5, mapSize / 2 + 1);
                Console.WriteLine("Здоровье игрока: " + PlayerHealth);
                Console.SetCursorPosition(mapSize + 5, mapSize / 2 + 2);
                Console.WriteLine("Количество убитых врагов: " + EnemyCount);
                Console.SetCursorPosition(mapSize + 5, mapSize / 2 + 3);
                Console.WriteLine("Урон: " + impacForcePlayer);


                //проверка на активность баффа
                CheckActivateBaff();

                //проверка на победу
                WinGame();

                //смена координат в зависимости от нажатия клавиш
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        playerX--;
                        stepPlayer++;
                        if (playerX == -1)
                        {
                            playerX = 23;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        playerX++;
                        stepPlayer++;
                        if (playerX == 24)
                        {
                            playerX = 0;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        playerY--;

                        stepPlayer++;
                        if (playerY == -1)
                        {
                            playerY = 24;
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        playerY++;
                        stepPlayer++;
                        if (playerY == 25)
                        {
                            playerY = 0;
                        }
                        break;

                    case ConsoleKey.Escape:
                        ClickForEscape();
                        break;
                }

                Console.Beep(500, 50);

                //проверка на соприкосновение игрока с объектами(B, E, H)
                switch (map[playerX, playerY])
                {
                    case 'E':
                        Damage();
                        break;
                    case '^':
                        Baff();
                        break;
                    case '+':
                        HealthAid();
                        break;
                }


                Console.CursorVisible = false; //скрытный курсов

                //предыдущее положение игрока затирается
                map[playerOldY, playerOldX] = '_';
                Console.SetCursorPosition(playerOldY, playerOldX);
                Console.Write('_');

                //обновленное положение игрока
                map[playerY, playerX] = 'P';
                Console.SetCursorPosition(playerY, playerX);
                Console.Write('P');
            }
        }

        //Взаимодействие с врагом
        static void Damage()
        {
            Console.SetCursorPosition(playerOldY, playerOldX);
            Console.Write('_');
            while (true)
            {
                Console.SetCursorPosition(playerY, playerX);
                Console.SetCursorPosition(playerY, playerX);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write('E');
                Thread.Sleep(100);
                Console.SetCursorPosition(playerY, playerX);
                Console.ResetColor();
                Console.Write('P');
                Thread.Sleep(50);
                Console.SetCursorPosition(playerY, playerX);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write('E');
                Thread.Sleep(50);

                if (EnemyHealth <= 0)
                {
                    EnemyHealth = 30;
                    EnemyCount++;
                    map[playerX, playerY] = '_';
                    Console.SetCursorPosition(playerY, playerX);
                    Console.ResetColor();
                    Console.Write('P');
                    break;
                }

                else if (PlayerHealth <= 1)
                {
                    Console.SetCursorPosition(playerY, playerX);
                    Console.ResetColor();
                    Console.Write('P');
                    Death();
                    break;
                }

                else if (EnemyHealth > 0)
                {
                    PlayerHealth = PlayerHealth - 5;
                    EnemyHealth = EnemyHealth - impacForcePlayer;
                    Console.ResetColor();
                }
            }
        }

        //Проверяем активен ли бафф
        static void CheckActivateBaff()
        {
            if (impacForcePlayer > 10)
            {
                if (20 - (stepPlayer - oldStepToBaff) < 10)
                {
                    Console.SetCursorPosition(0, mapSize + 1);
                    Console.WriteLine(new String(' ', Console.BufferWidth));
                }
                Console.SetCursorPosition(0, mapSize + 1);
                Console.WriteLine("шагов до окончания действия бафа: " + (20 - (stepPlayer - oldStepToBaff)));

                if (stepPlayer - oldStepToBaff == 20)
                {
                    impacForcePlayer = 10;
                    Console.SetCursorPosition(0, mapSize + 1);
                    Console.WriteLine(new String(' ', Console.BufferWidth));
                }
            }
        }

        //Взаимодействие с баффами
        static void Baff()
        {
            oldStepToBaff = stepPlayer;
            impacForcePlayer *= 2;
        }

        //Аптечка
        static void HealthAid()
        {
            PlayerHealth = 50;
        }

        //Победа
        static void WinGame()
        {
            if (EnemyCount == 10)
            {
                Console.Clear();
                Console.SetCursorPosition(mapSize / 2, mapSize / 2);
                Console.Write($"ПОБЕДА, игра пройдена за {stepPlayer} шагов \nНажмите \"J\" для начала новой игры. Нажмите \"H\" для выхода из игры");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.J:
                        StartGame();
                        break;
                    case ConsoleKey.H:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.SetCursorPosition(mapSize / 2, mapSize / 2);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Нажата неверная буква");
                        Thread.Sleep(700);
                        Console.ForegroundColor = ConsoleColor.White;
                        ClickForEscape();
                        break;
                }
            }
        }

        //Экран смерти
        static void Death()
        {
            Console.Clear();
            Console.SetCursorPosition(mapSize / 2, mapSize / 2);
            Console.Write("СМЕРТЬ");
            Console.SetCursorPosition(mapSize / 2, mapSize / 2 + 1);
            Console.Write($"Нажмите кнопку \"j\" чтобы векрнуться на главный экран");
            Console.Beep(784, 150);

            if (Console.ReadKey().Key == ConsoleKey.J)
            {
                Console.Clear();
                BasicSet();
                StartGame();
            }

            else
            {
                Console.SetCursorPosition(mapSize / 2, mapSize / 2 + 1);
                Console.Write(new String(' ', Console.BufferWidth));
                Console.WriteLine("Нажата неверная буква");
                Thread.Sleep(700);
                Death();
            }
        }

        //Стартовое окно
        static void StartGame()
        {
            Console.Clear();
            Console.SetCursorPosition(mapSize / 2, mapSize / 2);
            Console.WriteLine($"Нажмите кнопку \"g\" для старта новой игры");

            if (Console.ReadKey().Key == ConsoleKey.G)
            {
                BasicSet();
                GenerationMap();
                Move();
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(mapSize / 2, mapSize / 2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нажата неверная буква");
                Thread.Sleep(700);
                Console.ForegroundColor = ConsoleColor.White;
                StartGame();
            }
        }

        //базовые настройки
        static void BasicSet()
        {
            mapSize = 25;
            playerY = 12;
            playerX = 12;
            enemies = 10;
            buffs = 5;
            health = 5;
            PlayerHealth = 50;
            EnemyHealth = 30;
            EnemyCount = 0;
            impacForcePlayer = 10;
            stepPlayer = 0;
            oldStepToBaff = 0;
        }

        //Метод, который срабатывает при нажатии на ESC
        static void ClickForEscape()
        {
            SaveGame();
            Console.Clear();
            Console.SetCursorPosition(mapSize / 2, mapSize / 2);
            Console.Write($"Нажмите \"j\" что бы загрузиить последнее сохранение, \"r\" что бы перезапустить игру");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.J:
                    Console.Clear();
                    Console.SetCursorPosition(mapSize / 2, mapSize / 2);
                    Console.Write($"Игра закрыта");
                    LoadGame();
                    break;
                case ConsoleKey.R:
                    StartGame();
                    ClickForEscape();
                    break;
                default:
                    Console.Clear();
                    Console.SetCursorPosition(mapSize / 2, mapSize / 2);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Нажата неверная буква");
                    Thread.Sleep(700);
                    Console.ForegroundColor = ConsoleColor.White;
                    ClickForEscape();
                    break;

            }

        }

        //Загрузка сохранения
        static void LoadGame()
        {
            Console.Clear();
            string path = "save"; //файл с символами сущностей, координатами и параметрами
            Console.CursorVisible = false;
            using (FileStream file = new FileStream(path + ".txt", FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    Console.Clear();
                    string[] lines = reader.ReadToEnd().Split(); //заполнение массива данными из файла
                    int count = 0; //для подсчёта данных с линий
                    int X = 0; int Y = 0; //для считывания координат сущностей

                    //создание пустой карты
                    for (int i = 0; i < mapSize; i++)
                    {
                        for (int j = 0; j < mapSize; j++)
                        {
                            map[i, j] = '_';
                            Console.Write(map[i, j]);
                        }
                        Console.WriteLine(map[i, 0]);
                    }

                    //запись в массив map сущностей, согласно их координатам
                    while (true)
                    {
                        if (Convert.ToChar(lines[count]) == 'E')
                        {
                            Y = Convert.ToInt32(lines[count + 1]);
                            X = Convert.ToInt32(lines[count + 2]);
                            map[Y, X] = Convert.ToChar(lines[count]);
                            count += 3;
                        }
                        else if (Convert.ToChar(lines[count]) == '+')
                        {
                            Y = Convert.ToInt32(lines[count + 1]);
                            X = Convert.ToInt32(lines[count + 2]);
                            Console.ForegroundColor = ConsoleColor.Red;
                            map[Y, X] = Convert.ToChar(lines[count]);
                            count += 3;
                        }
                        else if (Convert.ToChar(lines[count]) == '^')
                        {
                            Y = Convert.ToInt32(lines[count + 1]);
                            X = Convert.ToInt32(lines[count + 2]);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            map[Y, X] = Convert.ToChar(lines[count]);
                            count += 3;
                        }
                        else if (Convert.ToChar(lines[count]) == '*')
                        {
                            //переход к записи параметров
                            break;
                        }
                        else
                        {
                            count += 3;
                        }
                    }
                    //запись параметров
                    playerX = Convert.ToInt32(lines[count + 1]);
                    playerY = Convert.ToInt32(lines[count + 2]);
                    remainEnemy = Convert.ToInt32(lines[count + 3]);
                    buffs = Convert.ToByte(lines[count + 4]);
                    health = Convert.ToInt32(lines[count + 5]);
                    PlayerHealth = Convert.ToInt32(lines[count + 6]);
                    EnemyHealth = Convert.ToInt32(lines[count + 7]);
                    impacForcePlayer = Convert.ToInt32(lines[count + 8]);
                    stepPlayer = Convert.ToInt32(lines[count + 9]);
                    oldStepToBaff = Convert.ToInt32(lines[count + 10]);

                    //запись в массив игрока
                    map[playerX, playerY] = 'P';
                    UpdateMap(); //вывод карты по получившимся параметрам
                }

            }
        }
        //сохранение игры
        static void SaveGame()
        {
            string path = "save"; //файл с символами сущностей, координатами и параметрами
            Console.CursorVisible = false;
            using (FileStream file = new FileStream(path + ".txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    for (int i = 0; i < mapSize; i++) //цикл для записи в файл координат сущностей и параметров игры
                    {
                        for (int j = 0; j < mapSize; j++)
                        {
                            if (map[i, j] != '_' && map[i, j] != 'P')
                            {
                                writer.Write(map[i, j] + " ");
                                writer.Write(i + " ");
                                writer.Write(j + " ");
                            }
                        }
                    }
                    //запись всех параметров в момент сохранения игры
                    writer.Write("* "); //стоп-символ (применяется в LoadGame()
                    writer.Write(playerX + " ");
                    writer.Write(playerY + " ");
                    writer.Write(remainEnemy + " ");
                    writer.Write(buffs + " ");
                    writer.Write(health + " ");
                    writer.Write(PlayerHealth + " ");
                    writer.Write(EnemyHealth + " ");
                    writer.Write(impacForcePlayer + " ");
                    writer.Write(stepPlayer + " ");
                    writer.Write(oldStepToBaff + " ");

                }
            }
        }
        static void UpdateMap()
        {
            Console.Clear();

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    //раскраска сущностей и их вывод
                    switch (map[i, j])
                    {
                        case '+':
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        case '^':
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        case 'E':
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        case 'P':
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(map[i, j]);
                            Console.ResetColor();
                            break;
                        default:
                            Console.Write(map[i, j]);
                            break;
                    }
                }
                Console.WriteLine(map[i, 0]);
            }
        }
    }
}
