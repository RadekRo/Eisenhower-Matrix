using System.Globalization;

namespace Eisenhower_Matrix.View;

internal class Input
{


    public string GetTitle()
    {
        var titleInput = Console.ReadLine();
        
        if (titleInput != "")
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
        var deadlineInput = Console.ReadLine();
        
        string dateFormat = "dd-MM-yyyy";

        DateTime parsedDate;
        if (DateTime.TryParseExact(deadlineInput, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
        {
            if (parsedDate.Date < DateTime.Today)
            {
                Console.WriteLine("The deadline cannot be in the past. Please enter a future date.");
                return DateTime.MinValue; // Indicating an invalid or past deadline
            }
            return parsedDate;
        }
        return parsedDate;
              
    }



    public string GetMark()
    {
        var markInput = Console.ReadLine();
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
        var importanceStatusInput = Console.ReadLine();

        if (importanceStatusInput != "")
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
        var statusInput = Console.ReadLine();

        if (statusInput != "")
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
