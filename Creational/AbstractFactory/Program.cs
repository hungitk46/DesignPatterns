using System;

namespace AbstractFactory
{
    
    public class Program
    {
        static void Main(string[] args)
        {
            var structural = new Structural();
            structural.Run();
            Console.WriteLine("Implement in real world");
            var realWord = new RealWorld();
            realWord.Run();

            // Wait for user input
            Console.ReadKey();
        }
    }
    
}
