using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gesture_and_Voice_Robot_Controller.View
{
    public partial class PointSettingForm : Form
    {
        double[] mp;
        double[] dp;
        public PointSettingForm(ref double[] material_point, ref double[] des_point)
        {
            InitializeComponent();
            mp = material_point;
            dp = des_point;
            textBox1.Text = mp[0].ToString();
            textBox2.Text = mp[1].ToString();
            textBox3.Text = mp[2].ToString();
            textBox4.Text = dp[0].ToString();
            textBox5.Text = dp[1].ToString();
            textBox6.Text = dp[2].ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mp[0] = Double.Parse(textBox1.Text);
            mp[1] = Double.Parse(textBox2.Text);
            mp[2] = Double.Parse(textBox3.Text);
            //textBox1.Text = textBox2.Text = textBox3.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dp[0] = Double.Parse(textBox4.Text);
            dp[1] = Double.Parse(textBox5.Text);
            dp[2] = Double.Parse(textBox6.Text);
            //textBox4.Text = textBox5.Text = textBox6.Text = "0";
        }
    }
}
