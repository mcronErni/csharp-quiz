namespace CalculatorApp;

public class Calculator
{
    public double PerformOperation(double num1, double num2, string operation)
    {
        // TODO: Implement the PerformOperation method
        switch (operation)
        {
            case "add":
                return num1 + num2;
            case "subtract":
                return num1 - num2;
            case "multiply":
                return num1 * num2;
            case "divide":
                if(num2 == 0)
                    throw new DivideByZeroException();
                return num1 / num2;
            default:
                throw new Exception("\nAn error occurred: The specified operation is not supported.\n");
        }
    }
}