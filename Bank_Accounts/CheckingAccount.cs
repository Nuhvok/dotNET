// Brandon Rolfe
// Project #5 (Bank Accounts)
// 4/9/21

using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_Accounts
{
    class CheckingAccount : BankAccount
    {
        public CheckingAccount(int accountNumberIn, string firstNameIn, string lastNameIn) : base(accountNumberIn, firstNameIn, lastNameIn, 0.0f)
        {
            SetAccountType("Checking");
        }

        public sealed override string GetAccountType() => accountType;

        public override void SetAccountType(string accountTypeIn)
        {
            accountType = accountTypeIn;
        }

        public override string ToString()
        {
            return base.ToString() +
                   "\nAccount Type: " + GetAccountType();
        }
    }
}
