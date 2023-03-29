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
        protected string NameFigure { get; set; }
        protected double Square { get; set; }
        protected double Perimeter { get; set; }
        public GeometricFigure(string nameFigure)
        {
            NameFigure = nameFigure;
            Square = 0;
            Perimeter = 0;
        }
        protected abstract void SquareFigure();
        protected abstract void PerimeterFigure();
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
