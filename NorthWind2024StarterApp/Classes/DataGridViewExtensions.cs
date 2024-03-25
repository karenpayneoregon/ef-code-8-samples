using System.Text;
using System.Text.RegularExpressions;

namespace NorthWind2024StarterApp.Classes;
public static partial class DataGridViewExtensions
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

    [GeneratedRegex(@"([A-Z][a-z]+)")]
    private static partial Regex UpperLowerSplit();

    public static void FixHeaders(this DataGridView source)
    {
        string SplitUpperLower(string sender)
            => string.Join(" ", UpperLowerSplit().Matches(sender).Select(m => m.Value));

        for (int index = 0; index < source.Columns.Count; index++)
        {
            //source.Columns[index].Width = 150;
            source.Columns[index].HeaderText = SplitUpperLower(source.Columns[index].HeaderText);
        }
    }



    // replace last occurrence with replacement.
    public static string ReplaceLastOccurrence(this string sender, string find, string replace)
    {
        int place = sender.LastIndexOf(find, StringComparison.Ordinal);
        return place == -1 ?
            sender :
            sender.Remove(place, find.Length)
                .Insert(place, replace);
    }


    public static void ExportRows(this DataGridView sender, string fileName, string defaultNullValue = "(empty)")
    {
        File.WriteAllLines(fileName, (sender.Rows.Cast<DataGridViewRow>()
            .Where(row => !row.IsNewRow)
            .Select(row => new {
                row,
                rowItem = string.Join(",", Array.ConvertAll(row.Cells.Cast<DataGridViewCell>()
                    .ToArray(), c => ((c.Value == null) ? defaultNullValue : c.Value.ToString())))
            })
            .Select(@row => @row.rowItem)));
    }
}
