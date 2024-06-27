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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhoneBook));
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
            linkLabel1 = new LinkLabel();
            pictureBox1 = new PictureBox();
            searchTextBox = new TextBox();
            searchLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)contactsDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // newEntryButton
            // 
            newEntryButton.BackColor = Color.PaleGreen;
            newEntryButton.Cursor = Cursors.Hand;
            newEntryButton.FlatAppearance.BorderSize = 2;
            newEntryButton.FlatAppearance.MouseOverBackColor = Color.DarkSeaGreen;
            newEntryButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            newEntryButton.Location = new Point(25, 20);
            newEntryButton.Margin = new Padding(2);
            newEntryButton.Name = "newEntryButton";
            newEntryButton.Size = new Size(123, 38);
            newEntryButton.TabIndex = 5;
            newEntryButton.Text = "New Entry";
            newEntryButton.UseVisualStyleBackColor = false;
            newEntryButton.Click += newEntryButton_Click;
            // 
            // firstNameTextBox
            // 
            firstNameTextBox.Cursor = Cursors.IBeam;
            firstNameTextBox.Location = new Point(342, 20);
            firstNameTextBox.Margin = new Padding(2);
            firstNameTextBox.Name = "firstNameTextBox";
            firstNameTextBox.Size = new Size(360, 23);
            firstNameTextBox.TabIndex = 1;
            // 
            // firstNameLabel
            // 
            firstNameLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            firstNameLabel.Location = new Point(253, 24);
            firstNameLabel.Margin = new Padding(2, 0, 2, 0);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(85, 19);
            firstNameLabel.TabIndex = 2;
            firstNameLabel.Text = "First Name:";
            // 
            // lastNameLabel
            // 
            lastNameLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lastNameLabel.Location = new Point(253, 61);
            lastNameLabel.Margin = new Padding(2, 0, 2, 0);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(85, 19);
            lastNameLabel.TabIndex = 3;
            lastNameLabel.Text = "Last Name:";
            // 
            // lastNameTextBox
            // 
            lastNameTextBox.Cursor = Cursors.IBeam;
            lastNameTextBox.ForeColor = SystemColors.WindowText;
            lastNameTextBox.Location = new Point(342, 57);
            lastNameTextBox.Margin = new Padding(2);
            lastNameTextBox.Name = "lastNameTextBox";
            lastNameTextBox.Size = new Size(360, 23);
            lastNameTextBox.TabIndex = 2;
            // 
            // phoneNumberTextBox
            // 
            phoneNumberTextBox.Cursor = Cursors.IBeam;
            phoneNumberTextBox.ForeColor = SystemColors.WindowText;
            phoneNumberTextBox.Location = new Point(342, 91);
            phoneNumberTextBox.Margin = new Padding(2);
            phoneNumberTextBox.Name = "phoneNumberTextBox";
            phoneNumberTextBox.Size = new Size(360, 23);
            phoneNumberTextBox.TabIndex = 3;
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            phoneNumberLabel.Location = new Point(222, 95);
            phoneNumberLabel.Margin = new Padding(2, 0, 2, 0);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(116, 19);
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
            loadButton.Location = new Point(25, 76);
            loadButton.Margin = new Padding(2);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(123, 38);
            loadButton.TabIndex = 6;
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
            saveButton.Location = new Point(25, 133);
            saveButton.Margin = new Padding(2);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(123, 38);
            saveButton.TabIndex = 7;
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
            deleteButton.Location = new Point(25, 188);
            deleteButton.Margin = new Padding(2);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(123, 38);
            deleteButton.TabIndex = 8;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += deleteButton_Click;
            // 
            // emailTextBox
            // 
            emailTextBox.Cursor = Cursors.IBeam;
            emailTextBox.ForeColor = SystemColors.WindowText;
            emailTextBox.Location = new Point(342, 129);
            emailTextBox.Margin = new Padding(2);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(360, 23);
            emailTextBox.TabIndex = 4;
            // 
            // emailLabel
            // 
            emailLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            emailLabel.Location = new Point(279, 133);
            emailLabel.Margin = new Padding(2, 0, 2, 0);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(50, 19);
            emailLabel.TabIndex = 11;
            emailLabel.Text = "Email:";
            // 
            // contactsDataGrid
            // 
            contactsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            contactsDataGrid.BorderStyle = BorderStyle.Fixed3D;
            contactsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            contactsDataGrid.Location = new Point(1, 251);
            contactsDataGrid.Margin = new Padding(2);
            contactsDataGrid.Name = "contactsDataGrid";
            contactsDataGrid.RowHeadersWidth = 62;
            dataGridViewCellStyle1.BackColor = Color.AntiqueWhite;
            dataGridViewCellStyle1.Font = new Font("Trebuchet MS", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.MediumBlue;
            dataGridViewCellStyle1.SelectionBackColor = Color.LightGreen;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            contactsDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle1;
            contactsDataGrid.RowTemplate.Height = 33;
            contactsDataGrid.Size = new Size(952, 410);
            contactsDataGrid.TabIndex = 12;
            contactsDataGrid.CellMouseClick += contactsDataGrid_CellMouseClick;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.OrangeRed;
            linkLabel1.AutoSize = true;
            linkLabel1.Cursor = Cursors.Hand;
            linkLabel1.LinkColor = Color.SteelBlue;
            linkLabel1.Location = new Point(785, 173);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(159, 15);
            linkLabel1.TabIndex = 13;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "PhoneBook-by-I-M-Marinov";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(800, 41);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(131, 129);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(342, 223);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(360, 23);
            searchTextBox.TabIndex = 15;
            // 
            // searchLabel
            // 
            searchLabel.AutoSize = true;
            searchLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            searchLabel.Location = new Point(187, 226);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(151, 20);
            searchLabel.TabIndex = 16;
            searchLabel.Text = "Search by First Name:";
            // 
            // PhoneBook
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(956, 661);
            Controls.Add(searchLabel);
            Controls.Add(searchTextBox);
            Controls.Add(linkLabel1);
            Controls.Add(pictureBox1);
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
            Margin = new Padding(2);
            Name = "PhoneBook";
            Text = "PhoneBook-by-I-M-Marinov";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)contactsDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private LinkLabel linkLabel1;
        private PictureBox pictureBox1;
        private TextBox searchTextBox;
        private Label searchLabel;
    }
}
