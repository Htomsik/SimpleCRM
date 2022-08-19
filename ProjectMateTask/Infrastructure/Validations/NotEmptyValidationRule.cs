using System.Globalization;
using System.Windows.Controls;

namespace ProjectMateTask.Infrastructure.Validations;

internal sealed class NotEmptyValidationRule:ValidationRule
{
    public override ValidationResult Validate(object? value, CultureInfo cultureInfo)
    {
        return string.IsNullOrEmpty(value!.ToString())
            ? new ValidationResult(false, "Требуемое поле")
            : ValidationResult.ValidResult;
    }
}