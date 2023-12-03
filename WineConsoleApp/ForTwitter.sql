

	--- Not using a variable
	SELECT [w].[WineId], [w].[Name], [w].[WineType]
	FROM [Wines] AS [w]
	WHERE [w].[WineType] = 3
	--- using a variable
	SELECT [w].[WineId], [w].[Name], [w].[WineType]
	FROM [Wines] AS [w]
	WHERE [w].[WineType] = @__roseType_0