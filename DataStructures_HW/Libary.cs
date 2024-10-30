using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_HW
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }

        public Book(string title, string author, int year, string isbn)
        {
            Title = title;
            Author = author;
            Year = year;
            ISBN = isbn;
        }

        public override string ToString() => $"{Title} by {Author} ({Year}) - ISBN: {ISBN}";
    }

    public class Library
    {

        private Stack<Book> returnStack = new Stack<Book>();
        private LinkedList<string> readersList = new LinkedList<string>();
        private ObservableCollection<Book> libraryBooks = new ObservableCollection<Book>();
        private SortedList<string, Book> booksByISBN = new SortedList<string, Book>();
        private HashSet<string> genres = new HashSet<string>();
        private SortedSet<int> years = new SortedSet<int>();

        public Library()
        {
            libraryBooks.CollectionChanged += (sender, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (Book book in e.NewItems)
                    {
                        Console.WriteLine($"Book added to library: {book}");
                    }
                }
                else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                {
                    foreach (Book book in e.OldItems)
                    {
                        Console.WriteLine($"Book removed from library: {book}");
                    }
                }
            };
        }


        public void ReturnBook(Book book)
        {
            returnStack.Push(book);
            Console.WriteLine($"Book returned: {book}");
        }

        public void ProcessReturn()
        {
            if (returnStack.Count > 0)
            {
                Book returnedBook = returnStack.Pop();
                libraryBooks.Add(returnedBook);
                booksByISBN[returnedBook.ISBN] = returnedBook;
                AddYear(returnedBook.Year);
                Console.WriteLine($"Processed returned book: {returnedBook}");
            }
            else
            {
                Console.WriteLine("No books to process.");
            }
        }


        public void RegisterReader(string name)
        {
            readersList.AddLast(name);
            Console.WriteLine($"Reader registered: {name}");
        }

        public void RemoveReader(string name)
        {
            if (readersList.Remove(name))
            {
                Console.WriteLine($"Reader removed: {name}");
            }
            else
            {
                Console.WriteLine($"Reader not found: {name}");
            }
        }

        public void ShowAllReaders()
        {
            Console.WriteLine("Registered readers:");
            foreach (string reader in readersList)
            {
                Console.WriteLine(reader);
            }
        }


        public void AddBook(Book book)
        {
            libraryBooks.Add(book);
            booksByISBN[book.ISBN] = book;
            AddYear(book.Year);
        }

        public void RemoveBook(string isbn)
        {
            if (booksByISBN.TryGetValue(isbn, out Book book))
            {
                libraryBooks.Remove(book);
                booksByISBN.Remove(isbn);
                Console.WriteLine($"Removed book: {book}");
            }
            else
            {
                Console.WriteLine($"Book not found: ISBN {isbn}");
            }
        }


        public Book FindBookByISBN(string isbn)
        {
            return booksByISBN.TryGetValue(isbn, out Book book) ? book : null;
        }

        public void RemoveBookByISBN(string isbn)
        {
            if (booksByISBN.TryGetValue(isbn, out Book book))
            {
                libraryBooks.Remove(book);
                booksByISBN.Remove(isbn);
                Console.WriteLine($"Removed book by ISBN: {isbn}");
            }
            else
            {
                Console.WriteLine($"Book not found: ISBN {isbn}");
            }
        }


        public void AddGenre(string genre)
        {
            if (genres.Add(genre))
            {
                Console.WriteLine($"Genre added: {genre}");
            }
            else
            {
                Console.WriteLine($"Genre already exists: {genre}");
            }
        }

        public void ShowGenres()
        {
            Console.WriteLine("Available genres:");
            foreach (string genre in genres)
            {
                Console.WriteLine(genre);
            }
        }


        public void AddYear(int year)
        {
            years.Add(year);
            Console.WriteLine($"Year added: {year}");
        }

        public void ShowYears()
        {
            Console.WriteLine("Publication years in the library:");
            foreach (int year in years)
            {
                Console.WriteLine(year);
            }
        }
    }
    }
