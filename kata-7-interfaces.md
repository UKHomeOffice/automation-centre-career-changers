# Kata 7 - Interfaces

## Objective

Create an interface `IShape` with methods to calculate area and perimeter. Implement this interface in classes for different shapes like `Circle`, `Rectangle`, and `Triangle`.

## Steps

### Step 1: Create a New .NET Console Application

1. Open a terminal and navigate to your working directory.

   ```bash
   mkdir -p _dev/kata-7-interfaces && cd _dev/kata-7-interfaces
   ```

2. Run the following command to create a new .NET console app:

   ```bash
    dotnet new console -n ShapeInterfaces
   ```

3. Navigate into the newly created project folder:

   ```bash
   cd ShapeInterfaces
   ```

4. Open the project in Visual Studio Code:

   ```bash
   code .
   ```

---

### Step 2: Define the IShape Interface

1. Create a new file named `IShape.cs` in the project directory.
2. Add the following code to define the `IShape` interface:

```csharp
public interface IShape
{
      double CalculateArea();
      double CalculatePerimeter();
}
```

---

### Step 3: Implement Shape Classes

1. Create a new file named `Circle.cs` and implement the `IShape` interface:

```csharp
using System;

public class Circle : IShape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * radius * radius;
    }

    public double CalculatePerimeter()
    {
        return 2 * Math.PI * radius;
    }
}

```

2. Create a new file named `Rectangle.cs` and implement the `IShape` interface:

```csharp
public class Rectangle : IShape
{
      private double length;
      private double width;

      public Rectangle(double length, double width)
      {
          this.length = length;
          this.width = width;
      }

      public double CalculateArea()
      {
       // Implement This Method
      }

      public double CalculatePerimeter()
      {
         // Implement This Method


      }

}
```

3. Create a new file named `Triangle.cs` and implement the `IShape` interface:

```csharp
using System;
public class Triangle : IShape
{
      private double sideA;
      private double sideB;
      private double sideC;

      // Implement the rest of this file
}
```

---

### Implement Shape Classes into Program.cs to test functionality:

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<IShape> shapes = new List<IShape>
        {
            new Circle(5),
            new Rectangle(4, 6),
            new Triangle(3, 4, 5)
        };

        foreach (var shape in shapes)
        {
            Console.WriteLine($"Area: {shape.CalculateArea():F2}, Perimeter: {shape.CalculatePerimeter():F2}");
        }
    }
}
```

### Step 4: Finish Up

1. Run the applicaiton to see the calculations for each shape.
2. Commit all the changes to your git repository.

## Completion Criteria

- An interface `IShape` is created with methods for calculating area and perimeter.
- Classes `Circle`, `Rectangle`, and `Triangle` implement the `IShape` interface
- The `Program.cs` file demonstrates the use of these classes and interface.
- Changes are committed to the Git repository.

## Resources

| Topic                    | Link                                                                                                                           |
| ------------------------ | ------------------------------------------------------------------------------------------------------------------------------ |
| C# Interfaces            | [C# Interfaces](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/)                                  |
| Implementing Interfaces  | [Implementing Interfaces](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/implementing-interfaces) |
| C# Classes Documentation | [C# Classes Documentation](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/classes)                         |
