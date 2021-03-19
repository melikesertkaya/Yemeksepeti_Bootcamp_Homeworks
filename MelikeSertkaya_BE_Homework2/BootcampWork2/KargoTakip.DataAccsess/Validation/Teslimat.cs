using KargoTakip.DataAccsess.RequestModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KargoTakip.DataAccsess.Validation
{
   public class Teslimat:ValidationAttribute
    {
       
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Product kargoModel = (Product)validationContext.ObjectInstance;

            if (kargoModel ==null)
            {
               
                
                
            }

            return ValidationResult.Success;
        }
    }
}
