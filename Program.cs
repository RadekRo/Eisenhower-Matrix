﻿using System.Globalization;

namespace Eisenhower_Matrix
{
    internal class Program
    {   
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Eisenhower!");
            ToDoItem todoItem = new ToDoItem();
            var input = new Input();
            var display = new Display();
            //var quarterMatrix = 
            var importantUrgent = new ToDoQuarter();
            var notImportantUrgent = new ToDoQuarter();
            var importantNotUrgent = new ToDoQuarter();
            var notImportantNotUrgent = new ToDoQuarter();
            display.DisplayQuestion("Input task title: ");
            string userInputTitle = input.GetTitle();
            display.DisplayQuestion("Input deadline in format DD-MM: ");
            string userInputDeadline = input.GetDeadline(); // 12-12
            
            string dateFormat = "dd-MM";

            DateTime parsedDate;

            // Próba sparsowania daty
            if (DateTime.TryParseExact(userInputDeadline, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                Console.WriteLine("Parsowanie powiodło się. Data: " + parsedDate);
            }
            else
            {
                Console.WriteLine("Nie udało się sparsować daty.");
            }
            
            DateTime dateTime = DateTime.Now;
            var dateDiff = dateTime - parsedDate;
            Console.WriteLine(dateDiff);
            Console.WriteLine(dateDiff.ToString("dd"));
            Console.WriteLine(dateTime.ToString("dd.MM.yyyy"));
            Console.WriteLine(parsedDate.ToString("dd.MM.yyyy"));
            
            //display.DisplayQuestion("Is this task already done? Y/N: ");
            //string userInputMark = input.GetMark();
            display.DisplayQuestion("Select task group: \n" +
                                    "1] Important and Urgent\n" +
                                    "2] Important but Not urgent\n" +
                                    "3] Not important but Urgent\n" +
                                    "4] Not important and Not urgent\n" +
                                    "Your choice: ");
            // Is it urgent? (Y/N) Y - true, N - false
            // userInputTitle - title
            // userInputDeadline -> urgency
            // userImportance - Y / N true/false

            int importanceStatus = input.GetImportanceStatus();
            display.DisplayStatus(importanceStatus);
            //Console.WriteLine(userInputTitle);
            //Console.WriteLine(userInputDeadline);
            //Console.WriteLine(userInputMark);
            importantUrgent.AddItem(userInputTitle, userInputDeadline);
            Console.WriteLine("Important and Urgent:");
            Console.WriteLine(importantUrgent);
            Console.WriteLine("Important but Not urgent:");
            Console.WriteLine(importantNotUrgent);
            Console.WriteLine("Not important but Urgent:");
            Console.WriteLine(notImportantUrgent);
            Console.WriteLine("Not important and Not urgent:");
            Console.WriteLine(notImportantNotUrgent);
            
            //display.DisplayMatrix(importantUrgent, importantNotUrgent, notImportantUrgent, notImportantNotUrgent);
            //var newMatrix = new ToDoMatrix();
            //Console.WriteLine(newMatrix);
            var matrix = new ToDoMatrix();
            //matrix.AddItem(userInputTitle, deadline, importance);
            Console.WriteLine(matrix.ToString());
        }
    }
}