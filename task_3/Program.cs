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
        string FirstName { get; set; }
        string LastName { get; set; }
        string Group { get; set; }
        int Age { get; set; }

        int[] _progRank;
        int[] _adminRank;
        int[] _designRank;
        public Student()
        {
            _progRank = new int[0];
        }  
        void AddRank(ref int[] arr, int rank)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = rank;
        }
        public void AddRangProg(int rang)
        {
            AddRank(ref _progRank, rang);
        }
        public void AddRangAdmin(int rang)
        {
            AddRank(ref _adminRank, rang);
        }
        public void AddRangDesign(int rang)
        {
            AddRank(ref _designRank, rang);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();

            student.AddRangProg(10);
            student.AddRangProg(9);
            student.AddRangProg(12);

            
        }
    }
}
