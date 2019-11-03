using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMemento
{    
    public class Caretaker
    {

        // Where all mementos are saved
        //Each memento is a statement. Here we just create a list of
        //the statements/mementos.
        List<Memento> savedStatements = new List<Memento>();

        // Adds memento to the collection

        public void addMemento(Memento m) { savedStatements.Add(m); }

        // Gets the memento requested from the Collection

        public Memento getMemento(int index) {
            if (index > -1)
            {
                return savedStatements[index];
            }
            else {
                return new Memento(string.Empty);
            }
            
        }
    }
}
