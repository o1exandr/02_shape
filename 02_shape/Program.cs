/*
 2. Створити базовий абстрактний клас Shape. 
	Визначити у класі  абстрактну властивість для читання Square
	Визначити у класі віртуальний  метод Print()  (вивести назву фігури(this.GetType().Name ) та її площу(Square)).
 Створити клас Circle, похідний від  класу Shape. 
	Визначити у класі поле radius
	Реалізувати у класі віртуальну властивість для читання Square(повернути pi * r * r).
	
Створити клас Rectangle, похідний від  класу Shape. 
	Визначити у класі поля висота та ширина.
	Реалізувати у класі віртуальну властивість для читання Square(ширина  * висота).
	
Створити для перевірки список( List<> ) з фігур. Помістити у список різного типу фігури.
	Вивести інформацію про всі фігури
	Впорядкувати список фігур за зростанням площ фігур.
	Зібрати фігури, що є колами  у окремий список(FindAll)

Використати Linq для виконання завдань :
	вибрати всі фігури з площами від 10 до 20(2 способи: from ..., метод Where())
	знайти максимальну площу з прямокутників
	знайти кількість кругів з площею більше 10
	вибрати прямокутники та круги, впорядкувати за зростанням площ
	сформувати колекцію з висот прямокутників
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_shape
{
    class Program
    {
        abstract class Shape
        {
            double Square { get; }
            virtual public void Print()
            {
                Console.WriteLine($"{this.GetType().Name, 10}\tSquare: {Square}");
            }
        }

        class Circle : Shape
        {
            double radius;
            const double pi = 3.14;

            public Circle(double r = 1)
            {
                Radius = r;
            }

            double Radius
            {
                get => radius;
                set
                {
                    radius = value;
                }
            }

            public double Square => pi * Radius * Radius;

            override public void Print()
            {
                Console.WriteLine($"{this.GetType().Name, 10}\tSquare: {Square}");
            }

        }

        class Rectangle : Shape
        {
            double width;
            double height;

            public Rectangle(double w = 1, double h = 1)
            {
                Width = w;
                Height = h;
            }

            double Width
            {
                get => width;
                set
                {
                    width = value;
                }
            }

            double Height
            {
                get => height;
                set
                {
                    height = value;
                }
            }

            public double Square => Width * Height;
            

            override public void Print()
            {
                Console.WriteLine($"{this.GetType().Name, 10}\tSquare: {Square}");
            }

        }

        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>
            {
                new Circle(1.5),
                new Rectangle(2.5, 3),
                new Circle(2),
                new Rectangle(4, 5),
                new Circle(5),
                new Rectangle(4.5, 6),
                new Circle(2.7),
                new Rectangle(5, 3),
            };

            foreach (Shape s in shapes)
                s.Print();
            //shapes.Sort((x, y) => x.Square.CompareTo(y.Square));
            //animals.Sort((x, y) => x.age.CompareTo(y.age));
            Console.WriteLine("\n\tSort by Square");
            foreach (Shape s in shapes)
                s.Print();
            //shapes.FindAll(object);
        }
    }
}
