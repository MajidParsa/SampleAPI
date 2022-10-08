using System.ComponentModel.DataAnnotations;

namespace Blog.Application.DTOs
{
    public class BlogInsertCommand : IValidatableObject
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Name))
                yield return new ValidationResult("The Name field must not be empty", new[] { nameof(Name) });
        }
    }
}
