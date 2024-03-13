using System.Text.RegularExpressions;

namespace WorkingWithExcelApp.Classes;
public static class DataGridViewExtensions
{
    public static void ExpandColumns(this DataGridView source, bool sizable = false)
    {
        foreach (DataGridViewColumn col in source.Columns)
        {
            if (col.ValueType.Name != "ICollection`1")
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        if (!sizable) return;

        for (int index = 0; index <= source.Columns.Count - 1; index++)
        {
            int columnWidth = source.Columns[index].Width;

            source.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            source.Columns[index].Width = columnWidth;
        }


    }
    public static void FixHeaders(this DataGridView source)
    {
        string SplitCamelCase(string sender)
            => string.Join(" ", Regex.Matches(sender,
                @"([A-Z][a-z]+)").Select(m => m.Value));

        for (int index = 0; index < source.Columns.Count; index++)
        {
            //source.Columns[index].Width = 150;
            source.Columns[index].HeaderText = SplitCamelCase(source.Columns[index].HeaderText);
        }
    }
}
