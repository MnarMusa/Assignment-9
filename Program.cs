#region Project-1
/**using System;

public class Point3D : IComparable, ICloneable
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }


    public Point3D() : this(0, 0, 0) { }

    public Point3D(int x) : this(x, 0, 0) { }

    public Point3D(int x, int y) : this(x, y, 0) { }

    public Point3D(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }


    public override string ToString()
    {
        return $"Point Coordinates: ({X}, {Y}, {Z})";
    }


    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Point3D p = (Point3D)obj;
        return X == p.X && Y == p.Y && Z == p.Z;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z);
    }

    public static bool operator ==(Point3D? p1, Point3D? p2)
    {
        if (ReferenceEquals(p1, p2))
            return true;
        if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
            return false;
        return p1.Equals(p2);
    }

    public static bool operator !=(Point3D? p1, Point3D? p2)
    {
        return !(p1 == p2);
    }


    public int CompareTo(object? obj)
    {
        if (obj == null) return 1;

        Point3D? other = obj as Point3D;
        if (other != null)
        {
            int compareX = X.CompareTo(other.X);
            if (compareX != 0) return compareX;

            int compareY = Y.CompareTo(other.Y);
            if (compareY != 0) return compareY;

            return Z.CompareTo(other.Z);
        }
        else
        {
            throw new ArgumentException("Object is not a Point3D");
        }
    }


    public object Clone()
    {
        return new Point3D(X, Y, Z);
    }
}

public class Program
{
    public static void Main()
    {

        Point3D p = new Point3D(10, 10, 10);
        Console.WriteLine(p.ToString());

        Point3D P1 = ReadPointFromConsole("P1");
        Point3D P2 = ReadPointFromConsole("P2");

        if (P1 == P2)
            Console.WriteLine("P1 and P2 are equal.");
        else
            Console.WriteLine("P1 and P2 are not equal.");

        Point3D[] points = new Point3D[]
        {
            new Point3D(3, 4, 5),
            new Point3D(1, 2, 3),
            new Point3D(6, 7, 8),
            new Point3D(2, 2, 2)
        };

        Array.Sort(points);
        foreach (var point in points)
        {
            Console.WriteLine(point.ToString());
        }


        Point3D P3 = (Point3D)P1.Clone();
        Console.WriteLine("P3 (clone of P1): " + P3.ToString());
    }

    private static Point3D ReadPointFromConsole(string pointName)
    {
        int x = ReadCoordinate(pointName, "X");
        int y = ReadCoordinate(pointName, "Y");
        int z = ReadCoordinate(pointName, "Z");

        return new Point3D(x, y, z);
    }

    private static int ReadCoordinate(string pointName, string coordinateName)
    {
        int coordinate;
        while (true)
        {
            Console.Write($"Enter coordinate {coordinateName} for {pointName}: ");
            if (int.TryParse(Console.ReadLine(), out coordinate))
            {
                break;
            }
            else
            {
                Console.WriteLine($"Invalid input for {coordinateName} coordinate. Please enter a valid integer.");
            }
        }
        return coordinate;
    }
}*/

#endregion


#region project-2
/**using System;

public static class Maths
{

    public static int Add(int a, int b)
    {
        return a + b;
    }


    public static int Subtract(int a, int b)
    {
        return a - b;
    }


    public static int Multiply(int a, int b)
    {
        return a * b;
    }


    public static double Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Division by zero is not allowed.");
        }
        return (double)a / b;
    }
}

public class Program
{
    public static void Main()
    {
        int a = 10;
        int b = 5;

        Console.WriteLine($"Add: {a} + {b} = {Maths.Add(a, b)}");
        Console.WriteLine($"Subtract: {a} - {b} = {Maths.Subtract(a, b)}");
        Console.WriteLine($"Multiply: {a} * {b} = {Maths.Multiply(a, b)}");
        Console.WriteLine($"Divide: {a} / {b} = {Maths.Divide(a, b)}");
    }
} */
#endregion


#region Project-3
/**using System;

public class Duration
{
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public int Seconds { get; set; }


    public Duration(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
        Ranges();
    }


    public Duration(int totalSeconds)
    {
        Hours = totalSeconds / 3600;
        totalSeconds %= 3600;
        Minutes = totalSeconds / 60;
        Seconds = totalSeconds % 60;
        Ranges();
    }


    public override string ToString()
    {
        return $"Hours: {Hours}, Minutes: {Minutes}, Seconds: {Seconds}";
    }


    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Duration other = (Duration)obj;
        return Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds;
    }


    public override int GetHashCode()
    {
        return HashCode.Combine(Hours, Minutes, Seconds);
    }


    private void Ranges()
    {
        if (Seconds >= 60)
        {
            Minutes += Seconds / 60;
            Seconds %= 60;
        }
        if (Minutes >= 60)
        {
            Hours += Minutes / 60;
            Minutes %= 60;
        }
    }


    public static Duration operator +(Duration d1, Duration d2)
    {
        return new Duration(d1.Hours + d2.Hours, d1.Minutes + d2.Minutes, d1.Seconds + d2.Seconds);
    }

    public static Duration operator +(Duration d, int seconds)
    {
        return new Duration(d.ToTotalSeconds() + seconds);
    }

    public static Duration operator +(int seconds, Duration d)
    {
        return new Duration(d.ToTotalSeconds() + seconds);
    }

    public static Duration operator ++(Duration d)
    {
        return new Duration(d.ToTotalSeconds() + 60);
    }

    public static Duration operator --(Duration d)
    {
        return new Duration(d.ToTotalSeconds() - 60);
    }

    public static Duration operator -(Duration d1, Duration d2)
    {
        return new Duration(d1.ToTotalSeconds() - d2.ToTotalSeconds());
    }

    public static bool operator >(Duration d1, Duration d2)
    {
        return d1.ToTotalSeconds() > d2.ToTotalSeconds();
    }

    public static bool operator <(Duration d1, Duration d2)
    {
        return d1.ToTotalSeconds() < d2.ToTotalSeconds();
    }

    public static bool operator >=(Duration d1, Duration d2)
    {
        return d1.ToTotalSeconds() >= d2.ToTotalSeconds();
    }

    public static bool operator <=(Duration d1, Duration d2)
    {
        return d1.ToTotalSeconds() <= d2.ToTotalSeconds();
    }

    public static implicit operator bool(Duration d)
    {
        return d.ToTotalSeconds() > 0;
    }

    public static explicit operator DateTime(Duration d)
    {
        return new DateTime(1, 1, 1, d.Hours, d.Minutes, d.Seconds);
    }

    private int ToTotalSeconds()
    {
        return Hours * 3600 + Minutes * 60 + Seconds;
    }
}

public class Program
{
    public static void Main()
    {

        Duration D1 = new Duration(1, 10, 15);
        Console.WriteLine(D1.ToString());

        Duration D2 = new Duration(3600);
        Console.WriteLine(D2.ToString());

        Duration D3 = new Duration(7800);
        Console.WriteLine(D3.ToString());

        Duration D4 = new Duration(666);
        Console.WriteLine(D4.ToString());

        Duration D5 = D1 + D3;
        Console.WriteLine(D5.ToString());

        Duration D6 = D1 + 7800;
        Console.WriteLine(D6.ToString());

        Duration D7 = 666 + D4;
        Console.WriteLine(D7.ToString());

        Duration D8 = ++D1;
        Console.WriteLine(D8.ToString());

        Duration D9 = --D2;
        Console.WriteLine(D9.ToString());

        Duration D10 = D1 - D3;
        Console.WriteLine(D10.ToString());

        if (D1 > D2)
            Console.WriteLine("D1 is greater than D2.");
        else
            Console.WriteLine("D1 is not greater than D2.");

        if (D1 <= D3)
            Console.WriteLine("D1 is less than or equal to D3.");


        if (D1)
            Console.WriteLine("D1 is non-zero.");

        DateTime dt = (DateTime)D1;
        Console.WriteLine($"DateTime: {dt.Hour}:{dt.Minute}:{dt.Second}");
    }
} */
#endregion
