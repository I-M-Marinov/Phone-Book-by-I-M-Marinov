using OfficeOpenXml;
using System.Data;
using System.Drawing.Text;

namespace Phone_Book_by_I_M_Marinov
{
    public partial class PhoneBook : Form
    {

        string excelFilePath = @"C:\Users\Marinov\Desktop\Contacts.xlsx";
        DataTable contactsTable = new();
        Dictionary<string, bool> contactsDictionary = new();
        bool isEdited;
        private int lastEntryIndex = -1;

        public PhoneBook()
        {
            InitializeComponent();
            searchTextBox.TextChanged += SearchTextBox_TextChanges;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeContactsTable();
            LoadContactsFromExcel();
        }

        private void InitializeContactsTable()
        {
            contactsTable.Columns.Add("First Name");
            contactsTable.Columns.Add("Last Name");
            contactsTable.Columns.Add("Phone Number");
            contactsTable.Columns.Add("Email");

            contactsDataGrid.DataSource = contactsTable;
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
                        string entryKey = GenerateEntryKey(contactsTable.Rows[rowIndex]);
                        contactsTable.Rows.RemoveAt(rowIndex);
                        contactsDictionary.Remove(entryKey);
                        SaveContactsToExcel();

                        if (contactsTable.Rows.Count == 0)
                        {
                            ClearAllEntries();
                            isEdited = false;
                        }
                        else
                        {
                            if (rowIndex >= contactsTable.Rows.Count)
                            {
                                rowIndex = contactsTable.Rows.Count - 1;
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

            string entryKey = GenerateEntryKey(firstNameTextBox.Text, lastNameTextBox.Text);

            if (isEdited)
            {
                if (contactsDataGrid.CurrentCell != null)
                {
                    contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex]["First Name"] = firstNameTextBox.Text;
                    contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex]["Last Name"] = lastNameTextBox.Text;
                    contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex]["Phone Number"] = phoneNumberTextBox.Text;
                    contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex]["Email"] = emailTextBox.Text;
                    SaveContactsToExcel();
                }
                else
                {
                    MessageBox.Show("No row was selected!");
                    return;
                }
            }
            else
            {
                if (contactsDictionary.ContainsKey(entryKey))
                {
                    MessageBox.Show($"{firstNameTextBox.Text} {lastNameTextBox.Text} already exists in the phone book.");
                }
                else
                {
                    AddEntryToDataTable(firstNameTextBox.Text, lastNameTextBox.Text, phoneNumberTextBox.Text, emailTextBox.Text);
                    SaveContactsToExcel();
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

                if (rowIndex < contactsTable.Rows.Count)
                {
                    firstNameTextBox.Text = contactsTable.Rows[rowIndex].ItemArray[0].ToString();
                    lastNameTextBox.Text = contactsTable.Rows[rowIndex].ItemArray[1].ToString();
                    phoneNumberTextBox.Text = contactsTable.Rows[rowIndex].ItemArray[2].ToString();
                    emailTextBox.Text = contactsTable.Rows[rowIndex].ItemArray[3].ToString();
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
                firstNameTextBox.Text = contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].ItemArray[0].ToString();
                lastNameTextBox.Text = contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].ItemArray[1].ToString();
                phoneNumberTextBox.Text = contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].ItemArray[2].ToString();
                emailTextBox.Text = contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].ItemArray[3].ToString();
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

        private void LoadContactsFromExcel()
        {
            if (!File.Exists(excelFilePath))
            {
                // Create a new Excel file if it does not exist

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Contacts");

                    worksheet.Cells[1, 1].Value = "First Name";
                    worksheet.Cells[1, 2].Value = "Last Name";
                    worksheet.Cells[1, 3].Value = "Phone Number";
                    worksheet.Cells[1, 4].Value = "Email";

                    package.SaveAs(new FileInfo(excelFilePath));
                }
            }
            
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Contacts"];
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    string firstName = worksheet.Cells[row, 1].Value?.ToString();
                    string lastName = worksheet.Cells[row, 2].Value?.ToString();
                    string phoneNumber = worksheet.Cells[row, 3].Value?.ToString();
                    string email = worksheet.Cells[row, 4].Value?.ToString();

                    contactsTable.Rows.Add(firstName, lastName, phoneNumber, email);
                    string entryKey = GenerateEntryKey(firstName, lastName);
                    if (!contactsDictionary.ContainsKey(entryKey))
                    {
                        contactsDictionary.Add(entryKey, true);
                    }
                }
            }
        }

        private void SaveContactsToExcel()
        {
            if (File.Exists(excelFilePath))
            {
                using (ExcelPackage package = new ExcelPackage(new FileInfo(excelFilePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["Contacts"];

                    if (contactsTable.Rows.Count > 0)
                    {
                        if (worksheet.Dimension?.Rows > 1 && worksheet.Dimension?.Columns > 0)
                        {
                            worksheet.Cells["A2:D" + worksheet.Dimension.End.Row].Clear();
                        }

                        int rowIndex = 2;
                        foreach (DataRow row in contactsTable.Rows)
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

                    if (contactsTable.Rows.Count == 0)
                    {
                        worksheet.Cells["A2:D" + worksheet.Dimension.End.Row].Clear();
                    }

                    package.Save();
                }
            }
        }

        private void AddEntryToDataTable(string firstName, string lastName, string phoneNumber, string email)
        {
            contactsTable.Rows.Add(firstName, lastName, phoneNumber, email);
            string entryKey = GenerateEntryKey(firstName, lastName);
            if (!contactsDictionary.ContainsKey(entryKey))
            {
                contactsDictionary.Add(entryKey, true);
            }
            lastEntryIndex = contactsTable.Rows.Count - 1;
        }

        private string GenerateEntryKey(DataRow row)
        {
            return $"{row["First Name"]?.ToString().ToLower()}-{row["Last Name"]?.ToString().ToLower()}";
        }

        private string GenerateEntryKey(string firstName, string lastName)
        {
            return $"{firstName?.ToLower()} {lastName?.ToLower()}";
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
                contactsDataGrid.DataSource = contactsTable; // Reset the data source to the original contactsTable
                deleteButton.Enabled = true; // Enable the delete button if the searchTextBox is IsNullOrWhiteSpace
            }
            else
            {
                DataTable filteredTable = contactsTable.Clone(); // Create a clone of the contactsTable 

                foreach (DataRow row in contactsTable.Rows) // Iterate over all the Rows of the contactsTable to look for matches to the searchString
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
