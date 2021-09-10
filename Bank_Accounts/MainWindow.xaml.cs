// Brandon Rolfe
// Project #5 (Bank Accounts)
// 4/9/21

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bank_Accounts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        BankAccount[] accounts;
        public MainWindow()
        {
            InitializeComponent();

            accounts = new BankAccount[4];

            // Creates stock accounts
            try
            {
                accounts[0] = new CheckingAccount(100, "John", "Doe");
                accounts[1] = new SavingsAccount(101, "John", "Doe", 0.075f);
                accounts[2] = new CheckingAccount(102, "Sally", "May");
                accounts[3] = new SavingsAccount(103, "Sally", "May", 0.030f);
            }
            catch(ArgumentOutOfRangeException ex) when (ex.ParamName == "AccountNumber")
            {
                Result.Content = "Account number cannot be zero or negative";
            }
            catch (ArgumentOutOfRangeException ex) when (ex.ParamName == "AnnualInterestRate")
            {
                Result.Content = "Annual Interest Rate cannot be negative";
            }
            SetOutput();
        }

        // Sets/Resets the output field
        public void SetOutput()
        {
            accList.Items.Clear();

            foreach (BankAccount index in accounts)
            {
                accList.Items.Add(index.ToString());
            }
        }

        // Checks if the entered account exists
        public Boolean CheckAccount()
        {
            foreach(BankAccount index in accounts)
            {
                if (index.AccountNumber.ToString() == AccountIn.Text)
                    return true;
            }
            return false;
        }

        // Makes an entered deposit into the entered account
        private void GetDepositIn_Click(object sender, RoutedEventArgs e)
        {
            if(CheckAccount())
            {
                try
                {
                    // Finds the selected account and deposits
                    foreach (BankAccount index in accounts)
                    {
                        if (index.AccountNumber.ToString() == AccountIn.Text)
                        {
                            index.MakeDeposit(float.Parse(DepositIn.Text));
                            SetOutput();
                            Result.Content = "Deposited $" + DepositIn.Text + " into account " + AccountIn.Text;
                        }
                        break;
                    }
                }
                catch(FormatException)
                {
                    Result.Content = "Invalid Deposit";
                    return;
                }
            }
            else
            {
                Result.Content = "Invalid Account Number";
                return;
            }
        }

        // Makes an entered withdrawal into the entered account
        private void GetWithdrawalIn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckAccount())
            {
                try
                {
                    // Finds the selected account and withdraws
                    foreach (BankAccount index in accounts)
                    {
                        if (index.AccountNumber.ToString() == AccountIn.Text)
                        {
                            index.MakeWithdrawal(float.Parse(WithdrawalIn.Text));
                            SetOutput();
                            Result.Content = "Withdrew $" + WithdrawalIn.Text + " from account " + AccountIn.Text;
                        }
                        break;
                    }
                }
                catch (FormatException)
                {
                    Result.Content = "Invalid Withdrawal";
                    return;
                }
                catch(ArgumentOutOfRangeException)
                {
                    Result.Content = "Insufficient Balance";
                    return;
                }
            }
            else
            {
                Result.Content = "Invalid Account Number";
                return;
            }
        }

        // Calculates the monthly interest for the entered account
        private void CalculateMonthlyInterest_Click(object sender, RoutedEventArgs e)
        {
            if (CheckAccount())
            {
                // Finds the selected account and calculates the monthly interest
                foreach (BankAccount index in accounts)
                {
                    if (index.AccountNumber.ToString() == AccountIn.Text)
                    {
                        if (index.GetAccountType() == "Checking")
                        {
                            Result.Content = "Checking Accounts do not have interest";
                        }
                        else
                        {
                            Result.Content = "Monthly Interest is " + index.CalculateMonthlyInterest().ToString("C2") + " for account " + AccountIn.Text;
                        }
                        break;
                    }
                }
            }
            else
            {
                Result.Content = "Invalid Account Number";
                return;
            }
        }
    }
}
