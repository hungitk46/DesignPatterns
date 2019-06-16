using System;

namespace FactoryMethod
{
    class Program
    {
        // Define an interface for creating an object, but let subclasses decide which class to instantiate. 
        // Factory Method lets a class defer instantiation to subclasses.
        static void Main(string[] args)
        {
            var structural = new Structural();
            structural.Run();
            Console.WriteLine("Implement in real world");
            var realWord = new RealWorld();
            realWord.Run();
        }
    }
}
