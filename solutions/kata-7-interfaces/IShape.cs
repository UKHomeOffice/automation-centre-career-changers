public interface IShape
{
    double GetArea();
    double GetPerimeter();
}

public class Circle : IShape
{
    private double _radius;

    public Circle(double radius)
    {
        _radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * _radius * _radius;
    }

    public double GetPerimeter()
    {
        return 2 * Math.PI * _radius;
    }
}



public class Rectangle : IShape
{
    private double _width;
    private double _height;

    public Rectangle(double width, double height)
    {
        _width = width;
        _height = height;
    }

    public double GetArea()
    {
        return _width * _height;
    }

    public double GetPerimeter()
    {
        return 2 * (_width + _height);
    }
}

public class Triangle : IShape
{
    private double _sideA;
    private double _sideB;
    private double _sideC;

    public Triangle(double sideA, double sideB, double sideC)
    {
        _sideA = sideA;
        _sideB = sideB;
        _sideC = sideC;
    }

    public double GetArea()
    {
        double s = GetPerimeter() / 2;
        return Math.Sqrt(s * (s - _sideA) * (s - _sideB) * (s - _sideC));
    }

    public double GetPerimeter()
    {
        return _sideA + _sideB + _sideC;
    }
}