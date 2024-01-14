using System.Text.Json;

namespace DbCommandInterceptorApp1.Classes;
public static class JSonHelper
{

    public static void ToJson<T>(this List<T> sender, string fileName)
    {
        File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Json", $"{fileName}.json"),
            JsonSerializer.Serialize(sender, new JsonSerializerOptions
            {
                WriteIndented = true 
            }));
    }

    public static List<T> AppendFromFile<T>(this List<T> sender, string fileName)
    {


        if (File.Exists(fileName))
        {
            var json = File.ReadAllText(fileName);
            if (json.Length > 0)
            {
                List<T> data = JsonSerializer.Deserialize<List<T>>(File.ReadAllText(fileName));
                data.AddRange(sender);
                return data;
            }
            else
            {
                return sender;
            }

        }
        else
        {
            return sender;
        }

    }


}
