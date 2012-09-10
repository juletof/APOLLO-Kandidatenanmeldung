using System.ComponentModel.DataAnnotations;

namespace ApolloDb
{
    public class BooleanRequiredToBeTrueAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            return value != null && (bool)value;
        }
    }   
}