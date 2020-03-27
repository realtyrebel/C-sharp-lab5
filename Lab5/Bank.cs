using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;//needed for CultureInfo function

namespace Lab5
{
    class Bank
    {
        static void Main(string[] args)
        {
            /*
             * List<SavingsAccount> listAccounts = new List<SavingsAccount>();//blank list
             * SavingsAccount newAccount = new SavingsAccount();//creates new class
             * listAccounts.Add(newAccount);//add class to list
             * */

            //initialize variables
            double initialSavingsDeposit = 0.0;

            int selectedCustomer = -1;

            int maxOptionSelection;
            int minOptionSelection;
            int inputSelection;

            double inputAmount;

            List<Customer> listCustomers = new List<Customer>();//blank list of customers


            //start program
            Console.WriteLine("Welcome to Algonquin Bank");
            Console.WriteLine("");

            //step 1: create Customers and Accounts
            bool getMoreCustomers = true;
            do
            {
                Console.Write("Please enter new customer name: ");
                string inputName = Console.ReadLine();
                string customerName = new CultureInfo("en-US").TextInfo.ToTitleCase(inputName);

                if (!string.IsNullOrEmpty(customerName))//if not null or empty, create new account
                {
                    //Initial Deposit Amount
                    Console.Write("Please enter {0}'s initial deposit amount: $", customerName);
                    string input = Console.ReadLine();

                    Console.WriteLine("");
                    
                    if (input != "")
                    {
                        initialSavingsDeposit = Convert.ToDouble(input);

                        //create a new Customer object
                        Customer newCustomer = new Customer(customerName, initialSavingsDeposit);

                        //add new Customer object to list of customers
                        listCustomers.Add(newCustomer);
                    }                    
                }
                else
                {
                    //set continueInput to false to exit loop
                    getMoreCustomers = false;
                    Console.WriteLine("");
                }
            } while (getMoreCustomers);



            //list all Customers
            Console.WriteLine("Select one of the following customers:");

            for (int i=0; i < listCustomers.Count(); i++)
            {
                Console.WriteLine(" {0}. Customer {1} has a {2} account", i, listCustomers[i].Name, listCustomers[i].Status);
            }

            Console.WriteLine("");

            /*
            if (listCustomers.Count() > 0)
            {
                int i = 1;
                foreach (Customer customer in listCustomers)
                {
                    Console.WriteLine("  {0}: {1}", i, customer.Name);
                    i++;
                }

            }
            */

            //select Customer
            inputSelection = -1;
            minOptionSelection = 0;
            maxOptionSelection = listCustomers.Count() - 1;
            inputSelection = getSelection(minOptionSelection, maxOptionSelection);
            if(inputSelection != -1)
            {
                //set the selected customer number
                selectedCustomer = inputSelection;
                Console.WriteLine("");
                Console.WriteLine("Hello {0}. ", listCustomers[selectedCustomer].Name);
            }


            bool doNextActivity = true;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("Select activity:");
                Console.WriteLine("");
                Console.WriteLine(" 1. Deposit ...");
                Console.WriteLine(" 2. Withdraw ...");
                Console.WriteLine(" 3. Transfer ...");
                Console.WriteLine(" 4. Balance Enquiry ...");
                Console.WriteLine(" 5. Account Activity Enquiry ...");
                Console.WriteLine(" 6. Exit");
                

                //select Activity
                inputSelection = -1;
                minOptionSelection = 1;
                maxOptionSelection = 6;
                inputSelection = getSelection(minOptionSelection, maxOptionSelection);
                if (inputSelection != -1)
                {
                    switch (inputSelection)
                    {
                        case 1://Deposit

                            Console.WriteLine("");
                            Console.WriteLine(" 1. Deposit Funds to Chequing Account");
                            Console.WriteLine(" 2. Deposit Funds to Savings Account");                            
                            
                            inputSelection = -1;
                            minOptionSelection = 1;
                            maxOptionSelection = 2;
                            inputSelection = getSelection(minOptionSelection, maxOptionSelection);
                            if (inputSelection != -1)
                            {
                                //get amount to deposit
                                inputAmount = getAmount();

                                if (inputSelection == 1)
                                {
                                    //deposit to Chequing Account
                                    try
                                    {
                                        listCustomers[selectedCustomer].ChequingAccount.Deposit(inputAmount, Enums.TransactionType.DEPOSIT);

                                        Console.WriteLine("");
                                        Console.WriteLine("Deposited ${0} to Chequing Account. Current Chequing Account balance: ${1}", inputAmount, listCustomers[selectedCustomer].ChequingAccount.Balance);
                                    }
                                    catch (Exception error)
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine(error.Message);
                                    }                                    
                                }
                                else
                                {
                                    //deposit to Savings Account
                                    try
                                    {
                                        listCustomers[selectedCustomer].SavingsAccount.Deposit(inputAmount, Enums.TransactionType.DEPOSIT);

                                        Console.WriteLine("");
                                        Console.WriteLine("Deposited ${0} to Savings Account. Current Savings Account balance: ${1}", inputAmount, listCustomers[selectedCustomer].SavingsAccount.Balance);
                                    }
                                    catch (Exception error)
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine(error.Message);
                                    }                                    
                                } 
                            }
                            break;

                        case 2://Withdraw

                            Console.WriteLine("");
                            Console.WriteLine(" 1. Withdraw Funds from Chequing Account");
                            Console.WriteLine(" 2. Withdraw Funds from Savings Account");

                            inputSelection = -1;
                            minOptionSelection = 1;
                            maxOptionSelection = 2;
                            inputSelection = getSelection(minOptionSelection, maxOptionSelection);
                            if (inputSelection != -1)
                            {
                                //get Amount to Withdraw
                                inputAmount = getAmount();

                                if (inputSelection == 1)
                                {
                                    //Withdraw funds from ChequingAccount
                                    try
                                    {
                                        listCustomers[selectedCustomer].ChequingAccount.Withdraw(inputAmount, Enums.TransactionType.WITHDRAWAL);

                                        Console.WriteLine("");
                                        Console.WriteLine("Withdrawn ${0} from Chequing Account. Current Chequing Account balance: ${1}", inputAmount, listCustomers[selectedCustomer].ChequingAccount.Balance);
                                    }
                                    catch (Exception error)
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine(error.Message);
                                    }                                    
                                }
                                else
                                {
                                    //Withdraw funds from SavingsAccount
                                    try
                                    {
                                        listCustomers[selectedCustomer].SavingsAccount.Withdraw(inputAmount, Enums.TransactionType.WITHDRAWAL);

                                        Console.WriteLine("");
                                        Console.WriteLine("Withdrawn ${0} from Savings Account. Current Savings Account balance: ${1}", inputAmount, listCustomers[selectedCustomer].SavingsAccount.Balance);
                                    }
                                    catch (Exception error)
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine(error.Message);
                                    }                                    
                                }
                            }
                            break;

                        case 3://Transfer

                            Console.WriteLine("");
                            Console.WriteLine(" 1. Transfer from Chequing Account to Savings Account");
                            Console.WriteLine(" 2. Transfer from Savings Account to Chequing Account");

                            inputSelection = -1;
                            minOptionSelection = 1;
                            maxOptionSelection = 2;
                            inputSelection = getSelection(minOptionSelection, maxOptionSelection);
                            if (inputSelection != -1)
                            {
                                inputAmount = getAmount();
                                
                                if (inputSelection == 1)
                                {
                                    //Transfer from Chequing Account to Savings Account
                                    try
                                    {
                                        //check to see if there are available funds
                                        if (inputAmount <= listCustomers[selectedCustomer].ChequingAccount.Balance)
                                        {
                                            //Withdraw funds from ChequingAccount
                                            listCustomers[selectedCustomer].ChequingAccount.Withdraw(inputAmount, Enums.TransactionType.TRANSFER_OUT);

                                            //Deposit funds to SavingsAccount
                                            listCustomers[selectedCustomer].SavingsAccount.Deposit(inputAmount, Enums.TransactionType.TRANSFER_IN);

                                            Console.WriteLine("");
                                            Console.WriteLine("Transferred ${0} from Chequing Account to Savings Account.", inputAmount);
                                        }
                                        else
                                        {
                                            throw new Exception("Transfer cancelled: INSUFFICIENT_FUNDS");
                                        }
                                    }
                                    catch (Exception error)
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine(error.Message);
                                    }                                    
                                }                                
                                else
                                {
                                    //Transfer from Savings Account to Chequing Account
                                    try
                                    {
                                        //check to see if there are available funds
                                        if (inputAmount <= listCustomers[selectedCustomer].SavingsAccount.Balance)
                                        {
                                            //Withdraw funds from SavingsAccount
                                            listCustomers[selectedCustomer].SavingsAccount.Withdraw(inputAmount, Enums.TransactionType.TRANSFER_OUT);

                                            //Deposit funds to ChequingAccount
                                            listCustomers[selectedCustomer].ChequingAccount.Deposit(inputAmount, Enums.TransactionType.TRANSFER_IN);

                                            Console.WriteLine("");
                                            Console.WriteLine("Transferred ${0} from Savings Account to Chequing Account.", inputAmount);
                                        }
                                        else
                                        {
                                            throw new Exception("Transfer cancelled: INSUFFICIENT_FUNDS");
                                        }
                                    }
                                    catch (Exception error)
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine(error.Message);
                                    }                                    
                                }
                            }
                            break;
                        case 4://Balance Enquiry

                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine(" Current Balance \t Account");
                            Console.WriteLine(" --------------- \t -------");
                            Console.WriteLine(" ${0} \t\t\t Chequing", listCustomers[selectedCustomer].ChequingAccount.Balance);
                            Console.WriteLine(" ${0} \t\t\t Savings - {1}", listCustomers[selectedCustomer].SavingsAccount.Balance, listCustomers[selectedCustomer].Status);

                            break;
                        case 5://Account Activity

                            Console.WriteLine("");
                            Console.WriteLine("Transaction History for Chequing Account:");
                            for (int i = 0; i < listCustomers[selectedCustomer].ChequingAccount.TransactionHistory.Count(); i++)
                            {
                                Console.WriteLine(" {0}. ${1} {2} - {3}", i, listCustomers[selectedCustomer].ChequingAccount.TransactionHistory[i].Amount, listCustomers[selectedCustomer].ChequingAccount.TransactionHistory[i].Type, listCustomers[selectedCustomer].ChequingAccount.TransactionHistory[i].TransactionDate);
                            }

                            Console.WriteLine("");
                            Console.WriteLine("Transaction History for Savings Account:");
                            for (int i = 0; i < listCustomers[selectedCustomer].SavingsAccount.TransactionHistory.Count(); i++)
                            {
                                Console.WriteLine(" {0}. ${1} {2} - {3}", i, listCustomers[selectedCustomer].SavingsAccount.TransactionHistory[i].Amount, listCustomers[selectedCustomer].SavingsAccount.TransactionHistory[i].Type, listCustomers[selectedCustomer].SavingsAccount.TransactionHistory[i].TransactionDate);
                            }

                            break;
                        default://Exit
                            doNextActivity = false;
                            Console.WriteLine("Exiting program.");
                            Console.WriteLine("");
                            break;
                    }
                }
            } while (doNextActivity);
        }//end Main


        //Method to get valid integer
        static double getAmount()
        {
            bool validInput = false;
            double amount = 0.0;
            double inputAmount;

            //check for valid input
            do
            {
                Console.WriteLine("");
                Console.Write("Enter Amount: $");
                string inputString = Console.ReadLine();

                if (!string.IsNullOrEmpty(inputString))//if not null, process integer values
                {
                    //check if input is valid integer
                    if (double.TryParse(inputString, out inputAmount))
                    {
                        if (inputAmount < 0.0)
                        {
                            Console.WriteLine("Error: Invalid input.");
                        }
                        else if (inputAmount == 0.0)
                        {
                            Console.WriteLine("Error: Amount should be greater than zero.");
                        }
                        else
                        {
                            amount = inputAmount;
                            validInput = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: Invalid input.");
                    }
                }
                else
                {//if null or empty
                    Console.WriteLine("Error: You did not enter an integer.");
                }
            } while (validInput == false);

            return amount;
        }


        //Method to get valid selection number from the user
        static int getSelection(int minOptionSelection, int maxOptionSelection)
        {
            bool validInput = false;
            int integer = -1;
            int inputNumber;

            //check for valid input
            do
            {
                Console.WriteLine("");
                if(minOptionSelection == maxOptionSelection)
                {
                    Console.Write("Enter selection number: ");
                }
                else
                {
                    Console.Write("Enter selection number from {0} to {1}: ", minOptionSelection, maxOptionSelection);
                }
                
                string inputString = Console.ReadLine();

                if (!string.IsNullOrEmpty(inputString))//if not null, process integer values
                {
                    //check if input is valid integer
                    if (int.TryParse(inputString, out inputNumber))
                    {
                        if (inputNumber < minOptionSelection || inputNumber > maxOptionSelection)
                        {
                            Console.WriteLine("Error: Invalid selection.");
                        }
                        else
                        {
                            integer = inputNumber;
                            validInput = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: Invalid input.");
                    }
                }
                else
                {//if null or empty
                    Console.WriteLine("Error: You did not enter an integer.");
                }
            } while (validInput == false);

            return integer;
        }
    }//end class Bank    
}
