//2.Описати перелік(enum) ArticleType, який визначає типи товарів, і додати відповідне
//поле в структуру Article із завдання №1.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    enum ArticleType
    {
        Empty, FrozenFood, Food, DomesticChemistry, BuildingMaterials, Petrol
    }
    struct Article
    {
        ArticleType _articleType;
        int _id;
        string _name;
        int _price;

        public Article(ArticleType articleType, int id, string name, int price)
        {
            _articleType = ArticleType.Empty;
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
        public ArticleType EArticleType
        {
            get { return _articleType; }
            set { _articleType = value; }
        }

        public void Print()
        {
            Console.WriteLine($"ArticleType: {_articleType}\nID: {_id}\nName: {_name}\nPrice: {_price}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Article[] article = new Article[2];
            string[] str;
            int number;
            str = Enum.GetNames(typeof(ArticleType));
            PrintNamesArticleType(str);

            for (int i = 0; i < article.Length; i++)
            {
                Console.Write("\nВведите номер ArticleType: ");
                number = Int32.Parse(Console.ReadLine());

                if (number >= 0 && number <= 5 )
                {
                    article[i].EArticleType = (ArticleType)number;
                }
                else
                {
                    Console.WriteLine("Не верно введенный номер!!!");
                    i--;
                    continue;
                }

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

        public static void PrintNamesArticleType(string[] names)
        {
            Console.WriteLine();

            for (int i = 0; i < names.Length; i++)
            {
                Console.Write($" {i} - {names[i]} ");
            }
            Console.WriteLine();
        }
    }
}
