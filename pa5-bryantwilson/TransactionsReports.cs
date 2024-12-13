using System;
using System.IO;

namespace pa5_bryantwilson
{
    public class TransactionsReports
    {
        private Transactions[] myTransactions;
        private int customerCount = 0;

        public TransactionsReports(Transactions[] myTransactions)
        {
            this.myTransactions = myTransactions;
        }
        
        public void SetMyTransactions(Transactions[] myTransactions) 
        {
            this.myTransactions = myTransactions;
        }

        public Transactions[] GetMyTransactions() 
        {
            return myTransactions;
        }

        public void PrintAllTransactions() 
        {
            for(int i=0; i < Transactions.GetCount(); i++) 
            {
                Console.WriteLine(myTransactions[i].ToString());
            }
        }

        public void IncCustomerCount()
        {
            customerCount++;
        }

        public void MonthYearRentals(Transactions[] myTransactions)
        {
            //I tried so hard but could not for the life of me figure out how to do different years:(
            DateTime rentalDate = DateTime.Now;
            int month = 0;
			long[] rentalsByMonth = new long[12];
			int count = 0;

			for (int i = 1; i < 13; i++)
			{
				for (int j = 0; j < Transactions.GetCount(); j++)
				{
					rentalDate = myTransactions[j].GetRentalDate();
					month = rentalDate.Month;
					if (month == i)
					{
						rentalsByMonth[count]++;
					}
				}

				count++;
			}

            Console.WriteLine("Total rentals for each month: ");
			Console.WriteLine("January: " + rentalsByMonth[0]);
			Console.WriteLine("February: " + rentalsByMonth[1]);
			Console.WriteLine("March: " + rentalsByMonth[2]);
			Console.WriteLine("April: " + rentalsByMonth[3]);
			Console.WriteLine("May: " + rentalsByMonth[4]);
			Console.WriteLine("June: " + rentalsByMonth[5]);
			Console.WriteLine("July: " + rentalsByMonth[6]);
			Console.WriteLine("August: " + rentalsByMonth[7]);
			Console.WriteLine("September: " + rentalsByMonth[8]);
			Console.WriteLine("October: " + rentalsByMonth[9]);
			Console.WriteLine("November: " + rentalsByMonth[10]);
			Console.WriteLine("December: " + rentalsByMonth[11]);
        }

        public void EmailRentals(Transactions[] transactions)
        {
            TransactionsFile OpenFile = new TransactionsFile("Transations.txt");
            TransactionsUtility transactionsUtility = new TransactionsUtility(myTransactions);
            Transactions transaction = new Transactions();
            int foundEmail = -1;
            Console.WriteLine("What is your email?");
            string email = Console.ReadLine();
            Console.WriteLine("Renatls associated with this customer: ");
            for(int i = 0; i < Transactions.GetCount(); i++)
            {
                if(transactions[i].GetEmail() == email)
                {
                    foundEmail = i;
                    transactionsUtility.SortArrayEmail(email);
                    IncCustomerCount();
                    Console.WriteLine(transactions[foundEmail].ToConsole());
                }
            }
        }

        public void CustomerRentals(Transactions[] myTransactions)
        {
            TransactionsFile openFile = new TransactionsFile("Transactions.txt");
            TransactionsUtility utility = new TransactionsUtility(myTransactions);
            Transactions transaction = new Transactions();
            openFile.GetAllTransactions();
            for(int i = 0; i < Transactions.GetCount(); i++)
            {
                utility.SortArrayName(myTransactions[2]);
                utility.SortArrayDate(myTransactions[4]);
                Console.WriteLine(myTransactions[i]);
                Console.WriteLine("Total transactions: " + Transactions.GetCount());
            }
        }
    }
}