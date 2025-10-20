namespace kata_7_interfaces;

class Program
{
    static void Main(string[] args)
    {
        List<IShape> _shapes = new List<IShape>()
        {
            new Circle(5),
            new Rectangle(4, 6),
            new Triangle(3, 4, 5)
        };

        foreach (var shape in _shapes)
        {
            Console.WriteLine($"Shape: {shape.GetType().Name}");
            Console.WriteLine($"Area: {shape.GetArea()}");
            Console.WriteLine($"Perimeter: {shape.GetPerimeter()}\n");
        }
    }
}
