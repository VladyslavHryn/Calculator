class ShuntingYard
{
    public static string[] Convert(string[] tokens)
    {
        string[] output = new string[100];
        int outCount = 0;
        Stack<string> operators = new Stack<string>();

        for (int i = 0; i < tokens.Length; i++)
        {
            string token = tokens[i];

            if (char.IsDigit(token[0]))
            {
                output[outCount] = token;
                outCount++;
            }
            else if (token == "(")
            {
                operators.Push(token);
            }
            else if (token == ")")
            {
                while (operators.Peek() != "(")
                {
                    output[outCount] = operators.Pop();
                    outCount++;
                }
                operators.Pop();
            }
            else if (token == "+" || token == "-" || token == "*" || token == "/")
            {
                while (!operators.IsEmpty() && operators.Peek() != "(" && Priority(operators.Peek()) >= Priority(token))
                {
                    output[outCount] = operators.Pop();
                    outCount++;
                }
                operators.Push(token);
            }
        }

        while (!operators.IsEmpty())
        {
            output[outCount] = operators.Pop();
            outCount++;
        }

        string[] result = new string[outCount];
        for (int i = 0; i < outCount; i++)
            result[i] = output[i];
        return result;
    }

    static int Priority(string op)
    {
        if (op == "*" || op == "/") 
            return 2;
        if (op == "+" || op == "-") 
            return 1;
        return 0;
    }
}