string input = args[0];
string[] tokens = Tokenizer.Tokenize(input);
string[] rpn = ShuntingYard.Convert(tokens);
double result = Calculator.Evaluate(rpn);
Console.WriteLine(result);