using FluentValidation;

namespace MicroVideosCatalog.Application.Categories.Commands;
public record CreateCategoryCommand : Command<CreateCategoryCommand>
{
    public string Name { get; set; }
    public CreateCategoryCommand(string name) => Name = name;
    protected override void ConfigureValidations(Validator ruler)
    {
        ruler.RuleFor(c => c.Name).NotNull().NotEmpty().MinimumLength(3);
    }
}