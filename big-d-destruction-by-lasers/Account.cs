using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace big_d_destruction_by_lasers
{
    internal class Account
    {
        private int _account;
        private float _balance;
        private readonly List<Movement> _debits;
        private readonly List<Movement> _credits;

        public Account(float balance, int account)
        {
            _balance = balance;
            _account = account;
            _debits = new List<Movement>();
            _credits = new List<Movement>();
        }

        public void AddCredit(Movement credit)
        {
            Contract.Requires<BalanceException>(credit.Amount > 0);
            Contract.EnsuresOnThrow<BalanceException>(
                Contract.OldValue<int>(_credits.Count) == _credits.Count
            );
            Contract.EnsuresOnThrow<BalanceException>(
                Contract.OldValue<float>(_balance) == _balance
            );
            _credits.Add(credit);
            _balance += credit.Amount;
        }

        public void AddDebit(Movement debit)
        {
            Contract.Requires<BalanceException>(debit.Amount > 0);
            Contract.EnsuresOnThrow<BalanceException>(
                Contract.OldValue<int>(_debits.Count) == _debits.Count
            );
            Contract.EnsuresOnThrow<BalanceException>(
               Contract.OldValue<float>(_balance) == _balance
           );
            _debits.Add(debit);
            _balance -= debit.Amount;
        }

        public int CountDebits()
        {
            return _debits.Count;
        }

        public int CountCredits()
        {
            return _credits.Count;
        }



        [ContractInvariantMethod]
        private void Invariant()
        {
            Contract.Invariant(
                _balance >= 0
            );
        }

        internal class BalanceException : Exception
        {
        }
    }
}