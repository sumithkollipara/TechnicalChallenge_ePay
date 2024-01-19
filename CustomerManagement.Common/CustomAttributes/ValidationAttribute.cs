using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.Common.CustomAttributes
{
    public class MaxValueAttribute : ValidationAttribute
    {
        private readonly int _maxValue;

        public MaxValueAttribute(int maxValue)
        {
            _maxValue = maxValue;
        }

        public override bool IsValid(object value) => (int)value <= _maxValue;
    }

    public class MinValueAttribute : ValidationAttribute
    {
        private readonly int _minValue;

        public MinValueAttribute(int minValue)
        {
            _minValue = minValue;
        }

        public override bool IsValid(object value) => (int)value >= _minValue;
    }
}
