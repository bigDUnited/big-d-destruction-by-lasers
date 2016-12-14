namespace big_d_destruction_by_lasers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var a = new Account(-2, 123);
            var bank = new Bank("Hello 1");
            var account1 = new Account(150,1);
            var account2 = new Account(200,2);
            //fail
            bank.Move(1350,account1,account2);
            //fail
            bank.Move(-350,account1,account2);
            //pass
            bank.Move(150,account1,account2);
        }
    }
}