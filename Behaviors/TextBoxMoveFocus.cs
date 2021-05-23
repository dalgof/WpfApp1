using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Input;
using System.IO;

namespace WpfApp1.Behaviors
{
    class TextBoxMoveFocus : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewKeyDown += OnPreviewKeyDown;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.PreviewKeyDown -= OnPreviewKeyDown;
        }

        private void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                TraversalRequest request = null;

                switch (e.Key)
                {
                    case Key.Left:
                        if (textBox.SelectionStart.Equals(0))
                        {
                            request = new TraversalRequest(FocusNavigationDirection.Left);

                        }

                        break;

                    case Key.Right:
                        if (textBox.SelectionStart.Equals(textBox.Text.Length))
                        {
                            request = new TraversalRequest(FocusNavigationDirection.Right);
                        }
                        break;

                    case Key.OemPeriod:
                    case Key.Decimal:
                        if (!textBox.SelectionStart.Equals(0))
                        {
                            request = new TraversalRequest(FocusNavigationDirection.Right);
                        }
                        break;

                    default:
                        break;
                }

                if (request != null)
                {
                    textBox.MoveFocus(request);

                    if (request.FocusNavigationDirection == FocusNavigationDirection.Left){
                        textBox.Select(textBox.Text.Length, 0);
                    }
                    //StreamWriter sw = new StreamWriter("main.txt",true);
                    //sw.WriteLine(request.FocusNavigationDirection);
                    //sw.Close();
                }
            }
        }
    }
}
