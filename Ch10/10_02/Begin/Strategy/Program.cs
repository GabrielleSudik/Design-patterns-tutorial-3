using System;
using System.Collections.Generic;

/// <summary>
/// This code demonstrates the Strategy pattern which encapsulates 
/// sorting algorithms in the form of sorting objects. This allows 
/// clients to dynamically change sorting strategies including 
/// Quicksort, Shellsort, and Mergesort.
/// </summary>
namespace Strategy.Demonstration
{
    /// <summary> 
    /// Strategy Design Pattern.
    /// </summary>
    class Client
    {        
        static void Main()
        {
            //as always, Main code comes after the setup below.

            //first create a list that needs to be sorted, and add items to it.
            SortedList studentRecord = new SortedList();

            studentRecord.Add("Ronny");
            studentRecord.Add("Bobby");
            studentRecord.Add("Kate");
            studentRecord.Add("Mike");
            studentRecord.Add("Ricky");

            //here we'll call the three different ways to sort:
            //first time you pass in QuickSort to set which strategy is used,
            //so when Sort() is called, code knows to use QuickSort.Sort()
            studentRecord.SetSortStrategy(new QuickSort());
            studentRecord.Sort();

            //etc with second type of sort
            studentRecord.SetSortStrategy(new ShellSort());
            studentRecord.Sort();

            //and with third type of sort
            studentRecord.SetSortStrategy(new MergeSort());
            studentRecord.Sort();

            // Wait for user
            Console.ReadKey();

        }
    }

    /// <summary>
    /// The 'Strategy' abstract class
    /// </summary>
    //Any way to sort will need a list of strings.
    abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    class QuickSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort(); // Default is Quicksort
            Console.WriteLine("QuickSorted list ");
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    class ShellSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.ShellSort(); not-implemented
            //FYI the prof skipped writing all the implementing code for this kind of sort.
            //cuz it's just an example;
            //IRL, there would be code about how to Shell Sort.
            Console.WriteLine("ShellSorted list ");
        }
    }

    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    class MergeSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.MergeSort(); not-implemented
            //ditto prof is skipping the actual code; it's not relevant to the lesson.
            Console.WriteLine("MergeSorted list ");
        }
    }

    /// <summary>
    /// The 'Context' class
    /// </summary>
    //This is where the list gets set up
    class SortedList
    {
        private List<string> _list = new List<string>();
        private SortStrategy _sortstrategy;

        //here's the part that makes the pattern work:
        //you pick which sorting method you want to use
        //and pass it as the SortStrategy variable.
        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            this._sortstrategy = sortstrategy;
        }

        public void Add(string name)
        {
            _list.Add(name);
        }

        public void Sort()
        {
            //you picked which sort method you would use above.
            //this is what will call the relevant Sort() method,
            //based on the strategy you picked.
            _sortstrategy.Sort(_list);

            // Iterate over list and display results
            foreach (string name in _list)
            {
                Console.WriteLine(" " + name);
            }
            Console.WriteLine();
        }
    }
}

/*

STRATEGY PATTERN:

Defines a family of algorithms, encapsulates each one,
and makes them interchangeable.
It lets the algorithm vary independently from clients that use it.

Allows a client to chose an algorithm from a group of algorithms
and gives it a simple way to access it.

Our example will be some objects that each encapsulate a sorting algorithm.
The client can pick which sorting method to use.
QuickSort, ShellSort, MergeSort.

*/
