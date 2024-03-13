namespace WorkingWithExcelApp;

partial class Form1
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
        panel1 = new Panel();
        DetailsButton = new Button();
        ReadSheetButton = new Button();
        dataGridView1 = new DataGridView();
        CompanyName = new DataGridViewTextBoxColumn();
        ContactTitle = new DataGridViewTextBoxColumn();
        ContactNameColumn = new DataGridViewTextBoxColumn();
        StreetColumn = new DataGridViewTextBoxColumn();
        CityColumn = new DataGridViewTextBoxColumn();
        CountryNameColumn = new DataGridViewTextBoxColumn();
        PostalCodeColumn = new DataGridViewTextBoxColumn();
        PhoneColumn = new DataGridViewTextBoxColumn();
        CurrentCustomerButton = new Button();
        panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();
        // 
        // panel1
        // 
        panel1.Controls.Add(CurrentCustomerButton);
        panel1.Controls.Add(DetailsButton);
        panel1.Controls.Add(ReadSheetButton);
        panel1.Dock = DockStyle.Bottom;
        panel1.Location = new Point(0, 385);
        panel1.Name = "panel1";
        panel1.Size = new Size(1333, 65);
        panel1.TabIndex = 0;
        // 
        // DetailsButton
        // 
        DetailsButton.Location = new Point(263, 15);
        DetailsButton.Name = "DetailsButton";
        DetailsButton.Size = new Size(94, 29);
        DetailsButton.TabIndex = 2;
        DetailsButton.Text = "Details";
        DetailsButton.UseVisualStyleBackColor = true;
        DetailsButton.Click += DetailsButton_Click;
        // 
        // ReadSheetButton
        // 
        ReadSheetButton.Location = new Point(23, 15);
        ReadSheetButton.Name = "ReadSheetButton";
        ReadSheetButton.Size = new Size(94, 29);
        ReadSheetButton.TabIndex = 0;
        ReadSheetButton.Text = "Read";
        ReadSheetButton.UseVisualStyleBackColor = true;
        ReadSheetButton.Click += ReadSheetButton_Click;
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Columns.AddRange(new DataGridViewColumn[] { CompanyName, ContactTitle, ContactNameColumn, StreetColumn, CityColumn, CountryNameColumn, PostalCodeColumn, PhoneColumn });
        dataGridView1.Dock = DockStyle.Fill;
        dataGridView1.Location = new Point(0, 0);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.RowHeadersWidth = 51;
        dataGridView1.Size = new Size(1333, 385);
        dataGridView1.TabIndex = 1;
        // 
        // CompanyName
        // 
        CompanyName.DataPropertyName = "CompanyName";
        CompanyName.HeaderText = "Name";
        CompanyName.MinimumWidth = 6;
        CompanyName.Name = "CompanyName";
        CompanyName.Width = 125;
        // 
        // ContactTitle
        // 
        ContactTitle.DataPropertyName = "ContactTitle";
        ContactTitle.HeaderText = "Title";
        ContactTitle.MinimumWidth = 6;
        ContactTitle.Name = "ContactTitle";
        ContactTitle.Width = 125;
        // 
        // ContactNameColumn
        // 
        ContactNameColumn.DataPropertyName = "ContactName";
        ContactNameColumn.HeaderText = "Contact";
        ContactNameColumn.MinimumWidth = 6;
        ContactNameColumn.Name = "ContactNameColumn";
        ContactNameColumn.Width = 125;
        // 
        // StreetColumn
        // 
        StreetColumn.DataPropertyName = "Street";
        StreetColumn.HeaderText = "Street";
        StreetColumn.MinimumWidth = 6;
        StreetColumn.Name = "StreetColumn";
        StreetColumn.Width = 125;
        // 
        // CityColumn
        // 
        CityColumn.DataPropertyName = "City";
        CityColumn.HeaderText = "City";
        CityColumn.MinimumWidth = 6;
        CityColumn.Name = "CityColumn";
        CityColumn.Width = 125;
        // 
        // CountryNameColumn
        // 
        CountryNameColumn.DataPropertyName = "CountryName";
        CountryNameColumn.HeaderText = "Country";
        CountryNameColumn.MinimumWidth = 6;
        CountryNameColumn.Name = "CountryNameColumn";
        CountryNameColumn.Width = 125;
        // 
        // PostalCodeColumn
        // 
        PostalCodeColumn.DataPropertyName = "PostalCode";
        PostalCodeColumn.HeaderText = "Zip";
        PostalCodeColumn.MinimumWidth = 6;
        PostalCodeColumn.Name = "PostalCodeColumn";
        PostalCodeColumn.Width = 125;
        // 
        // PhoneColumn
        // 
        PhoneColumn.DataPropertyName = "Phone";
        PhoneColumn.HeaderText = "Phone";
        PhoneColumn.MinimumWidth = 6;
        PhoneColumn.Name = "PhoneColumn";
        PhoneColumn.Width = 125;
        // 
        // CurrentCustomerButton
        // 
        CurrentCustomerButton.Location = new Point(136, 15);
        CurrentCustomerButton.Name = "CurrentCustomerButton";
        CurrentCustomerButton.Size = new Size(94, 29);
        CurrentCustomerButton.TabIndex = 3;
        CurrentCustomerButton.Text = "Current";
        CurrentCustomerButton.UseVisualStyleBackColor = true;
        CurrentCustomerButton.Click += CurrentCustomerButton_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1333, 450);
        Controls.Add(dataGridView1);
        Controls.Add(panel1);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Customers in Excel";
        panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel panel1;
    private Button ReadSheetButton;
    private DataGridView dataGridView1;
    private Button DetailsButton;
    private DataGridViewTextBoxColumn CompanyName;
    private DataGridViewTextBoxColumn ContactTitle;
    private DataGridViewTextBoxColumn ContactNameColumn;
    private DataGridViewTextBoxColumn StreetColumn;
    private DataGridViewTextBoxColumn CityColumn;
    private DataGridViewTextBoxColumn CountryNameColumn;
    private DataGridViewTextBoxColumn PostalCodeColumn;
    private DataGridViewTextBoxColumn PhoneColumn;
    private Button CurrentCustomerButton;
}
