using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsControlSampleTest
{
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        this.ucSample1.OnCountUp += ucSample1_OnCountUp;
        this.ucSample2.OnCountUp += () => { 
            _count++;
            this.label1.Text = $"count: {_count}";
        };
    }
    private void ucSample1_OnCountUp()
    {
        _count++;
        this.label1.Text = $"count: {_count}";
    }
    private int _count = 0;

    private void button1_Click(object sender, EventArgs e)
    {
        this.ucSample1.CountUp();
        this.ucSample2.CountUp();
    }
}
}
