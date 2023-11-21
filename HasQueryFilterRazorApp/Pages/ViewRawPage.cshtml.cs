using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Serilog;
using ShadowProperties.Models;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

#pragma warning disable CS8601

namespace HasQueryFilterRazorApp.Pages
{
    
    public class ViewRawPageModel : PageModel
    {
        private IConfiguration _configuration;
        private string _connectionString;
        [BindProperty]
        public List<Report> Reports { get; set; }
        public ViewRawPageModel(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public async Task OnGet()
        {
            string command =
                """
                SELECT ContactId,
                       FirstName,
                       LastName,
                       LastUser,
                       CreatedBy,
                	   FORMAT(CreatedAt, 'MM/dd/yyyy') AS CreatedAt,
                	   FORMAT(LastUpdated, 'MM/dd/yyyy') AS LastUpdated,
                       IIF(isDeleted = 'TRUE' , 'Y','N') AS Deleted
                FROM dbo.Contact1;
                """;

            await using var cn = new SqlConnection(_connectionString);
            await using var cmd = new SqlCommand { Connection = cn, CommandText = command };
            await cn.OpenAsync();
            var reader = await cmd.ExecuteReaderAsync();
            Reports = new List<Report>();

            while (reader.Read())
            {
                Reports.Add(new Report
                {
                    ContactId = reader.GetInt32(0), 
                    FirstName = reader.GetString(1), 
                    LastName = reader.GetString(2), 
                    LastUser = reader.GetString(3), 
                    CreatedBy = reader.GetString(4), 
                    CreatedAt = reader.GetString(5),
                    LastUpdated = reader.GetString(6),
                    Deleted = reader.GetString(7)
                });
            }
        }
    }
}
