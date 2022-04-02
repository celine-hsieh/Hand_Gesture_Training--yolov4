using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpeechRecTest
{
    public partial class TextChangeForm : Form
    {
        string[] showtext;
        List<string> ss = new List<string>();
        public TextChangeForm(string[] orignal_text,ref List<string> final_choice)
        {
            InitializeComponent();
            showtext = orignal_text;
            ss = final_choice;
            ss.Clear();
            label2.Text = "";
            foreach (string s in showtext)
            {
                label2.Text += s + "\n";
                ss.Add(s);
            }
        }

        private void TextChangeForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] newtext= new string[] {   "暫停", "夾取", "鬆開","下降","移動至材料點","移動至目的點",
                                            "確認","取消","開始操作","結束操作" };
            showtext = newtext;
            label2.Text = "";
            ss.Clear();
            foreach (string s in showtext)
            {
                label2.Text += s + "\n";
                ss.Add(s);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (add_command.Text!="")
            {
                string[] newtext = new string[showtext.Length + 1];
                int i = 0;
                label2.Text = "";
                ss.Clear();
                foreach (string s in showtext)
                {
                    newtext[i] = s;
                    i++;
                    label2.Text += s + "\n";
                    ss.Add(s);
                }
                newtext[i] = add_command.Text;
                label2.Text += newtext[i] + "\n";
                ss.Add(newtext[i]);
                add_command.Text = "";
                showtext = newtext;
            }
        }

        private void TextChangeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
