using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Net5WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
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
            var name = textBox1.Text;
            MessageBox.Show(
                $"こんにちは、{name} さん",
                ".NET5の解説",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int GetWindowText(IntPtr hWnd, string lpString, int nMaxCount);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hwnd);

        /// <summary>
        /// WIN32 API を使ってテキストを取得する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            var hwnd = textBox1.Handle;
            int length = GetWindowTextLength(hwnd);
            string name = new string('\0', length + 1);
            GetWindowText(hwnd, name, name.Length);

            MessageBox.Show(
                $"こんにちは、{name} さん",
                ".NET5の解説(WIN32 API)",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
