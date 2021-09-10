// Brandon Rolfe
// Project #5 (Bank Accounts)
// 4/9/21

using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_Accounts
{
    abstract class BankAccount
    {
        int accountNumber;
        string firstName;
        string lastName;
        float balance;
        protected string accountType = null;
        float annualInterestRate;

        public BankAccount()
        {
            AccountNumber = 100000;
            FirstName = "First";
            LastName = "Last";
            balance = 0.0f;
            AnnualInterestRate = 0.0f;
        }

        public BankAccount(int accountNumberIn, string firstNameIn, string lastNameIn, float annualInterestRatein = 0.0f)
        {
            AccountNumber = accountNumberIn;
            FirstName = firstNameIn;
            LastName = lastNameIn;
            balance = 0.0f;
            AnnualInterestRate = annualInterestRatein;
        }

        public BankAccount(int accountNumberIn, string firstNameIn, string lastNameIn, string accountTypeIn, float annualInterestRatein)
        {
            AccountNumber = accountNumberIn;
            FirstName = firstNameIn;
            LastName = lastNameIn;
            balance = 0.0f;
            accountType = accountTypeIn;
            AnnualInterestRate = annualInterestRatein;
        }

        public int AccountNumber
        {
            get => accountNumber;
            set
            {
                if(value <= 0)
                    throw new ArgumentOutOfRangeException("AccountNumber", "Account number cannot be zero or negative");
                else
                    accountNumber = value;
            }
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
            }
        }

        public float Balance
        {
            get => balance;
        }

        public virtual string GetAccountType() => "Bank Account";
        public abstract void SetAccountType(string accountTypeIn);

        public float AnnualInterestRate
        {
            get => annualInterestRate;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("AnnualInterestRate", "Annual Interest Rate cannot be negative");
                else
                    annualInterestRate = value;
            }
        }

        public void MakeDeposit(float deposit)
        {
            balance += deposit;
        }

        public void MakeWithdrawal(float requestedWithdrawal)
        {
            if (balance - requestedWithdrawal < 0.0f)
                throw new ArgumentOutOfRangeException("MakeWithdrawal", "Insufficient balance to make withdrawal");
            else
                balance -= requestedWithdrawal;
        }

        public float CalculateMonthlyInterest() => Balance * (AnnualInterestRate / 12.0f);

        public override string ToString()
        {
            return "Account Number: " + AccountNumber +
                 "\nFirst Name: "     + FirstName +
                 "\nLast Name: "      + LastName + 
                 "\nBalance: "        + Balance.ToString("C2");
        }
    }
}
