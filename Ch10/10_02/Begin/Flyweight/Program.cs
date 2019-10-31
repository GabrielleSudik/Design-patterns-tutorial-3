using System;
using System.Collections.Generic;

/// <summary>
/// This code demonstrates the Flyweight pattern in which a relatively 
/// small number of shape objects is shared several times.
/// </summary>
namespace Flyweight.Demonstration
{
    /// <summary>
    /// Flyweight Design Pattern.
    /// </summary>
    class Client
    {
        static void Main(string[] args)
        {
            //first, create the shape factory.
            ShapeObjectFactory sof = new ShapeObjectFactory();

            //create some shapes (or get them if they already exist)
            IShape shape = sof.GetShape("Triangle");
            shape.Print();
            shape = sof.GetShape("Triangle");
            shape.Print();
            shape = sof.GetShape("Triangle");
            shape.Print();

            shape = sof.GetShape("Square");
            shape.Print();
            shape = sof.GetShape("Square");
            shape.Print();
            shape = sof.GetShape("Square");
            shape.Print();
            //result of all of that: Triangle and Square will print three times.
            //BUT total objects are only two (one of each).
            //ie, methods will run on the created objects, it just runs the methods
            //on the version of the shape that already exists.

            int total = sof.TotalObjectsCreated;
            Console.WriteLine($"\n Number of objects created = {total}");

            Console.ReadKey();
        }
    }
    /// <summary>
    /// The 'Flyweight' interface
    /// </summary>
    //This is THE flyweight.
    interface IShape
    {
        void Print();
    }

    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    //Inherits the flyweight.
    class Triangle : IShape
    {
        public void Print()
        {
            Console.WriteLine("Printing Triangle");
        }
    }

    /// <summary>
    /// A 'ConcreteFlyweight' class
    /// </summary>
    //Ditto.
    class Square : IShape
    {
        public void Print()
        {
            Console.WriteLine("Printing Square");
        }
    }

    /// <summary>
    /// The 'FlyweightFactory' class
    /// </summary>
    class ShapeObjectFactory
    {
        Dictionary<string, IShape> shapes = new Dictionary<string, IShape>();

        public int TotalObjectsCreated
        {
            get { return shapes.Count; }
        }

        //This is HOW the flyweight pattern operates.
        //It checks the dictionary of shapes (created above)
        //if the shape already exists, GetShape just returns that shape.
        //if it doesn't, it will create a new instane of that shape
        //and add it to the dictionary.
        public IShape GetShape(string ShapeName)
        {
            IShape shape = null;
            if (shapes.ContainsKey(ShapeName))
            {
                shape = shapes[ShapeName];
            }
            else
            {
                switch (ShapeName)
                {
                    case "Triangle":
                        shape = new Triangle();
                        shapes.Add("Triangle", shape);
                        break;
                    case "Square":
                        shape = new Square();
                        shapes.Add("Square", shape);
                        break;
                    default:
                        throw new Exception("The factory cannot " +
                            "create the object specified");
                }
            }
            return shape;
        }
    }
}

/*
FLYWEIGHT PATTERN

Uses sharing to support large numbers of fine-grained objects efficiently.

Share existing objects instead of creating new ones. No explanation of 
WHY/when we'd need to do that.

In our example: We'll use Triangles and Squares (Shapes) we've already created.
The pattern checks if a shape already exists. If so, use it. If not, create it.
That's simple, but again... why/when? Is it a memory thing?
*/
