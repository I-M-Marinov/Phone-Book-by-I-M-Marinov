using OfficeOpenXml;
using Phone_Book_by_I_M_Marinov.Validation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book_by_I_M_Marinov.Methods
{
    public class ExcelControlMethods
    {

        private string _excelFilePath = ExcelValidation.ExcelFilePathOne;
        public DataTable ContactsTable = new();
        public SortedList<string, bool> ContactsDictionary = new();
        private readonly PhoneBook _phoneBook;



        public ExcelControlMethods(PhoneBook phoneBook)
        {
            _phoneBook = phoneBook;
        }

        public void LoadContactsFromExcel()
        {
            
            if (!File.Exists(_excelFilePath)) // Create a new Excel file if it does not exist
            {
                SetAndValidateFilePath();
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Contacts");

                    worksheet.Cells[1, 1].Value = "First Name";
                    worksheet.Cells[1, 2].Value = "Last Name";
                    worksheet.Cells[1, 3].Value = "Phone Number";
                    worksheet.Cells[1, 4].Value = "Email";

                    package.SaveAs(new FileInfo(_excelFilePath));
                }
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(new FileInfo(_excelFilePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Contacts"];
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    string firstName = worksheet.Cells[row, 1].Value?.ToString();
                    string lastName = worksheet.Cells[row, 2].Value?.ToString();
                    string phoneNumber = worksheet.Cells[row, 3].Value?.ToString();
                    string email = worksheet.Cells[row, 4].Value?.ToString();

                    ContactsTable.Rows.Add(firstName, lastName, phoneNumber, email);
                    string entryKey = GenerateEntryKey(firstName, lastName);
                    if (!ContactsDictionary.ContainsKey(entryKey))
                    {
                        ContactsDictionary.Add(entryKey, true);
                    }
                }
            }
        }
        private void SaveContactsToExcel()
    {
        if (File.Exists(_excelFilePath))
        {
            using (ExcelPackage package = new ExcelPackage(new FileInfo(_excelFilePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Contacts"];

                if (ContactsTable.Rows.Count > 0)
                {
                    if (worksheet.Dimension?.Rows > 1 && worksheet.Dimension?.Columns > 0)
                    {
                        worksheet.Cells["A2:D" + worksheet.Dimension.End.Row].Clear();
                    }

                    int rowIndex = 2;
                    foreach (DataRow row in ContactsTable.Rows)
                    {
                        if (row.RowState != DataRowState.Deleted)
                        {
                            worksheet.Cells[rowIndex, 1].Value = row["First Name"];
                            worksheet.Cells[rowIndex, 2].Value = row["Last Name"];
                            worksheet.Cells[rowIndex, 3].Value = row["Phone Number"];
                            worksheet.Cells[rowIndex, 4].Value = row["Email"];
                            rowIndex++;
                        }
                    }
                }

                if (ContactsTable.Rows.Count == 0)
                {
                    worksheet.Cells["A2:D" + worksheet.Dimension.End.Row].Clear();
                }

                package.Save();
            }
        }
    }
        private bool SetAndValidateFilePath()
    {
        if (string.IsNullOrEmpty(_excelFilePath))
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = ExcelValidation.FilterExcelFile;
            saveFileDialog.Title = ExcelValidation.TitleExcelFile;
            saveFileDialog.DefaultExt = ExcelValidation.DefaultExtExcelFile;
            saveFileDialog.FileName = ExcelValidation.FileNameExcelFile;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _excelFilePath = saveFileDialog.FileName;
            }
            else
            {
                return false; 
            }
        }

        if (File.Exists(_excelFilePath))
        {
            DialogResult overwriteResult = MessageBox.Show(ExcelValidation.OverwriteFileMessage, ExcelValidation.OverwriteFileCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (overwriteResult == DialogResult.No)
            {
                return false;
            }
        }

        return true; 
    }
        public void AddNewContactAndSave()
    {
        if (SetAndValidateFilePath())
        {
            SaveContactsToExcel();
        }
    }
        public string GenerateEntryKey(DataRow row)
        {
            return $"{row["First Name"]?.ToString().ToLower()}-{row["Last Name"]?.ToString().ToLower()}";
        }
        public string GenerateEntryKey(string firstName, string lastName)
        {
            return $"{firstName?.ToLower()} {lastName?.ToLower()}";
        }
    }
}