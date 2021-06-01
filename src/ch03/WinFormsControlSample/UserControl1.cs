using System;
using System.Windows.Forms;

namespace WinFormsControlSample
{
    public partial class UserControlSample: UserControl
    {
        public UserControlSample()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ボタンをクリックしたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var name = label1.Text;
            MessageBox.Show(
                $"こんにちは、{name} さん",
                ".NET5の解説",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        ///
        /// プロパティを公開する
        ///
        public string HelloMessage
        {
            get { return this.Message.Text; }
            set { this.Message.Text = value; }
        }

        private int _count = 0;
        ///
        /// メソッドを公開する
        /// 
        public void CountUp()
        {
            _count++;
            button2.Text = $"Click me {_count}";
        }
        /// <summary>
        /// カウントアップボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            CountUp();
            /// イベントを発生する
            this.OnCountUp?.Invoke();
        }
        ///
        /// 内部でイベントを発生する
        /// 
        public event Action OnCountUp ;
    }
}
