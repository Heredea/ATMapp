using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATMinternship
{
    class Program
    {
        BankAccount selectedBankAccount;
        Bills selectedBill;
        List<BankAccount> bankAccounts;
        List<Bills> bills;

        public Program()
        {
            bankAccounts = new List<BankAccount>
            {
                new BankAccount("Paul Heredea", "1234", 100, false, true),
                new BankAccount("Catalin Heredea", "1222", 200, false, false),
                new BankAccount("Heredea Heredea", "1333", 300, false, false)
            };
        }
        void showOptions()
        {
            Console.WriteLine("--------");
            Console.WriteLine("Insert a card (press 1)");
            Console.WriteLine("--------");
        }

        void showCardOptions()
        {
            Console.WriteLine("1.Withdraw money");
            Console.WriteLine("2.Deposit");
            Console.WriteLine("3.Pay bills");
            Console.WriteLine("4.Show balance");
            Console.WriteLine("5.Withdraw card");
            Console.WriteLine("6.Block card");
        }

        void showBalance()
        {
            Console.WriteLine("Your balance : " + selectedBankAccount.Balance);
            int i = 1;
            Console.WriteLine("The history of transaction:\n");
            foreach (var item in selectedBankAccount.TranHistory)
            {
                Console.WriteLine($"{i}.{item}");
                i++;
            }

        }
        void withDrawMoney()
        {
            Console.WriteLine("Select the amount you want to withdraw:");
            int amount;
            if (int.TryParse(Console.ReadLine(), out amount))
            {
                if (selectedBankAccount.Balance <= amount)
                {
                    Console.WriteLine("Not enough funds!\n");
                    selectedBankAccount.TranHistory.Add($"Try to withdraw the amount {amount} but not enough funds - " + DateTime.UtcNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"));
                    return;
                }
                else
                {
                    selectedBankAccount.Balance -= amount;
                    selectedBankAccount.TranHistory.Add($"The amount {amount} was withdrawned - " + DateTime.UtcNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"));
                    Console.WriteLine("Operation great success!");
                    Console.WriteLine("The balance changed to: " + amount + "\n");
                }
            }
        }

        void depositMoney()
        {
            Console.WriteLine("Enter the amount you want to deposit:");
            int amount;
            if (int.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("\n");
                Console.WriteLine("The amount to deposit is: " + amount);
                Console.WriteLine("Continue?");
                Console.WriteLine("1.Yes");
                Console.WriteLine("2.No\n");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            selectedBankAccount.Balance += amount;
                            selectedBankAccount.TranHistory.Add($"The amount {amount} was added to account - " + DateTime.UtcNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"));
                            Console.WriteLine("You add the amount: " + amount + "\n");
                            break;
                        case 2:
                            break;
                    }
                }
            }
        }

        void payBills()
        {
            Console.WriteLine("Which bill you wanna pay?\n");
            int i = 1;

            foreach (var bill in selectedBankAccount.myBills)
            {
                Console.WriteLine($"{i}.{bill.Name} -- Amount: {bill.Amount}");
                i++;
            }

            i = 0;

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"For {selectedBankAccount.myBills[0].Name} you should pay {selectedBankAccount.myBills[0].Amount}");
                        Console.WriteLine("Are you you wanna proceed with this payment?");
                        Console.WriteLine("1.Yes");
                        Console.WriteLine("2.No\n");

                        if (int.TryParse(Console.ReadLine(), out choice))
                        {
                            switch (choice)
                            {
                                case 1:
                                    if (selectedBankAccount.myBills[0].IsPaid == false)
                                    {
                                        if (selectedBankAccount.myBills[0].Amount > selectedBankAccount.Balance)
                                        {
                                            selectedBankAccount.TranHistory.Add($"The {selectedBankAccount.myBills[0].Name} bill payment failed - " + DateTime.UtcNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"));
                                            Console.WriteLine("Not enough money!\n");
                                        }
                                        else
                                        {
                                            selectedBankAccount.Balance -= selectedBankAccount.myBills[0].Amount;
                                            selectedBankAccount.TranHistory.Add($"The {selectedBankAccount.myBills[0].Name} bill payment was successfully made - " + DateTime.UtcNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"));
                                            selectedBankAccount.myBills[0].IsPaid = true;
                                            Console.WriteLine("The bill was paid!\n");
                                        }
                                    }
                                    else
                                    {
                                        selectedBankAccount.TranHistory.Add($"Try to pay the {selectedBankAccount.myBills[0].Name} bill again - " + DateTime.UtcNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"));
                                        Console.WriteLine("The bill was alraedy paid! You don't need to pay it anymore!\n");
                                    }
                                    break;
                                case 2:
                                    break;
                            }
                        }

                        break;

                    case 2:
                        Console.WriteLine($"For {selectedBankAccount.myBills[1].Name} you should pay {selectedBankAccount.myBills[1].Amount}");
                        Console.WriteLine("Are you you wanna proceed with this payment?\n");
                        Console.WriteLine("1.Yes");
                        Console.WriteLine("2.No\n");

                        if (int.TryParse(Console.ReadLine(), out choice))
                        {
                            switch (choice)
                            {
                                case 1:
                                    if (selectedBankAccount.myBills[1].IsPaid == false)
                                    {
                                        if (selectedBankAccount.myBills[1].Amount > selectedBankAccount.Balance)
                                        {
                                            selectedBankAccount.TranHistory.Add($"The {selectedBankAccount.myBills[1].Name} bill payment failed - " + DateTime.UtcNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"));
                                            Console.WriteLine("Not enough money!\n");
                                        }
                                        else
                                        {
                                            selectedBankAccount.Balance -= selectedBankAccount.myBills[1].Amount;
                                            selectedBankAccount.TranHistory.Add($"The {selectedBankAccount.myBills[1].Name} bill payment was successfully made - " + DateTime.UtcNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"));
                                            selectedBankAccount.myBills[1].IsPaid = true;
                                            Console.WriteLine("The bill was paid!\n");
                                        }
                                    }
                                    else
                                    {
                                        selectedBankAccount.TranHistory.Add($"Try to pay the {selectedBankAccount.myBills[1].Name} bill again - " + DateTime.UtcNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"));
                                        Console.WriteLine("The bill was alraedy paid! You don't need to pay it anymore!\n");
                                    }
                                    break;
                                case 2:
                                    break;
                            }
                        }

                        break;

                    case 3:
                        Console.WriteLine($"For {selectedBankAccount.myBills[2].Name} you should pay {selectedBankAccount.myBills[2].Amount}");
                        Console.WriteLine("Are you you wanna proceed with this payment?");
                        Console.WriteLine("1.Yes");
                        Console.WriteLine("2.No\n");

                        if (int.TryParse(Console.ReadLine(), out choice))
                        {
                            switch (choice)
                            {
                                case 1:
                                    if (selectedBankAccount.myBills[2].IsPaid == false)
                                    {
                                        if (selectedBankAccount.myBills[2].Amount > selectedBankAccount.Balance)
                                        {
                                            selectedBankAccount.TranHistory.Add($"The {selectedBankAccount.myBills[2].Name} bill payment failed - " + DateTime.UtcNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"));
                                            Console.WriteLine("Not enough money!\n");
                                        }
                                        else
                                        {
                                            selectedBankAccount.Balance -= selectedBankAccount.myBills[2].Amount;
                                            selectedBankAccount.TranHistory.Add($"The {selectedBankAccount.myBills[2].Name} bill payment was successfully made - " + DateTime.UtcNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"));
                                            selectedBankAccount.myBills[2].IsPaid = true;
                                            Console.WriteLine("The bill was paid!\n");
                                        }
                                    }
                                    else
                                    {
                                        selectedBankAccount.TranHistory.Add($"Try to pay the {selectedBankAccount.myBills[1].Name} bill again - " + DateTime.UtcNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"));
                                        Console.WriteLine("The bill was alraedy paid! You don't need to pay it anymore!\n");
                                    }
                                    break;
                                case 2:
                                    break;
                            }
                        }

                        break;


                }
            }
        }

        void resetBills()
        {
            foreach (var bill in selectedBankAccount.myBills)
            {
                bill.IsPaid = false;
            }
        }

        void blockingCard()
        {
            Console.WriteLine("With this action your card will be blocked an can't be used anymore, untill an Admin will unblock it.");
            Console.WriteLine("Are you sure you wanna do that?");
            Console.WriteLine("1.Yes");
            Console.WriteLine("2.No\n");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        selectedBankAccount.IsLocked = true;
                        Console.WriteLine("Your card has been blocked!\n");
                        break;
                    case 2:
                        break;
                }
            }
        }
        void InsertCard()
        {
            Boolean withDrawned = false;
            Console.WriteLine("The card was inserted, please provide a PIN");
            var pin = Console.ReadLine();
            Console.WriteLine("\n");
            selectedBankAccount = null;

            foreach (var bankAccount in bankAccounts)
            {
                if (bankAccount.Id != pin)
                    continue;

                selectedBankAccount = bankAccount;
                break;
            }
            if (selectedBankAccount == null)
            {
                throw new BankAccountNotFound();
            }

            while (withDrawned == false)
            {
                if (selectedBankAccount.IsLocked == false)
                {
                    showCardOptions();
                    if (selectedBankAccount.IsAdmin == true) Console.WriteLine("7.Reset bills");
                    Console.WriteLine("\n");
                    int choice;
                    int.TryParse(Console.ReadLine(), out choice);
                    switch (choice)
                    {
                        case 1:
                            withDrawMoney();
                            break;
                        case 2:
                            depositMoney();
                            break;
                        case 3:
                            payBills();
                            break;
                        case 4:
                            showBalance();
                            break;
                        case 5:
                            withDrawned = true;
                            break;
                        case 6:
                            blockingCard();
                            withDrawned = true;
                            break;
                        case 7:
                            if (selectedBankAccount.IsAdmin == true)
                            {
                                resetBills();
                                Console.WriteLine("The bills reset succesfully!\n");
                            }
                            break;
                        default:
                            Console.WriteLine("\nNo valid option selected!2\n");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("This card is blocked!\n");
                    break;
                }
            }


        }

        static void Main(string[] args)
        {
            Program myProgram = new Program();

            while (true)
            {
                myProgram.showOptions();

                int choice;

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            try
                            {
                                myProgram.InsertCard();
                            }
                            catch (BankAccountNotFound ex)
                            {
                                Console.WriteLine("No account was found!\n");
                                Console.WriteLine(ex.Message);
                            }
                            break;
                    }
                }
            }

        }
    }
}
