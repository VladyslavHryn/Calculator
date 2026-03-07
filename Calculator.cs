namespace CalculatorAssigment;

public class Calculator
{
    public static double Evaluate(string[] tokens)
    {
        Stack<double> stack = new Stack<double>();
        for (int i = 0; i < tokens.Length; i++)
        {
            string token = tokens[i];
            if (char.IsDigit(token[0]))
            {
                stack.Push(double.Parse(token));
            }
        }
    }

}