//imports -- structural comments
using System;
using System.Collections.Generic;

namespace WagesApp
{
    class Program
    {
        //global variables
        static string topEarner = "";
        static int topEarnerHours = -1;

        //methods and/or functions

        static string CheckFlag()
        {
            while (true)
            {
                //get user's choice
                Console.WriteLine("Press <ENTER> to add another employee or type 'XXX'to quit\n");
                string userInput = Console.ReadLine();

                //Convert user input to uppercase
                userInput = userInput.ToUpper();

                if (userInput.Equals("XXX") || userInput.Equals("") )
                {
                    return userInput;
                }

                Console.WriteLine("Error: Please enter a correct choice.");
            }
        }

        static string CheckName()
        {
            while (true)
            {
                //get name
                Console.WriteLine("Enter the employee's name:\n");
                string name = Console.ReadLine();

                if (!name.Equals(""))
                {
                    //convert swimmer name to capitalised name
                    name = name[0].ToString().ToUpper() + name.Substring(1);
                    return name;
                }

                Console.WriteLine("Error: You must enter a name for the employee");
            }
        }



        static void CalculateWages(int totalHoursWorked, string employeeName)
        {
            //Display total weekly hours to variable sumHours.
            Console.WriteLine($"Total hours worked : {totalHoursWorked}hrs");



            //Add 5 to the total hours if the total hours >30
            if (totalHoursWorked >= 30)
            {
                totalHoursWorked += 5;


                //Display bonus hours worked
                Console.WriteLine($"5 bonus hours added: {totalHoursWorked}hrs");
            }


            if (totalHoursWorked > topEarnerHours)
            {
                topEarnerHours = totalHoursWorked;
                topEarner = employeeName;

            }


            //Calculate wages at a rate of 22/hr

            int wages = totalHoursWorked * 22;

            float tax = 0.07f;

            //Calculate tax. -- floats always end in f
            if (wages > 450)
            {
                tax = 0.08f;
            }


            //Subtract the tax from the weeklyPay to determine worker's final pay

            float finalPay = wages - (float)Math.Round(wages * tax, 2);

            //Display results 

            Console.WriteLine($"Weekly pay: {wages}\nTax rate:{tax}\nTax:{Math.Round(wages * tax, 2)}\nFinal Pay: {finalPay}\n\n\n");


        }

        static void OneEmployee()
        {
            List<string> weekDays = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            
            
                        
            //Enter and store employee name
            string employeeName = CheckName();


            //Display employee name
            Console.WriteLine(employeeName);
            int sumHoursWorked = 0;

            //Loop 5 times(below)
            for (int dayIndex = 0; dayIndex < 5; dayIndex++)
            {
                Random randGen = new Random();
                
                //Randomly generate the number of hours worked by a worker each day
                int hoursWorked = randGen.Next(2, 7);

                
                //Assign the name of the day of the week to a variable called day

                string day = weekDays[dayIndex];

                //Store / calculate the total number of hours worked over the five days for each worker. -- += means add to
                sumHoursWorked += hoursWorked;

                //Display the name of the day and the number of hours worked for each worker
                Console.WriteLine($"\tHours worked on {day}: {hoursWorked}");
                                
            }
            
            
            //Call the CalculateWages()
            CalculateWages(sumHoursWorked, employeeName);



        }


        //when run or main process -- ! equals not equals
        static void Main(string[] args)
        {
            string flagMain = "";
            
            while (!flagMain.Equals("XXX"))
            {
                OneEmployee();


                flagMain = CheckFlag();
            }

            Console.WriteLine($"{topEarner} has the most hours worked with {topEarnerHours}hrs");
            
        }
    }
}
