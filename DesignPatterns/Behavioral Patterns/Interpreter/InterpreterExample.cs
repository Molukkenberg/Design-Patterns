namespace DesignPatterns.Behavioral_Patterns.Interpreter;

public class InterpreterExample
{
    public static void Run()
    {
        // Example: Interpret the expression "5 + 3 - 2"
        IExpression expression = new BinaryOperationExpression(
            new BinaryOperationExpression(
                new NumberExpression(5),
                new NumberExpression(3),
                '+'),
            new NumberExpression(2),
            '-');

        Context context = new();
        int result = expression.Interpret(context);

        Console.WriteLine($"Result of the expression is: {result}"); 
        // Output: Result of the expression is: 6
    }

    public static void RunExample2()
    {
        // Example: Interpret the expression "x + y" where x = 5 and y = 2
        IExpression expression = new BinaryOperationExpression(
            new VariableExpression("x"),
            new VariableExpression("y"),
            '+');

        var context = new Context();
        context.SetVariable("x", 5);
        context.SetVariable("y", 2);

        int result = expression.Interpret(context);
        
        Console.WriteLine($"Result of the expression is: {result}"); 
        // Output: Result of the expression is: 7
    }
}