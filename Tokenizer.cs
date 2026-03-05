class Tokenizer
{
    public static string[] Tokenize(string input)
    {
        string[] tokens = new string[100];
        int count = 0;
        string buffer = "";

        for (int i = 0; i < input.Length; i++)
        {
            char s = input[i];

            if (char.IsDigit(s))
            {
                buffer += s;
            }
            else if (s == ' ')
            {
                if (buffer != "")
                {
                    tokens[count] = buffer;
                    count++;
                    buffer = "";
                }
            }
            else if (s == '+' || s == '-' || s == '*' || s == '/' || s == '(' || s == ')')
            {
                if (buffer != "")
                {
                    tokens[count] = buffer;
                    count++;
                    buffer = "";
                }
                tokens[count] = s.ToString();
                count++;
            }
        }
        
        if (buffer != "")
        {
            tokens[count] = buffer;
            count++;
        }

        string[] result = new string[count];
        for (int i = 0; i < count; i++)
            result[i] = tokens[i];
        return result;
    }
}