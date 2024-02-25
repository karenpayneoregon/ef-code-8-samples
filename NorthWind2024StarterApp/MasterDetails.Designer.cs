namespace NorthWind2024StarterApp;

partial class MasterDetails
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        CustomersDataGridView = new DataGridView();
        CompanyNameColumn = new DataGridViewTextBoxColumn();
        CountryColumn = new DataGridViewComboBoxColumn();
        OrdersDataGridView = new DataGridView();
        OrderDateColumn = new DataGridViewTextBoxColumn();
        ShipAddressColumn = new DataGridViewTextBoxColumn();
        FreightColumn = new DataGridViewTextBoxColumn();
        CustomersBindingNavigator = new Components.CoreBindingNavigator();
        ((System.ComponentModel.ISupportInitialize)CustomersDataGridView).BeginInit();
        ((System.ComponentModel.ISupportInitialize)OrdersDataGridView).BeginInit();
        CustomersBindingNavigator.BeginInit();
        SuspendLayout();
        // 
        // CustomersDataGridView
        // 
        CustomersDataGridView.AllowUserToAddRows = false;
        CustomersDataGridView.AllowUserToDeleteRows = false;
        CustomersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        CustomersDataGridView.Columns.AddRange(new DataGridViewColumn[] { CompanyNameColumn, CountryColumn });
        CustomersDataGridView.Location = new Point(0, 35);
        CustomersDataGridView.Name = "CustomersDataGridView";
        CustomersDataGridView.RowHeadersWidth = 51;
        CustomersDataGridView.Size = new Size(796, 251);
        CustomersDataGridView.TabIndex = 0;
        // 
        // CompanyNameColumn
        // 
        CompanyNameColumn.DataPropertyName = "CompanyName";
        CompanyNameColumn.HeaderText = "Name";
        CompanyNameColumn.MinimumWidth = 6;
        CompanyNameColumn.Name = "CompanyNameColumn";
        CompanyNameColumn.Width = 125;
        // 
        // CountryColumn
        // 
        CountryColumn.DataPropertyName = "CountryName";
        CountryColumn.HeaderText = "Country";
        CountryColumn.MinimumWidth = 6;
        CountryColumn.Name = "CountryColumn";
        CountryColumn.Resizable = DataGridViewTriState.True;
        CountryColumn.SortMode = DataGridViewColumnSortMode.Automatic;
        CountryColumn.Width = 125;
        // 
        // OrdersDataGridView
        // 
        OrdersDataGridView.AllowUserToAddRows = false;
        OrdersDataGridView.AllowUserToDeleteRows = false;
        OrdersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        OrdersDataGridView.Columns.AddRange(new DataGridViewColumn[] { OrderDateColumn, ShipAddressColumn, FreightColumn });
        OrdersDataGridView.Location = new Point(0, 308);
        OrdersDataGridView.Name = "OrdersDataGridView";
        OrdersDataGridView.ReadOnly = true;
        OrdersDataGridView.RowHeadersWidth = 51;
        OrdersDataGridView.Size = new Size(796, 188);
        OrdersDataGridView.TabIndex = 1;
        // 
        // OrderDateColumn
        // 
        OrderDateColumn.DataPropertyName = "OrderDate";
        OrderDateColumn.HeaderText = "Order Date";
        OrderDateColumn.MinimumWidth = 6;
        OrderDateColumn.Name = "OrderDateColumn";
        OrderDateColumn.ReadOnly = true;
        OrderDateColumn.Width = 125;
        // 
        // ShipAddressColumn
        // 
        ShipAddressColumn.DataPropertyName = "ShipAddress";
        ShipAddressColumn.HeaderText = "Ship Address";
        ShipAddressColumn.MinimumWidth = 6;
        ShipAddressColumn.Name = "ShipAddressColumn";
        ShipAddressColumn.ReadOnly = true;
        ShipAddressColumn.Width = 450;
        // 
        // FreightColumn
        // 
        FreightColumn.DataPropertyName = "Freight";
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
        dataGridViewCellStyle2.Format = "C2";
        dataGridViewCellStyle2.NullValue = null;
        FreightColumn.DefaultCellStyle = dataGridViewCellStyle2;
        FreightColumn.HeaderText = "Freight";
        FreightColumn.MinimumWidth = 6;
        FreightColumn.Name = "FreightColumn";
        FreightColumn.ReadOnly = true;
        FreightColumn.Width = 125;
        // 
        // CustomersBindingNavigator
        // 
        CustomersBindingNavigator.ImageScalingSize = new Size(20, 20);
        CustomersBindingNavigator.Location = new Point(0, 0);
        CustomersBindingNavigator.Name = "CustomersBindingNavigator";
        CustomersBindingNavigator.Size = new Size(800, 27);
        CustomersBindingNavigator.TabIndex = 2;
        CustomersBindingNavigator.Text = "coreBindingNavigator1";
        // 
        // MasterDetails
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 503);
        Controls.Add(CustomersBindingNavigator);
        Controls.Add(OrdersDataGridView);
        Controls.Add(CustomersDataGridView);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        Name = "MasterDetails";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "MasterDetails";
        ((System.ComponentModel.ISupportInitialize)CustomersDataGridView).EndInit();
        ((System.ComponentModel.ISupportInitialize)OrdersDataGridView).EndInit();
        CustomersBindingNavigator.EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private DataGridView CustomersDataGridView;
    private DataGridView OrdersDataGridView;
    private DataGridViewTextBoxColumn CompanyNameColumn;
    private DataGridViewComboBoxColumn CountryColumn;
    private DataGridViewTextBoxColumn OrderDateColumn;
    private DataGridViewTextBoxColumn ShipAddressColumn;
    private DataGridViewTextBoxColumn FreightColumn;
    private Components.CoreBindingNavigator CustomersBindingNavigator;
}