namespace DesignPatterns.Behavioral_Patterns.Interpreter;

/// <summary>
/// Purpose:
/// - Describe a grammatical representation for a language
/// - Provide an interpreter to deal with this grammar
/// - Provide a way to evaluate sentences based on the defined grammar
/// 
/// Applicability:
/// - When a language needs to be interpreted  & Can be defined by an abstract syntax tree
/// - When the grammar is simple. 
/// - When efficiency is not a critical concern.
/// 
/// Participants:
/// - AbstractExpression: Declares an abstract Interpret operation that is common to all nodes in the abstract syntax tree.
/// - TerminalExpression: Implements the Interpret operation for terminal symbols in the grammar. 
///                       i.e. numbers or variables.
/// - NonterminalExpression: Implements the Interpret operation for nonterminal symbols in the grammar.
///                          i.e. operations like addition or subtraction. 
///                          or structures like loops or conditionals.
/// - Context: Contains information that is global to the interpreter.
/// - Client: Builds and traverses the abstract syntax tree using the Interpreter classes.
/// </summary>
public class Interpreter
{
}

/// <summary>
/// Abstract Expression
/// </summary>
public interface IExpression
{
    int Interpret(Context context);
}

/// <summary>
/// Terminal Expression
/// </summary>
/// <param name="number"></param>
public class NumberExpression(int number) : IExpression
{
    public int Interpret(Context context)
    {
        return number;
    }
}

/// <summary>
/// Nonterminal Expression
/// </summary>
/// <param name="left"></param>
/// <param name="right"></param>
/// <param name="operation"></param>
public class BinaryOperationExpression(IExpression left, IExpression right, char operation) : IExpression
{
    public int Interpret(Context context)
    {
        return operation switch
        {
            '+' => left.Interpret(context) + right.Interpret(context),
            '-' => left.Interpret(context) - right.Interpret(context),

            _ => throw new NotSupportedException($"Operation {operation} is not supported.")
        };
    }
}

/// <summary>
/// TerminalExpression:
/// Represents a variable whose value is stored in the Context.
/// </summary>
public class VariableExpression(string name) : IExpression
{
    public int Interpret(Context context)
    {
        return context.GetVariable(name);
    }
}

public class Context
{
    private readonly Dictionary<string, int> _variables = [];

    public void SetVariable(string name, int value)
    {
        _variables[name] = value;
    }

    public int GetVariable(string name)
    {
        if (!_variables.TryGetValue(name, out var value))
        {
            throw new KeyNotFoundException($"Variable '{name}' is not defined in the context.");
        }

        return value;
    }
}