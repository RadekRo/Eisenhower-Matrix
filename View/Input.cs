using System.Globalization;

namespace Eisenhower_Matrix.View;

internal class Input
{


    public string GetTitle()
    {
        string? titleInput = Console.ReadLine();
        
        if (titleInput != null)
        {
            return titleInput;
        }
        else
        {
            return "No title";
        }

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
                    Console.Write("Enter valid deadline (DD-MM-YYYY): ");
                }
                else
                {
                    validDateEntered = true;
                }
            }
        }
        return parsedDate;
              
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
