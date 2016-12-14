using System;

namespace big_d_destruction_by_lasers
{
    internal class Movement
    {
        private readonly float _amount;
        private DateTime _date;

        public Movement(float amount, DateTime date)
        {
            _amount = amount;
            _date = date;
        }

        public float Amount
        {
            get { return _amount; }
        }
    }
}