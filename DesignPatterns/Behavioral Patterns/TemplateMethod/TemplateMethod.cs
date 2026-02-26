namespace DesignPatterns.Behavioral_Patterns.TemplateMethod;

/// <summary>
/// Purpose:
///     - Define the skeleton of an algorithm in an operation, 
///         delegating some steps to subclasses.
///     - Allow subclasses to redefine certain steps of an algorithm 
///         without changing the algorithm's structure.
///         
/// Applicability: 
///     Use Template Method when
///     - To implement the invariant parts of an algorithm once 
///         and leave it up to subclasses to implement the behavior that can vary.
///     - When common behavior among subclasses should be refactored 
///         and generalized in a common class.
///     - To control subclasses extensions by providing a template method 
///         that calls the abstract operations in a particular sequence.
///         
/// Participants:
///     - AbstractClass:
///         - Defines abstract operations that concrete subclasses must implement.
///         - Implements a template method defining the skeleton of an algorithm.
///     - ConcreteClass:
///         - Implements the abstract operations to carry out subclass-specific steps of the algorithm.
/// </summary>
public abstract class TemplateMethod
{
    // Template method, do NOT override.
    public void TemplateMethodAlgorithm()
    {
        StepOne();
        StepTwo();
        StepThree();
    }

    // Abstract steps must be implemented by subclasses.
    protected abstract void StepOne();
    protected abstract void StepTwo();

    // Not every step is required.
    // Virtual steps are optional to override
    protected virtual void StepThree() { /* Default implementation */ }
}

public class ConcreteClassA : TemplateMethod
{
    protected override void StepOne() { /* Implementation A */ }
    protected override void StepTwo() { /* Implementation A */ }
    protected override void StepThree() { /* Implementation A */ }
}

public class ConcreteClassB : TemplateMethod
{
    protected override void StepOne() { /* Implementation B */ }
    protected override void StepTwo() { /* Implementation B */ }
}
