using System;
using System.IO;

namespace pa5_bryantwilson
{
    public class Transactions
    {
        private string rentalId;
        private string isbn;
        private string name;
        private string email;
        private DateTime rentalDate;
        private DateTime returnDate;

        private static int count;

        public Transactions()
        {

        }

        public Transactions(string rentalId, string isbn, string name, string email, DateTime rentalDate, DateTime returnDate)
        {
            this.rentalId = rentalId;
            this.isbn = isbn;
            this.name = name;
            this.email = email;
            this.rentalDate = rentalDate;
            this.returnDate = returnDate;
        }

        public void SetRentalId(string rentalId)
        {
            this.rentalId = rentalId;
        }

        public string GetRentalId()
        {
            return rentalId;
        }

        public void SetIsbn(string isbn)
        {
            this.isbn = isbn;
        }

        public string GetIsbn()
        {
            return isbn;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }

        public string GetEmail()
        {
            return email;
        }

        public void SetRentalDate(DateTime rentalDate)
        {
            this.rentalDate = rentalDate;
        }

        public DateTime GetRentalDate()
        {
            return rentalDate;
        }

        public void SetReturnDate(DateTime returnDate)
        {
            this.returnDate = returnDate;
        }

        public DateTime GetReturnDate()
        {
            return returnDate;
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

        public override string ToString()
        {
            return rentalId + '#' + isbn + '#' + name + '#' + email + '#' + rentalDate + '#' + returnDate;
        }

        public string ToConsole()
        {
            return rentalId + ' ' + isbn + ' ' + name + ' ' + email + ' ' + rentalDate + ' ' + returnDate;
        }

        public int CompareToEmail(Transactions value)
        {
            return this.email.CompareTo(value.GetEmail());
        }

        public int CompareToDate(Transactions value)
        {
            return this.rentalDate.CompareTo(value.GetRentalDate());
        }

        public int CompareToName(Transactions value)
        {
            return this.name.CompareTo(value.GetName());
        }

        public bool EqualsIsbn(string tempIsbn)
        {
            return this.isbn == tempIsbn;
        }

        public bool EqualsEmail(string tempEmail)
        {
            return this.email == tempEmail;
        }

        public bool EqualsRentalDate(DateTime tempRentalDate)
        {
            return this.rentalDate == tempRentalDate;
        }

        public void Rent(Transactions[] myTransactions)
        {
            BookFile bookFile = new BookFile("Books.txt");
            Book[] myBooks = bookFile.GetAllBooks();
            StreamWriter inFile = new StreamWriter("Transactions.txt");
            
            Console.WriteLine ("enter isbn");
            isbn = Console.ReadLine();

            int searchValue = new BookUtility(myBooks).SequentialSearch(isbn);
            if(myBooks[searchValue].GetCopiesOfBooks() == 0)
            {
                Console.WriteLine("There are no copies of that book left. Please pick another.");
                inFile.Close();
                Rent(myTransactions);
            }

            else
            {
                Console.WriteLine("enter rental id");
                rentalId = Console.ReadLine();

                Console.WriteLine("enter customer's name");
                name = Console.ReadLine();

                Console.WriteLine("enter customer's email");
                email = Console.ReadLine();

                DateTime now = DateTime.Now;
                rentalDate = now;
                Console.WriteLine("This is the rental date: " + now);
            
                DateTime placeHold = new DateTime(18,1,1);
                returnDate = placeHold;
                Console.WriteLine("This is the return date: " + placeHold);

                new BookUtility(myBooks).SequentialSearch(isbn);
                myBooks[new BookUtility(myBooks).SequentialSearch(isbn)].SetCopiesOfBooks(myBooks[new BookUtility(myBooks).SequentialSearch(isbn)].GetCopiesOfBooks() - 1);
                bookFile.SaveAllBooks(myBooks);

                for(int i = 0; i < Transactions.GetCount(); i++)
                {
                    inFile.WriteLine(myTransactions[i].ToString());
                }
            
                inFile.WriteLine(new Transactions(rentalId, isbn , name, email, rentalDate, returnDate).ToString());
            

                inFile.Close();
            }
        }

        public void Return(Transactions[] myTransactions)
        {
            TransactionsUtility transactionsUtility = new TransactionsUtility(myTransactions);
            TransactionsFile transactions = new TransactionsFile("Transactions.txt");
            
            Console.WriteLine("Enter the customer's email address");
            email = Console.ReadLine();

            Console.WriteLine("enter the isbn of the book they are returning");
            isbn = Console.ReadLine();

            int searchIndex = transactionsUtility.SequentialSearchEmail(email);
            int searchVal = transactionsUtility.SequentialSearchISBN(isbn);

            if(searchIndex > -1 && searchVal > -1)
            {
                BookFile bookFile = new BookFile("Books.txt");
                Book[] myBooks = bookFile.GetAllBooks();
                DateTime now = DateTime.Now;
                returnDate = now;
                myTransactions[searchIndex].SetReturnDate(returnDate);
                new BookUtility(myBooks).SequentialSearch(isbn);
                //search for book isbn to add to invintory
                myBooks[new BookUtility(myBooks).SequentialSearch(isbn)].SetCopiesOfBooks(myBooks[new BookUtility(myBooks).SequentialSearch(isbn)].GetCopiesOfBooks() + 1);
                bookFile.SaveAllBooks(myBooks);
            }

            transactions.SaveAllTransactions(myTransactions);

            // myTransactions[searchIndex].SetIsbn(isbn);

            // Console.WriteLine ("enter title");
            // title = Console.ReadLine();
            // myBooks[searchIndex].SetTitle(title);
        }
    }
}