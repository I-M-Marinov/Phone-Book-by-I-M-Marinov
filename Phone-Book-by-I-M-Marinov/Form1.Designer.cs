namespace Phone_Book_by_I_M_Marinov
{
    partial class PhoneBook
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            newEntryButton = new Button();
            firstNameTextBox = new TextBox();
            firstNameLabel = new Label();
            lastNameLabel = new Label();
            lastNameTextBox = new TextBox();
            phoneNumberTextBox = new TextBox();
            phoneNumberLabel = new Label();
            loadButton = new Button();
            saveButton = new Button();
            deleteButton = new Button();
            emailTextBox = new TextBox();
            emailLabel = new Label();
            contactsDataGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)contactsDataGrid).BeginInit();
            SuspendLayout();
            // 
            // newEntryButton
            // 
            newEntryButton.BackColor = Color.PaleGreen;
            newEntryButton.Cursor = Cursors.Hand;
            newEntryButton.FlatAppearance.BorderSize = 2;
            newEntryButton.FlatAppearance.MouseOverBackColor = Color.DarkSeaGreen;
            newEntryButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            newEntryButton.Location = new Point(77, 12);
            newEntryButton.Name = "newEntryButton";
            newEntryButton.Size = new Size(176, 64);
            newEntryButton.TabIndex = 0;
            newEntryButton.Text = "New Entry";
            newEntryButton.UseVisualStyleBackColor = false;
            newEntryButton.Click += newEntryButton_Click;
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Cursor = Cursors.IBeam;
            firstNameTextBox.Location = new Point(355, 93);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(401, 31);
            firstNameTextBox.TabIndex = 1;
            // 
            // firstNameLabel
            // 
            firstNameLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            firstNameLabel.Location = new Point(215, 93);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(122, 31);
            firstNameLabel.TabIndex = 2;
            firstNameLabel.Text = "First Name:";
            // 
            // lastNameLabel
            // 
            lastNameLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lastNameLabel.Location = new Point(215, 151);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(122, 31);
            lastNameLabel.TabIndex = 3;
            lastNameLabel.Text = "Last Name:";
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Cursor = Cursors.IBeam;
            lastNameTextBox.ForeColor = SystemColors.WindowText;
            lastNameTextBox.Location = new Point(355, 152);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(401, 31);
            lastNameTextBox.TabIndex = 4;
            // 
            // phoneNumberTextBox
            // 
            phoneNumberTextBox.Cursor = Cursors.IBeam;
            phoneNumberTextBox.ForeColor = SystemColors.WindowText;
            phoneNumberTextBox.Location = new Point(355, 211);
            phoneNumberTextBox.Name = "phoneNumberTextBox";
            phoneNumberTextBox.Size = new Size(401, 31);
            phoneNumberTextBox.TabIndex = 5;
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            phoneNumberLabel.Location = new Point(179, 211);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(170, 31);
            phoneNumberLabel.TabIndex = 6;
            phoneNumberLabel.Text = "Phone Number:";
            // 
            // loadButton
            // 
            loadButton.BackColor = Color.LightSteelBlue;
            loadButton.Cursor = Cursors.Hand;
            loadButton.FlatAppearance.BorderSize = 2;
            loadButton.FlatAppearance.MouseOverBackColor = Color.DarkSeaGreen;
            loadButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            loadButton.Location = new Point(309, 12);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(176, 64);
            loadButton.TabIndex = 7;
            loadButton.Text = "Load";
            loadButton.UseVisualStyleBackColor = false;
            loadButton.Click += loadButton_Click;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.Green;
            saveButton.Cursor = Cursors.Hand;
            saveButton.FlatAppearance.BorderSize = 2;
            saveButton.FlatAppearance.MouseOverBackColor = Color.DarkSeaGreen;
            saveButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            saveButton.ForeColor = SystemColors.Control;
            saveButton.Location = new Point(563, 12);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(176, 64);
            saveButton.TabIndex = 8;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.BackColor = Color.Tomato;
            deleteButton.Cursor = Cursors.Hand;
            deleteButton.FlatAppearance.BorderSize = 2;
            deleteButton.FlatAppearance.MouseOverBackColor = Color.DarkSeaGreen;
            deleteButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            deleteButton.ForeColor = SystemColors.Control;
            deleteButton.Location = new Point(816, 12);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(176, 64);
            deleteButton.TabIndex = 9;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += deleteButton_Click;
            // 
            // emailTextBox
            // 
            emailTextBox.Cursor = Cursors.IBeam;
            emailTextBox.ForeColor = SystemColors.WindowText;
            emailTextBox.Location = new Point(355, 270);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(401, 31);
            emailTextBox.TabIndex = 10;
            // 
            // emailLabel
            // 
            emailLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            emailLabel.Location = new Point(244, 270);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(72, 31);
            emailLabel.TabIndex = 11;
            emailLabel.Text = "Email:";
            // 
            // contactsDataGrid
            // 
            contactsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            contactsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            contactsDataGrid.Location = new Point(12, 330);
            contactsDataGrid.Name = "contactsDataGrid";
            contactsDataGrid.RowHeadersWidth = 62;
            dataGridViewCellStyle1.BackColor = Color.AntiqueWhite;
            dataGridViewCellStyle1.Font = new Font("Trebuchet MS", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.MediumBlue;
            dataGridViewCellStyle1.SelectionBackColor = Color.LightGreen;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            contactsDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle1;
            contactsDataGrid.RowTemplate.Height = 33;
            contactsDataGrid.Size = new Size(1092, 353);
            contactsDataGrid.TabIndex = 12;
            contactsDataGrid.CellMouseClick += contactsDataGrid_CellMouseClick;
            // 
            // PhoneBook
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(1116, 695);
            Controls.Add(contactsDataGrid);
            Controls.Add(emailLabel);
            Controls.Add(emailTextBox);
            Controls.Add(deleteButton);
            Controls.Add(saveButton);
            Controls.Add(loadButton);
            Controls.Add(phoneNumberLabel);
            Controls.Add(phoneNumberTextBox);
            Controls.Add(lastNameTextBox);
            Controls.Add(lastNameLabel);
            Controls.Add(firstNameLabel);
            Controls.Add(firstNameTextBox);
            Controls.Add(newEntryButton);
            ForeColor = SystemColors.ControlText;
            Name = "PhoneBook";
            Text = "PhoneBook-by-I-M-Marinov";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)contactsDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button newEntryButton;
        private TextBox firstNameTextBox;
        private Label firstNameLabel;
        private Label lastNameLabel;
        private TextBox lastNameTextBox;
        private TextBox phoneNumberTextBox;
        private Label phoneNumberLabel;
        private Button loadButton;
        private Button saveButton;
        private Button deleteButton;
        private TextBox emailTextBox;
        private Label emailLabel;
        private DataGridView contactsDataGrid;
    }
}
