using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book_by_I_M_Marinov.Methods
{
    public class UtilityMethods
    {

        private readonly PhoneBook _phoneBook;


        public UtilityMethods(PhoneBook phoneBook)
        {
            _phoneBook = phoneBook;
        }


        public string GetFirstCellValue()
        {
            // Get the current cell's row index and column index
            int rowIndex = _phoneBook.ContactsDataGrid.CurrentCell.RowIndex;
            int colIndex = _phoneBook.ContactsDataGrid.CurrentCell.ColumnIndex;

            string currentCellValue = _phoneBook.ContactsDataGrid.Rows[rowIndex].Cells[colIndex].EditedFormattedValue.ToString();


            return currentCellValue;
        }
        public string GetSecondCellValue()
        {
            int rowIndex = _phoneBook.ContactsDataGrid.CurrentCell.RowIndex;
            int colIndex = _phoneBook.ContactsDataGrid.CurrentCell.ColumnIndex;

            string nextCellValue = "";

            DataGridViewCell nextCell = _phoneBook.ContactsDataGrid.Rows[rowIndex].Cells[colIndex].OwningRow.Cells.Cast<DataGridViewCell>()
                .FirstOrDefault(c => c.Visible && c.ColumnIndex > colIndex);

            if (nextCell != null)
            {
                nextCellValue = nextCell.EditedFormattedValue.ToString();
            }

            return nextCellValue;
        }
        public void ClearAllEntries()
        {
            _phoneBook.FirstNameTextBox.Text = "";
            _phoneBook.LastNameTextBox.Text = "";
            _phoneBook.PhoneNumberTextBox.Text = "";
            _phoneBook.EmailTextBox.Text = "";
        }
        
    }
}