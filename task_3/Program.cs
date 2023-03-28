//3.Розробити клас, який описує студента. Передбачити в ньому наступні властивості: 
//прізвище, ім'я, по батькові, група, вік, масив оцінок з програмування, адміністрування та дизайну. 
//А також додати методи роботи з перерахованими даними: можливість встановлення/отримання оцінки, 
//отримання середнього балу по заданому предмету, роздрук даних про студента.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3
{
    public class Student
    {
        int[] _progRank;
        int[] _adminRank;
        int[] _designRank;

        void AddRank(ref int[] arr, int rank)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = rank;
        }
        void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(" {0} ", item);
            }
        }
        float AverageMark(int[] arr)
        {
            return arr.Sum() / (float)arr.Length;
        }

        public Student()
        {
            _progRank = new int[0];
            _adminRank = new int[0];
            _designRank = new int[0];
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Group { get; set; }
        public int Age { get; set; }
        public void AddRangProg(int rang) { AddRank(ref _progRank, rang); }
        public void AddRangAdmin(int rang) { AddRank(ref _adminRank, rang); }
        public void AddRangDesign(int rang) { AddRank(ref _designRank, rang);}
        public void Print()
        {
            Console.Write($" {FirstName} {LastName}\n");
            Console.WriteLine($" Группа: {Group}");
            Console.WriteLine($" Возраст: {Age}");

            Console.WriteLine("\n Успеваемость:\n");

            if (_progRank.Length != 0)
            {
                Console.Write(" Программирование: ");
                PrintArray(_progRank);
                Console.WriteLine("\n Средни бал: {0:f1}\n", AverageMark(_progRank));
            }

            if (_adminRank.Length != 0)
            {
                Console.Write(" Администрирование: ");
                PrintArray(_adminRank);
                Console.WriteLine("\n Средни бал: {0:f1}\n", AverageMark(_adminRank));
            }

            if (_designRank.Length != 0)
            {
                Console.Write(" Дизайн: ");
                PrintArray(_designRank);
                Console.WriteLine("\n Средни бал: {0:f1}\n", AverageMark(_designRank));
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student[] student = new Student[0];
            int count;

            while (true)
            {
                Console.Clear();

                Console.WriteLine("1 - Добавить студента | 2 - Показать студента | 0 - Выход");
                Console.Write(" > ");
                count = Int32.Parse(Console.ReadLine());

                if (count == 0)
                {
                    break;
                }

                switch (count)
                {
                    case 1:
                        Array.Resize(ref student, student.Length + 1);
                        student[student.Length - 1] = new Student();
                        Console.Write("\n Имя: ");
                        student[student.Length - 1].FirstName = Console.ReadLine();
                        Console.Write(" Фамилия: ");
                        student[student.Length - 1].LastName = Console.ReadLine();
                        Console.Write(" Группа: ");
                        student[student.Length - 1].Group = Console.ReadLine();
                        Console.Write(" Возраст: ");
                        student[student.Length - 1].Age = Int32.Parse(Console.ReadLine());

                        while (true)
                        {
                            Console.WriteLine("\n Добавить оценки: ");
                            Console.WriteLine("1 - Программирование | 2 - Администрирование | 3 - Дизайн | 0 - Выход");
                            Console.Write(" > ");
                            count = Int32.Parse(Console.ReadLine());

                            if (count == 0)
                            {
                                break;
                            }

                            switch (count)
                            {
                                case 1:
                                    while (true)
                                    {
                                        int rang = Int32.Parse(Console.ReadLine());
                                        student[student.Length - 1].AddRangProg(rang);

                                        if (!ExitLoop())
                                        {
                                            break;
                                        }
                                    }
                                    break;
                                case 2:
                                    while (true)
                                    {
                                        int rang = Int32.Parse(Console.ReadLine());
                                        student[student.Length - 1].AddRangAdmin(rang);

                                        if (!ExitLoop())
                                        {
                                            break;
                                        }
                                    }
                                    break;
                                case 3:
                                    while (true)
                                    {
                                        int rang = Int32.Parse(Console.ReadLine());
                                        student[student.Length - 1].AddRangDesign(rang);

                                        if (!ExitLoop())
                                        {
                                            break;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case 2:
                        if (student.Length == 0)
                        {
                            Console.WriteLine(" Список студентов пуст");
                            Console.ReadLine();
                            break;
                        }

                        while (true)
                        {
                            Console.Write(" Введите номер студента: ");
                            int index = Int32.Parse(Console.ReadLine());
                            index--;

                            if (index >= 0 && index < student.Length)
                            {
                                student[index].Print();
                                Console.ReadLine();
                                break;
                            }
                            else
                            {
                                Console.WriteLine(" Не верный номер студента");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            
        }

        static bool ExitLoop()
        {
            Console.WriteLine("Продолжить? (y/n): ");
            char ch = Char.Parse(Console.ReadLine());

            if (ch == 'y')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
