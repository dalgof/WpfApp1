using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfApp1
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ValidWindow : Window
    {
        public ValidWindow()
        {
            InitializeComponent();
        }

        //private void UseCustomHandler(object sender, RoutedEventArgs e)
        //{
        //    var myBindingExpression = textBox3.GetBindingExpression(TextBox.TextProperty);
        //    var myBinding = myBindingExpression.ParentBinding;
        //    myBinding.UpdateSourceExceptionFilter = ReturnExceptionHandler;
        //    myBindingExpression.UpdateSource();
        //}

        //private void DisableCustomHandler(object sender, RoutedEventArgs e)
        //{
        //    // textBox3 is an instance of a TextBox
        //    // the TextProperty is the data-bound dependency property
        //    var myBinding = BindingOperations.GetBinding(textBox3, TextBox.TextProperty);
        //    myBinding.UpdateSourceExceptionFilter -= ReturnExceptionHandler;
        //    BindingOperations.GetBindingExpression(textBox3, TextBox.TextProperty).UpdateSource();
        //}
        //private object ReturnExceptionHandler(object bindingExpression, Exception exception) => "This is from the UpdateSourceExceptionFilterCallBack.";
    }
}