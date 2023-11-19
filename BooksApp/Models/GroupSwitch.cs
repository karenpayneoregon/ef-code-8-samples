namespace BooksApp.Models;

public record GroupSwitch(string Category, List<Book> List)
{
    public override string ToString()
    {
        return $"{{ Category = {Category}, List = {List} }}";
    }
}