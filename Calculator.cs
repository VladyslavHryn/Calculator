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
            else if (token == "+")
            {
                double b = stack.Pop(); 
                double a = stack.Pop(); 
                stack.Push(a + b);
            }
            else if (token == "-")
            {
                double b = stack.Pop(); 
                double a = stack.Pop(); 
                stack.Push(a - b);
            }
            else if (token == "*")
            {
                double b = stack.Pop(); 
                double a = stack.Pop(); 
                stack.Push(a * b);
            }
            else if (token == "/")
            {
                double b = stack.Pop(); 
                double a = stack.Pop(); 
                stack.Push(a / b);
            }
            else if (token == "^")
            {
                double b = stack.Pop();
                double a = stack.Pop();
                stack.Push(Math.Pow(a, b));
            }
            else if (token == "sin")
            {
                double a = stack.Pop();
                stack.Push(Math.Sin(a));
            }
            else if (token == "cos")
            {
                double a = stack.Pop();
                stack.Push(Math.Cos(a));
            }
            else if (token == "max")
            {
                double b = stack.Pop();
                double a = stack.Pop();
                stack.Push(Math.Max(a, b));
            }
        }
        return stack.Pop();
    }

}