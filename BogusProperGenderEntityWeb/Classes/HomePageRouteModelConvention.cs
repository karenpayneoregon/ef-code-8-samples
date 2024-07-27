using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Options;

namespace BogusProperGenderEntityWeb.Classes;
/// <summary>
/// Map ... as the home page
/// </summary>
public class HomePageRouteModelConvention : IPageRouteModelConvention
{
    public void Apply(PageRouteModel model)
    {
        if (model.RelativePath == "/Pages/Index.cshtml")
        {
            var currentHomePage = model.Selectors.Single(s => s.AttributeRouteModel!.Template == string.Empty);
            model.Selectors.Remove(currentHomePage);
        }

        if (model.RelativePath == "/Pages/TODO.cshtml")
        {
            model.Selectors.Add(new SelectorModel()
            {
                AttributeRouteModel = new AttributeRouteModel
                {
                    Template = string.Empty
                }
            });
        }
    }
}


//builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
//{
//    options.Conventions.Add(new HomePageRouteModelConvention());
//});