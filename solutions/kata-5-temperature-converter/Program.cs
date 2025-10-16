namespace TemperatureConversion;

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
