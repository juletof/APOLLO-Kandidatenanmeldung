using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ApolloDb
{
    public class BooleanRequiredToBeTrueAttribute : RequiredAttribute, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            return value != null && (bool)value;
        }

        public override string FormatErrorMessage(string name)
        {
            return "The " + name + " field must be checked in order to continue.";
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ErrorMessage = String.IsNullOrEmpty(ErrorMessage) ? FormatErrorMessage(metadata.DisplayName) : ErrorMessage,
                ValidationType = "checkrequired"
            };
        }
    }   
}