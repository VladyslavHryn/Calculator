class ShuntingYard
{
    public static string[] Convert(string[] tokens)
    {
        string[] output = new string[100]; // масив для результату
        int counter = 0; // лічильник токенів в output
        Stack<string> operators = new Stack<string>(); // стек для тимчасового зберігання операторів

        for (int i = 0; i < tokens.Length; i++)
        {
            string token = tokens[i]; // поточний токен

            if (char.IsDigit(token[0]))
            {
                output[counter] = token; // число одразу йде в результат
                counter++;
            }
            else if (token == "(") // відкриваюча дужка - просто в стек
            {
                operators.Push(token);
            }
            else if (token == ")") // закриваюча дужка - виштовхуємо зі стеку в output поки не зустрінемо "("
            {
                while (operators.Peek() != "(")
                {
                    output[counter] = operators.Pop();
                    counter++;
                }
                operators.Pop(); // видаляємо "(" зі стеку
            }
            else if (token == "+" || token == "-" || token == "*" || token == "/" || token == "^")
            {
                while (!operators.IsEmpty() && operators.Peek() != "(" && Priority(operators.Peek()) >= Priority(token))
                {
                    output[counter] = operators.Pop();
                    counter++;
                }
                operators.Push(token); // кладемо поточний оператор в стек
            }
            else if (token == "sin" || token == "cos" || token == "max")
            {
                operators.Push(token);
            }
        }
           
        while (!operators.IsEmpty()) // виштовхуємо все що залишилось в стеку в output
        {
            output[counter] = operators.Pop();
            counter++;
        }

        string[] result = new string[counter]; // обрізаємо масив до потрібного розміру
        for (int i = 0; i < counter; i++)
            result[i] = output[i];
        return result;
    }

    static int Priority(string op)     // повертає пріоритет оператора
    { 
        if (op == "*" || op == "/") 
            return 2;
        if (op == "+" || op == "-") 
            return 1;
        if (op == "^") 
            return 3;
        if (op == "sin" || op == "cos" || op == "max") 
            return 4;
        return 0;
    }
}