//1.Описати структуру Article, що містить такі поля: код товару; Назва товару; ціну товару.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    struct Article
    {
        int _id;
        string _name;
        int _price;

        public Article(int id, string name, int price)
        {
            _id = id;
            _name = name;
            _price = price;
        }
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public void Print()
        {
            Console.WriteLine($"ID: {_id}\nName: {_name}\nPrice: {_price}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Article[] article = new Article[2];

            for (int i = 0; i < article.Length; i++)
            {
                Console.Write("Введите ID: ");
                article[i].ID = Int32.Parse(Console.ReadLine());

                Console.Write("Введите Name: ");
                article[i].Name = Console.ReadLine();

                Console.Write("Введите Price: ");
                article[i].Price = Int32.Parse(Console.ReadLine());

                Console.WriteLine();
            }

            foreach (var item in article)
            {
                item.Print();
                Console.WriteLine();
            }
        }
    }
}
