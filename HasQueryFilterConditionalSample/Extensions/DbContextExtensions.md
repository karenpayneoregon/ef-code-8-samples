# Usage

```csharp

using var context = new Context();

bool hasFilter = context.HasQueryFilter<Customer>();
var entityType = context.Model.FindEntityType(typeof(Customer));

var filter = context.QueryFilterDefinition<Customer>();
Console.WriteLine(filter);
```