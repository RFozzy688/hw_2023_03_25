//4.Розробити абстрактний клас «Геометрична Фігура» з методами «Площа Фігури» та «Периметр Фігури». 
//Розробити класи-спадкоємці: Трикутник, Квадрат, Ромб, Прямокутник, Паралелограм, Трапеція, Коло, Еліпс.
//Реалізувати конструктори, що є унікальними об'єктами класів. Реалізувати клас "Складова Фігура", 
//який може складатися з будь-якої кількості "Геометричних Фігур". Для цього класу визначають метод 
//знаходження площі фігури.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_4
{
    public abstract class GeometricFigure
    {
        public string NameFigure { get; set; }
        protected double Square { get; set; }
        protected double Perimeter { get; set; }
        public GeometricFigure(string nameFigure)
        {
            NameFigure = nameFigure;
            Square = 0;
            Perimeter = 0;
        }
        public abstract double SquareFigure();
        public abstract double PerimeterFigure();
    }
    public class Triangle : GeometricFigure
    {
        double _halfPerimeter;
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }
        public Triangle(string nameFigure, int a, int b, int c) : base(nameFigure)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            _halfPerimeter = 0;
        }
        public override double SquareFigure()
        {
            _halfPerimeter = (a + b + c) / 2.0;
            Square = Math.Sqrt(_halfPerimeter * (_halfPerimeter - a) * (_halfPerimeter - b) * (_halfPerimeter - c));

            return Square;
        }
        public override double PerimeterFigure()
        {
            Perimeter = a + b + c;

            return Perimeter;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GeometricFigure geometricFigure = new Triangle("треугольник", 5, 5, 5);
            Console.WriteLine("название: {0}", geometricFigure.NameFigure);
            Console.WriteLine("периметр: {0}", geometricFigure.PerimeterFigure());
            Console.WriteLine("площадь: {0:0.00}", geometricFigure.SquareFigure());
            
        }
    }
}
