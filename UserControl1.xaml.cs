﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{

    public class IpAddressControl : ValidationRule
    {
        private int _min;
        private int _max;

        public int Min
        {
            get { return _min; }
            set { _min = value; }
        }

        public int Max
        {
            get { return _max; }
            set { _max = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int val = 0;
            var strVal = (string)value;
            try
            {
                if (strVal.Length > 0)
                {
                    if (strVal.EndsWith("."))
                    {
                        return CheckRanges(strVal.Replace(".", ""));
                    }

                    // Allow dot character to move to next box
                    return CheckRanges(strVal);
                }
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "Illegal characters or " + e.Message);
            }

            if ((val < Min) || (val > Max))
            {
                return new ValidationResult(false,
                 "Please enter the value in the range: " + Min + " - " + Max + ".");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }

        //public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        //{
        //    throw new NotImplementedException();
        //}

        private ValidationResult CheckRanges(string strVal)
        {
            if (int.TryParse(strVal, out var res))
            {
                if ((res < Min) || (res > Max))
                {
                    return new ValidationResult(false,
                     "Please enter the value in the range: " + Min + " - " + Max + ".");
                }
                else
                {
                    return ValidationResult.ValidResult;
                }
            }
            else
            {
                return new ValidationResult(false, "Illegal characters entered");
            }
        }
        private void Part2_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Back && part2.Text == "")
            {
                part1.Focus();
            }
            if (e.Key == Key.Right && part2.CaretIndex == part2.Text.Length)
            {
                part3.Focus();
                e.Handled = true;
            }
            if (e.Key == Key.Left && part2.CaretIndex == 0)
            {
                part1.Focus();
                e.Handled = true;
            }

            if (e.KeyboardDevice.Modifiers.HasFlag(ModifierKeys.Control) && e.Key == Key.C)
            {
                if (part2.SelectionLength == 0)
                {
                    var vm = this.DataContext as IpAddressViewModel;
                    Clipboard.SetText(vm.AddressText);
                }
            }
        }
    }
    public static class FocusChangeExtension
    {
        public static bool GetIsFocused(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsFocusedProperty);
        }

        public static void SetIsFocused(DependencyObject obj, bool value)
        {
            obj.SetValue(IsFocusedProperty, value);
        }

        public static readonly DependencyProperty IsFocusedProperty =
         DependencyProperty.RegisterAttached(
          "IsFocused", typeof(bool), typeof(FocusChangeExtension),
          new UIPropertyMetadata(false, OnIsFocusedPropertyChanged));

        private static void OnIsFocusedPropertyChanged(
         DependencyObject d,
         DependencyPropertyChangedEventArgs e)
        {
            var control = (UIElement)d;
            if ((bool)e.NewValue)
            {
                control.Focus();
            }
        }

    }
    public class IpAddressViewModel : INotifyPropertyChanged
    {
        public event EventHandler AddressChanged;

        public string AddressText
        {
            get { return $"{Part1 ?? "0"}.{Part2 ?? "0"}.{Part3 ?? "0"}.{Part4 ?? "0"}"; }
        }

        private bool isPart1Focused;

        public bool IsPart1Focused
        {
            get { return isPart1Focused; }
            set { isPart1Focused = value; OnPropertyChanged(); }
        }

        private string part1;

        public string Part1
        {
            get { return part1; }
            set
            {
                part1 = value;
                SetFocus(true, false, false, false);

                var moveNext = CanMoveNext(ref part1);

                OnPropertyChanged();
                OnPropertyChanged(nameof(AddressText));
                AddressChanged?.Invoke(this, EventArgs.Empty);

                if (moveNext)
                {
                    SetFocus(false, true, false, false);
                }
            }
        }

        private bool isPart2Focused;

        public bool IsPart2Focused
        {
            get { return isPart2Focused; }
            set { isPart2Focused = value; OnPropertyChanged(); }
        }


        private string part2;

        public string Part2
        {
            get { return part2; }
            set
            {
                part2 = value;
                SetFocus(false, true, false, false);

                var moveNext = CanMoveNext(ref part2);

                OnPropertyChanged();
                OnPropertyChanged(nameof(AddressText));
                AddressChanged?.Invoke(this, EventArgs.Empty);

                if (moveNext)
                {
                    SetFocus(false, false, true, false);
                }
            }
        }

        private bool isPart3Focused;

        public bool IsPart3Focused
        {
            get { return isPart3Focused; }
            set { isPart3Focused = value; OnPropertyChanged(); }
        }

        private string part3;

        public string Part3
        {
            get { return part3; }
            set
            {
                part3 = value;
                SetFocus(false, false, true, false);
                var moveNext = CanMoveNext(ref part3);

                OnPropertyChanged();
                OnPropertyChanged(nameof(AddressText));
                AddressChanged?.Invoke(this, EventArgs.Empty);

                if (moveNext)
                {
                    SetFocus(false, false, false, true);
                }
            }
        }

        private bool isPart4Focused;

        public bool IsPart4Focused
        {
            get { return isPart4Focused; }
            set { isPart4Focused = value; OnPropertyChanged(); }
        }

        private string part4;

        public string Part4
        {
            get { return part4; }
            set
            {
                part4 = value;
                SetFocus(false, false, false, true);
                var moveNext = CanMoveNext(ref part4);

                OnPropertyChanged();
                OnPropertyChanged(nameof(AddressText));
                AddressChanged?.Invoke(this, EventArgs.Empty);

            }
        }

        public void SetAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                return;

            var parts = address.Split('.');

            if (int.TryParse(parts[0], out var num0))
            {
                Part1 = num0.ToString();
            }

            if (int.TryParse(parts[1], out var num1))
            {
                Part2 = parts[1];
            }

            if (int.TryParse(parts[2], out var num2))
            {
                Part3 = parts[2];
            }

            if (int.TryParse(parts[3], out var num3))
            {
                Part4 = parts[3];
            }

        }

        private bool CanMoveNext(ref string part)
        {
            bool moveNext = false;

            if (!string.IsNullOrWhiteSpace(part))
            {
                if (part.Length >= 3)
                {
                    moveNext = true;
                }

                if (part.EndsWith("."))
                {
                    moveNext = true;
                    part = part.Replace(".", "");
                }
            }

            return moveNext;
        }

        private void SetFocus(bool part1, bool part2, bool part3, bool part4)
        {
            IsPart1Focused = part1;
            IsPart2Focused = part2;
            IsPart3Focused = part3;
            IsPart4Focused = part4;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

