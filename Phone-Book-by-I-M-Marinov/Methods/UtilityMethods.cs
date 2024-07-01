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
        private readonly ExcelControlMethods _excel;


        public UtilityMethods(PhoneBook phoneBook)
        {
            _phoneBook = phoneBook;
            _excel = new ExcelControlMethods(phoneBook);
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
        private void SearchTextBox_TextChanges(object sender, EventArgs e)
        {
            string searchString = _phoneBook.SearchTextBox.Text.ToLower(); // Get the search string, convert it to lower case ( so the search is not case-sensitive )

            if (string.IsNullOrWhiteSpace(searchString))
            {
                _phoneBook.ContactsDataGrid.DataSource = _excel.ContactsTable; // Reset the data source to the original ContactsTable
                _phoneBook.DeleteButton.Enabled = true; // Enable the delete button if the searchTextBox is IsNullOrWhiteSpace
            }
            else
            {
                DataTable filteredTable = _excel.ContactsTable.Clone(); // Create a clone of the ContactsTable 

                foreach (DataRow row in _excel.ContactsTable.Rows) // Iterate over all the Rows of the ContactsTable to look for matches to the searchString
                {
                    if (row["First Name"].ToString().ToLower().Contains(searchString))
                    {
                        filteredTable.ImportRow(row); // Import matching rows to the filtered table
                    }
                }

                _phoneBook.ContactsDataGrid.DataSource = filteredTable; // Visualize the filtered table to the DataGridView
                _phoneBook.DeleteButton.Enabled = false; // Disable the delete button while searching
            }
        }
    }
}
