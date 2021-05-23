using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace WpfApp1.Behaviors
{
    class TextBoxMoveFocus_textinput : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewTextInput += OnPreviewTextInput;

        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewTextInput += OnPreviewTextInput;
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                TraversalRequest request = null;

                e.Handled = !new Regex("[0-9]").IsMatch(e.Text);
                if (textBox.Text.Length == textBox.MaxLength)
                {
                    request = new TraversalRequest(FocusNavigationDirection.Right);
                    textBox.MoveFocus(request);

                }

                //if (request != null)
                //{
                //    textBox.MoveFocus(request);
                //}

            }
        }
    }
}

