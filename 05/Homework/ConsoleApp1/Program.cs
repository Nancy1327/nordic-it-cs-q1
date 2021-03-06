﻿using System;

namespace ConsoleApp1
{
    [Flags]
    enum Form : int
    {
        Circle = 1,
        Equilateraltriangle = 2,
        Rectangle = 3,
    };
    class Program
    {

        static void Main(string[] args)
        {
            foreach (var value in Enum.GetValues(typeof(Form)))
            {

                Console.WriteLine("{0,-3}  {1}", ((Form)value) + ":", (int)value);
            }
            Console.WriteLine("Please enter form:");
            int typeForm = default;
            
                try
                {
                    typeForm = int.Parse(Console.ReadLine());
                    if (typeForm < 1 || typeForm > 3)
                    {
                        throw new ArgumentException($" Number  don't not match form");

                    }
                }
                catch (FormatException exp)
                {

                    Console.WriteLine(exp.Message);
                    Console.WriteLine(exp.StackTrace);
                }
                catch (ArgumentException exp)
                {

                    Console.WriteLine(exp.Message);
                    Console.WriteLine(exp.StackTrace);
                }
            
            try
            {
                switch (typeForm)
                {
                    case 1:
                        {
                            double radius = default;

                            Console.WriteLine("Enter the diameter");
                            var diameter = double.Parse(Console.ReadLine());
                            radius = diameter / 2;
                            if (radius < 0)
                            {
                                throw new ArgumentException("The radous must be greated than 0");
                            }
                            
                            var area = Math.PI * Math.Pow(radius, 2);
                            var perimetr = 2 * Math.PI * radius;
                            Console.WriteLine($"Area of a circle: {area}");
                            Console.WriteLine($"Circle perimeter: {perimetr}");

                        }
                        break;
                    case 2:
                        {
                            double longside = default;

                            Console.WriteLine("Enter the long side:");
                            longside = double.Parse(Console.ReadLine());
                            if (longside < 0)
                            {
                                throw new ArgumentException("The radous must be greated than 0");
                            }
                            var area = (Math.Sqrt(3) / 4) * Math.Pow(longside, 2);
                            var perimetr = 3 * longside;
                            Console.WriteLine($"Area of an equilateral triangle: {area}");
                            Console.WriteLine($"Perimeter of an equilateral triangle: {perimetr}");
                        }
                        break;
                    case 3:
                        {
                            double longside = default;
                            double heightside = default;

                            Console.WriteLine("Enter the long of the side:");
                            longside = double.Parse(Console.ReadLine());
                            if (longside < 0)
                            {
                                throw new ArgumentException("The radous must be greated than 0");
                            }
                            Console.WriteLine("Enter the height of the side:");
                            heightside = double.Parse(Console.ReadLine());
                            if (heightside < 0)
                            {
                                throw new ArgumentException("The radous must be greated than 0");
                            }
                            var area = longside * heightside;
                            var perimetr = 2 * longside + 2 * heightside;
                            Console.WriteLine($"The area of a rectangle: {area}");
                            Console.WriteLine($"The perimeter of the rectangle: {perimetr}");
                        }
                        break;
                }
            }
            catch (FormatException rad)
            {
                Console.WriteLine(rad.Message);
                Console.WriteLine(rad.StackTrace);
            }
            catch (ArgumentException rad)
            {

                Console.WriteLine(rad.Message);
                Console.WriteLine(rad.StackTrace);
            }
            Console.ReadKey();

        }
    }
}
