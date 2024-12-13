using System;
using System.IO;

namespace pa5_bryantwilson
{
    public class BookFile
    {
        private string fileName;

        public BookFile(string fileName)
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

        public Book[] GetAllBooks()
        {
            //creates a new array of books
            Book[] myBooks = new Book[100];
            Book.SetCount(0);
            StreamReader inFile = new StreamReader(fileName);
            string input = inFile.ReadLine();

            //adds a new book to the array
            while(input != null)
            {
                string[] temp = input.Split('#');
                myBooks[Book.GetCount()] = new Book(temp[0], temp[1], temp[2], temp[3], double.Parse(temp[4]), int.Parse(temp[5]));
                Book.IncCount();
                input = inFile.ReadLine();
            }

            inFile.Close();

            return myBooks;
        }

        public void SaveAllBooks(Book[] myBooks)
        {
            //open
            StreamWriter inFile = new StreamWriter("Books.txt");

            //process
            //rewrites the books to the books to the file
            for(int i = 0; i < Book.GetCount(); i++)
            {
                inFile.WriteLine(myBooks[i].ToString());
            }

            //close
            inFile.Close();
        }
    }
}