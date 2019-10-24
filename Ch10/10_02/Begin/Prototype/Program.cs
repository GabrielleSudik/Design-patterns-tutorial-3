using System;
using System.Collections.Generic;

/// <summary>
/// This code demonstrates the Prototype pattern in which new 
/// Color objects are created by copying pre-existing, user-defined
/// Colors of the same type.
/// </summary>
namespace Prototype.Demonstration
{
    /// <summary>
    /// Prototype Design Pattern.
    /// </summary>
    class Program
    {
        static void Main()
        {
            //this code comes after the setup below

            //create an instance of the ColorController:
            ColorController cc = new ColorController();

            //initialize some standard colors:
            cc["yellow"] = new Color(255, 255, 0);
            cc["orange"] = new Color(255, 128, 0);
            cc["purple"] = new Color(128, 0, 255);

            //initialize some personalized colors:
            //they are kind of random, this is just an example.
            cc["sunshine"] = new Color(255, 54, 0);
            cc["toast"] = new Color(255, 153, 51);
            cc["rainyday"] = new Color(255, 0, 255);

            //let's clone.
            Color c1 = ColorController["yellow"].Clone() as Color; //will match yellow's RGB
            Color c2 = ColorController["toast"].Clone() as Color; //will match toast's RGB
            Color c3 = ColorController["rainyday"].Clone() as Color; //will match rainyday's RGB

            //yeah so... why is this useful?
            //the only thing I see is, setting
            //cc["yellow"] to the variable c1 makes typing more code easier.
            //but couldn't that just happen with a = ??
            //what's up with cloning?? :\

        }
    }

    /// <summary>
    /// The 'Prototype' abstract class
    /// </summary>
    abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }

    /// <summary>
    /// The 'ConcretePrototype' class
    /// </summary>
    class Color : ColorPrototype
    {
        private int _yellow;
        private int _orange;
        private int _purple;

        // Constructor
        public Color(int yellow, int orange, int purple)
        {
            this._yellow = yellow;
            this._orange = orange;
            this._purple = purple;
        }

        // Create a shallow copy
        public override ColorPrototype Clone()
        {
            Console.WriteLine(
              "RGB color is cloned to: {0,3},{1,3},{2,3}",
              _yellow, _orange, _purple);

            return this.MemberwiseClone() as ColorPrototype;
            //MemberwiseClone is a method from the .net library
        }
    }

    /// <summary>
    /// Prototype manager
    /// </summary>
    class ColorController
    {
        //track all your colors:
        private Dictionary<string, ColorPrototype> _colors =
          new Dictionary<string, ColorPrototype>();

        // Indexer
        public ColorPrototype this[string key]
        {
            get { return _colors[key]; }
            set { _colors.Add(key, value); }
        }
    }
}