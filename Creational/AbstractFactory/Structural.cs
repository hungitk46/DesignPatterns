using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    // Provide an interface for creating families of related or dependent objects without specifying their concrete classes.
    public class Structural
    {
        public void Run()
        {
            // Abstract factory #1
            AbstractFactory factory1 = new ConcreteFactory1();
            Client client1 = new Client(factory1);
            client1.Run();

            // Abstract factory #2
            AbstractFactory factory2 = new ConcreteFactory2();
            Client client2 = new Client(factory2);
            client2.Run();
        }
    }
    /// <summary>
    /// The 'AbstractFactory' abstract class
    /// </summary>
    abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }

    /// <summary>
    /// The 'ConcreteFactory1' class
    /// </summary>
    class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }
        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    /// <summary>
    /// The 'ConcreteFactory2' class
    /// </summary>
    class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }
        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    /// <summary>
    /// The 'AbstractProductA' abstract class
    /// </summary>
    abstract class AbstractProductA
    {

    }

    /// <summary>
    /// The 'AbstractProductB' abstract class
    /// </summary>
    abstract class AbstractProductB
    {
        public abstract void Interact(AbstractProductA a);
    }

    class ProductA1 : AbstractProductA
    {

    }
    class ProductB1 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + " interacts with " + a.GetType().Name);
        }
    }

    class ProductA2 : AbstractProductA
    {

    }

    class ProductB2 : AbstractProductB
    {
        public override void Interact(AbstractProductA a)
        {
            Console.WriteLine(this.GetType().Name + " interacts with " + a.GetType().Name);
        }
    }

    class Client
    {
        private readonly AbstractProductA _abstractProductA;
        private readonly AbstractProductB _abstractProductB;
        public Client(AbstractFactory abstractFactory)
        {
            _abstractProductA = abstractFactory.CreateProductA();
            _abstractProductB = abstractFactory.CreateProductB();
        }
        public void Run()
        {
            _abstractProductB.Interact(_abstractProductA);
        }
    }
}
