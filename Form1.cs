using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PDFComparer.Class.PDF;
namespace PDFComparer
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

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] arr = File.ReadAllBytes("10.pdf");
            string verify = PDFController.IsPDFSignautre(arr) ? "OK" : "FAIL";
            Console.WriteLine($"TIME : {DateTime.Now}. Verify : {verify}");
            int pages = PDFController.GetPages(arr);
            Console.WriteLine($"TIME : {DateTime.Now}. Pages : {pages}");
            string language = PDFController.GetLanguge(arr);
            Console.WriteLine($"TIME : {DateTime.Now}. Language : {language}");
            List<string> kidsList = new List<string>();
            kidsList = PDFController.GetPDFKids(arr, pages);
        }
    }
}
