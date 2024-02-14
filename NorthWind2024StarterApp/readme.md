# About

This project is a basic example of using Entity Framework Core 8 in a Windows Forms project.

- Supplier column in the DataGridView should be a drop down. See my [article](https://dev.to/karenpayneoregon/learn-to-use-a-databound-datagridview-combobox-in-windows-forms-1coa) on how to setup a drop down.
- For changing data outside the form controls implement `INotifyPropertyChanged` as done in Product model.
- `SortableBindingList` under components folder provides sorting for the DataGridView.

The way code is setup work with the BindingList and BindingSource to work with data rathe than accessing data in this case from the DataGridView.

:curly_loop: Connection string is in `appsettings.json`

## Setup

- In SSMS create `NorthWind2024 `database
- Run `populate.sql` under the script folder.