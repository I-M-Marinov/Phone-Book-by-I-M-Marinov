using OfficeOpenXml;
using System.Data;
using System.Drawing.Text;
using Phone_Book_by_I_M_Marinov.Methods;

namespace Phone_Book_by_I_M_Marinov
{
    public partial class PhoneBook : Form
    {

        bool isEdited;
        private int lastEntryIndex = -1;
        private readonly ExcelControlMethods _excel;


        public PhoneBook()
        {
            InitializeComponent();
            searchTextBox.TextChanged += SearchTextBox_TextChanges;
            _excel = new ExcelControlMethods(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeContactsTable();
            _excel.LoadContactsFromExcel();
        }

        private void InitializeContactsTable()
        {
            _excel.contactsTable.Columns.Add("First Name");
            _excel.contactsTable.Columns.Add("Last Name");
            _excel.contactsTable.Columns.Add("Phone Number");
            _excel.contactsTable.Columns.Add("Email");

            contactsDataGrid.DataSource = _excel.contactsTable;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (contactsDataGrid.CurrentCell != null && contactsDataGrid.CurrentCell.RowIndex >= 0)
            {
                string nameCellValue = GetFirstCellValue();
                string lastNameCellValue = GetSecondCellValue();


                // Show confirmation dialog
                DialogResult result = MessageBox.Show($"Are you sure you want to delete {nameCellValue} {lastNameCellValue} ?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // If user clicks 'Yes', proceed with deletion
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int rowIndex = contactsDataGrid.CurrentCell.RowIndex;
                        string entryKey = _excel.GenerateEntryKey(_excel.contactsTable.Rows[rowIndex]);
                        _excel.contactsTable.Rows.RemoveAt(rowIndex);
                        _excel.contactsDictionary.Remove(entryKey);
                        _excel.SaveContactsToExcel();

                        if (_excel.contactsTable.Rows.Count == 0)
                        {
                            ClearAllEntries();
                            isEdited = false;
                        }
                        else
                        {
                            if (rowIndex >= _excel.contactsTable.Rows.Count)
                            {
                                rowIndex = _excel.contactsTable.Rows.Count - 1;
                            }
                            contactsDataGrid.CurrentCell = contactsDataGrid.Rows[rowIndex].Cells[0];
                            contactsDataGrid.Rows[rowIndex].Selected = true;
                        }

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Not a valid row!");
                    }
                }

            }
            else
            {
                MessageBox.Show("No row is selected!");
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(lastNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(phoneNumberTextBox.Text) ||
                string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                MessageBox.Show("Please fill all the information before saving!");
                return;
            }

            string entryKey = _excel.GenerateEntryKey(firstNameTextBox.Text, lastNameTextBox.Text);

            if (isEdited)
            {
                if (contactsDataGrid.CurrentCell != null)
                {
                    _excel.contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex]["First Name"] = firstNameTextBox.Text;
                    _excel.contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex]["Last Name"] = lastNameTextBox.Text;
                    _excel.contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex]["Phone Number"] = phoneNumberTextBox.Text;
                    _excel.contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex]["Email"] = emailTextBox.Text;
                    _excel.SaveContactsToExcel();
                }
                else
                {
                    MessageBox.Show("No row was selected!");
                    return;
                }
            }
            else
            {
                if (_excel.contactsDictionary.ContainsKey(entryKey))
                {
                    MessageBox.Show($"{firstNameTextBox.Text} {lastNameTextBox.Text} already exists in the phone book.");
                }
                else
                {
                    AddEntryToDataTable(firstNameTextBox.Text, lastNameTextBox.Text, phoneNumberTextBox.Text, emailTextBox.Text);
                    _excel.SaveContactsToExcel();
                }
            }

            ClearAllEntries();
            isEdited = false;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (contactsDataGrid.CurrentCell != null && contactsDataGrid.CurrentCell.RowIndex >= 0)
            {
                int rowIndex = contactsDataGrid.CurrentCell.RowIndex;

                if (rowIndex < _excel.contactsTable.Rows.Count)
                {
                    firstNameTextBox.Text = _excel.contactsTable.Rows[rowIndex].ItemArray[0].ToString();
                    lastNameTextBox.Text = _excel.contactsTable.Rows[rowIndex].ItemArray[1].ToString();
                    phoneNumberTextBox.Text = _excel.contactsTable.Rows[rowIndex].ItemArray[2].ToString();
                    emailTextBox.Text = _excel.contactsTable.Rows[rowIndex].ItemArray[3].ToString();
                    isEdited = true;
                }
                else
                {
                    ClearAllEntries();
                }
            }
        }

        private void newEntryButton_Click(object sender, EventArgs e)
        {
            ClearAllEntries();
        }

        private void contactsDataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (contactsDataGrid.CurrentCell != null && lastEntryIndex == contactsDataGrid.CurrentCell.RowIndex + 1)
            {
                firstNameTextBox.Text = _excel.contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].ItemArray[0].ToString();
                lastNameTextBox.Text = _excel.contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].ItemArray[1].ToString();
                phoneNumberTextBox.Text = _excel.contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].ItemArray[2].ToString();
                emailTextBox.Text = _excel.contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].ItemArray[3].ToString();
                isEdited = true;
            }
        }

        private void ClearAllEntries()
        {
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            phoneNumberTextBox.Text = "";
            emailTextBox.Text = "";
        }

        private void AddEntryToDataTable(string firstName, string lastName, string phoneNumber, string email)
        {
            _excel.contactsTable.Rows.Add(firstName, lastName, phoneNumber, email);
            string entryKey = _excel.GenerateEntryKey(firstName, lastName);
            if (!_excel.contactsDictionary.ContainsKey(entryKey))
            {
                _excel.contactsDictionary.Add(entryKey, true);
            }
            lastEntryIndex = _excel.contactsTable.Rows.Count - 1;
        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://github.com/I-M-Marinov/Phone-Book-by-I-M-Marinov";

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening link: " + ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/I-M-Marinov/Phone-Book-by-I-M-Marinov";

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening link: " + ex.Message);
            }
        }

        private void SearchTextBox_TextChanges(object sender, EventArgs e)
        {
            string searchString = searchTextBox.Text.ToLower(); // Get the search string, convert it to lower case ( so the search is not case-sensitive )

            if (string.IsNullOrWhiteSpace(searchString))
            {
                contactsDataGrid.DataSource = _excel.contactsTable; // Reset the data source to the original contactsTable
                deleteButton.Enabled = true; // Enable the delete button if the searchTextBox is IsNullOrWhiteSpace
            }
            else
            {
                DataTable filteredTable = _excel.contactsTable.Clone(); // Create a clone of the contactsTable 

                foreach (DataRow row in _excel.contactsTable.Rows) // Iterate over all the Rows of the contactsTable to look for matches to the searchString
                {
                    if (row["First Name"].ToString().ToLower().Contains(searchString))
                    {
                        filteredTable.ImportRow(row); // Import matching rows to the filtered table
                    }
                }

                contactsDataGrid.DataSource = filteredTable; // Visualize the filtered table to the DataGridView
                deleteButton.Enabled = false; // Disable the delete button while searching
            }
        }

        private string GetFirstCellValue()
        {
            // Get the current cell's row index and column index
            int rowIndex = contactsDataGrid.CurrentCell.RowIndex;
            int colIndex = contactsDataGrid.CurrentCell.ColumnIndex;

            string currentCellValue = contactsDataGrid.Rows[rowIndex].Cells[colIndex].EditedFormattedValue.ToString();


            return currentCellValue;
        }

        private string GetSecondCellValue()
        {
            int rowIndex = contactsDataGrid.CurrentCell.RowIndex;
            int colIndex = contactsDataGrid.CurrentCell.ColumnIndex;

            string nextCellValue = "";

            DataGridViewCell nextCell = contactsDataGrid.Rows[rowIndex].Cells[colIndex].OwningRow.Cells.Cast<DataGridViewCell>()
                .FirstOrDefault(c => c.Visible && c.ColumnIndex > colIndex);

            if (nextCell != null)
            {
                nextCellValue = nextCell.EditedFormattedValue.ToString();
            }

            return nextCellValue;
        }
    }
}
