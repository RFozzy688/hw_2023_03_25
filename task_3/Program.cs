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

            Console.Write(" Программирование: ");
            PrintArray(_progRank);
            Console.WriteLine("\n Средни бал: {0:f1}\n", AverageMark(_progRank));

            Console.Write(" Администрирование: ");
            PrintArray(_adminRank);
            Console.WriteLine("\n Средни бал: {0:f1}\n", AverageMark(_adminRank));

            Console.Write(" Дизайн: ");
            PrintArray(_designRank);
            Console.WriteLine("\n Средни бал: {0:f1}\n", AverageMark(_designRank));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();

            student.FirstName = "Vasya";
            student.LastName = "Pupkin";
            student.Group = "SPY 221";
            student.Age = 30;

            student.AddRangProg(11);
            student.AddRangProg(9);
            student.AddRangProg(12);

            student.AddRangAdmin(10);
            student.AddRangAdmin(9);
            student.AddRangAdmin(12);

            student.AddRangDesign(10);
            student.AddRangDesign(9);
            student.AddRangDesign(12);

            student.Print();
        }
    }
}
