using OfficeOpenXml;
using System.Data;


namespace Phone_Book_by_I_M_Marinov
{
    public partial class PhoneBook : Form
    {


        string excelFilePath = @"C:\Users\Marinov\Desktop\contacts.xlsx";
        DataTable contactsTable = new();
        bool isEdited;
        private int lastEntryIndex = -1;

        public PhoneBook()
        {
            InitializeComponent();
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
                try
                {
                    int rowIndex = contactsDataGrid.CurrentCell.RowIndex;
                    contactsTable.Rows.RemoveAt(rowIndex);
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
                AddEntryToDataTable(
                    firstNameTextBox.Text,
                    lastNameTextBox.Text,
                    phoneNumberTextBox.Text,
                    emailTextBox.Text
                    );

                SaveContactsToExcel();
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
            if (File.Exists(excelFilePath))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage package = new ExcelPackage(new FileInfo(excelFilePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets["Contacts"];
                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        contactsTable.Rows.Add(
                            worksheet.Cells[row, 1].Value?.ToString(),
                            worksheet.Cells[row, 2].Value?.ToString(),
                            worksheet.Cells[row, 3].Value?.ToString(),
                            worksheet.Cells[row, 4].Value?.ToString()
                        );
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
            lastEntryIndex = contactsTable.Rows.Count - 1;
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
