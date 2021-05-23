using System;
using System.Collections.Generic;
using System.Text;

using System.Globalization;
using System.Windows.Controls;

namespace WpfApp1.ValidationRules
{
    public class NumberValidationRule : ValidationRule
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public bool NotEmpty { get; set; }
        public string MessageHeader { get; set; }

        public NumberValidationRule()
        {
            MinValue = int.MinValue;
            MaxValue = int.MaxValue;
            NotEmpty = false;
            MessageHeader = null;
        }

        public NumberValidationRule(int min, int max, bool notEmpty = false, string msgHeader = null)
        {
            MinValue = min;
            MaxValue = max;
            NotEmpty = notEmpty;
            MessageHeader = msgHeader;
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                if (NotEmpty)
                {
                    var msg = "値を入力してください";
                    if (!string.IsNullOrWhiteSpace(MessageHeader))
                    {
                        msg = MessageHeader + "に" + msg;
                    }
                    return new ValidationResult(false, msg);
                }
                else
                {
                    return ValidationResult.ValidResult;
                }
            }
            string str = value.ToString();
            if (string.IsNullOrEmpty(str))
            {
                if (NotEmpty)
                {
                    var msg = "値を入力してください";
                    if (!string.IsNullOrWhiteSpace(MessageHeader))
                    {
                        msg = MessageHeader + "に" + msg;
                    }
                    return new ValidationResult(false, msg);
                }
                else
                {
                    return ValidationResult.ValidResult;
                }
            }
            int ret;
            if (!int.TryParse(str, out ret))
            {
                var msg = "数値を入力してください";
                if (!string.IsNullOrWhiteSpace(MessageHeader))
                {
                    msg = MessageHeader + "に" + msg;
                    return new ValidationResult(false, msg);

                }
                return new ValidationResult(false, msg);
            }
            if ((MinValue > ret) || (MaxValue < ret))
            {
                var msg = "値が範囲外です(" + MinValue + "～" + MaxValue + ")";
                if (!string.IsNullOrWhiteSpace(MessageHeader))
                {
                    msg = MessageHeader + "の" + msg;
                    return new ValidationResult(false, msg);
                }
                return new ValidationResult(false, msg);
            }
            return ValidationResult.ValidResult;
        }
    }
}
