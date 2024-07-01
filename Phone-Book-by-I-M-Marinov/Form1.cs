using OfficeOpenXml;
using System.Data;
using System.Drawing.Text;
using Phone_Book_by_I_M_Marinov.Methods;

namespace Phone_Book_by_I_M_Marinov
{
    public partial class PhoneBook : Form
    {

        private bool _isEdited;
        private int _lastEntryIndex = -1;
        private readonly ExcelControlMethods _excel;
        private readonly UtilityMethods _utilityMethod;
        private readonly Search _search;


        public PhoneBook()
        {
            InitializeComponent();
            searchTextBox.TextChanged += _search.SearchTextBox_TextChanges;
            _excel = new ExcelControlMethods(this);
            _search = new Search(this);
            _utilityMethod = new UtilityMethods(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _utilityMethod.InitializeContactsTable();
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


        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (contactsDataGrid.CurrentCell != null && contactsDataGrid.CurrentCell.RowIndex >= 0)
            {
                string nameCellValue = _utilityMethod.GetFirstCellValue();
                string lastNameCellValue = _utilityMethod.GetSecondCellValue();


                // Show confirmation dialog
                DialogResult result = MessageBox.Show($"Are you sure you want to delete {nameCellValue} {lastNameCellValue} ?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // If user clicks 'Yes', proceed with deletion
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        int rowIndex = contactsDataGrid.CurrentCell.RowIndex;
                        string entryKey = _excel.GenerateEntryKey(_excel.ContactsTable.Rows[rowIndex]);
                        _excel.ContactsTable.Rows.RemoveAt(rowIndex);
                        _excel.ContactsDictionary.Remove(entryKey);
                        _excel.SaveContactsToExcel();

                        if (_excel.ContactsTable.Rows.Count == 0)
                        {
                            _utilityMethod.ClearAllEntries();
                            _isEdited = false;
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

            if (_isEdited)
            {
                if (contactsDataGrid.CurrentCell != null)
                {
                    _excel.ContactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex]["First Name"] = firstNameTextBox.Text;
                    _excel.ContactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex]["Last Name"] = lastNameTextBox.Text;
                    _excel.ContactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex]["Phone Number"] = phoneNumberTextBox.Text;
                    _excel.ContactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex]["Email"] = emailTextBox.Text;
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
                if (_excel.ContactsDictionary.ContainsKey(entryKey))
                {
                    MessageBox.Show($"{firstNameTextBox.Text} {lastNameTextBox.Text} already exists in the phone book.");
                }
                else
                {
                    AddEntryToDataTable(firstNameTextBox.Text, lastNameTextBox.Text, phoneNumberTextBox.Text, emailTextBox.Text);
                    _excel.SaveContactsToExcel();
                }
            }

            _utilityMethod.ClearAllEntries();
            _isEdited = false;
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
                    _isEdited = true;
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
            if (contactsDataGrid.CurrentCell != null && _lastEntryIndex == contactsDataGrid.CurrentCell.RowIndex + 1)
            {
                firstNameTextBox.Text = _excel.ContactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].ItemArray[0].ToString();
                lastNameTextBox.Text = _excel.ContactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].ItemArray[1].ToString();
                phoneNumberTextBox.Text = _excel.ContactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].ItemArray[2].ToString();
                emailTextBox.Text = _excel.ContactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].ItemArray[3].ToString();
                _isEdited = true;
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
            _lastEntryIndex = _excel.ContactsTable.Rows.Count - 1;
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



    }
}
