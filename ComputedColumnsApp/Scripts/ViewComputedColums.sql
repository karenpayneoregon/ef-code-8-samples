--- get a list of computed columns in a SQL Server database
SELECT SCHEMA_NAME(o.schema_id) AS SchemaName,
       c.name AS ColumnName,
       OBJECT_NAME(c.object_id) AS TableName,
       TYPE_NAME(c.user_type_id) AS DataType,
       c.Definition
FROM sys.computed_columns c
    JOIN sys.objects o
        ON o.object_id = c.object_id
ORDER BY SchemaName,
         TableName,
         c.column_id;