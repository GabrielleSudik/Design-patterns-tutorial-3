using System;

/// <summary>
/// This code demonstrates how a document reader will use the
/// correct kind of interpreter to either read a PDF or RTF
/// </summary>
namespace TemplatePatternDemo
{
    /// <summary> 
    /// Template Method Pattern.
    /// </summary>
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-- Document Reader - PDF doc. --");

            //create an instance of a DocumentReader.
            //pdf version.
            DocumentReader drpdf = new PDFDocument();

            drpdf.OpenDocument(); //will "open" the pdf.

            //create a rtf version:
            DocumentReader drrtf = new RTFDocument();

            drrtf.OpenDocument(); //will "open" the rtf.

            Console.ReadLine();

            //Prof never says so, but I'm picking up that a lot of these patterns
            //can be used in place of if/else or case statements.
            //IE, instead of "if pdf then..." and "else..."
            //it's like each option goes in its own inheriting class.
            //it makes encapulation and simple and testing easier.

            //I'm also picking up that we might not need all of these fancy names.
            //Many of these "patterns" are just inheritance of some sort,
            //but slightly different as applied to different situations.
        }
    }

    //'AbstractClass' abstract class
    abstract class DocumentReader
    {
        //default steps 
        public void LoadFile()
        {
            Console.WriteLine("Document File loaded");
        }

        // steps that will be overidden by subclass
        //This is the key part of this abstract class.
        //Here is where some behaviors will change, depending on pdf vs rtf.
        public abstract void InterpretDocumentFormat();

        // default step
        public void Open()
        {
            Console.WriteLine("Document File opens");
        }

        //'Template Method'
        public void OpenDocument()
        {
            this.LoadFile();
            this.InterpretDocumentFormat();
            this.Open();
        }

    }
    //'ConcreteClass'- concrete class
    class PDFDocument : DocumentReader
    {
        //specific to pdf only:
        //IRL there would be a lot more, obviously.
        public override void InterpretDocumentFormat()
        {
            Console.WriteLine("Document file is processed with " +
                                "PDF Interpreter");
        }
    }

    //'ConcreteClass' - concrete class
    class RTFDocument : DocumentReader
    {
        //specific to rtf only:
        public override void InterpretDocumentFormat()
        {
            Console.WriteLine("Document file is processed with " +
                                "RTF Interpreter");
        }
    }
}

/*

TEMPLATE PATTERN:

Define the skeleton of an algorithm in an operation,
deferring some steps to subclasses. The subclasses can redefine steps
of the algorithm without changing the algorithm's structure.

IE, it allows child classes to change some steps of an algorithm
without changing the algorithm's structure.

Our example: DocumentReader is the abstract class.
Two concrete classes: Pdf and Rtf.

 */