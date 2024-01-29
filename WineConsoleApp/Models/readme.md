# About

`WineType.tt` template is responsible for generating WineType model. Before running the template, run the application which checks to see if the database exists, if the database does not exists.

Create the `WineType` table using a model, [WineTypes](WineTypes.cs) as we can not create the WineType table via an emum. There are other methods to create the table and seed it, I wanted to keep this simple for this demonstration.

## Important

For `.tt` or `.ttinclude` files, under properties set `Custom Tool` to `TextTemplatingFileGenerator`

## Tip

Use Visual Studio Code to work with template files with [T4 Support extension](https://marketplace.visualstudio.com/items?itemName=zbecknell.t4-support) which has better color theme than the extension [T4 Language](https://marketplace.visualstudio.com/items?itemName=bricelam.T4Language) for Visual Studo 2022.

Microsoft docs: [Design-Time Code Generation by using T4 Text Templates](https://learn.microsoft.com/en-us/visualstudio/modeling/design-time-code-generation-by-using-t4-text-templates?view=vs-2022&tabs=csharp)



