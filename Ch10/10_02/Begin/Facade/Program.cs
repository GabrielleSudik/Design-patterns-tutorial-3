using System;

/// <summary>
/// This code demonstrates the Facade pattern as a MortgageApplication 
/// object which provides a simplified interface to a large subsystem 
/// of classes measuring the creditworthyness of an applicant.
/// </summary>
namespace Facade.Demonstration
{
    /// <summary>
    /// Facade Design Pattern.
    /// </summary>
    class Client
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Facade
            //create an instance of the top level CollegeLoan
            CollegeLoan collegeLoan = new CollegeLoan();

            // Evaluate loan
            //create the student applying for the load
            Student student = new Student("Hunter Sky");

            //call the facade's method, which calls the subsystem methods:
            bool eligible = collegeLoan.IsEligible(student, 75000);

            //show results:
            Console.WriteLine("\n" + student.Name +
                " has been " + (eligible ? "Approved" : "Rejected"));

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Facade' class
    /// </summary>
    class CollegeLoan
    {
        //the facade's subsystems:
        //create instances of each.
        private Bank _bank = new Bank();
        private Loan _loan = new Loan();
        private Credit _credit = new Credit();

        //high level method takes in basic info.
        public bool IsEligible(Student stud, int amount)
        {
            Console.WriteLine("{0} applies for {1:C} loan\n",
              stud.Name, amount);

            bool eligible = true;

            // Verify creditworthyness of applicant
            //the logic here funnels info to each subsystem
            //ie, _bank, _loan, _credit.
            //each subsystem checks its own methods and
            //returns true or false, as it determines.
            //this looks familiar, like our refactoring
            //of the Tasks Api.
            //(see below for the classes and their methods)
            //note how "eligible" is a variable in this method
            //that is dependent on the results of all three other methods.
            //again, our refactoring creates instances of "subsystems"
            //then our "facade" relies on the instances of those subsystems
            //and their methods to build a master result in the facade level.
            if (!_bank.HasSufficientSavings(stud, amount))
            {
                eligible = false;
            }
            else if (!_loan.HasNoBadLoans(stud))
            {
                eligible = false;
            }
            else if (!_credit.HasGoodCredit(stud))
            {
                eligible = false;
            }

            return eligible;
        }
    }

    /// <summary>
    /// The 'Subsystem ClassA' class
    /// </summary>
    class Bank
    {
        public bool HasSufficientSavings(Student c, int amount)
        {
            Console.WriteLine("Verify bank for " + c.Name);
            return true;
        }
    }

    /// <summary>
    /// The 'Subsystem ClassB' class
    /// </summary>
    class Credit
    {
        public bool HasGoodCredit(Student c)
        {
            Console.WriteLine("Verify credit for " + c.Name);
            return true;
        }
    }

    /// <summary>
    /// The 'Subsystem ClassC' class
    /// </summary>
    class Loan
    {
        public bool HasNoBadLoans(Student c)
        {
            Console.WriteLine("Verify loans for " + c.Name);
            return true;
        }
    }

    /// <summary>
    /// Student class
    /// </summary>
    class Student
    {
        private string _name;

        // Constructor
        public Student(string name)
        {
            this._name = name;
        }

        // Gets the name
        public string Name
        {
            get { return _name; }
        }
    }
}

/*

Facade Pattern:
Provides a unified interface to a set of interfaces.
Defines a higher level interface.

IOW, it hides complexities of a system.
Subsystems implement methods; and the facade level
knows which subsystem will be needed at a given time.

Our example: High level interface will approve loans,
handling several lower level processes. Sufficient funds,
good credit, and no bad loans. 

Facade is the CollegeLoan. Subsystems are Bank, Credit, Loan.

*/