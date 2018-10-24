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

namespace _02_shape
{
    public abstract class Shape
    {
        virtual public double Square { get; }
        virtual public void Print()
        {
            Console.WriteLine($"{this.GetType().Name,10}\tSquare: {Square}");
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

        public override double Square => pi * Radius * Radius;

        public override void Print()
        {
            Console.WriteLine($"{this.GetType().Name,10}\tSquare: {Square}\t\tRadius: {Radius}");
        }

    }

    public class Rectangle : Shape
    {
        double width;
        double height;

        public Rectangle(double w = 1, double h = 1)
        {
            Width = w;
            Height = h;
        }

        public double Width
        {
            get => width;
            set
            {
                width = value;
            }
        }

        public double Height
        {
            get => height;
            set
            {
                height = value;
            }
        }

        public override double Square => Width * Height;


        public override void Print()
        {
            Console.WriteLine($"{this.GetType().Name,10}\tSquare: {Square}\t\tH x W: {Height} x {Width}");
        }

    }

    class Program
    {
        
        

        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>
            {
                new Circle(1.5),
                new Rectangle(2.5, 4),
                new Circle(2),
                new Rectangle(4, 5),
                new Circle(5),
                new Rectangle(4.5, 6),
                new Circle(2.7),
                new Circle(1),
                new Rectangle(5, 3),
            };

            //Вивести інформацію про всі фігури
            foreach (Shape s in shapes)
                s.Print();

            //Впорядкувати список фігур за зростанням площ фігур.
            shapes.Sort((x, y) => x.Square.CompareTo(y.Square));
            Console.WriteLine("\n\tSort by Square");
            foreach (Shape s in shapes)
                s.Print();

            //Зібрати фігури, що є колами  у окремий список(FindAll)
            var circles = shapes.FindAll(x => x is Circle);
            Console.WriteLine("\n\tOnly Circles");
            foreach (Shape c in circles)
                c.Print();

            // вибрати всі фігури з площами від 10 до 20(2 способи: from..., метод Where())
            var shapes_10_20 =
                from s in shapes
                where s.Square >= 10 && s.Square <= 20
                select s;

            Console.WriteLine("\n\tShapes with squares between 10 and 20 (from)");
            foreach (Shape t in shapes_10_20)
                t.Print();

            var shapes_10_20_ = shapes.Where(x => x.Square >= 10 && x.Square <= 20); 
            Console.WriteLine("\n\tShapes with squares between 10 and 20 (Where())");
            foreach (Shape t in shapes_10_20_)
                t.Print();

            // знайти максимальну площу з прямокутників
            var rectangles = shapes.FindAll(x => x is Rectangle);
            Console.WriteLine("\nMax square of rectangle:\t{0}", rectangles.Max(x => x.Square));

            // знайти кількість кругів з площею більше 10
            var circles_10 = circles.Where(x => x.Square >= 10);
            Console.WriteLine("\nQ-ty of circles with square > 10:\t{0}", circles_10.Count());

            // вибрати прямокутники та круги, впорядкувати за зростанням площ
            Console.WriteLine("\n\tSort by type/square");
            var shapes2 = circles.Concat(rectangles);  // списки посортовані вище в інших завданнях
            foreach (Shape s in shapes2)
                s.Print();

            // сформувати колекцію з висот прямокутників
            Console.WriteLine("\n\tHeigths of rectangles");
            var heights =
               from h in shapes
               where h is Rectangle
               select ((Rectangle)h).Height;
            int count = 0;
            foreach (var h in heights)
                Console.WriteLine("({0}) Height of rectangle:\t{1}",count++, h);

            Console.ReadKey();
        }
    }
}
