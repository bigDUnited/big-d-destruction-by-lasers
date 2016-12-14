﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace big_d_destruction_by_lasers
{
    internal class Bank
    {
        private string _name;
        private List<Customer> _customersList;
        private List<Account> _accountList;


        public Bank(string name)
        {
            _name = name;
            _customersList = new List<Customer>();
            _accountList = new List<Account>();
        }

        public void Move(float amount, Account source, Account target)
        {
            Contract.Requires<MovementException>(amount > 0);
            Contract.Requires<MovementException>(source != target);
            Contract.EnsuresOnThrow<MovementException>(
                Contract.OldValue<int>(source.CountDebits()) == source.CountDebits()
            );  
            Contract.EnsuresOnThrow<MovementException>(
                Contract.OldValue<int>(target.CountCredits()) == target.CountCredits()
            );
            

            source.AddDebit(new Movement(amount, new DateTime()));
            target.AddCredit(new Movement(amount, new DateTime()));
        }

        public void MakeStatement(Customer customer, Account account)
        {
            customer.AddAccount(account);
            _accountList.Add(account);
        }

        public void AddCustomer(Customer item)
        {
            _customersList.Add(item);
        }

        internal class MovementException : Exception
        {
        }
    }
}