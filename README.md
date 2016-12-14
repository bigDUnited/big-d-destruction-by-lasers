### Links :

#### Github URL : 
https://github.com/bigDUnited/big-d-destruction-by-lasers

#### Project URL : 
https://fronter.com/cphbusiness/links/files.phtml/885729757$989241503$/Arkiv/Contract+Based+Systems+Development/Fall+2016/Assignments/Design+by+Contract+2.pdf

### Purpose :

We were supposed to create a C# project that uses Design by Contract principles. 

The project consists of a 5 C# files - a Program class with main method, an Account class which contains the contract functionality, similar to the previous assignment, a Movement class, a Customer class and a Bank class which also implements contract methods.

### **Account** 


The contract comes into play in the AddCredit and AddDebit methods. The functionality is very similar for the two cases so we will only go through one.
```
Contract.Requires<BalanceException>(credit.Amount > 0);
```
The above line requires the credit amount to be more than 0;

```
Contract.EnsuresOnThrow<BalanceException>(
    Contract.OldValue(_credits.Count) == _credits.Count
);
Contract.EnsuresOnThrow<BalanceException>(
    Contract.OldValue(_balance) == _balance
);
```
In the case of the BalanceException being thrown we want to ensure that the list of credits and the balance are unchanged by the actions that caused the exception.

The contract functionality for the AddDebit method is the same as the one above, just that insead of credit.Amount and _credits.Count we will have debit.Amount and _debits.Count.

The final thing that we have in the account class is:
```
Contract.Invariant(
  _balance >= 0
);
```
The code above ensures that the balance will always be above 0 otherwise exceptions will be thrown.

### **Bank** 

In the bank class, the purpose of the contract is to 
```
Contract.Requires<MovementException>(amount > 0);
Contract.Requires<MovementException>(source != target);
```
The above lines require the credit amount to be more than 0 as well as the source be different from the target.

```
Contract.EnsuresOnThrow<MovementException>(
    Contract.OldValue(source.CountDebits()) == source.CountDebits()
);
Contract.EnsuresOnThrow<MovementException>(
    Contract.OldValue(target.CountCredits()) == target.CountCredits()
);
```
In the case of the MovementException being thrown we want to ensure that the list of debits in the source and the list of credits in the target remain unchanged.

### **Others**
The rest of the classes in our project do not have any contract functionality.  
Our custom exceptions are MovementException and BalanceException, the two are only thrown when the contract is being broken.
