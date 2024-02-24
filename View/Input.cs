using Eisenhower_Matrix.Manager;
using System.Globalization;

namespace Eisenhower_Matrix.View;

internal class Input
{
    
    private readonly MatrixDbManager _matrixDbManager;

    public Input(MatrixDbManager matrixDbManager)
    {
        _matrixDbManager = matrixDbManager;
    }

    public string GetTitle()
    {
        string? titleInput = null; 
        bool titleInputPresent = false;

        while (!titleInputPresent)
        {
            titleInput = Console.ReadLine();

            if (string.IsNullOrEmpty(titleInput)) 
            {
                Console.WriteLine("Title cannot be empty. Please enter a title.");
                Console.Write("Enter title: ");
            }
            else
            {
                titleInputPresent = true;
            }
        }

        return titleInput!; 
    }


    public DateTime GetDeadline()
    {
        DateTime parsedDate = DateTime.MinValue;
        bool validDateEntered = false;

        while (!validDateEntered)
        {
            string? deadlineInput = Console.ReadLine();
            string dateFormat = "dd-MM-yyyy";

            if (DateTime.TryParseExact(deadlineInput, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                if (parsedDate.Date < DateTime.Today)
                {
                    Console.WriteLine("The deadline cannot be in the past. Please enter a future date.");
                    Console.Write("Enter future deadline (DD-MM-YYYY): ");
                }
                else if (!IsDeadlineUnique(parsedDate))
                {
                    Console.WriteLine("The deadline is already taken. Please enter a unique deadline.");
                    Console.Write("Enter unique deadline (DD-MM-YYYY): ");
                }
                else
                {
                    validDateEntered = true;
                }
            }
        }
        return parsedDate;
              
    }

    private bool IsDeadlineUnique(DateTime deadline)
    {
        var allItems =  _matrixDbManager.GetAllItems();
        return allItems.All(item => item.Deadline.Date != deadline.Date);
    }


    public string GetMark()
    {
        string? markInput = Console.ReadLine();
        if (markInput != null)
        {
            return markInput;
        }
        else if (markInput == "Y")
        {
            return "X";
        }
        else if (markInput == "N")
        {
            return " ";
        }
        else
        {
            return "No mark";
        }
    }

    public string GetImportanceStatus()
    {
        string? importanceStatusInput = Console.ReadLine();

        if (importanceStatusInput != null)
        {
            return importanceStatusInput;
        }
        else
        {
            return "No importance";
        }
    }

    public bool IsImportant(string importanceStatusInput)
    {
        return importanceStatusInput == "Y";
    }

    public string GetStatus()
    {
        string? statusInput = Console.ReadLine();

        if (statusInput != null)
        {
            return statusInput;
        }
        else
        {
            return "No status";
        }
    }
    
    public bool IsDone(string statusInput)
    {
        return statusInput == "Y";
    }

    
}
