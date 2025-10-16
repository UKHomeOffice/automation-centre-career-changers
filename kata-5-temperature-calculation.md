# Kata 5 - Temperature Calculation

## Objective

Implement methods to convert temperatures between Celsius, Fahrenheit, and Kelvin. This kata will help you practice basic arithmetic operations and method creation. 

## Guidance

### Temperature Conversion Formulas

- Celsius to Fahrenheit: (C × 9/5) + 32
- Fahrenheit to Celsius: (F - 32) × 5/9
- Celsius to Kelvin: C + 273.15
- Kelvin to Celsius: K - 273.15
- Fahrenheit to Kelvin: (F - 32) × 5/9 + 273.15
- Kelvin to Fahrenheit: (K - 273.15) × 9/5 + 32

## Steps

### Step 1: Create a New .NET Console Application
1. Open a terminal and navigate to your working directory.

   ```bash
   mkdir -p _dev/kata-5-temperature-calculation && cd _dev/kata-5-temperature-calculation
   ```
2. Run the following command to create a new .NET console app:

   ```bash
    dotnet new console -n TemperatureConversion
    ```
3. Navigate into the newly created project folder:

    ```bash
    cd TemperatureConversion
    ```
4. Open the project in Visual Studio Code:
    ```bash
    code .
    ``` 

---

### Step 2: Implement Temperature Conversion Methods

```csharp
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a temperature value:");
        if (double.TryParse(Console.ReadLine(), out double temperature))
        {
            Console.WriteLine("Enter the current scale (C for Celsius, F for Fahrenheit, K for Kelvin):");
            string currentScale = Console.ReadLine()?.ToUpper();

            Console.WriteLine("Enter the target scale (C for Celsius, F for Fahrenheit, K for Kelvin):");
            string targetScale = Console.ReadLine()?.ToUpper();

            double convertedTemperature = ConvertTemperature(temperature, currentScale, targetScale);

            if (!double.IsNaN(convertedTemperature))
            {
                Console.WriteLine($"{temperature}°{currentScale} is {convertedTemperature:F2}°{targetScale}");
            }
            else
            {
                Console.WriteLine("Invalid scale entered. Please use C, F, or K.");
            }
        }
        else
        {
            Console.WriteLine("Invalid temperature value entered.");
        }
    }

    static double ConvertTemperature(double temperature, string currentScale, string targetScale)
    {
        if (currentScale == "C" && targetScale == "F")
        {
            return CelsiusToFahrenheit(temperature);
        }
        else if (currentScale == "C" && targetScale == "K")
        {
            return CelsiusToKelvin(temperature);
        }
        else if (currentScale == "F" && targetScale == "K")
        {
            return FahrenheitToKelvin(temperature);
        }
        else if (currentScale == "F" && targetScale == "C")
        {
            return FahrenheitToCelsius(temperature);
        }
        else if (currentScale == "K" && targetScale == "C")
        {
            return KelvinToCelsius(temperature);
        }
        else if (currentScale == "K" && targetScale == "F")
        {
            return KelvinToFahrenheit(temperature);
        }
        else if (currentScale == targetScale)
        {
            return temperature;
        }
        else
        {
            return double.NaN;
        }
    }

    static double CelsiusToFahrenheit(double temperature)
    {
        return (temperature * 9 / 5) + 32;
    }

    static double CelsiusToKelvin(double temperature)
    {
        return temperature + 273.15;
    }

    static double FahrenheitToKelvin(double temperature)
    {
        return (temperature - 32) * 5 / 9 + 273.15;
    }

    static double FahrenheitToCelsius(double temperature)
    {
        return (temperature - 32) * 5 / 9;
    }

    static double KelvinToCelsius(double temperature)
    {
        return temperature - 273.15;
    }

    static double KelvinToFahrenheit(double temperature)
    {
        return (temperature - 273.15) * 9 / 5 + 32;
    }
}
```


### Step 3: Run the Application

1. In the terminal, run the application:

   ```bash
   dotnet run
   ```

2. Test the application by entering various strings and observing the Sanitised output.

---
    
### Step 4: Commit Your Work

1. Initialize a Git repository (if not already done):

   ```bash
   git init
   ```

2. Add the files to the repository:

   ```bash
   git add .
   ```

3. Commit your changes:

   ```bash
   git commit -m "Implement String Sanitiser."
   ```

4. Push to a remote repository (if applicable):

   ```bash
   git remote add origin https://github.com/<username>/StringSanitiser.git
   git branch -M main
   git push -u origin main
   ```

---

## Completion Criteria

* The application correctly converts temperatures between Celsius, Fahrenheit, and Kelvin.

## Stretch Goals 

* Have the application throw errors for invalid inputs (e.g. non-numeric temperature values, invalid scale entries).

## Resources

| Topic                    | Link                                                                                                                           |
| ------------------------ | ------------------------------------------------------------------------------------------------------------------------------ |
| C# Math Documentation    | [https://learn.microsoft.com/en-us/dotnet/api/system.math](https://learn.microsoft.com/en-us/dotnet/api/system.math)         |
| Temperature Conversion   | [https://www.rapidtables.com/convert/temperature/how-celsius-to-fahrenheit.html](https://www.rapidtables.com/convert/temperature/how-celsius-to-fahrenheit.html) |
