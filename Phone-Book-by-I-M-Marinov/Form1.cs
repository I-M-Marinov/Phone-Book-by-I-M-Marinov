using System.Data;

namespace Phone_Book_by_I_M_Marinov
{
    public partial class PhoneBook : Form
    {
        public PhoneBook()
        {
            InitializeComponent();
        }

        DataTable contactsTable = new();
        bool isEdited;

        private void Form1_Load(object sender, EventArgs e)
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
                try
                {
                    int rowIndex = contactsDataGrid.CurrentCell.RowIndex;
                    contactsTable.Rows.RemoveAt(rowIndex);
                    contactsDataGrid.DataSource = contactsTable;

                    // After deletion, check if there are any rows left in the table
                    if (contactsTable.Rows.Count == 0)
                    {
                        ClearAllEntries();
                        isEdited = false;
                    }
                    else
                    {
                        // Ensure the DataGridView shows the last row after deletion
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
                    Console.WriteLine("Not a valid row!");
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

            if (isEdited)
            {
                if (contactsDataGrid.CurrentCell != null)
                {
                    contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex]["First Name"] = firstNameTextBox.Text;
                    contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex]["Last Name"] = lastNameTextBox.Text;
                    contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex]["Phone Number"] = phoneNumberTextBox.Text;
                    contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex]["Email"] = emailTextBox.Text;
                }
                else
                {
                    MessageBox.Show("No row was selected!");
                    return;
                }
            }
            else
            {
                contactsTable.Rows.Add(
                    firstNameTextBox.Text, 
                    lastNameTextBox.Text, 
                    phoneNumberTextBox.Text,
                    emailTextBox.Text
                    );
            }

            ClearAllEntries();
            isEdited = false;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            firstNameTextBox.Text = contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].ItemArray[0].ToString();
            lastNameTextBox.Text = contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].ItemArray[1].ToString();
            phoneNumberTextBox.Text = contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].ItemArray[2].ToString();
            emailTextBox.Text = contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].ItemArray[3].ToString();
            isEdited = true;
        }

        private void newEntryButton_Click(object sender, EventArgs e)
        {
            ClearAllEntries();
        }

        private void contactsDataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            firstNameTextBox.Text = contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].ItemArray[0].ToString();
            lastNameTextBox.Text = contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].ItemArray[1].ToString();
            phoneNumberTextBox.Text = contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].ItemArray[2].ToString();
            emailTextBox.Text = contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].ItemArray[3].ToString();
            isEdited = true;
        }

        private void ClearAllEntries()
        {
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            phoneNumberTextBox.Text = "";
            emailTextBox.Text = "";
        }
    }
}
