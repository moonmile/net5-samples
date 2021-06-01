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
                $"����ɂ��́A{name} ����",
                ".NET5�̉��",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }


        private int _count = 0;
        ///
        /// ���\�b�h�����J����
        /// 
        public void CountUp()
        {
            _count++;
            this.button2.Content = $"Click me {_count}";
        }
        /// <summary>
        /// �J�E���g�A�b�v�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickMe_Click(object sender, EventArgs e)
        {
            CountUp();
            /// �R�}���h�𔭐�����
            if ( this.Command.CanExecute(null))
            {
                this.Command?.Execute(null);
            }
        }

        /// <summary>
        /// �ˑ��v���p�e�B�̒�`
        /// </summary>
        public static readonly DependencyProperty HelloMessageProperty =
            DependencyProperty.Register(
                "Message",         // �v���p�e�B��
                typeof(string),    // �v���p�e�B�̌^
                typeof(UserControlSample),�@ // �R���g���[���̌^
                new FrameworkPropertyMetadata(   // ���^�f�[�^                   
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
        /// �v���p�e�B�����J����
        ///
        public string HelloMessage
        {
            get => (string)GetValue(HelloMessageProperty);
            set => SetValue(HelloMessageProperty, value);
        }

        /// <summary>
        /// Command�v���p�e�B�����J����
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