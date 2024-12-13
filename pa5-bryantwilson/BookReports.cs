using System;

namespace pa5_bryantwilson
{
    public class BookReports
    {
        private Book[] myBooks;

        public BookReports(Book[] myBooks)
        {
            this.myBooks = myBooks;
        }
        
        public void SetMyBooks(Book[] myBooks) 
        {
            this.myBooks = myBooks;
        }

        public Book[] GetMyBooks() 
        {
            return myBooks;
        }

        public void PrintAllBooks() 
        {
            for(int i=0; i < Book.GetCount(); i++) 
            {
                Console.WriteLine(myBooks[i].ToString());
            }
        }

        public void AverageListeningTimeByGenre()
        {
            double sum = myBooks[0].GetTotalListeningTime();
            int count = 1;
            string currentGenre = myBooks[0].GetGenre();

            for(int i = 1; i < Book.GetCount(); i++)
            {
                if(myBooks[i].GetGenre() == currentGenre)
                {
                    sum =+ myBooks[i].GetTotalListeningTime();
                    count++;
                }

                else
                {
                    ProcessBreak(ref currentGenre, ref sum, ref count, i);
                }
            }

            ProcessBreak(ref currentGenre, ref sum, ref count, 0);
        }

        public void ProcessBreak(ref string currentGenre, ref double sum, ref int count, int i)
        {
            double avg = sum/count;
            Console.WriteLine($"The average listening time of {currentGenre} books is {avg}.");
        }
    }
}