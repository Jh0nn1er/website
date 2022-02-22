using System.ComponentModel.DataAnnotations;

namespace WebsiteForms.Helpers
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class AllowExtensionsAttribute : ValidationAttribute
    {
        private List<string> AllowedExtensions { get; set; }
        private const string DefaultErrorMessage = "The Policy field only accepts files with the following extensions: ";
        public string NotExtensionMessage { get; set; }


        public AllowExtensionsAttribute(string fileExtensions)
        {
            AllowedExtensions = fileExtensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IFormFile? file = value as IFormFile;

            if (file != null)
            {
                var fileName = file.FileName;

                bool hasExtension = AllowedExtensions.Any(y => fileName.EndsWith(y));

                if (hasExtension)
                    return ValidationResult.Success;
                else
                    return new ValidationResult(NotExtensionMessage ?? $"{DefaultErrorMessage}{String.Join(", ", AllowedExtensions.ToArray())}");
            }

            return ValidationResult.Success;
        }
    }
}
