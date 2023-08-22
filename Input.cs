﻿using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eisenhower_Matrix
{
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


        public string GetDeadline()
        {
            // input provides only day and month - year is firmed to 2023
            var deadlineInput = Console.ReadLine();
            if (deadlineInput != null)
            {
                return deadlineInput;
            }
            else
            {
                return "No deadline";
            }
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

        public bool IsImportant(string importanceStatusINPUT)
        {
            if (importanceStatusINPUT == "Y")
            {
                return true;
            }
            else { return false; }
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
            if (statusInput == "Y")
            {
                return true;
            }
            else { return false; }
        }

        
    }
}
