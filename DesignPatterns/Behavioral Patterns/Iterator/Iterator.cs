namespace DesignPatterns.Behavioral_Patterns.Iterator;

/// <summary>
/// Purpose: Provide sequential access to the elements of a collection object,
///          without exposing its underlying structure.
///          
/// Also known as: Cursor
/// 
/// Applicability: Iterator Pattern enables:
/// - Accessing elements of a collection sequentially without exposing its underlying representation.
/// - Supporting multiple traversals of a collection simultaneously.
/// - Providing a uniform interface for traversing different types of collections.
///
/// Participants:
/// - Iterator: Defines an interface for accessing and traversing elements.
/// - ConcreteIterator: Implements the Iterator interface &
///                     Keeps track of the current position in the traversal of the aggregate.
/// - Aggregate: Defines an interface for creating an Iterator object.
/// - ConcreteAggregate: Implements the Aggregate interface by returning an instance of the ConcreteIterator.
/// 
/// Consequences:
/// 1. Supports traversal variations: Different iterators can provide different traversal algorithms.
/// 2. Simplifies the aggregate interface: The aggregate doesn't need to expose its internal structure.
/// 3. Supports multiple traversals: Multiple iterators can traverse the same aggregate independently.
///
/// </summary>
public interface IIterator<T>
{
    T First();
    T Next();
    T CurrentItem();
    bool IsDone();

    // Optional
    T Previous();
    T Last();
}

/// <summary>
/// Aggregate interface for the objects collection.
/// </summary>
/// <typeparam name="T">Generic type parameter</typeparam>
public interface IAggregate<T>
{
    IIterator<T> CreateIterator();
}

public class ConcreteAggregate<T> : IAggregate<T>
{
    private readonly List<T> _items = [];

    public void AddItem(T item)
    {
        _items.Add(item);
    }

    public T GetItem(int index)
    {
        return _items[index];
    }

    public int Count => _items.Count;

    public IIterator<T> CreateIterator()
    {
        return new ConcreteIterator<T>(this);
    }
}

public class ConcreteIterator<T>(ConcreteAggregate<T> aggregate) : IIterator<T>
{
    private int _currentIndex = -1;

    public T First()
    {
        if(aggregate.Count == 0)
        {
            _currentIndex = -1;
            return default;
        }

        _currentIndex = 0;
        return aggregate.GetItem(_currentIndex);
    }

    public T Next()
    {
        _currentIndex++;
        if (!IsDone())
        {
            return aggregate.GetItem(_currentIndex);
        }
        return default;
    }

    public T CurrentItem()
    {
        if (!IsDone())
        {
            return aggregate.GetItem(_currentIndex);
        }
        return default;
    }

    public bool IsDone()
    {
        return _currentIndex < 0 
            || _currentIndex >= aggregate.Count;
    }

    public T Previous()
    {
        _currentIndex--;
        if (!IsDone())
        {
            return aggregate.GetItem(_currentIndex);
        }

        return default; 

    }
    public T Last()
    {
        if(aggregate.Count == 0)
        {
            _currentIndex = -1;
            return default;
        }

        _currentIndex = aggregate.Count - 1;
        return aggregate.GetItem(_currentIndex);
    }
}
