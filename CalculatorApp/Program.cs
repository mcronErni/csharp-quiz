using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CalculatorApp;

class Program
{
    static void Main(string[] args)
    {
        //using ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        //{
        //    builder.AddConsole(); 
        //});

        //ILogger program = loggerFactory.CreateLogger<Program>();

        using var serviceProvider = new ServiceCollection()
            .AddLogging(configure => configure.AddConsole())
            .BuildServiceProvider();
        var program = serviceProvider.GetRequiredService<ILogger<Program>>();

        try
        {

            Console.WriteLine("Enter the first number:");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the second number:");
            double num2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the operation (add, subtract, multiply, divide):");
            string operation = Console.ReadLine()?.ToLower() ?? string.Empty;

            var calculator = new Calculator();
            double result = calculator.PerformOperation(num1, num2, operation);
            Console.WriteLine($"The result is: {result}");

        }
        catch (FormatException ex)
        {
            Console.WriteLine("\nInvalid input. Please enter numeric values.\n");
            program.LogError($"{DateTime.Now} : Format Exception Occured.\n{ex}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Cannot divide by zero.");
            program.LogError($"{DateTime.Now} : Cannot divide by zero.\n{ex}");
        }
        catch(ArgumentException e)
        {
            Console.WriteLine(e.Message.ToString());
            program.LogError($"{DateTime.Now} : Something went wrong.\n{e}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
            program.LogError($"{DateTime.Now} : Something went wrong.\n{ex}");
        }
        finally
        {
            Console.WriteLine("Calculation attempt finished.");
        }
    }
}