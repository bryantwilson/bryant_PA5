using System;

namespace pa5_bryantwilson
{
    public class BookUtility
    {
        private Book[] myBooks;

        public BookUtility(Book[] myBooks)
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

        public int SequentialSearch(string searchValue)
        {
            int foundIndex = -1;
            for(int i = 0; i < Book.GetCount(); i++)
            {
                if(myBooks[i].Equals(searchValue))
                {
                    foundIndex = i;
                }
            }
            return foundIndex;
        }

        public void SortArray()
        {
            for(int i = 0; i < Book.GetCount()-1; i++)
            {
                int minIndex = i;
                for(int j = i + 1; j < Book.GetCount(); i++)
                {
                    if(myBooks[minIndex].CompareTo(myBooks[j]) > 0)
                    {
                        minIndex = j;
                    }
                }

                if(minIndex!= i)
                {
                    Swap(i, minIndex);
                }
            }
        }

        public void Swap(int x, int y)
        {
            Book temp = myBooks[x];
            myBooks[x] = myBooks[y];
            myBooks [y] = temp;
        }
    }
}