using System;

/// <summary>
/// This code demonstrates the bridge pattern by sending messages using 
/// two independent systems. One by text & the other, webservice.
/// </summary>
namespace Bridge.Demonstration
{
    /// <summary>
    /// Bridge Design Pattern Demo
    /// </summary>
    class Client
    {
        static void Main(string[] args)
        {
            //create instances of a text sender and a web sender:
            IMessageSender text = new TextSender();
            IMessageSender web = new WebServiceSender();

            //create a message and put stuff in it:
            Message message = new SystemMessage();
            message.Subject = "A Message";
            message.Body = "Hi there, Please accept this message.";

            //send it via text:
            //first assign the message to the text instance of a message sender.
            message.MessageSender = text;
            message.Send();

            //send it via web:
            //first assign the message to the web instance of a message sender.
            message.MessageSender = web;
            message.Send();

            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Abstraction' class
    /// </summary>
    public abstract class Message
    {
        public IMessageSender MessageSender { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public abstract void Send();
    }

    /// <summary>
    /// The 'RefinedAbstraction' class
    /// </summary>
    public class SystemMessage : Message
    {
        public override void Send()
        {
            MessageSender.SendMessage(Subject, Body);
        }
    }

    /// <summary>
    /// The 'Bridge/Implementor' interface
    /// </summary>
    public interface IMessageSender
    {
        void SendMessage(string subject, string body);
    }

    /// <summary>
    /// The 'ConcreteImplementor' class
    /// </summary>
    public class TextSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            string messageType = "Text";
            Console.WriteLine($"{messageType}");
            Console.WriteLine("--------------");
            Console.WriteLine($"Subject:  {subject} from {messageType}\nBody:  {body}\n");
        }
    }

    /// <summary>
    /// The 'ConcreteImplementor' class
    /// </summary>
    public class WebServiceSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            string messageType = "Web Service";
            Console.WriteLine($"{messageType}");
            Console.WriteLine("--------------");
            Console.WriteLine($"Subject:  {subject} from {messageType}\nBody:  {body}\n");
        }
    }
}

/*
Bridge Pattern:
Decouple an abstraction from its implementation
so they can be modified independently.

Example will be an app that uses different programs to send messages:
texting and a web service. The abstraction will send the messages
but won't know what the method of delivery will be.

In the code, IMessageSender is the abstract bridge (it looks like a plain old
interface to me, although we call it abstract). Then TextSender and
WebServiceSender are the two implementations of it.

What makes it a bridge is that different implementation methods
can be assigned to the same high-level abstract class. (Which actually
still just sounds like using an interface and various implementing methods?)


*/


