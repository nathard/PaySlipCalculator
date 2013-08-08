// Nathan Harding 210602527
using System;
using System.Collections.Generic;
using System.Text;

namespace ass1
{
    class Program
    {
        static void DisplayMenu()
        {
            Console.WriteLine("Add a person (a)");
            Console.WriteLine("Find a person (s)");
            Console.WriteLine("Display current person (p)");
            Console.WriteLine("Delete current person (d)");
            Console.WriteLine("Calculate and display pay slip  for current person (c)");
            Console.WriteLine("Exit (x)");
        }

        static void GetChoice(out char choice)
        {
            // int choice = 0;
            do Console.Write("Enter your choice ? ");
            while (char.TryParse(Console.ReadLine(), out choice) == false);


        }
        // Add person function
        static int AddPerson(Person[] SalaryList, int record)
        {
            if (record == SalaryList.Length)
                Console.WriteLine("Array is full - select 4 remove first");
            else
            {
                SalaryList[record] = new Person(); // create the object

                Console.Write("Enter Name: ");
                SalaryList[record].Name = Console.ReadLine();

                Console.Write("Enter your Street number: ");
                SalaryList[record].StreetNo = Console.ReadLine();

                Console.Write("Enter your Street address: ");
                SalaryList[record].Address = Console.ReadLine();

                Console.Write("Enter your State: ");
                SalaryList[record].State = Console.ReadLine();

                string vtemp = "";
                bool parseAttempt = true;

                int postcode;
                parseAttempt = false;
                while (parseAttempt == false)
                {
                    Console.Write("Enter your Post code: ");
                    vtemp = Console.ReadLine();
                    parseAttempt = int.TryParse(vtemp, out postcode);
                    if (parseAttempt == false)
                    {
                        Console.WriteLine("Error: Post Code must be numeric and 4 digits");
                    }
                    else
                    {
                        // Check data is logical
                        if (vtemp.Length != 4)
                        {
                            Console.WriteLine("Error: Post Code must be numeric and 4 digits");
                            parseAttempt = false;
                        }
                    }
                }

                long phoneno = 0;
                parseAttempt = false;
                while (parseAttempt == false)
                {
                    Console.Write("Enter your phone number: ");
                    vtemp = Console.ReadLine();
                    parseAttempt = long.TryParse(vtemp, out phoneno);
                    if (parseAttempt == false)
                    {
                        Console.WriteLine("Error: Phone number must be numeric and a maximum of 10 digits");
                    }
                    else
                    {
                        // Check data is logical
                        if (vtemp.Length < 1 || vtemp.Length > 10)
                        {
                            Console.WriteLine("Error: Phone number must be numeric and a maximum of 10 digits");
                            parseAttempt = false;
                        }
                    }
                }

                SalaryList[record].PhoneNo = vtemp;

                int salary = 0;
                do Console.Write("Enter Salary ");
                while (Int32.TryParse(Console.ReadLine(), out salary) == false || salary < 0);
                SalaryList[record].Salary = salary;

                record++; // increase no of record
            }
            return record;
        }
        // Search function
        static void FindPerson(Person[] SalaryList, int record)
        {
            if (record == 0)
                Console.WriteLine("There are no records to display");
            else
            {
                Console.Write("Enter Searching Name: ");
                string searchName = Console.ReadLine();
                int i;
                for (i = 0; i < record; i++)
                    if (SalaryList[i].Name.Contains(searchName))
                    {
                        Console.WriteLine(SalaryList[i]);
                        Console.Write("Press any key to display duplicate record");
                        Console.ReadLine();
                    }
                if (i == record)
                    Console.WriteLine("{0} is not on the list", searchName);
            }
        }
        // Display Record function
        static void DisplayPerson(Person[] SalaryList, int record)
        {
            if (record == 0)
                Console.WriteLine("There are no records to display");
            else
                for (int i = 0; i < record; i++)
                    Console.WriteLine(SalaryList[i]);
        }

        static void DeletePerson(Person[] SalaryList, ref int record)
        {
            if (record == 0)
                Console.WriteLine("There are no records to display");
            else
            {
                Console.Write("Enter Deleting Name: ");
                string searchName = Console.ReadLine();
                int i;
                for (i = 0; i < record; i++)
                    if (SalaryList[i].Name.Contains(searchName))
                    {
                        Console.WriteLine(SalaryList[i]);
                        Console.Write("Do you want to delete this record (y/n): ");
                        string answer = Console.ReadLine();
                        if (answer.ToLower() == "y")
                        {  // shift all record after i up by 1 place
                            for (; i < record - 1; i++)
                            {
                                SalaryList[i].Name = SalaryList[i + 1].Name;
                                SalaryList[i].StreetNo = SalaryList[i + 1].StreetNo;
                                SalaryList[i].Address = SalaryList[i + 1].Address;
                                SalaryList[i].State = SalaryList[i + 1].State;
                                SalaryList[i].PostCode = SalaryList[i + 1].PostCode;
                                SalaryList[i].PhoneNo = SalaryList[i + 1].PhoneNo;
                                SalaryList[i].Salary = SalaryList[i + 1].Salary;
                            }
                            record--; // reduce number of record by 1
                        }
                        break;
                    }
                if (i == record)
                    Console.WriteLine("{0} is not on the list", searchName);
            }

        }
        // Calculate Pay function
        static void CalculateDisplayPay(Person[] SalaryList, ref int record)
        {
            if (record == 0)
                Console.WriteLine("Array is Empty - No Details to display");
            else
            {
                float TaxRate, PayRate, GrossPay, Hours, NetPay, TotalTax;
                TaxRate = 0.0f;
                PayRate = 0.0f;
                do
                {
                    Console.Write("Enter Your Hours Worked: ");
                    if ((float.TryParse(Console.ReadLine(), out Hours) == false || Hours < 0f))
                    {
                        Console.WriteLine("Hours must not be empty or contain characters");
                    }

                } while (Hours == 0f);

                int i;
                for (i = 0; i < record; i++)

                    if (SalaryList[i].Salary > 0 && SalaryList[i].Salary < 16500)
                    {
                        TaxRate = 0.1132f;
                        PayRate = 8.68f;
                    }
                    else if (SalaryList[i].Salary < 19500)
                    {
                        TaxRate = 0.1514f;
                        PayRate = 10.26f;
                    }
                    else if (SalaryList[i].Salary < 29500)
                    {
                        TaxRate = 0.2265f;
                        PayRate = 15.54f;
                    }
                    else if (SalaryList[i].Salary < 33500)
                    {
                        TaxRate = 0.2712f;
                        PayRate = 17.63f;
                    }
                    else if (SalaryList[i].Salary < 39500)
                    {
                        TaxRate = 0.3092f;
                        PayRate = 20.79f;
                    }
                    else if (SalaryList[i].Salary < 59500)
                    {
                        TaxRate = 0.3572f;
                        PayRate = 31.31f;
                    }
                    else if (SalaryList[i].Salary < 89500)
                    {
                        TaxRate = 0.4072f;
                        PayRate = 47.12f;
                    }
                    else if (SalaryList[i].Salary > 89500)
                    {
                        TaxRate = 0.5052f;
                        PayRate = 55.67f;
                    }


                // Calculations
                GrossPay = PayRate * Hours;		// $25.55 * Hours
                TotalTax = GrossPay * TaxRate;	// $25.55 * Hours * 33%
                NetPay = GrossPay - TotalTax;	// ($25.55 * Hours) - ($25.55 * Hours * 33%)

                {
                    for (i = 0; i < record; i++)
                        Console.WriteLine(SalaryList[i]);
                }

                Console.WriteLine("\nHours Worked: \t{0}\n", Hours);
                Console.WriteLine("Pay Rate: \t{0:c}", PayRate);
                Console.WriteLine("Tax Rate: \t{0}%", TaxRate * 100);
                Console.WriteLine("Gross Pay: \t{0:c}", GrossPay);
                Console.WriteLine("Tax: \t\t{0:c}", TotalTax);
                Console.WriteLine("Net Pay: \t{0:c}\n---", NetPay);


            }


        }

        static void Main(string[] args)
        {

            // Main Program menu
            const int SIZE = 50;
            Person[] SalaryList = new Person[SIZE];

            int record = 0; // actual record
            char choice = ' ';

            while (choice != 'x')
            {
                DisplayMenu(); // call DisplayMenu() do writeline all option


                GetChoice(out choice);

                switch (choice)
                {
                    case 'a':
                        record = AddPerson(SalaryList, record);
                        break;

                    case 's':
                        FindPerson(SalaryList, record);
                        break;
                    case 'p':
                        DisplayPerson(SalaryList, record);
                        break;
                    case 'd':
                        DeletePerson(SalaryList, ref record);
                        break;
                    case 'c':
                        CalculateDisplayPay(SalaryList, ref record);
                        break;
                    case 'x':
                        break;
                    default: Console.WriteLine("Unknown option");
                        break;

                }

            }

            // delete all objects
            for (int i = 0; i < record; i++) SalaryList[i] = null;
        }
    }
}