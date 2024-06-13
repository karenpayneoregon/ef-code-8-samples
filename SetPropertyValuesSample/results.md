# Results

The following data was taken from the log file.

## First

```
info: 6/13/2024 06:36:37.086 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command) 
      Executed DbCommand (4ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT TOP(1) [p].[Id], [p].[BirthDate], [p].[FirstName], [p].[LastName], [p].[Title]
      FROM [Person] AS [p]
```

---

## Second

```
info: 6/13/2024 06:36:37.171 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command) 
      Executed DbCommand (27ms) [Parameters=[@p1='1', @p0='Jane' (Nullable = false) (Size = 4000)], CommandType='Text', CommandTimeout='30']
      SET IMPLICIT_TRANSACTIONS OFF;
      SET NOCOUNT ON;
      UPDATE [Person] SET [FirstName] = @p0
      OUTPUT 1
      WHERE [Id] = @p1;
```

---

## Third

```
info: 6/13/2024 06:36:37.188 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command) 
      Executed DbCommand (1ms) [Parameters=[@p1='1', @p0='Cater' (Nullable = false) (Size = 4000)], CommandType='Text', CommandTimeout='30']
      SET IMPLICIT_TRANSACTIONS OFF;
      SET NOCOUNT ON;
      UPDATE [Person] SET [LastName] = @p0
      OUTPUT 1
      WHERE [Id] = @p1;
```

---

## Fourth (smaller model)

```
info: 6/13/2024 06:36:37.197 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command) 
      Executed DbCommand (1ms) [Parameters=[@p1='2', @p0='Greg' (Nullable = false) (Size = 4000)], CommandType='Text', CommandTimeout='30']
      SET IMPLICIT_TRANSACTIONS OFF;
      SET NOCOUNT ON;
      UPDATE [Person] SET [FirstName] = @p0
      OUTPUT 1
      WHERE [Id] = @p1;
```