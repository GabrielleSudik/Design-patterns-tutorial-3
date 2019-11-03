using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Diagnostics.Debug;

namespace DemoMemento
{
    
    public class Originator
    {

        private String statement;

        // Sets the value for the statement

        public void set(String newStatement)
        {
            WriteLine("----");
            WriteLine("From Originator: Current Version of Statement\n" 
                + newStatement + "\n");
            this.statement = newStatement;
        }

        // Creates a new Memento with a new statement
        //remember: the statement begins in the originator class.
        //this method will pass the statement to the Memento class,
        //so you have the statement and it's copy as a Memento property.
        public Memento storeInMemento()
        {
            WriteLine("From Originator: Saving to Memento");
            return new Memento(statement);
        }

        // Gets the statement currently stored in memento
        public String restoreFromMemento(Memento memento)
        {

            statement = memento.getState();

            WriteLine("From Originator: Previous Statement Saved in Memento\n" + statement + "\n");

            return statement;

        }
    }
}
