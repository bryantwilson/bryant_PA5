using System;

namespace pa5_bryantwilson
{
    public class TransactionsUtility
    {
        private Transactions[] myTransactions;

        public TransactionsUtility(Transactions[] myTransactions)
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

        public int SequentialSearchISBN(string searchValue)
        {
            int foundIndex = -1;
            for(int i = 0; i < Transactions.GetCount(); i++)
            {
                if(myTransactions[i].EqualsIsbn(searchValue))
                {
                    foundIndex = i;
                }
            }
            return foundIndex;
        }

        public int SequentialSearchEmail(string searchValue)
        {
            int foundIndex = -1;
            for(int i = 0; i < Transactions.GetCount(); i++)
            {
                if(myTransactions[i].EqualsEmail(searchValue))
                {
                    foundIndex = i;
                }
            }
            return foundIndex;
        }

        public int SequentialSearchRentalDate(DateTime searchVal)
        {
            int foundIndex = -1;
            for(int i = 0; i < Transactions.GetCount(); i++)
            {
                if(myTransactions[i].EqualsRentalDate(searchVal))
                {
                    foundIndex = i;
                }
            }
            return foundIndex;
        }

        public void SortArrayEmail(string email)
        {
            for(int i = 0; i < Transactions.GetCount()-1; i++)
            {
                int minIndex = i;
                for(int j = i + 1; j < Transactions.GetCount(); j++)
                {
                    if(myTransactions[minIndex].CompareToEmail(myTransactions[j]) > 0)
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

        public void SortArrayDate(Transactions transactions)
        {

            for(int i = 0; i < Transactions.GetCount()-1; i++)
            {
                int minIndex = i;
                for(int j = i + 1; j < Transactions.GetCount(); j++)
                {
                    if(myTransactions[minIndex].CompareToDate(myTransactions[j]) > 0)
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

        public void SortArrayName(Transactions transactions)
        {
            for(int i = 0; i < Transactions.GetCount()-1; i++)
            {
                int minIndex = i;
                for(int j = i + 1; j < Transactions.GetCount(); j++)
                {
                    if(myTransactions[minIndex].CompareToName(myTransactions[j]) > 0)
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
            Transactions temp = myTransactions[x];
            myTransactions[x] = myTransactions[y];
            myTransactions [y] = temp;
        }
    }
}