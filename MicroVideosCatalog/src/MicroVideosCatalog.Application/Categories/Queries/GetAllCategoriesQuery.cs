namespace MicroVideosCatalog.Application.Categories.Queries;
public record GetAllCategoriesQuery : Query<GetAllCategoriesQuery>
{
    protected override void ConfigureValidations(Validator ruler) { }
}