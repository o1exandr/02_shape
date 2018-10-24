/*
 3. Доступ до класу з  іншої збірки.
Створити новий проект(Test_Access) у рішенні(solution) задачі Фігури. 
	Дoдати  посилання на проект з Фігурами( References-> Add references)
	Створити у проекті Test_Access  класи Paralelepiped, Square, успадковані від Rectangle
	Перевизначити для класів( де потрібно) властивість   Square.
Створити список  з різних фігур. Вивести інформацію про фігури та їх площу.

Перевірити чи всі фігури мають площу  більшу  10 (Linq, All())
Перевірити чи є хоч один паралелепід з площею більше 100(Linq, Any())
Знайти перший  з квадратів у якого площа  менша 20 (Linq: Select, Where, First())
Знайти останній  з квадратів у якого площа  менша 20(Linq: Select, Where, Last()

*First() та Last() кидають винятки у випадку неуспішного пошуку
*Можна скористатися  замість First() та Last() методами FirstOrDefault(), LastOrDefault()
https://www.dotnetperls.com/firstordefault
	
 */
using System;
using System.Collections.Generic;
using System.Linq;
using _02_shape;


namespace Test_Access

{
    class Program
    {

        class Paralelepiped : Rectangle
        {
            double length;

            public Paralelepiped(double w = 1, double h = 1, double l = 1)
            {
                Width = w;
                Height = h;
                Length = l;
            }

            public double Length
            {
                get => length;
                set
                {
                    length = value;
                }
            }

            public override double Square => 2 * Width * Height + 2 * Width * Length + 2 * Height * Length;

            public override void Print()
            {
                Console.WriteLine($"{this.GetType().Name,15}\t\tSquare: {Square}\tH x W x L: {Height} x {Width} x {Length}");
            }
        }

        class Quadrate : Rectangle
        {
            double side;

            public Quadrate(double s = 1)
            {
                side = s;
            }

            public double Side
            {
                get => side;
                set
                {
                    side = value;
                }
            }

            public override double Square => 6 * Side * Side;

            public override void Print()
            {
                Console.WriteLine($"{this.GetType().Name,15}\t\tSquare: {Square}\tH x W x L: {Side} x {Side} x {Side}");
            }

            public override string ToString()
            {
                return $"Quadrate with Square: {Square} and side { Side}";
            }
        }

        static void Main(string[] args)
        {
            List<Shape> shapes3D = new List<Shape>
            {
                new Paralelepiped (2, 3, 4),
                new Quadrate (3),
                new Quadrate (1.2),
                new Quadrate (1.4),
                new Paralelepiped (10, 5, 7),
                new Quadrate (1.3),
            };

            // Створити список  з різних фігур. Вивести інформацію про фігури та їх площу.
            foreach (Shape s in shapes3D)
                s.Print();

            // Перевірити чи всі фігури мають площу  більшу  10(Linq, All())
            Console.WriteLine("\nAre all 3D shapes squares > 10:\t{0}", shapes3D.All(x => x.Square > 10));

            // Перевірити чи є хоч один паралелепід з площею більше 100(Linq, Any())
            Console.WriteLine("\nIs there at least one figure with square > 100:\t{0}", shapes3D.Any(x => x.Square > 100));

            // Знайти перший  з квадратів у якого площа менша 20(Linq: Select, Where, First())
            var firstQ20 = from s in shapes3D
                           where s is Quadrate && s.Square < 20
                           select s;
            Console.WriteLine("\nFirst Quadrate with square < 20:\t{0}", firstQ20.FirstOrDefault());

            // Знайти останній  з квадратів у якого площа менша 20(Linq: Select, Where, Last()
            Console.WriteLine("\nLast Quadrate with square < 20: \t{0}", firstQ20.LastOrDefault());

            Console.ReadKey();
        }
    }
}
