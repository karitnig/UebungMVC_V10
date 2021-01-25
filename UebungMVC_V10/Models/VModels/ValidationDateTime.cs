using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UebungMVC_V10.Models.DBModels;

namespace UebungMVC_V10.Models.VModels
{
    public class ValidationDateTime : ValidationAttribute
    {
        protected override ValidationResult
            IsValid(object value, ValidationContext validationContext)
        {
            var model = (DataVM)validationContext.ObjectInstance;
            DateTime _endeDateTime = Convert.ToDateTime(value); ;
            DateTime _anfangDateTime = Convert.ToDateTime(model.AnfangDateTime);

            if (_anfangDateTime > _endeDateTime)
            {
                return new ValidationResult("Die EndZeit darf nicht vor AnfangsZeit erstellt werden");
            }
            else
            {
                return ValidationResult.Success;
            }

        }
    }
}