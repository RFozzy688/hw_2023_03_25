﻿//5. Разработать класс  Fraction , представляющий простую дробь . в классе предусмотреть два поля: числитель
//и знаменатель дроби . Выполнить перегрузку следующих операторов: +,-,*,/,==,!=,<,>,  true  и false.
//Арифметические действия и сравнение выполняется в соответствии с правилами работы с дробями . 
//Оператор  true  возвращает  true  если дробь правильная (числитель меньше знаменателя), оператор false
//возвращает true  если дробь неправильная (числитель больше знаменателя) .

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_5
{
    public class Fraction
    {
        int _numerator;
        int _denominator;
        Fraction FractionReduction(Fraction obj)
        {
            int count = 2;

            while (true)
            {
                if (obj._numerator % count == 0 && obj._denominator % count == 0)
                {
                    obj._numerator /= count;
                    obj._denominator /= count;
                    count = 2;
                }
                else
                {
                    count++;
                }

                if (count > obj._numerator || count > obj._denominator)
                {
                    break;
                }
            }

            return obj;
        }
        public Fraction(int numerator, int denominator)
        {
            _numerator = numerator;

            try
            {
                if (denominator == 0)
                {
                    throw new Exception("Недопустимая дробь");
                }
                else
                {
                    _denominator = denominator;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(-1);
            }
        }
        public override string ToString()
        {
            return $"{_numerator}/{_denominator}";
        }
        public static Fraction operator +(Fraction d1, Fraction d2)
        {
            int totalDenominator = d1._denominator * d2._denominator;
            int numerator = (totalDenominator / d1._denominator) * d1._numerator + 
                (totalDenominator / d2._denominator) * d2._numerator;

            Fraction temp = new Fraction(numerator, totalDenominator);

            return temp.FractionReduction(temp);
        }
        public static Fraction operator -(Fraction d1, Fraction d2)
        {
            int totalDenominator = d1._denominator * d2._denominator;
            int numerator = (totalDenominator / d1._denominator) * d1._numerator -
                (totalDenominator / d2._denominator) * d2._numerator;

            Fraction temp = new Fraction(numerator, totalDenominator);

            return temp.FractionReduction(temp);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Fraction d1 = new Fraction(10, 30);
            Fraction d2 = new Fraction(5, 6);
            Fraction d3 = d1 + d2;
            Fraction d4 = d2 - d1;
            Console.WriteLine(d3);
            Console.WriteLine(d4);
        }
    }
}
