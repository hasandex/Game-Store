using System.ComponentModel.DataAnnotations;

namespace GameZone.Attributes
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        public AllowedExtensionsAttribute(string allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }
        private readonly string _allowedExtensions;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extensions = Path.GetExtension(file.FileName);
                var isAllowed = _allowedExtensions.Split(separator:',').Contains(extensions,StringComparer.OrdinalIgnoreCase);  
                if(!isAllowed )
                {
                    return new ValidationResult(errorMessage: $"only {_allowedExtensions} is available");
                }          
            }
            return ValidationResult.Success;

        }
    }
}
