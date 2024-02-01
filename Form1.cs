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
        private bool IsCallRealPDFLogic = false;
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(this.txtPDF1.Text.Trim(), out int pdf1Page))
                {
                    Console.WriteLine($"TIME : {DateTime.Now}. ERROR : PDF1 Should be written by integer");
                    return;
                }
                if (!int.TryParse(this.txtPDF2.Text.Trim(), out int pdf2Page))
                {
                    Console.WriteLine($"TIME : {DateTime.Now}. ERROR : PDF2 Should be written by integer");
                    return;
                }
                if (pdf1Page <= 0 || pdf2Page <= 0)
                {
                    Console.WriteLine($"Page should be bigger than 0. PDF1 : {pdf1Page}. PDF2 : {pdf2Page}");
                    return;
                }

                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Multiselect = true;
                string pdf1str = string.Empty;
                string pdf2str = string.Empty;
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    if (openFile.FileNames.Length != 2)
                    {
                        Console.WriteLine($"TIME : {DateTime.Now}. You Should Select 2 Files");
                        return;
                    }
                    else if (openFile.FileNames.Length == 0)
                    {
                        Console.WriteLine($"TIME : {DateTime.Now}. You Should Select files.");
                        return;
                    }
                    else
                    {
                        if (!Path.GetExtension(openFile.FileNames[0]).ToUpper().Contains("PDF"))
                        {
                            Console.WriteLine($"TIME : {DateTime.Now}. You should Select PDF File. {openFile.SafeFileNames[0]}");
                            return;
                        }
                        if (!Path.GetExtension(openFile.FileNames[1]).ToUpper().Contains("PDF"))
                        {
                            Console.WriteLine($"TIME : {DateTime.Now}. You should Select PDF File. {openFile.SafeFileNames[1]}");
                            return;
                        }
                    }
                    List<string> list = new List<string>();
                    foreach (string item in openFile.FileNames)
                    {
                        list.Add(item);
                    }
                    if (list.Count == 2)
                    {
                        PDFController controller = new PDFController();
                        if(controller.Compare(ref list, pdf1Page, pdf2Page))
                        {
                            this.label1.ForeColor = Color.Green;
                            this.label2.ForeColor = Color.Green;
                            MessageBox.Show($"{openFile.SafeFileNames[0]} and {openFile.SafeFileNames[1]} are same each other.");
                        }
                        else
                        {
                            // PDF files are differnt each other.
                            // So I will Start logic to Show diffenrence of PDF files.
                            this.label1.ForeColor = Color.Red;
                            this.label2.ForeColor = Color.Red;


                        }
                    }
                    else
                    {
                        Console.WriteLine($"TIME : {DateTime.Now}. ERROR : list count is not 2. Count : {list.Count}");
                    }
                }
                #region PDF 로직 확인
                if (!IsCallRealPDFLogic) { return; }
                byte[] arr = File.ReadAllBytes("10.pdf");
                string verify = PDFController.IsPDFSignautre(arr) ? "OK" : "FAIL";
                Console.WriteLine($"TIME : {DateTime.Now}. Verify : {verify}");
                int pages = PDFController.GetPages(arr);
                Console.WriteLine($"TIME : {DateTime.Now}. Pages : {pages}");
                string language = PDFController.GetLanguge(arr);
                Console.WriteLine($"TIME : {DateTime.Now}. Language : {language}");
                Dictionary<int, string> dic = PDFController.GetPDFKids(arr, pages);
                if (dic != null)
                {
                    Console.WriteLine($"TIME : {DateTime.Now}. Kids : {dic.Count}");
                    foreach (KeyValuePair<int, string> item in dic)
                    {
                        Console.WriteLine($"page : {item.Key}. id : {item.Value}");
                    }
                }
                byte[] arr2 = new byte[344];
                for (int i = 0; i < 344; i++)
                {
                    arr2[i] = arr[i + 473];
                }
                string hi = "i";
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine($"TIME : {DateTime.Now}. ERROR : {ex}");
            }
        }
    }
}
