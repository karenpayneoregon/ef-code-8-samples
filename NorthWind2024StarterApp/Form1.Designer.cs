namespace NorthWind2024StarterApp;

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
        CategoriesComboBox = new ComboBox();
        dataGridView1 = new DataGridView();
        ProductNameColumn = new DataGridViewTextBoxColumn();
        UnitPriceColumn = new DataGridViewTextBoxColumn();
        SupplierColumn = new DataGridViewTextBoxColumn();
        panel1 = new Panel();
        CurrentButton = new Button();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // CategoriesComboBox
        // 
        CategoriesComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        CategoriesComboBox.FormattingEnabled = true;
        CategoriesComboBox.Location = new Point(12, 12);
        CategoriesComboBox.Name = "CategoriesComboBox";
        CategoriesComboBox.Size = new Size(232, 28);
        CategoriesComboBox.TabIndex = 0;
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ProductNameColumn, UnitPriceColumn, SupplierColumn });
        dataGridView1.Dock = DockStyle.Fill;
        dataGridView1.Location = new Point(0, 55);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.RowHeadersWidth = 51;
        dataGridView1.Size = new Size(800, 395);
        dataGridView1.TabIndex = 1;
        // 
        // ProductNameColumn
        // 
        ProductNameColumn.DataPropertyName = "ProductName";
        ProductNameColumn.HeaderText = "Name";
        ProductNameColumn.MinimumWidth = 6;
        ProductNameColumn.Name = "ProductNameColumn";
        ProductNameColumn.Width = 125;
        // 
        // UnitPriceColumn
        // 
        UnitPriceColumn.DataPropertyName = "UnitPrice";
        UnitPriceColumn.HeaderText = "Unit Price";
        UnitPriceColumn.MinimumWidth = 6;
        UnitPriceColumn.Name = "UnitPriceColumn";
        UnitPriceColumn.Width = 125;
        // 
        // SupplierColumn
        // 
        SupplierColumn.DataPropertyName = "SupperlierCompanyName";
        SupplierColumn.HeaderText = "Supplier";
        SupplierColumn.MinimumWidth = 6;
        SupplierColumn.Name = "SupplierColumn";
        SupplierColumn.Width = 125;
        // 
        // panel1
        // 
        panel1.Controls.Add(CurrentButton);
        panel1.Controls.Add(CategoriesComboBox);
        panel1.Dock = DockStyle.Top;
        panel1.Location = new Point(0, 0);
        panel1.Name = "panel1";
        panel1.Size = new Size(800, 55);
        panel1.TabIndex = 2;
        // 
        // CurrentButton
        // 
        CurrentButton.Location = new Point(266, 11);
        CurrentButton.Name = "CurrentButton";
        CurrentButton.Size = new Size(94, 29);
        CurrentButton.TabIndex = 3;
        CurrentButton.Text = "Current";
        CurrentButton.UseVisualStyleBackColor = true;
        CurrentButton.Click += CurrentButton_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(dataGridView1);
        Controls.Add(panel1);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Display products by category";
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        panel1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private ComboBox CategoriesComboBox;
    private DataGridView dataGridView1;
    private Panel panel1;
    private DataGridViewTextBoxColumn ProductNameColumn;
    private DataGridViewTextBoxColumn UnitPriceColumn;
    private DataGridViewTextBoxColumn SupplierColumn;
    private Button CurrentButton;
}
