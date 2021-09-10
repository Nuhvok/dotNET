// Brandon Rolfe
// Project #5 (Bank Accounts)
// 4/9/21

using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_Accounts
{
    class SavingsAccount: BankAccount
    {
        public SavingsAccount(int accountNumberIn, string firstNameIn, string lastNameIn, float annualInterestRatein) : base(accountNumberIn, firstNameIn, lastNameIn, annualInterestRatein)
        {
            SetAccountType("Savings");
        }

        public sealed override string GetAccountType() => accountType;

        public override void SetAccountType(string accountTypeIn)
        {
            accountType = accountTypeIn;
        }

        public override string ToString()
        {
            return base.ToString() +
                   "\nAccount Type: "  + GetAccountType() +
                   "\nInterest Rate: " + ((AnnualInterestRate) * 100.0f).ToString("N2") + "%";
        }
    }
}
