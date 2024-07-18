using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book_by_I_M_Marinov.Validation
{
    public class ExcelValidation
    {

        public const string FilterExcelFile = "Excel Files|*.xlsx";
        public const string TitleExcelFile = "Save Contacts to Excel File";
        public const string DefaultExtExcelFile = "xlsx";
        public const string FileNameExcelFile = "Contacts.xlsx";
        public const string OverwriteFileCaption = "File Exists";
        public const string OverwriteFileMessage = "The file Contacts.xlsx already exists in the selected directory.Do you want to overwrite it?";

    }
}