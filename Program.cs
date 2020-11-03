using System;
using System.Text.RegularExpressions;

namespace GetToKnowYourClassmates
{
    class Program
    {
        static void Main(string[] args)
        {
            string yesNo = string.Empty;
            string[,] studentInfoMatrix = new string[,]
            {
                { "Jason", "Steak", "Redford","blue" },
                { "Mike", "Spegetti", "Livonia","red" },
                {"Greg","Chicken","Detroit", "black"},
                {"Jeana","Tacos","New Orleans", "green" },
                 { "James", "five guys", "Bedford", "cyan" },
                { "Mary", "fish tacos", "Portland", "orange" },
                {"Steve","Chulupas","Dallas", "gray"},
                {"Jeremy","Sandwiches","Traverse City", "yellow" },
                 { "David", "Stir fry", "Pitsburg", "rose" },
                { "Bill", "Waffles", "Bend", "Pink" },
                {"Hillary","Chicken and dumplings","Monroe", "blue"},
                {"Tory","French Fries","Toronto", "dark red" },
                 { "Kyle", "Pork Chops", "Redford" , "pink"},
                { "Bob", "Reese cups", "Roswell", "red" },
                {"Paul","Turkey burgers","Seattle", "blue"},
                {"Hanna","tacos","Calgury" , "green"},
            };
            do
            {
                CollectUserInfo(studentInfoMatrix);
                Console.WriteLine("do you want to learn about another student?");
                Console.WriteLine("please enter yes or no");
                yesNo = Console.ReadLine();
            } while (YesNoValidator(yesNo));
        }
        public static void CollectUserInfo(string[,] studentInfoMatrix)
        {
           
                Console.WriteLine("Its kinda creapy to ask questons about a bunch of people you dont know but I'm game");
                Console.WriteLine("Please enter a number between 1-20");
                uint.TryParse(Console.ReadLine(), out uint studentNumber);
                uint studentIndex=GetStudentIndex(studentNumber);
                string studentName=GetStudentName(studentIndex, studentInfoMatrix);
                Console.WriteLine($"what would you like to know about {studentName}");
                Console.WriteLine("[1] for favorite food [2] for hometown [3] for favorite color");
                uint.TryParse(Console.ReadLine(), out uint infoIndex);
                string studentInfo = GetStudentInfo(studentIndex, studentInfoMatrix, infoIndex);
                DisplayStudentInfo(studentInfo, studentName, infoIndex);
            
        }
        public static uint GetStudentIndex(uint studentNumber) => studentNumber - 1;

        public static string GetStudentName(uint studentIndex, string[,] studentInfoMatrix) => studentInfoMatrix[studentIndex, 0];

        public static string GetStudentInfo(uint studentIndex, string[,] studentInfoMatrix, uint infoIndex) => studentInfoMatrix[studentIndex, infoIndex];
        private static void DisplayStudentInfo(string studentInfo, string studentName, uint infoIndex)
        {
            if (infoIndex == 1)
            {
                Console.WriteLine($"{studentName}'s favorite food is {studentInfo}");
            }
            if (infoIndex == 2)
            {
                Console.WriteLine($"{studentName}'s hometown is {studentInfo}");
            }
            if (infoIndex == 3)
            {
                Console.WriteLine($"{studentName}'s favorite color {studentInfo}");
            }
        }
        private static Boolean YesNoValidator(string yesNo)
        {
            Regex yesNoPattern = new Regex(@"^((Y|y)|(ES|es))");
            if (yesNoPattern.IsMatch(yesNo))
            {
                return true;
            }
            Console.WriteLine("thank you for being a weirdo");
            return false;
        }
    }
}