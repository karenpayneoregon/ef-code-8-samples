using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Serilog;

namespace EntityFrameworkChinookLoggingSample.Classes;
public class SlowQueryInterceptor : DbCommandInterceptor
{
    private const int SlowQueryThreshold = 200; // Threshold in milliseconds  

    public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
    {

        if (eventData.Duration.TotalMilliseconds > SlowQueryThreshold)
        {
            Log.Information("Slow query detected: {CommandText}", command.CommandText);
        }

        return base.ReaderExecuted(command, eventData, result);
    }
}

