using System;
using System.ComponentModel.DataAnnotations;
using QuantoEra.Web.Components.Pages; // To access InputModel

namespace QuantoEra.Web.Components.Validation
{
    public class FutureDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is not Home.InputModel model) return new ValidationResult("Invalid object type for validation.");

            DateTime today = DateTime.Today;
            DateTime selectedDate = new DateTime(model.SelectedYear, model.SelectedMonth, 1);
            if (selectedDate > today)
            {
                return new ValidationResult(
                    $"A data selecionada ({model.SelectedMonth:00}/{model.SelectedYear}) não pode ser no futuro.",
                    new[] { nameof(model.SelectedMonth), nameof(model.SelectedYear) });
            }

            return ValidationResult.Success;
        }
    }
}