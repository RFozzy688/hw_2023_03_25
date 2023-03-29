//5. Разработать класс  Fraction , представляющий простую дробь . в классе предусмотреть два поля: числитель
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
        Fraction ToFraction(double number)
        {
            string str = number.ToString();
            string[] arrStr = str.Split(',');

            if (arrStr.Length == 2)
            {
                int countDigit = arrStr[1].Length;

                _numerator = (int)(number * countDigit * 10);
                _denominator = countDigit * 10;
            }
            else
            {
                _numerator = (int)number;
                _denominator = 1;
            }

            return this;
        }
        public Fraction()
        {
            _numerator = 0;
            _denominator = 1;
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
        public static Fraction operator *(Fraction d1, Fraction d2)
        {
            int numerator = d1._numerator * d2._numerator;
            int denominator = d1._denominator * d2._denominator;

            Fraction result = new Fraction(numerator, denominator);

            return result.FractionReduction(result);
        }
        public static Fraction operator /(Fraction d1, Fraction d2)
        {
            int numerator = d1._numerator * d2._denominator;
            int denominator = d1._denominator * d2._numerator;

            Fraction result = new Fraction(numerator, denominator);

            return result.FractionReduction(result);
        }
        public static bool operator ==(Fraction d1, Fraction d2)
        {
            d1 = d1.FractionReduction(d1);
            d2 = d2.FractionReduction(d2);

            int totalDenominator = d1._denominator * d2._denominator;
            int numerator_D1 = d1._numerator * (totalDenominator / d1._denominator);
            int numerator_D2 = d2._numerator * (totalDenominator / d2._denominator);

            if (numerator_D1 == numerator_D2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Fraction d1, Fraction d2)
        {
            return d1 == d2 ? false : true;
        }
        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public static bool operator >(Fraction d1, Fraction d2)
        {
            d1 = d1.FractionReduction(d1);
            d2 = d2.FractionReduction(d2);

            int totalDenominator = d1._denominator * d2._denominator;
            int numerator_D1 = d1._numerator * (totalDenominator / d1._denominator);
            int numerator_D2 = d2._numerator * (totalDenominator / d2._denominator);

            if (numerator_D1 > numerator_D2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator <(Fraction d1, Fraction d2)
        {
            return d1 > d2 ? false : true;
        }
        public static bool operator true(Fraction d)
        {
            return d._numerator < d._denominator ? true : false;
        }
        public static bool operator false(Fraction d)
        {
            return d._numerator > d._denominator ? true : false;
        }
        public static Fraction operator +(Fraction d, double num)
        {
            Fraction temp = new Fraction();
            temp.ToFraction(num);

            return d + temp;
        }
        public static Fraction operator +(double num, Fraction d)
        {
            return d + num;
        }
        public static Fraction operator -(Fraction d, double num)
        {
            Fraction temp = new Fraction();
            temp.ToFraction(num);

            return d - temp;
        }
        public static Fraction operator -(double num, Fraction d)
        {
            return d - num;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Fraction d13 = new Fraction(5, 2);
            Fraction d3 = -2.2 + d13/* + 1.5*/;
            Console.WriteLine(d3);
        }
    }
}
