using System;

class Book
{
    public string BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(string id, string title, string author)
    {
        BookId = id;
        Title = title;
        Author = author;
    }

    public void Display()
    {
        Console.WriteLine($"Book ID: {BookId}, Title: {Title}, Author: {Author}");
    }
}

class LibrarySearch
{
    
    public static int LinearSearch(Book[] books, string searchTitle)
    {
        for (int i = 0; i < books.Length; i++)
        {
            if (books[i].Title.Equals(searchTitle, StringComparison.OrdinalIgnoreCase))
                return i;
        }
        return -1;
    }

 
    public static int BinarySearch(Book[] books, string searchTitle)
    {
        int left = 0, right = books.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            int cmp = string.Compare(books[mid].Title, searchTitle, StringComparison.OrdinalIgnoreCase);
            if (cmp == 0) return mid;
            else if (cmp < 0) left = mid + 1;
            else right = mid - 1;
        }
        return -1;
    }

    static void Main()
    {
        Book[] books = {
            new Book("B001", "The Hobbit", "J.R.R. Tolkien"),
            new Book("B002", "Harry Potter", "J.K. Rowling"),
            new Book("B003", "Pride and Prejudice", "Jane Austen"),
            new Book("B004", "1984", "George Orwell"),
            new Book("B005", "To Kill a Mockingbird", "Harper Lee")
        };

        Console.WriteLine("📕 Linear Search for '1984':");
        int index = LinearSearch(books, "1984");
        if (index != -1) books[index].Display();
        else Console.WriteLine("Book not found.");

        Array.Sort(books, (b1, b2) => b1.Title.CompareTo(b2.Title));

        Console.WriteLine("\n📗 Binary Search for 'The Hobbit':");
        index = BinarySearch(books, "The Hobbit");
        if (index != -1) books[index].Display();
        else Console.WriteLine("Book not found.");
    }
}
