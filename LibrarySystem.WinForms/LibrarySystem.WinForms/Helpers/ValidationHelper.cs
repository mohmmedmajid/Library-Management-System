using System;
using System.Linq;

namespace LibrarySystem.WinForms.Helpers
{
    public static class ValidationHelper
    {

        public static bool IsEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsValidNumber(string value)
        {
            return decimal.TryParse(value, out _);
        }

        public static bool IsValidInteger(string value)
        {
            return int.TryParse(value, out _);
        }

        public static bool IsValidPrice(string value)
        {
            if (!decimal.TryParse(value, out decimal price))
                return false;

            return price >= 0;
        }

        public static bool IsValidQuantity(string value)
        {
            if (!int.TryParse(value, out int quantity))
                return false;

            return quantity > 0;
        }

        public static bool IsValidPhone(string value)
        {
            if (IsEmpty(value)) return false;
            return value.All(c => char.IsDigit(c) || c == '+' || c == '-');
        }

        public static bool IsValidEmail(string value)
        {
            if (IsEmpty(value)) return false;
            return value.Contains("@") && value.Contains(".");
        }

        public static bool IsValidDate(string value)
        {
            return DateTime.TryParse(value, out _);
        }

        public static bool IsFutureDate(DateTime date)
        {
            return date > DateTime.Now;
        }

        public static bool ValidateRequired(params string[] fields)
        {
            foreach (var field in fields)
            {
                if (IsEmpty(field))
                    return false;
            }
            return true;
        }
    }
}