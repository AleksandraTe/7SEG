using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7_SEGtest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
           
            InitializeComponent();

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            _7segment1.Nr = textBox1.Text;
            _7segment1.Invalidate();
        }

        private void _7segment1_Load(object sender, EventArgs e)
        {
            textBox1.MaxLength = _7segment1.NumberOfDisplays;
        }

        
    }
}
