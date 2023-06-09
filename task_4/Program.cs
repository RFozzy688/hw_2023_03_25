﻿//4.Розробити абстрактний клас «Геометрична Фігура» з методами «Площа Фігури» та «Периметр Фігури». 
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
    public class Rectangle : GeometricFigure
    {
        public int a { get; set; }
        public int b { get; set; }
        public Rectangle(string nameFigure, int a, int b) : base(nameFigure)
        {
            this.a = a;
            this.b = b;
        }
        public override double SquareFigure()
        {
            return Square = a * b;
        }
        public override double PerimeterFigure()
        {
            return Perimeter = (a + b) * 2;
        }
    }
    public class Rhombus : GeometricFigure
    {
        public int a { get; set; }
        public double d1 { get; set; }
        public double d2 { get; set; }
        public Rhombus(string nameFigure, int a, double d1, double d2) : base(nameFigure)
        {
            this.a = a;
            this.d1 = d1;
            this.d2 = d2;
        }
        public override double SquareFigure()
        {
            return Square = 0.5 * d1 * d2;
        }
        public override double PerimeterFigure()
        {
            return Perimeter = a * 4;
        }
    }
    public class Parallelogram : GeometricFigure
    {
        public int a { get; set; }
        public int b { get; set; }
        public double h { get; set; }
        public Parallelogram(string nameFigure, int a, int b, double h) : base(nameFigure)
        {
            this.a = a;
            this.b = b;
            this.h = h;
        }
        public override double SquareFigure()
        {
            return Square = a * h;
        }
        public override double PerimeterFigure()
        {
            return Perimeter = (a + b) * 2;
        }
    }
    public class Trapeze : GeometricFigure
    {
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }
        public int d { get; set; }
        public double h { get; set; }
        public Trapeze(string nameFigure, int a, int b, int c, int d, double h) : base(nameFigure)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.h = h;
        }
        public override double SquareFigure()
        {
            return Square = 0.5 * (a + b) * h;
        }
        public override double PerimeterFigure()
        {
            return Perimeter = a + b + c + d;
        }
    }
    public class Circle : GeometricFigure
    {
        public int r { get; set; }

        public Circle(string nameFigure, int r) : base(nameFigure)
        {
            this.r = r;
        }
        public override double SquareFigure()
        {
            return Square = Math.PI * r * r;
        }
        public override double PerimeterFigure()
        {
            return Perimeter = 2 * Math.PI * r;
        }
    }
    public class Ellipse : GeometricFigure
    {
        public int a { get; set; }
        public int b { get; set; }
        public Ellipse(string nameFigure, int a, int b) : base(nameFigure)
        {
            this.a = a;
            this.b = b;
        }
        public override double SquareFigure()
        {
            return Square = Math.PI * a * b;
        }
        public override double PerimeterFigure()
        {
            return Perimeter = 4 * (Math.PI * a * b + Math.Pow((a - b), 2)) / (a + b);
        }
    }
    public class ComponentFigure
    {
        GeometricFigure[] _geometricFigures;
        public GeometricFigure[] GetGeometricFigures { get { return _geometricFigures; } }
        public ComponentFigure()
        {
            _geometricFigures = new GeometricFigure[0];
        }
        public void AddFigure(GeometricFigure figure)
        {
            Array.Resize(ref _geometricFigures, _geometricFigures.Length + 1);
            _geometricFigures[_geometricFigures.Length - 1] = figure;
            _geometricFigures[_geometricFigures.Length - 1] = figure;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ComponentFigure figure = new ComponentFigure();
            Ellipse ellipse = new Ellipse("эллипс", 6, 4);
            Circle circle = new Circle("круг", 10);
            Rhombus rhombus = new Rhombus("ромб", 10, 10, 15);
            Triangle triangle = new Triangle("треугольник", 5, 6, 7);

            figure.AddFigure(ellipse as GeometricFigure);
            figure.AddFigure(circle as GeometricFigure);
            figure.AddFigure(rhombus as GeometricFigure);
            figure.AddFigure(triangle as GeometricFigure);

            foreach(var item in figure.GetGeometricFigures)
            {
                Console.WriteLine($"фигура: {item.NameFigure}\nплощадь: {item.SquareFigure():0.00}\n");
            }
            
        }
    }
}
