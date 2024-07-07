using OfficeOpenXml;
using System.Data;
using System.Drawing.Text;
using Phone_Book_by_I_M_Marinov.Methods;
using System.Windows.Forms;
using Phone_Book_by_I_M_Marinov.Validation;

namespace Phone_Book_by_I_M_Marinov
{
    public partial class PhoneBook : Form
    {

        bool isEdited;
        private int lastEntryIndex = -1;
        private readonly ExcelControlMethods _excel;
        private readonly UtilityMethods _utilityMethod;
        

        public PhoneBook()
        {
            InitializeComponent();
            searchTextBox.TextChanged += SearchTextBox_TextChanges;
            _excel = new ExcelControlMethods(this);
            _utilityMethod = new UtilityMethods(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeContactsTable();
            _excel.LoadContactsFromExcel();
        }

        public DataGridView ContactsDataGrid
        {
            get { return contactsDataGrid; }
            set { contactsDataGrid = value; }
        }
        public TextBox FirstNameTextBox
        {
            get { return firstNameTextBox; }
            set { firstNameTextBox = value; }
        }
        public TextBox LastNameTextBox
        {
            get { return lastNameTextBox; }
            set { lastNameTextBox = value; }
        }
        public TextBox PhoneNumberTextBox
        {
            get { return phoneNumberTextBox; }
            set { phoneNumberTextBox = value; }
        }
        public TextBox EmailTextBox
        {
            get { return emailTextBox; }
            set { emailTextBox = value; }
        }
        public TextBox SearchTextBox
        {
            get { return searchTextBox; }
            set { searchTextBox = value; }
        }
        public Button DeleteButton
        {
            get { return deleteButton; }
            set { deleteButton = value; }
        }

        private void InitializeContactsTable()
        {
            _excel.ContactsTable.Columns.Add("First Name");
            _excel.ContactsTable.Columns.Add("Last Name");
            _excel.ContactsTable.Columns.Add("Phone Number");
            _excel.ContactsTable.Columns.Add("Email");

            contactsDataGrid.DataSource = _excel.ContactsTable;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (contactsDataGrid.CurrentCell != null && contactsDataGrid.CurrentCell.RowIndex >= 0)
            {
                string nameCellValue = _utilityMethod.GetFirstCellValue();
                string lastNameCellValue = _utilityMethod.GetSecondCellValue();


                // Show confirmation dialog
                string message = string.Format(ValidationMessages.ConfirmDeletionMessage, nameCellValue, lastNameCellValue);
                string caption = "Confirm Deletion";
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // If user clicks 'Yes', proceed with deletion
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int rowIndex = contactsDataGrid.CurrentCell.RowIndex;
                        string entryKey = _excel.GenerateEntryKey(_excel.ContactsTable.Rows[rowIndex]);
                        _excel.ContactsTable.Rows.RemoveAt(rowIndex);
                        _excel.ContactsDictionary.Remove(entryKey);
                        _excel.AddNewContactAndSave();

                        if (_excel.ContactsTable.Rows.Count == 0)
                        {
                            _utilityMethod.ClearAllEntries();
                            isEdited = false;
                        }
                        else
                        {
                            if (rowIndex >= _excel.ContactsTable.Rows.Count)
                            {
                                rowIndex = _excel.ContactsTable.Rows.Count - 1;
                            }
                            contactsDataGrid.CurrentCell = contactsDataGrid.Rows[rowIndex].Cells[0];
                            contactsDataGrid.Rows[rowIndex].Selected = true;
                        }

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(ValidationMessages.NotAValidRow);
                    }
                }

            }
            else
            {
                MessageBox.Show(ValidationMessages.NoRowSelected);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(lastNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(phoneNumberTextBox.Text) ||
                string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                MessageBox.Show(ValidationMessages.FillAllInformation);
                return;
            }

            string entryKey = _excel.GenerateEntryKey(firstNameTextBox.Text, lastNameTextBox.Text);

            if (isEdited)
            {
                if (contactsDataGrid.CurrentCell != null)
                {
                    _excel.ContactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex]["First Name"] = firstNameTextBox.Text;
                    _excel.ContactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex]["Last Name"] = lastNameTextBox.Text;
                    _excel.ContactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex]["Phone Number"] = phoneNumberTextBox.Text;
                    _excel.ContactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex]["Email"] = emailTextBox.Text;
                    _excel.AddNewContactAndSave();
                }
                else
                {
                    MessageBox.Show(ValidationMessages.NotAValidRow);
                    return;
                }
            }
            else
            {
                if (_excel.ContactsDictionary.ContainsKey(entryKey))
                {
                    string message = String.Format(ValidationMessages.NameAlreadyExists, firstNameTextBox.Text, lastNameTextBox.Text);
                    MessageBox.Show(message);
                }
                else
                {
                    AddEntryToDataTable(firstNameTextBox.Text, lastNameTextBox.Text, phoneNumberTextBox.Text, emailTextBox.Text);
                    _excel.AddNewContactAndSave();
                }
            }

            _utilityMethod.ClearAllEntries();
            isEdited = false;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (contactsDataGrid.CurrentCell != null && contactsDataGrid.CurrentCell.RowIndex >= 0)
            {
                int rowIndex = contactsDataGrid.CurrentCell.RowIndex;

                if (rowIndex < _excel.ContactsTable.Rows.Count)
                {
                    firstNameTextBox.Text = _excel.ContactsTable.Rows[rowIndex].ItemArray[0].ToString();
                    lastNameTextBox.Text = _excel.ContactsTable.Rows[rowIndex].ItemArray[1].ToString();
                    phoneNumberTextBox.Text = _excel.ContactsTable.Rows[rowIndex].ItemArray[2].ToString();
                    emailTextBox.Text = _excel.ContactsTable.Rows[rowIndex].ItemArray[3].ToString();
                    isEdited = true;
                }
                else
                {
                    _utilityMethod.ClearAllEntries();
                }
            }
        }

        private void newEntryButton_Click(object sender, EventArgs e)
        {
            _utilityMethod.ClearAllEntries();
        }

        private void contactsDataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (contactsDataGrid.CurrentCell != null && lastEntryIndex == contactsDataGrid.CurrentCell.RowIndex + 1)
            {
                firstNameTextBox.Text = _excel.ContactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].ItemArray[0].ToString();
                lastNameTextBox.Text = _excel.ContactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].ItemArray[1].ToString();
                phoneNumberTextBox.Text = _excel.ContactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].ItemArray[2].ToString();
                emailTextBox.Text = _excel.ContactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].ItemArray[3].ToString();
                isEdited = true;
            }
        }

        private void AddEntryToDataTable(string firstName, string lastName, string phoneNumber, string email)
        {
            _excel.ContactsTable.Rows.Add(firstName, lastName, phoneNumber, email);
            string entryKey = _excel.GenerateEntryKey(firstName, lastName);
            if (!_excel.ContactsDictionary.ContainsKey(entryKey))
            {
                _excel.ContactsDictionary.Add(entryKey, true);
            }
            lastEntryIndex = _excel.ContactsTable.Rows.Count - 1;
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
                MessageBox.Show(ValidationMessages.ErrorOpeningLink + ex.Message);
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
                MessageBox.Show(ValidationMessages.ErrorOpeningLink + ex.Message);
            }
        }

        private void SearchTextBox_TextChanges(object sender, EventArgs e)
        {
            string searchString = searchTextBox.Text.ToLower(); // Get the search string, convert it to lower case ( so the search is not case-sensitive )

            if (string.IsNullOrWhiteSpace(searchString))
            {
                contactsDataGrid.DataSource = _excel.ContactsTable; // Reset the data source to the original ContactsTable
                deleteButton.Enabled = true; // Enable the delete button if the searchTextBox is IsNullOrWhiteSpace
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

                contactsDataGrid.DataSource = filteredTable; // Visualize the filtered table to the DataGridView
                deleteButton.Enabled = false; // Disable the delete button while searching
            }
        }


    }
}