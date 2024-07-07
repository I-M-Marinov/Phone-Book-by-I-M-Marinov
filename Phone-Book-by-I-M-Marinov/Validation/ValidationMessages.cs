using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book_by_I_M_Marinov.Validation
{
    public class ValidationMessages
    {

        public const string ConfirmDeletionMessage = "Are you sure you want to delete {0} {1} ?";
        public const string NotAValidRow = "Not a valid row!";
        public const string NoRowSelected = "No row is selected!";
        public const string FillAllInformation = "Please fill all the information before saving!";
        public const string NameAlreadyExists = "{0} {0} already exists in the phone book.";
        public const string ErrorOpeningLink = "Error opening link: ";

    }
}
