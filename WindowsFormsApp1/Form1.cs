using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.MaxLength = 1000000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string source = textBox1.Text;
            textBox1.Text = ReplaceHtmlTag1(source); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string source = textBox1.Text;
            textBox1.Text = ReplaceHtmlTag2(source);
             MessageBox.Show("李虹霞是我的！", "提示：", MessageBoxButtons.OK);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string source = textBox1.Text;
            textBox1.Text = ReplaceHtmlTag3(source);
        }
        public string ReplaceHtmlTag1(string source)
        {
            string result;
            //remove line breaks,tabs
            result = source.Replace("\r", " ");
            result = result.Replace("\n", " ");
            result = result.Replace("\t", " ");
            //remove the header
            result = Regex.Replace(result, "(<head>).*(</head>)", string.Empty, RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"<( )*script([^>])*>", "<script>", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"(<script>).*(</script>)", string.Empty, RegexOptions.IgnoreCase);
            //remove all styles
            result = Regex.Replace(result, @"<( )*style([^>])*>", "<style>", RegexOptions.IgnoreCase); //clearing attributes
            result = Regex.Replace(result, "(<style>).*(</style>)", string.Empty, RegexOptions.IgnoreCase);
            //insert tabs in spaces of <td> tags
            result = Regex.Replace(result, @"<( )*td([^>])*>", " ", RegexOptions.IgnoreCase);
            //insert line breaks in places of  and <li> tags
            result = Regex.Replace(result, @"<( )*br( )*>", "\r", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"<( )*li( )*>", "\r", RegexOptions.IgnoreCase);
            //insert line paragraphs in places of <tr> and <p> tags
            result = Regex.Replace(result, @"<( )*tr([^>])*>", "\r\r", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"<( )*p([^>])*>", "\r\r", RegexOptions.IgnoreCase);
            //remove anything thats enclosed inside < >
            result = Regex.Replace(result, @"<[^>]*>", string.Empty, RegexOptions.IgnoreCase);
            //replace special characters:
            result = Regex.Replace(result, @"&", "&", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @" ", " ", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"<", "<", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @">", ">", RegexOptions.IgnoreCase);
            result = Regex.Replace(result, @"&(.{2,6});", string.Empty, RegexOptions.IgnoreCase);
            //remove extra line breaks and tabs
            result = Regex.Replace(result, @" ( )+", " ");
            result = Regex.Replace(result, "(\r)( )+(\r)", "\r\r");
            result = Regex.Replace(result, @"(\r\r)+", "\r\n");
            return result;
        }
        public static string ReplaceHtmlTag2(string html)

        //public static string ReplaceHtmlTag(string html, int length = 0)
        {
            string strText = Regex.Replace(html, "<[^>]+>", "");
            strText = Regex.Replace(strText, "&[^;]+;", "");

            //if (length > 0 && strText.Length > length)
            //    return strText.Substring(0, length);

            return strText;
        }

        public static string ReplaceHtmlTag3(string html)
        {

            html = html.Replace("(<style)+[^<>]*>[^\0]*(</style>)+", "");
            html = html.Replace(@"\<img[^\>] \>", "");
            html = html.Replace(@"<p>", "");
            html = html.Replace(@"</p>", "");


            System.Text.RegularExpressions.Regex regex0 =
            new System.Text.RegularExpressions.Regex("(<style)+[^<>]*>[^\0]*(</style>)+", System.Text.RegularExpressions.RegexOptions.Multiline);
            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S] </script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" on[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S] </iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S] </frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex6 = new System.Text.RegularExpressions.Regex(@"\<img[^\>] \>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex7 = new System.Text.RegularExpressions.Regex(@"</p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex8 = new System.Text.RegularExpressions.Regex(@"<p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex9 = new System.Text.RegularExpressions.Regex(@"<[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex1.Replace(html, ""); //过滤<script></script>标记  
            html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性   
            html = regex0.Replace(html, ""); //过滤href=javascript: (<A>) 属性   


            //html = regex10.Replace(html, "");  
            html = regex3.Replace(html, "");// _disibledevent="); //过滤其它控件的on...事件  
            html = regex4.Replace(html, ""); //过滤iframe  
            html = regex5.Replace(html, ""); //过滤frameset  
            html = regex6.Replace(html, ""); //过滤frameset  
            html = regex7.Replace(html, ""); //过滤frameset  
            html = regex8.Replace(html, ""); //过滤frameset  
            html = regex9.Replace(html, "");
            //html = html.Replace(" ", "");  
            html = html.Replace("</strong>", "");
            html = html.Replace("<strong>", "");
            html = html.Replace(" ", "");
            html = html.Replace("&nbsp;", " ");
            return html;

        }

    }
}
