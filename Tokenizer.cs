class Tokenizer
{
    public static string[] Tokenize(string input)
    {
        string[] tokens = new string[100]; // масив для зберігання токенів, максимум 100
        int count = 0;
        string buffer = "";  // буфер для збору цифр числа
        for (int i = 0; i < input.Length; i++)
        {
            char s = input[i]; // поточний символ

            if (char.IsDigit(s))
            {
                buffer += s; // якщо цифра - додаємо до буферу (збираємо число)
            }
            else if (s == ' ')
            {
                if (buffer != "") // пробіл - зберігаємо число з буферу якщо воно є
                {
                    tokens[count] = buffer;
                    count++;
                    buffer = "";  // очищаємо буфер
                }
            }
            else if (s == '+' || s == '-' || s == '*' || s == '/' || s == '(' || s == ')')
            {
                if (buffer != "") // якщо перед оператором було число - зберігаємо його
                {
                    tokens[count] = buffer;
                    count++;
                    buffer = "";
                }
                tokens[count] = s.ToString(); // зберігаємо сам оператор як токен
                count++; 
            }
        }
        
        if (buffer != "") // якщо рядок закінчився числом - зберігаємо останній токен
        {
            tokens[count] = buffer;
            count++;
        }

        string[] result = new string[count]; // обрізаємо масив до потрібного розміру
        for (int i = 0; i < count; i++)
            result[i] = tokens[i];
        return result; // повертаємо готовий масив токенів
    }
}