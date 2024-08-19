differences between interfaces and abstract classes.

*Interface: An interface defines a contract or a set of rules that a class must follow. It specifies the members (methods, properties, events, and indexers) that a class must implement.
*Abstract Class: An abstract class is a class that cannot be instantiated directly and serves as a base class for other classes. It can contain both abstract and non-abstract (concrete) members.

*Interface: Interfaces can only contain method signatures, properties, events, and indexers. They cannot contain any implementation details.
*Abstract Class: Abstract classes can contain both abstract and non-abstract (concrete) methods, as well as fields, properties, events, and indexers.

*Interface: A class can implement multiple interfaces.
*Abstract Class: A class can only inherit from a single abstract class.

*Interface: Members of an interface are implicitly public and cannot have access modifiers.
*Abstract Class: Members of an abstract class can have access modifiers, such as public, protected, internal, and private.

*Interface: Interfaces cannot have any state (i.e., instance fields or variables).
*Abstract Class: Abstract classes can have state, such as instance fields or variables.

*Interface: Interfaces can have default method implementations starting from C# 8.0.
*Abstract Class: Abstract classes can have both abstract and non-abstract (concrete) method implementations.

//Differences in new versions
//Default implementation
//static members
//private methods with implementation
public interface IExample
{
    static int MyStaticProperty { get; set; } = 42;
    void Method1();
    private void Method2()
    {
        Console.WriteLine("Default implementation of Method2");
    }
}

public class ExampleClass : IExample
{
    public void Method1()
    {
        Console.WriteLine("Implemented Method1");
    }

    public void Method2()
    {
        Console.WriteLine("Overridden implementation of Method2");
    }
}



class Program
{
    static void Main()
    {
        IExample example = new ExampleClass();
        example.Method1();
        //example.Method2();
    }
}
