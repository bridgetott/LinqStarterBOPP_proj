using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblemsLINQ
{
    public static class LinqProblems
    {
        //Weighted project points: /10
        //Project points: /25
       
        #region Problem 1 
        //(5 points) Problem 1
        //Using LINQ, write a method that takes in a list of strings and returns all words that contain the substring “th” from a list.
        public static List<string> RunProblem1(List<string> words)
        {
            //code
            var thwords = new List<string>(); //make new list to return line 18
            var wordLinqQuery = from word in words where word.Contains("th") select word; //using SQL to query a local var word inside our list of words to pull out only "th" words

            foreach( var word in wordLinqQuery)
            {
                thwords.Add(word);
                Console.WriteLine(word);
            }            
            return thwords;
            


            //return
            
        }
        #endregion

        #region Problem 2 
        //(5 points) Problem 2
        //Using LINQ, write a method that takes in a list of strings and returns a copy of the list without duplicates.
        public static List<string> RunProblem2(List<string> names)
        {

            //code
            var thingWeNeed = names.Distinct().ToList();  //using the Distinct keyword from SQL to only allow one instance of each list item "name" to be added to list thingWeNeed         
            return thingWeNeed;

            


            //return

        }
        #endregion

        #region Problem 3
        //(5 points) Problem 3
        //Using LINQ, write a method that takes in a list of customers and returns the lone customer who has the name of Mike. 
        public static Customer RunProblem3(List<Customer> customers)
        {
            //code
           
            var customerMikeList = customers.Where(I => I.FirstName.Contains("Mike")).ToList(); // using a WHERE clause, pulled the customer named Mike from the list of customers and created a new list with only Mike
            Customer customerMike = customerMikeList[0]; //extract customer Mike from the new list

            return customerMike;

            

        }
        #endregion

        #region Problem 4
        //(5 points) Problem 4
        //Using LINQ, write a method that takes in a list of customers and returns the customer who has an id of 3. 
        //Then, update that customer's first name and last name to completely different names and return the newly updated customer from the method.
        public static Customer RunProblem4(List<Customer> customers)
        {
            //code
            var customerIdThreeList = customers.Where(I => I.Id == 3).ToList(); //using a WHERE clause, pulled customer with ID of 3 from the list of customers
            Customer customerIdThree = customerIdThreeList[0]; // extract customer with ID of 3 from the new list
            customerIdThree.FirstName = "Bridget"; //renamed customer with ID of 3
            customerIdThree.LastName = "Pascarella";
            Console.WriteLine(customerIdThree.FirstName + " " + customerIdThree.LastName);



            return customerIdThree;

            //return

        }
        #endregion

        #region Problem 5
        //(5 points) Problem 5
        //Using LINQ, write a method that calculates the class grade average after dropping the lowest grade for each student.
        //The method should take in a list of strings of grades (e.g., one string might be "90,100,82,89,55"), 
        //drops the lowest grade from each string, averages the rest of the grades from that string, then averages the averages.
        //Expected output: 86.125
        public static double RunProblem5(List<string> classGrades)
        {
            //code
            double numbers = 0;//placeholder
            double averageStack = 0;
            foreach (string i in classGrades)
            {
                List<double> extractedNumberList;
                extractedNumberList = new List<double>();
                List<double> sortedExtractedNumberList;
                sortedExtractedNumberList = new List<double>();
                string pattern = @",";
                double numbersBeforeAvg = 0;

                String[] elements = System.Text.RegularExpressions.Regex.Split(i, pattern);
                foreach (var element in elements)
                {
                    double elementAsANumber = Convert.ToDouble(element);
                    extractedNumberList.Add(elementAsANumber);
                    Console.WriteLine(elementAsANumber);
                }
                sortedExtractedNumberList = extractedNumberList.OrderBy(number => number).ToList();
                foreach (var item in sortedExtractedNumberList)
                {
                    Console.WriteLine(item);
                }
                sortedExtractedNumberList.RemoveAt(0);
                foreach (var item in sortedExtractedNumberList)
                {
                    numbersBeforeAvg += item;
                }
                double average = numbersBeforeAvg / sortedExtractedNumberList.Count;
                averageStack += average;
            }
            double averageOfAverages = averageStack / classGrades.Count;

            Console.WriteLine(averageOfAverages);
            return averageOfAverages;

            //return

        }

        // select classGrades from list where = 
        // select classGrades from list ORDER BY 
        #endregion

        //#region Bonus Problem 1
        ////(5 points) Bonus Problem 1
        ////Write a method that takes in a string of letters(i.e. “Terrill”) 
        ////and returns an alphabetically ordered string corresponding to the letter frequency(i.e. "E1I1L2R2T1")
        //public static string RunBonusProblem1(string word)
        //{
        //    //code

        //    //return

        //}
        //#endregion
    }
}
