using System.ComponentModel.DataAnnotations;

namespace Blog.Application.DTOs
{
    public class BlogUpdateCommand : IValidatableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Id < 1)
                yield return new ValidationResult("The Id parameter must be greater than zero", new[] { nameof(Id) });

            if (string.IsNullOrWhiteSpace(Name))
                yield return new ValidationResult("The Name parameter must not be empty", new[] { nameof(Name) });
        }

    }
}
