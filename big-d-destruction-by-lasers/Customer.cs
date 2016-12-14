using System.Collections.Generic;

namespace big_d_destruction_by_lasers
{
    internal class Customer
    {
        private int _id;
        private string _name;
        private readonly List<Account> _accounts;

        public Customer(string name, int id)
        {
            _name = name;
            _id = id;
            _accounts = new List<Account>();
        }

        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }
    }
}