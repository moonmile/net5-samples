using System;
using System.Collections.Generic;
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

namespace WpfControlSample
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControlSample : UserControl
    {
        public UserControlSample()
        {
            InitializeComponent();
        }


        private void Hello_Click(object sender, RoutedEventArgs e)
        {
            var name = textBox1.Text;
            MessageBox.Show(
                $"こんにちは、{name} さん",
                ".NET5の解説",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }


        private int _count = 0;
        ///
        /// メソッドを公開する
        /// 
        public void CountUp()
        {
            _count++;
            this.button2.Content = $"Click me {_count}";
        }
        /// <summary>
        /// カウントアップボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickMe_Click(object sender, EventArgs e)
        {
            CountUp();
            /// コマンドを発生する
            if ( this.Command.CanExecute(null))
            {
                this.Command?.Execute(null);
            }
        }

        /// <summary>
        /// 依存プロパティの定義
        /// </summary>
        public static readonly DependencyProperty HelloMessageProperty =
            DependencyProperty.Register(
                "Message",         // プロパティ名
                typeof(string),    // プロパティの型
                typeof(UserControlSample),　 // コントロールの型
                new FrameworkPropertyMetadata(   // メタデータ                   
                    null,
                    new PropertyChangedCallback((o, e) =>
                    {
                        var uc = o as UserControlSample;
                        if (uc != null)
                        {
                            var data = e.NewValue as string;
                            uc.message.Text = data;
                        }
                    })));

        ///
        /// プロパティを公開する
        ///
        public string HelloMessage
        {
            get => (string)GetValue(HelloMessageProperty);
            set => SetValue(HelloMessageProperty, value);
        }

        /// <summary>
        /// Commandプロパティを公開する
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
             DependencyProperty.Register(
                 "Command", 
                 typeof(ICommand), 
                 typeof(UserControlSample), 
                 new UIPropertyMetadata(null));
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }
    }
}