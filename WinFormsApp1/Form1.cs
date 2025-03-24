using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void process1_Exited(object sender, EventArgs e)
        {

        }

        private void Search_shiming(object sender, EventArgs e)
        {
            string searchText = textBox1.Text;
            button1.Text = "搜索中";
            button1.Enabled = false;
            if (!string.IsNullOrEmpty(searchText))
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                    
                        string apiUrl = $"https://sssss/autoapi/fbaccinfo?q={System.Web.HttpUtility.UrlEncode(searchText)}";
                        HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            string result = response.Content.ReadAsStringAsync().Result;

                            result = result.Replace(",", "\r\n");
                            result=result.Replace("\"", "");
                            textBox2.Text = $"{result}";
                            //MessageBox.Show($"请求成功，返回结果：{result}");
                        }
                        else
                        {
                            textBox2.Text = $"请求失败，状态码：{response.StatusCode}";
                            //MessageBox.Show($"请求失败，状态码：{response.StatusCode}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    textBox2.Text = $"发生错误：{ex.Message}";
                    //MessageBox.Show($"发生错误：{ex.Message}");
                }
            }
            else
            {
                //textBox2.Text = $"发生错误：{ex.Message}";
                MessageBox.Show("请输入搜索内容！");
            }
            button1.Text = "搜索";
            button1.Enabled = true;
        }
    }
}
