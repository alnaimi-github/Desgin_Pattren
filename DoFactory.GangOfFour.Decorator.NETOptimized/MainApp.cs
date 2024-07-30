using System;
using System.Collections.Generic;

namespace DoFactory.GangOfFour.Decorator.NETOptimized
{
    /// <summary>
    /// MainApp startup class for .NET optimized 
    /// Decorator Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Create book
            var book = new Book("Worley", "Inside ASP.NET", 10);
            book.Display();

            // Create video
            var video = new Video("Spielberg", "Jaws", 23, 92);
            video.Display();

            // Make video borrowable, then borrow and display
            Console.WriteLine("\nMaking video borrowable:");

            var borrow = new Borrowable<Video>(video);
            borrow.BorrowItem("Customer #1");
            borrow.BorrowItem("Customer #2");

            borrow.Display();

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Component' abstract class
    /// </summary>
    abstract class LibraryItem<T>
    {
        // Each T has its own NumCopies
        public static int NumCopies { get; set; }

        public abstract void Display();
    }

    /// <summary>
    /// The 'ConcreteComponent' class
    /// </summary>
    class Book : LibraryItem<Book>
    {
        private string _author;
        private string _title;

        // Constructor
        public Book(string author, string title, int numCopies)
        {
            this._author = author;
            this._title = title;
            NumCopies = numCopies;
        }

        public override void Display()
        {
            Console.WriteLine("\nBook ------ ");
            Console.WriteLine(" Author: {0}", _author);
            Console.WriteLine(" Title: {0}", _title);
            Console.WriteLine(" # Copies: {0}", NumCopies);
        }
    }

    /// <summary>
    /// The 'ConcreteComponent' class
    /// </summary>
    class Video : LibraryItem<Video>
    {
        private string _director;
        private string _title;
        private int _playTime;

        // Constructor
        public Video(string director, string title,
            int numCopies, int playTime)
        {
            this._director = director;
            this._title = title;
            NumCopies = numCopies;
            this._playTime = playTime;
        }

        public override void Display()
        {
            Console.WriteLine("\nVideo ----- ");
            Console.WriteLine(" Director: {0}", _director);
            Console.WriteLine(" Title: {0}", _title);
            Console.WriteLine(" # Copies: {0}", NumCopies);
            Console.WriteLine(" Playtime: {0}\n", _playTime);
        }
    }

    /// <summary>
    /// The 'Decorator' abstract class
    /// </summary>
    abstract class Decorator<T> : LibraryItem<T>
    {
        private LibraryItem<T> _libraryItem;

        // Constructor
        public Decorator(LibraryItem<T> libraryItem)
        {
            _libraryItem = libraryItem;
        }

        public override void Display()
        {
            _libraryItem.Display();
        }
    }

    /// <summary>
    /// The 'ConcreteDecorator' class
    /// </summary>
    class Borrowable<T> : Decorator<T>
    {
        private List<string> _borrowers = new List<string>();

        // Constructor
        public Borrowable(LibraryItem<T> libraryItem)
            : base(libraryItem)
        {
        }

        public void BorrowItem(string name)
        {
            _borrowers.Add(name);
            NumCopies--;
        }

        public void ReturnItem(string name)
        {
            _borrowers.Remove(name);
            NumCopies++;
        }

        public override void Display()
        {
            base.Display();
            _borrowers.ForEach(b =>  Console.WriteLine(" borrower: " + b));
        }
    }
}
