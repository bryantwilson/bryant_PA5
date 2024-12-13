using System;
using System.IO;

namespace pa5_bryantwilson
{
    public class TransactionsFile
    {
        private string fileName;

        public TransactionsFile(string fileName)
        {
            this.fileName = fileName;
        }

        public void SetFileName(string fileName)
        {
            this.fileName = fileName;
        }

        public string GetFileName()
        {
            return fileName;
        }

        public Transactions[] GetAllTransactions()
        {
            //creates a new array of books
            Transactions[] myTransactions = new Transactions[100];
            Transactions.SetCount(0);
            StreamReader inFile = new StreamReader(fileName);
            string input = inFile.ReadLine();

            //adds a new book to the array
            while(input != null)
            {
                string[] temp = input.Split('#');
                myTransactions[Transactions.GetCount()] = new Transactions(temp[0], temp[1], temp[2], temp[3], DateTime.Parse(temp[4]), DateTime.Parse(temp[5]));
                Transactions.IncCount();
                input = inFile.ReadLine();
            }

            inFile.Close();

            return myTransactions;
        }

        public void SaveAllTransactions(Transactions[] myTransactions)
        {
            //open
            StreamWriter inFile = new StreamWriter("Transactions.txt");

            //process
            //rewrites the books to the books to the file
            for(int i = 0; i < Transactions.GetCount(); i++)
            {
                inFile.WriteLine(myTransactions[i].ToString());
            }

            //close
            inFile.Close();
        }

        public void SaveFile(Transactions[] myTransactions)
        {
            Console.WriteLine("Where would you like to store this file?");
            string getFile = GetFile();

            //open
            StreamWriter newFile = new StreamWriter(getFile);

            //process
            for(int i = 0; i < Transactions.GetCount(); i++)
            {
                newFile.WriteLine(myTransactions[i]);
            }

            //close
            newFile.Close();
        }

        public string GetFile()
        {
            return Console.ReadLine();
        }
    }
}