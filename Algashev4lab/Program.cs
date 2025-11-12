using System.Data;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Algashev4lab
{
    internal class Program
    {
        static double getNumber(string title)
        {
            double number = 0;
            while (true)
            {
                Console.Write(title);
                bool success = double.TryParse(Console.ReadLine(), out number);
                if (success == true)
                {
                    Console.Clear();
                    return number;
                }
                else
                {
                    Console.WriteLine("Можно вводить только числа");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        static double Calc()
        {
            const double PI = Math.PI;
            const double E = Math.E;
            double a = getNumber("Введите угол в градусах: ");
            double b = a * PI / 180;
            while (true)
            {
                if (a == 45)
                {
                    Console.WriteLine("Введено некоректное значение, повторите попытку");
                }
                else if (b > 0)
                {
                    double fanc = Math.Round((Math.Sin(b) + Math.Tan(b * 2)) / Math.Sqrt(Math.Log(Math.Pow(E, 2), 3)), 2);
                    return fanc;
                }
            }
        }
        static void Gues(double fanc)
        {
            int i = 3;
            int k = 0;
            while (k < 3)
            {
                double enter = getNumber("Угадывай: ");
                if (enter == fanc)
                {
                    Console.WriteLine("Угадал, молодец.");
                    k = 4;
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (enter != fanc)
                {
                    Console.WriteLine("Не угадал");
                    k++;
                    Console.WriteLine($"Осталось ({i - k}) попытки.");
                }
                if (k == 3)
                {
                    Console.WriteLine($"Ну. это полный анлак, пока!(Правильный ответ был: {fanc})");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        static void Author()
        {
            Console.WriteLine("6103-090301 Батюк Александр Игоревич");
            Console.ReadKey();
            Console.Clear();
        }
        static bool Exit()
        {
            bool cicle = true;
            while (cicle)
            {
                Console.Write("Вы уверены?(д/н): ");
                string confirmation = Console.ReadLine();
                if (confirmation != null && (confirmation.Trim().ToLower() == "д"))
                {
                    return false;
                }
                else if (confirmation != null && (confirmation.Trim().ToLower() == "н"))
                {
                    Console.Clear();
                    cicle = false;
                    return true;
                }
                else
                {
                    Console.WriteLine("Введено неверное значение");
                    Console.ReadKey();
                    Console.Clear();
                    return true;
                }
            }
            return false;
        }
        static int ArraySize()
        {
            int size = (int)getNumber("Введите размер массива: ");
            if (size < 1)
            {
                Console.WriteLine("Ошибка. Массив не может содержать менее 1 элемента. ");
            }
            return size;
        }
        static int[] Array(int size)
        {
            int[] array = new int[size];
            if (size > 0)
            {
                Random rnd = new Random();
                for (int i = 0; i < size; i++)
                {
                    array[i] = rnd.Next(-100, 100);
                }
            }
            else
            {
                Console.WriteLine("Ошибка. Массив не может содержать более 10 элементов или менее 1");
            }
            return array;
        }
        static int[] ArrayClone(int[] array)
        {
            int[] arrayClone = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                arrayClone[i] = array[i];
            }
            return arrayClone;
        }
        static int[] BubbleSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }

            }
            return array;
        }
        static int[] SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int indx = i;
                for (int j = i; j < array.Length; j++)
                {
                    if (array[j] < array[indx])
                    {
                        indx = j;
                    }
                }
                int temp = array[indx];
                array[indx] = array[i];
                array[i] = temp;
            }
            return array;
        }
        static int[] OutputArray(int[] array)
        {
            if (array.Length <= 10)
            {
                foreach (int i in array) Console.Write("{0} ", i);
            }
            else
            {
                Console.WriteLine("Не удасться вывести массив длинной, превышающей 10");
            }
            return array;
        }
        static void PrintField(string[,] gameField)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(gameField[i, j] + " ");
                }
                Console.WriteLine("\n");
            }
        }
        static void Game()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            string[,] gameField = new string[7, 7];
            Random rnd = new Random();
            for (int cols = 0; cols < 6; cols++)
            {
                gameField[cols, 0] = $"{cols}" + " ";
                for (int rows = 0; rows < 6; rows++)
                {
                    gameField[0, rows] = $"{rows}" + " ";
                    for (int i = 1; i < 6; i++)
                    {
                        for (int j = 1; j < 6; j++)
                        {
                            gameField[i, j] = "⬛";
                        }
                    }
                }
            }
            PrintField(gameField);
            string[,] bombField = new string[7, 7];
            int[] indexOfBomb1 = new int[5];
            int[] indexOfBomb2 = new int[5];
            for (int i = 0; i < 5; i++)
            {
                while (true)
                {
                    indexOfBomb1[i] = rnd.Next(1, 6);
                    indexOfBomb2[i] = rnd.Next(1, 6);
                    if (bombField[indexOfBomb1[i], indexOfBomb2[i]] != "💣") 
                    {
                        bombField[indexOfBomb1[i], indexOfBomb2[i]] = "💣";
                        break;
                    }
                }
            }
            while (true)
            {
                int choise = 0;
                while (true)
                {
                    choise = (int)getNumber("Введите номер ячейки, которую хотите открыть: ");
                    if (choise > 55 || choise < 11)
                    {
                        PrintField(gameField);
                        Console.WriteLine("Введено неверное значение ");
                    }
                    else break;
                }
                int colsChoise = choise % 10;
                int rowsChoise = choise / 10;
                if (bombField[colsChoise, rowsChoise] != "💣")
                {
                    int bombsAround = 0;
                    for (int i = -1; i < 2; i++)
                    {
                        for (int j = -1; j < 2; j++)
                        {
                            if (bombField[colsChoise + j, rowsChoise + i] == "💣")
                            {
                                bombsAround++;
                            }
                        }
                    }
                    gameField[colsChoise, rowsChoise] = $"{bombsAround}" + " "; 
                    PrintField(gameField);
                }
                else
                {
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            if (bombField[i, j] == "💣")
                            {
                                gameField[i, j] = "💣";
                            }
                        }
                    }
                    gameField[colsChoise, rowsChoise] = "💥";
                    PrintField(gameField);
                    Console.WriteLine("Вы проиграли");
                    break;
                }
                for (int i = 0; i < 7; i++)
                {
                    int fieldLast = 25;
                    for (int j = 0; j < 7; j++) {
                        if (bombField[colsChoise, rowsChoise] != "💣" && gameField[i,j] == "⬛")
                        {
                            fieldLast--;
                        }
                    }
                    if (fieldLast == 5) Console.WriteLine("Победа!");
                }

            }
            Console.Read();
            Console.Clear();
        }
        static void Arrs() 
        {
            int size = ArraySize();
            int[] array = Array(size);
            int[] output1 = OutputArray(array);
            Console.WriteLine("Начальный массив");
            int[] arrayClone = ArrayClone(array);
            Stopwatch stopwatch = Stopwatch.StartNew();
            int[] sort1 = BubbleSort(array);
            int[] output2 = OutputArray(sort1);
            stopwatch.Stop();
            Console.WriteLine($"Пузырьковая сортировка: {stopwatch.Elapsed.TotalMilliseconds} мс");
            Stopwatch stopwatch2 = Stopwatch.StartNew();
            int[] sort2 = SelectionSort(arrayClone);
            int[] output3 = OutputArray(sort2);
            stopwatch2.Stop();
            Console.WriteLine($"Сортировка выбором: {stopwatch2.Elapsed.TotalMilliseconds} мс");
            if (stopwatch.Elapsed < stopwatch2.Elapsed) Console.WriteLine("Сортировка пузырьком быстрее сортировки выбором. ");
            else Console.WriteLine("Сортировка пузырьком медленнее сортировки выбором ");
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            bool a = true;
            while (a)
            {

                Console.WriteLine("1.Отгадай ответ\n2.Об авторe\n3.Сортировка массива\n4.Сапёр\n5.Выход");
                int choise;
                if (int.TryParse(Console.ReadLine(), out choise))
                {
                    switch (choise)
                    {
                        case 1:
                            {
                                Console.Clear();
                                Gues(Calc());
                                break;
                            }
                        case 2:
                            {
                                Console.Clear();
                                Author();
                                break;
                            }
                        case 3:
                            {
                                Console.Clear();
                                Arrs();
                                Console.Clear();
                                break;
                            }
                        case 4:
                            {
                                Game();
                                break;
                            }
                        case 5:
                            {
                                a = Exit();
                                break;
                            }
                        default:
                            {
                                Console.Clear();
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("Введено неверное значение");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}

