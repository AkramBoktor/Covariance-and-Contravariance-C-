# Covariance and Contravariance C #
Covariance and Contravariance (C#) By Delegate

Covariance and contravariance allow us to be flexible when dealing with class hierarchy.

Consider the following class hierarchy before we learn about covariance and contravariance:
As per the above example classes, small is a base class for big and big is a base class for bigger. 
The point to remember here is that a derived class will always have something more than a base class, 
so the base class is relatively smaller than the derived class.
# Covariance in C#
Covariance enables you to pass a derived type where a base type is expected. Co-variance is like variance of the same kind. The base class and other derived classes are considered to be the same kind of class that adds extra functionalities to the base type. So covariance allows you to use a derived class where a base class is expected (rule: can accept big if small is expected).

Covariance can be applied on delegate, generic, array, interface, etc.

# Covariance with Delegate
Covariance in delegates allows flexiblity in the return type of delegate methods.
# Example

public delegate Small covarDel(Big mc);

public class Program
{
    public static Big Method1(Big bg)
    {
        Console.WriteLine("Method1");
    
        return new Big();
    }
    public static Small Method2(Big bg)
    {
        Console.WriteLine("Method2");
    
        return new Small();
    }
        
    public static void Main(string[] args)
    {
        covarDel del = Method1;

        Small sm1 = del(new Big());

        del= Method2;
        Small sm2 = del(new Big());
    }
}

# Output 
Method1
Mehtod2
\n As you can see in the above example, delegate expects a return type of small (base class) but we can still assign Method1 that returns Big (derived class) and also Method2 that has same signature as delegate expects.

Thus, covariance allows you to assign a method to the delegate that has a less derived return type

# C# Contravariance
Contravariane is applied to parameters. Cotravariance allows a method with the parameter of a base class to be assigned to a delegate that expects the parameter of a derived class.

Continuing with the example above, add Method3 that has a different parameter type than delegate:

# Example
delegate Small covarDel(Big mc);

class Program
{
    static Big Method1(Big bg)
    {
        Console.WriteLine("Method1");
        return new Big();
    }
    static Small Method2(Big bg)
    {
        Console.WriteLine("Method2");
        return new Small();
    }

    static Small Method3(Small sml)
    {
        Console.WriteLine("Method3");
        
        return new Small();
    }
    static void Main(string[] args)
    {
        covarDel del = Method1;
        del += Method2;
        del += Method3;

        Small sm = del(new Big());
}
# Output
Method1
Method2
Method3
