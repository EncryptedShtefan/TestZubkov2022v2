namespace TestZubkov2022v2
{
    public class Program
    {
        public class Point
        {
            public double X;
            public double Y;

            //точка в двумерной плоскости
            public Point(double x = 0.0, double y = 0.0)
            {
                X = x;
                Y = y;
            }
        }

        public class Triangle
        {
            public Point[] points;
            private const int PointsAmount = 3;

            public Triangle() => points = new Point[PointsAmount];

            //считывание данных
            public void Read()
            {
                //1
                for (var i = 0; i < PointsAmount; i++)
                {
                    //2
                    Console.Write($"Enter x of {i} vertex: ");
                    var x = double.Parse(Console.ReadLine());

                    Console.Write($"Enter y of {i} vertex: ");
                    var y = double.Parse(Console.ReadLine());

                    points[i] = new Point(x, y);
                }
                //3
            }

            //содержание
            public bool Contains(Triangle another)
            {
                var isContainsAnotherTriangle = true; // 1

                foreach (var point in another.points) // 2
                {
                    // 3 
                    var a = (points[0].X - point.X) * (points[1].Y - points[0].Y) - (points[1].X - points[0].X) * (points[0].Y - point.Y); 
                    var b = (points[1].X - point.X) * (points[2].Y - points[1].Y) - (points[2].X - points[1].X) * (points[1].Y - point.Y); 
                    var c = (points[2].X - point.X) * (points[0].Y - points[2].Y) - (points[0].X - points[2].X) * (points[2].Y - point.Y); 

                    //4
                    if (a >= 0)
                    {
                        //5
                        if (b >= 0)

                        {
                            //6
                            if (c >= 0)
                            {
                                //7
                                isContainsAnotherTriangle &= true;
                            }
                            else
                                //8
                                isContainsAnotherTriangle &= false;
                        }
                        else
                            //9
                            isContainsAnotherTriangle &= false;
                    }  //10
                    else if (a <= 0)
                    {
                        //11
                        if (b <= 0)
                        {
                            //12
                            if (c <= 0)
                            {
                                //13
                                isContainsAnotherTriangle &= true;
                            }
                            else
                                //14
                                isContainsAnotherTriangle &= false;
                        }
                        else //15
                            isContainsAnotherTriangle &= false;
                    } //16

                    //isContainsAnotherTriangle &= a >= 0 && b >= 0 && c >= 0 || a <= 0 && b <= 0 && c <= 0;
                }


                return isContainsAnotherTriangle; // 17

                // 18
            }

            //Длина отрезка
            private double LineLength(Point p1, Point p2)
            {
                //1
                var xd = p2.X - p1.X;
                var yd = p2.Y - p1.Y;

                //2
                return Math.Sqrt(xd * xd + yd * yd);
            }

            private double Perimeter() => LineLength(points[0], points[1]) + LineLength(points[1], points[2]) + LineLength(points[2], points[0]);

            public double Area()
            {
                //1
                var p = Perimeter() / 2;

                var a = LineLength(points[0], points[1]);
                var b = LineLength(points[1], points[2]);
                var c = LineLength(points[2], points[0]);

                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                //2
            }

            public bool EqualTo(Triangle another) =>
                points[0].X == another.points[0].X && points[0].Y == another.points[0].Y &&
                points[1].X == another.points[1].X && points[1].Y == another.points[1].Y &&
                points[2].X == another.points[2].X && points[2].Y == another.points[2].Y;
        }

        static void Main(string[] args)
        {
            //
            Console.WriteLine("Enter data of first triangle");
            var t1 = new Triangle();
            t1.Read();

            Console.WriteLine("Enter data of second triangle");
            var t2 = new Triangle();
            t2.Read();

            var indicationLargerTriangle = Convert.ToInt32(t1.Contains(t2)) - Convert.ToInt32(t2.Contains(t1));
            //2
            switch (indicationLargerTriangle)
            {
                case 1:
                    Console.WriteLine("First bigger");
                    Console.WriteLine($"Free area: {t1.Area() - t2.Area()}");
                    break;
                case -1:
                    Console.WriteLine("Bad result! We find, that");
                    Console.WriteLine("Second bigger");
                    Console.WriteLine($"Free area: {t2.Area() - t1.Area()}");
                    break;
                case 0:
                    if (t1.EqualTo(t2))
                    {
                        Console.WriteLine("Identical");
                        Console.WriteLine("Free area: 0");
                    }
                    else
                        Console.WriteLine("One does not contain the other");
                    break;
            }
        }
    }
}