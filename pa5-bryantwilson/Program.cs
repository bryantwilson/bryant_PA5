using System;
using System.IO;

namespace pa5_bryantwilson
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            Console.WriteLine("Enter 1 to Add a book.");
            Console.WriteLine("Enter 2 to Edit a book.");
            Console.WriteLine("Enter 3 to Rent a book.");
            Console.WriteLine("Enter 4 to Return a book.");
            Console.WriteLine("Enter 5 to view Reports.");
            Console.WriteLine("Enter 6 to Exit the application.");
            string userInput = GetUserInput();
            switch(userInput)
            {
                case "1":
                AddBook();
                break;

                case "2":
                EditBook();
                break;
                
                case "3":
                RentABook();
                break;

                case "4":
                ReturnBook();
                break;

                case "5":
                Reports();
                break;

                case "6":
                Exit();
                break;
                
                default:
                Console.WriteLine("Enter a valid option");
                Console.Clear();
                MainMenu();
                break;
            }
        }

        static string GetUserInput()
        {
            return Console.ReadLine();
        }

        static void AddBook()
        //get all books, open streamwriter, for loop to write all books, when loop ends writefile writeline new book, close writefile
        {
            BookFile books = new BookFile("Books.txt");
            Book[] myBooks = books.GetAllBooks();
            Book book = new Book();
            book.Add(myBooks);
            Console.Clear();
            MainMenu();
        }

        static void EditBook()
        {
        // look at screenshot, get all books, open streamwriter, for loop to write all books
            BookFile books = new BookFile("Books.txt");
            Book[] myBooks = books.GetAllBooks();
            Book book = new Book();
            book.Edit(myBooks);
            Console.Clear();
            MainMenu();
        }

        static void RentABook()
        {
            BookFile books = new BookFile("Books.txt");
            Book[] myBooks = books.GetAllBooks();
            BookReports bookReport = new BookReports(myBooks);
            Console.WriteLine("These are the books currently avliable to rent.");
            bookReport.PrintAllBooks();
            Console.WriteLine("Enter 1 to rent a book or 2 to go back to the main menu.");
            string userInput = GetUserInput();
            switch(userInput)
            {
                case "1":
                RentBook();
                break;

                case "2":
                MainMenu();
                break;

                default:
                Console.WriteLine("Enter a valid option");
                Console.Clear();
                RentABook();
                break;
            }
        }

        static void RentBook()
        {
            TransactionsFile transactions = new TransactionsFile("Transactions.txt");
            Transactions[] myTransactions = transactions.GetAllTransactions();
            Transactions transaction = new Transactions();
            transaction.Rent(myTransactions);
            Console.Clear();
            MainMenu();
        }

        static void ReturnBook()
        {
            TransactionsFile transactions = new TransactionsFile("Transactions.txt");
            Transactions[] myTransactions = transactions.GetAllTransactions();
            Transactions transaction = new Transactions();
            transaction.Return(myTransactions);
            Console.Clear();
            MainMenu();
        }

        static void Reports()
        {
            Console.WriteLine("Enter 1 to view transaction reports, 2 to view book reports, or 3 to go back to the main menu");
            string userInput = GetUserInput();
            switch(userInput)
            {
                case "1":
                TransactionsReports1();
                break;

                case "2":
                BookReports();
                break;

                case "3":
                MainMenu();
                break;

                default:
                Console.WriteLine("Enter a valid option");
                MainMenu();
                break;
            }
        }

        static void TransactionsReports1()
        {
            TransactionsFile transactions = new TransactionsFile("Transactions.txt");   
            Transactions[] myTransactions = transactions.GetAllTransactions();
            TransactionsReports reports = new TransactionsReports(myTransactions);
            Console.WriteLine("Enter 1 to see the Monthly and Yearly rentals, 2 to view rentals for a specific customer, or 3 to view all customer rentals.");
            string userInput = GetUserInput();
            switch(userInput)
            {
                case "1":
                reports.MonthYearRentals(myTransactions);
                Reports();
                break;

                case "2":
                reports.EmailRentals(myTransactions);
                Reports();
                break;

                case "3":
                reports.CustomerRentals(myTransactions);
                Reports();
                break;

                default:
                Console.WriteLine("Enter a valid option");
                MainMenu();
                break;
            }
            
            Console.WriteLine("Enter 1 to save this report to a new file, 2 to run another report, or 3 to return to the main menu.");
            userInput = GetUserInput();
            switch(userInput)
            {
                case "1":
                transactions.SaveFile(myTransactions);
                break;

                case "2":
                Reports();
                break;

                case "3":
                MainMenu();
                break;

                default:
                Console.WriteLine("Enter a valid option");
                MainMenu();
                break;
            }
        }

        static void BookReports()
        {
            BookFile book = new BookFile("Books.txt");   
            Book[] myBooks = book.GetAllBooks();
            BookReports reports = new BookReports(myBooks);
            Console.WriteLine("Enter 1 to see the Average Listering Time by Genre or 2 to return to the main menu.");
            string userInput = GetUserInput();
            switch(userInput)
            {
                case "1":
                reports.AverageListeningTimeByGenre();
                Reports();
                break;

                case "2":
                MainMenu();
                break;

                default:
                Console.WriteLine("Enter a valid option");
                MainMenu();
                break;
            }
        }

        static void Exit()
        {
            Environment.Exit(0);
        }
    }
}
