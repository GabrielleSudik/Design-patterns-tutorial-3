using DemoMemento;
using System.Windows;
using static System.Diagnostics.Debug;

/// <summary>
/// This Memento patter will create a caretaker that contains the 
/// collection with all the Statements in it. It can add and
/// retrieve Statements from the collection
/// </summary>
namespace Memento
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Create a caretaker that contains the collection
        //of the statements we will track.
        //We will be able to undo and redo the statements.
        Caretaker caretaker = new Caretaker();

        // The originator sets the value for the statement        
        Originator originator = new Originator();

        int saveFiles = 0, currentStatement = -1;

        // ---------------------------------------------

        public MainWindow()
        {
            InitializeComponent();
        }

        //the next few methods are what will do stuff.
        //notably, undo and redo.
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string text = theStatement.Text;

            originator.set(text); //pass the statement to the originator

            caretaker.addMemento(originator.storeInMemento()); //two things happening here:
                //add the memento to Caretaker
                //store the memento via the originator.
                //I know I'm missing some details here...

            saveFiles++;
            currentStatement++;

            WriteLine("Saved files " + saveFiles + "\n");

            btnUndo.IsEnabled = true; //turns on the button that will allow Undo
        }

        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            if (currentStatement >= 0)
            {
                currentStatement--;
                
                string textBoxString = originator.restoreFromMemento(caretaker.getMemento(currentStatement));

                theStatement.Text = textBoxString;

                btnRedo.IsEnabled = true;
            }
            else
            {
                btnUndo.IsEnabled = false;
            }
        }

        private void btnRedo_Click(object sender, RoutedEventArgs e)
        {
            if ((saveFiles - 1) > currentStatement)
            {
                currentStatement++;

                string textBoxString = originator.restoreFromMemento(caretaker.getMemento(currentStatement));

                theStatement.Text = textBoxString;

                btnUndo.IsEnabled = false;
            }
            else
            {
                btnRedo.IsEnabled = false;
            }

            btnUndo.IsEnabled = true;
        }
    }
}
