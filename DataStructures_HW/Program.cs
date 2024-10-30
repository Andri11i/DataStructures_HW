using DataStructures_HW;
using System;


  
        Library library = new Library();
        Book book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925, "1234567890");
        Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", 1960, "0987654321");
        Book book3 = new Book("1984", "George Orwell", 1949, "1122334455");

        // Частина 1 повернення книг
        Console.WriteLine("\n--- Testing ReturnBook and ProcessReturn ---");
        library.ReturnBook(book1);
        library.ProcessReturn(); 

        library.ReturnBook(book2);
        library.ProcessReturn();

        // Частина 2 додавання та видалення читачів
        Console.WriteLine("\n--- Testing RegisterReader, RemoveReader, and ShowAllReaders ---");
        library.RegisterReader("Alice");
        library.RegisterReader("Bob");
        library.RegisterReader("Charlie");

        library.ShowAllReaders();

        library.RemoveReader("Bob"); 
        library.ShowAllReaders();

        // Частина 3 додавання та видалення книг з бібліотеки
        Console.WriteLine("\n--- Testing AddBook and RemoveBook ---");
        library.AddBook(book3); 

        library.RemoveBook(book1.ISBN); 

        // Частина 4 пошук книги за ISBN
        Console.WriteLine("\n--- Testing FindBookByISBN and RemoveBookByISBN ---");
        Book foundBook = library.FindBookByISBN("0987654321");
        Console.WriteLine(foundBook != null ? $"Found book: {foundBook}" : "Book not found");

        library.RemoveBookByISBN("0987654321"); 

        // Частина 5 додавання та відображення жанрів
        Console.WriteLine("\n--- Testing AddGenre and ShowGenres ---");
        library.AddGenre("Classic");
        library.AddGenre("Science Fiction");
        library.AddGenre("Mystery");

        library.ShowGenres();

        // Частина 6 додавання та відображення років
        Console.WriteLine("\n--- Testing AddYear and ShowYears ---");
        library.AddYear(1925);
        library.AddYear(1960);
        library.AddYear(1949);

        library.ShowYears();
