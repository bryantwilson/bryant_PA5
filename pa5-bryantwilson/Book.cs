using System;
using System.IO;

namespace pa5_bryantwilson
{
    public class Book
    {
        private string isbn;
        private string title;
        private string author;
        private string genre;
        private double totalListeningTime;
        private static int count;
        private int copiesOfBooks;

        public Book()
        {

        }

        public Book(string isbn, string title, string author, string genre, double totalListeningTime, int copiesOfBooks)
        {
            this.isbn = isbn;
            this.title = title;
            this.author = author;
            this.genre = genre;
            this.totalListeningTime = totalListeningTime;
            this.copiesOfBooks = copiesOfBooks;
        }

        public void SetIsbn(string isbn)
        {
            this.isbn = isbn;
        }

        public string GetIsbn()
        {
            return isbn;
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public string GetTitle()
        {
            return title;
        }

        public void SetAuthor(string author)
        {
            this.author = author;
        }

        public string GetAuthor()
        {
            return author;
        }

        public void SetGenre(string genre)
        {
            this.genre = genre;
        }

        public string GetGenre()
        {
            return genre;
        }

        public void SetTotalListeningTime(double totalListeningTime)
        {
            this.totalListeningTime = totalListeningTime;
        }

        public double GetTotalListeningTime()
        {
            return totalListeningTime;
        }

        public static void SetCount(int value)
        {
            count = value;
        }

        public static int GetCount()
        {
            return count;
        }

        public static void IncCount()
        {
            count++;
        }

        public void SetCopiesOfBooks(int copiesOfBooks)
        {
            this.copiesOfBooks = copiesOfBooks;
        }

        public int GetCopiesOfBooks()
        {
            return copiesOfBooks;
        }

        public bool Equals(Book tempBook)
        {
            return this.isbn == tempBook.GetIsbn();
        }

        public bool Equals(string tempIsbn)
        {
            return this.isbn == tempIsbn;
        }

        public override string ToString()
        {
            return isbn + '#' + title + '#' + author + '#' + genre + '#' + totalListeningTime + '#' + copiesOfBooks;
        }

        public int CompareTo(Book value)
        {
            return this.author.CompareTo(value.GetAuthor());
        }

        public void Add(Book[] myBooks)
        {
            Console.WriteLine("enter isbn");
            isbn = Console.ReadLine();

            if(new BookUtility(myBooks).SequentialSearch(isbn) > -1)
            {
                StreamReader inFile = new StreamReader("Books.txt");
                //lmao
                myBooks[new BookUtility(myBooks).SequentialSearch(isbn)].SetCopiesOfBooks(myBooks[new BookUtility(myBooks).SequentialSearch(isbn)].GetCopiesOfBooks() + 1);
                inFile.Close();
                BookFile bookFile = new BookFile("Books.txt");
                bookFile.SaveAllBooks(myBooks);
            }

            else
            {
                StreamWriter inFile = new StreamWriter("Books.txt");
                Console.WriteLine ("enter title");
                title = Console.ReadLine();

                Console.WriteLine("enter author");
                author = Console.ReadLine();

                Console.WriteLine("enter genre");
                genre = Console.ReadLine();

                Console.WriteLine("enter total listening time");
                totalListeningTime = Double.Parse(Console.ReadLine());

                Console.WriteLine("enter the copies of the books");
                copiesOfBooks = int.Parse(Console.ReadLine());

                for(int i = 0; i < Book.GetCount(); i++)
                {
                    inFile.WriteLine(myBooks[i].ToString());
                }
            
                inFile.WriteLine(new Book(isbn, title, author, genre, totalListeningTime, copiesOfBooks).ToString());
                inFile.Close();
            }

            //inFile.Close();
        }

        public void Edit(Book[] myBooks)
        {
            BookUtility bookUtility = new BookUtility(myBooks);
            BookFile book = new BookFile("Books.txt");
            
            //the user states what book they want to edit by entering the isbn
            Console.WriteLine("Enter the isbn of the book you would you like to edit?");
            //searchs for the isbn that matchs what the user put in
            int searchIndex = bookUtility.SequentialSearch(Console.ReadLine());

            Console.WriteLine("what would you like to edit?");
            string userInput = GetUserInput();
            switch(userInput)
            {
                case "1":
                Console.WriteLine("enter isbn");
                //sets the isbn to what the user input
                isbn = Console.ReadLine();
                //finds the original isbn in the myBooks[] then sets the isbn to the isbn that has been entered
                myBooks[searchIndex].SetIsbn(isbn);
                break;

                case "2":
                Console.WriteLine ("enter title");
                title = Console.ReadLine();
                myBooks[searchIndex].SetTitle(title);
                break;

                case "3":
                Console.WriteLine("enter author");
                author = Console.ReadLine();
                myBooks[searchIndex].SetAuthor(author);
                break;

                case "4":
                Console.WriteLine("enter genre");
                genre = Console.ReadLine();
                myBooks[searchIndex].SetGenre(genre);
                break;

                case "5":
                Console.WriteLine("enter total listening time");
                totalListeningTime = Double.Parse(Console.ReadLine());
                myBooks[searchIndex].SetTotalListeningTime(totalListeningTime);
                break;

                case "6":
                Console.WriteLine("enter the copies of the books");
                copiesOfBooks = int.Parse(Console.ReadLine());
                myBooks[searchIndex].SetCopiesOfBooks(copiesOfBooks);
                break;
            }
            
            book.SaveAllBooks(myBooks);
        }

        private string GetUserInput()
        {
            return Console.ReadLine();
        }
    }
}