using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMemento
{
    public class Memento
    {
        // The statement stored in memento Object
        //In our example, each memento is a statement
        //Elsewhere, we have a List<memento> which is just a list of all statements.
        private String statement;

        // Save a new statement String to the memento Object
        //Key: the statement doesn't start in the Memento.
        //It starts in the originator.
        //Originator.cs has a method that takes a statement,
        //and passes it to the Memento constructor,
        //thereby having both a string in the Originator
        //and a version of the string in a Memento object too.
        public Memento(String statementSave) { statement = statementSave; }

        // Return the value stored in statement 

        public String getState() { return statement; }
    }
}

/*
MEMENTO PATTERN 

Capture and externalize an object's state, so the state can be restored later.
Ie, it tracks states of an object to go back and forth between
(like undo and redo, which is our example).

You have an originator -- the object with a state.
And a memento that gets and sets the states.
And a caretaker that takes care of the memento, whatever that means.

Start in the MainWindow file for your notes.

*/
