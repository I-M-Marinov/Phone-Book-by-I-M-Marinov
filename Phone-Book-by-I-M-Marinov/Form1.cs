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
            try
            {
                contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex].Delete();
            }
            catch (Exception exception) 
            {
                Console.WriteLine("Not a valid row!");
            }

            ClearAllEntries();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (isEdited)
            {
                contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex]["First Name"] = firstNameTextBox.Text;
                contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex]["Last Name"] = lastNameTextBox.Text;
                contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex]["Phone Number"] = phoneNumberTextBox.Text;
                contactsTable.Rows[contactsDataGrid.CurrentCell.RowIndex]["Email"] = emailTextBox.Text;
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
