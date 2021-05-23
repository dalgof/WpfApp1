using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//using System.Windows.Interactivity;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Num1
        {
            get;set;
        }
        //public int Num1
        //{
        //    get { return num1; }
        //    set
        //    {
        //        if (value < 1 || value > 255)
        //        {
        //            throw new ArgumentException();
        //        }

        //    }
        //}
        public MainWindow()
        {
            InitializeComponent();

        }


        private new void KeyDown(object sender, KeyEventArgs e)
        {
            StreamWriter sw = new StreamWriter("main.txt");
            //if (sender is TextBox textBox)
            //{
            //    TraversalRequest request = null;

            //    switch (e.Key)
            //    {
            //        case Key.Left:
            //            request = new TraversalRequest(FocusNavigationDirection.Left);
            //            //textBox.MoveFocus(request);

            //            sw.WriteLine("Left");
            //            sw.Close();
            //            break;

            //        case Key.Right:
            //            request  = new TraversalRequest(FocusNavigationDirection.Right);
            //            //textBox.MoveFocus(request);
            //            sw.WriteLine("Right");
            //            sw.Close();
            //            break;

            //        case Key.OemPeriod:
            //            request  = new TraversalRequest(FocusNavigationDirection.Right);
            //            //textBox.MoveFocus(request);
            //            break;

            //        default:
            //            break;
            //    }

            //    if(request != null)
            //    {
            //        textBox.MoveFocus(request);
            //    }
            //}

        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            LoggerFunc("FPDE Firm", -2100);

            //try
            //{
            //    DataStore dataStore = new DataStore();
            //    dataStore.TextData = MainText.Text;

            //    DataStore.statictextdata = MainText.Text;
            //}
            //catch (InvalidOperationException ex)
            //{
            //    StreamWriter sw = new StreamWriter("main.txt");
            //    sw.WriteLine(ex);
            //    sw.Close();
            //}
        }
        void LoggerFunc(string targettype, int errorcord)
        {
            //年月日　[ターゲット エラーコード:-0000]
            string errorTxt = string.Format("{0} [{1} ErrorCord:{2}]", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), targettype, errorcord);

            StreamWriter sw = new StreamWriter("log.txt", true);
            sw.WriteLine(errorTxt);
            sw.Close();

        }

        //0入力時の自動削除
        private void Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            if (textBox.Text.StartsWith("0") && textBox.Text != "0")
            {
                var currentPoint = textBox.SelectionStart;
                textBox.Text = textBox.Text.Substring(1);
                if (currentPoint > textBox.Text.Length)
                {
                    textBox.SelectionStart = textBox.Text.Length;
                }
            }
            textBox.TextChanged += Textbox_TextChanged;
        }
    }
}
